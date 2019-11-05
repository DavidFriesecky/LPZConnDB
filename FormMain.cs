using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using LPZConnDB.src_data;
using LPZConnDB.src_security;

namespace LPZConnDB
{
    public partial class FormMain : Form
    {
        private bool btnsChecker = false;

        private DataModel data;
        private AdminUtil admin = new AdminUtil();

        private bool isEditing = false;
        private bool isDeleting = false;
        private bool isRemovingRow = false;

        public FormMain()
        {
            InitializeComponent();

            data = new DataModel();
            sourceIniFiles.DataSource = data.IniFiles;

            btnEdit.BackColor = Color.Red;
            btnDelete.BackColor = Color.Red;

            SetLogin(false);

            GenerateConnBtns();
            BtnsChecker = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormDataItem dataItem = new FormDataItem(new ConnDB(), Constants.BTYPE_ADD);
            dataItem.Owner = this;
            dataItem.ShowDialog();

            ConnDB result = dataItem.ConnDB;

            if (result != null)
            {
                AddConnBtn(result, -1);
                result.CreateFileXML();
                BtnsChecker = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                btnEdit.BackColor = Color.Red;
                isEditing = false;
            }
            else
            {
                btnEdit.BackColor = Color.Green;
                btnDelete.BackColor = Color.Red;
                isEditing = true;
                isDeleting = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (isDeleting)
            {
                btnDelete.BackColor = Color.Red;
                isDeleting = false;
            }
            else
            {
                btnDelete.BackColor = Color.Green;
                btnEdit.BackColor = Color.Red;
                isDeleting = true;
                isEditing = false;                
            }
        }

        private void btnPasswd_Click(object sender, EventArgs e)
        {
            FormPasswordChange changePassword = new FormPasswordChange(admin);
            changePassword.Owner = this;
            changePassword.ShowDialog();
            SetLogin(!changePassword.IsCorrectChange);
        }

        private void menuLogIO_Click(object sender, EventArgs e)
        {
            if (!admin.IsCorrectLogin)
            {
                FormLogin login = new FormLogin(admin);
                login.Owner = this;
                login.ShowDialog();

                SetLogin(login.IsCorrectLogin);
            }
            else
            {
                SetLogin(false);
            }
        }

        private void menuEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GenerateConnBtns()
        {
            for (int i = 0; i < data.Connections.Count; i++)
            {
                AddConnBtn(data.Connections[i].Value, i);
            }

            if (data.Connections.Count > 0)
            {
                BtnsChecker = true;
            }
        }

        private void dgvIniFiles_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                isRemovingRow = true;
            }
        }

        private void dgvIniFiles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (isRemovingRow && e.RowIndex < dgvIniFiles.Rows.Count)
            {
                dgvIniFiles.Rows.RemoveAt(e.RowIndex);
            }

