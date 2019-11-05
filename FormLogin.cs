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
    public partial class FormLogin : Form
    {

        private AdminUtil admin;

        public FormLogin(AdminUtil admin)
        {
            InitializeComponent();

            this.admin = admin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (admin.Username.Equals(admin.ComputeSha256Hash(txtbUsername.Text, false)) && admin.Password.Equals(admin.ComputeSha256Hash(txtbPassword.Text, false)))
            {
                admin.IsCorrectLogin = true;
                this.Close();
            } 
            else
            {
                admin.IsCorrectLogin = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            admin.IsCorrectLogin = false;
            this.Close();
        }

        public bool IsCorrectLogin
        {
            get { return admin.IsCorrectLogin; }
        }
    }
}
