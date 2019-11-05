using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LPZConnDB.src_security;
namespace LPZConnDB
{
    public partial class FormPasswordChange : Form
    {
        private AdminUtil admin;
        private bool isCorrectChange = false;
        public FormPasswordChange(AdminUtil admin)
        {
            InitializeComponent();

            this.admin = admin;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (admin.Password.Equals(admin.ComputeSha256Hash(tbOldPasswd.Text, false)))
            {
                if (tbNewPasswd.Text.Length >= 8 && tbValidPasswd.Text.Length >= 8)
                {
                    if (tbNewPasswd.Text.Equals(tbValidPasswd.Text))
                    {
                        admin.ComputeSha256Hash(tbNewPasswd.Text, true);
                        isCorrectChange = true;
                        this.Close();
                        return;
                    }
                }
            }

            tbOldPasswd.Text = "";
            tbNewPasswd.Text = "";
            tbValidPasswd.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbPasswd_TextChanged(object sender, EventArgs e)
        {
            if (tbOldPasswd.Text.Length > 0 && tbNewPasswd.Text.Length > 0 && tbValidPasswd.Text.Length > 0)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        public AdminUtil Admin
        {
            get { return admin; }
        }

        public bool IsCorrectChange
        {
            get { return isCorrectChange; }
        }
    }
}
