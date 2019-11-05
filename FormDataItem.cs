using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LPZConnDB.src_data;

namespace LPZConnDB
{
    public partial class FormDataItem : Form
    {
        private ConnDB connDB;
        private ConnDB oldConnDB;
        private string type;
        private bool isSaved;
        private bool isRemovingRow = false;

        public FormDataItem(ConnDB connDB, string type)
        {
            InitializeComponent();

            dgvProperties.AutoGenerateColumns = false;

            this.connDB = connDB;
            this.oldConnDB = new ConnDB(connDB);
            this.type = type;

            this.Text = type + " oddělení";
            btnSave.Text = type;

            sourceProperties.DataSource = this.connDB.Properties;
            sourceModules.DataSource = this.connDB.Modules;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            isSaved = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isSaved = false;            
            this.Close();
        }

        private void FormDataItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (!isSaved)
            {
                if (type.Equals(Constants.BTYPE_ADD))
                {
                    connDB = null;
                }
                else
                {
                    connDB = oldConnDB;
                }
            }
        }
        
        public ConnDB ConnDB
        {
            get { return connDB; }
        }

        public ConnDB OldConnDB
        {
            get { return oldConnDB; }
        }

        private void dgvProperties_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colName = dgvProperties.Columns[e.ColumnIndex].Name;

            if (colName.Equals("Key") && string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                if (e.RowIndex < dgvProperties.Rows.Count - 1)
                {
                    if (dgvProperties[e.ColumnIndex + 1, e.RowIndex].Value != null)
                    {
                        if (string.IsNullOrEmpty(dgvProperties[e.ColumnIndex + 1, e.RowIndex].Value.ToString()))
                        {
                            isRemovingRow = true;
                        }
                        else
                        {
                            dgvProperties.Rows[e.RowIndex].ErrorText = "Název musí být uveden.";
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        isRemovingRow = true;
                    }
                }
                else
                {
                    dgvProperties.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
            else if (colName.Equals("Key") && !string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                if (e.RowIndex > 1 && (e.FormattedValue.ToString().Equals("id") || e.FormattedValue.ToString().Equals("name")))
                {
                    dgvProperties.Rows[e.RowIndex].ErrorText = "Název \"id\"/\"name\" musí být pouze jeden.";
                    e.Cancel = true;
                }
            }
            else if (colName.Equals("Value") && !string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                if (dgvProperties[e.ColumnIndex - 1, e.RowIndex].Value != null)
                {
                    if (string.IsNullOrEmpty(dgvProperties[e.ColumnIndex - 1, e.RowIndex].Value.ToString()))
                    {
                        dgvProperties.Rows[e.RowIndex].ErrorText = "Název musí být uveden.";
                        e.Cancel = true;
                    }
                    else
                    {
                        dgvProperties.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                }
                else
                {
                    dgvProperties.Rows[e.RowIndex].ErrorText = "Název musí být uveden.";
                    e.Cancel = true;
                }

            }
        }

        private void dgvProperties_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvProperties.Rows[e.RowIndex].ErrorText = string.Empty;

            if (isRemovingRow && e.RowIndex < dgvProperties.Rows.Count)
            {
                dgvProperties.Rows.RemoveAt(e.RowIndex);
            }

            isRemovingRow = false;
        }

        private void dgvProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && dgvProperties[e.ColumnIndex, e.RowIndex].Value != null)
            {
                if (dgvProperties[e.ColumnIndex, e.RowIndex].Value.Equals("id") || dgvProperties[e.ColumnIndex, e.RowIndex].Value.Equals("name"))
                {
                    dgvProperties[e.ColumnIndex, e.RowIndex].ReadOnly = true;
                }
            }
        }

        private void dgvProperties_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && dgvProperties[e.ColumnIndex, e.RowIndex].Value != null)
            {
                if (dgvProperties[e.ColumnIndex, e.RowIndex].Value.Equals("id") || dgvProperties[e.ColumnIndex, e.RowIndex].Value.Equals("name"))
                {
                    dgvProperties[e.ColumnIndex, e.RowIndex].ReadOnly = false;
                }
            }
        }

        private void dgvProperties_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Cells[0].Value.Equals("id") || e.Row.Cells[0].Value.Equals("name"))
            {
                e.Cancel = true;
            }
        }

        private void dgvModules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0 && index < dgvModules.Rows.Count - 1)
            {
                ConnModule temp = connDB.Module(index);

                if (temp != null)
                {
                    if (!temp.ModuleName.StartsWith("#"))
                    {
                        dgvModuleProperties.DataSource = new BindingSource(temp.Properties, null);
                        dgvModuleProperties.Enabled = true;
                    }
                    
                }
                else
                {
                    dgvModuleProperties.DataSource = null;
                    dgvModuleProperties.Enabled = false;
                }
            }
            else
            {
                dgvModuleProperties.DataSource = null;
                dgvModuleProperties.Enabled = false;
            }
        }

        private void dgvModules_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                isRemovingRow = true;
            }
        }

        private void dgvModules_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (isRemovingRow && e.RowIndex < dgvModules.Rows.Count)
            {
                dgvModules.Rows.RemoveAt(e.RowIndex);
            }

            isRemovingRow = false;
        }

        private void dgvModuleProperties_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                isRemovingRow = true;
            }
        }

        private void dgvModuleProperties_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (isRemovingRow && e.RowIndex < dgvModuleProperties.Rows.Count)
            {
                dgvModuleProperties.Rows.RemoveAt(e.RowIndex);
            }

            isRemovingRow = false;
        }
    }
}
