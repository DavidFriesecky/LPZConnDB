using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPZConnDB
{
    public partial class FormMultilineEdit : Form
    {
        private string content;

        public FormMultilineEdit(string content)
        {
            InitializeComponent();

            this.content = content;
            taEditContent.Text = content;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void taEditContent_TextChanged(object sender, EventArgs e)
        {
            content = taEditContent.Text;
        }

        public string Content
        {
            get { return content; }
        }
    }
}