            isRemovingRow = false;
        }

        private void AddConnBtn(ConnDB tempConnDB, int index)
        {
            Button btn = new Button();
            btn.Padding = new Padding(10, 10, 10, 10);
            btn.Text = tempConnDB.Property(Constants.XML_HEADER_ITEM_NAME);
            btn.Font = new Font("Arial", Constants.SIZE_BTN_TEXT, FontStyle.Bold);
            btn.MaximumSize = new Size(Constants.BTN_SIZE_BLOCK_WIDTH - 10, Constants.BTN_SIZE_BLOCK_HEIGHT - 10);
            btn.MinimumSize = new Size(Constants.BTN_SIZE_BLOCK_WIDTH - 10, Constants.BTN_SIZE_BLOCK_HEIGHT - 10);

            btn.Click += (sender, args) => 
            {
                if (isEditing)
                {
                    FormDataItem dataItem = new FormDataItem(tempConnDB, Constants.BTYPE_EDIT);
                    dataItem.Owner = this;
                    dataItem.ShowDialog();

                    dataItem.OldConnDB.DeleteFileXML();
                    tempConnDB.CreateFileXML();

                    btn.Text = tempConnDB.Property("name");
                    BtnsChecker = true;
                }
                else if (isDeleting)
                {
                    string message = string.Format("Opravdu chcete smazat oddělení [id={0}, name={1}]", tempConnDB.Property("id"), tempConnDB.Property("name"));
                    string caption = "Odstranění oddělení";
                    
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.Yes)
                    {
                        if (tempConnDB.DeleteFileXML())
                        {
                            data.RemoveID(tempConnDB.Property("id"));
                            BtnsChecker = true;
                        }
                    }
                }
                else
                {
                    tempConnDB.CreateFileConfig();
                }
            };

            if (index == -1)
            {
                data.Connections.Add(new KeyValuePair<Button, ConnDB>(btn, tempConnDB));
                return;

            }

            data.Connections[index] = new KeyValuePair<Button, ConnDB>(btn, tempConnDB);
        }

        private void SetLogin(bool login)
        {
            if (login)
            {
                menuLogIO.Text = "Odhlásit";
            }
            else
            {
                btnEdit.BackColor = Color.Red;
                isEditing = false;
                btnDelete.BackColor = Color.Red;
                isDeleting = false;

                menuLogIO.Text = "Přihlásit";
            }

            admin.IsCorrectLogin = login;
            panelAdminBtns.Visible = login;
            dgvIniFiles.Visible = login;
            BtnsChecker = true;
        }

        private bool BtnsChecker
        {
            get { return btnsChecker; }
            set
            {
                if (value)
                {
                    data.Connections = data.Connections.OrderBy(o => o.Key.Text).ToList();

                    int countLine = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(data.Connections.Count) / Constants.COUNT_BTNS));

                    this.Height = Constants.WIN_HEIGHT_LOUT + (countLine * Constants.BTN_SIZE_BLOCK_HEIGHT);
                    this.Width = Constants.WIN_WIDTH_LOUT + (((int)Constants.COUNT_BTNS) * Constants.BTN_SIZE_BLOCK_WIDTH);

                    panelConnBtns.Controls.Clear();
                    panelConnBtns.Height = countLine * Constants.BTN_SIZE_BLOCK_HEIGHT;
                    panelConnBtns.Width = ((int)Constants.COUNT_BTNS * Constants.BTN_SIZE_BLOCK_WIDTH);

                    int x = 0, y = 0;
                    int count = 0;

                    foreach (KeyValuePair<Button, ConnDB> tempBtn in data.Connections)
                    {
                        tempBtn.Key.Location = new Point(x, y);
                        panelConnBtns.Controls.Add(tempBtn.Key);

                        x += Constants.BTN_SIZE_BLOCK_WIDTH;
                        count++;
                        if (Constants.COUNT_BTNS == count)
                        {
                            count = 0;
                            x = 0;
                            y += Constants.BTN_SIZE_BLOCK_HEIGHT;
                        }

                    }

                    if (admin.IsCorrectLogin)
                    {
                        this.Width += Constants.DGV_WIDTH_OFFSET;

                        if (this.Width < Constants.WIN_WIDTH_LIN)
                        {
                            this.Width = Constants.WIN_WIDTH_LIN;
                        }

                        if (this.Height < Constants.WIN_HEIGHT_LIN)
                        {
                            this.Height = Constants.WIN_HEIGHT_LIN;
                        }

                        dgvIniFiles.Location = new Point(this.Width - Constants.DGV_WIDTH_OFFSET - 18, dgvIniFiles.Location.Y);
                        panelAdminBtns.Location = new Point(this.Width - panelAdminBtns.Width - Constants.ADMIN_BTNS_LOC_X, this.Height - panelAdminBtns.Height - Constants.ADMIN_BTNS_LOC_Y);
                    }

                    btnsChecker = false;
                }
            }
        }

        private void dgvIniFiles_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (File.Exists(Constants.DATA_FOLDER + e.Row.Cells["IniName"].Value))
            {
                File.Delete(Constants.DATA_FOLDER + e.Row.Cells["IniName"].Value);
            }
        }

        private void dgvIniFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvIniFiles.Rows.Count - 1 && dgvIniFiles.Columns[e.ColumnIndex].Equals(ControllContent))
            {
                FormMultilineEdit editor = new FormMultilineEdit(data.IniFiles[e.RowIndex].Content);
                editor.Owner = this;
                editor.ShowDialog();

                data.IniFiles[e.RowIndex].Content = editor.Content;
            }
        }
    }
}
