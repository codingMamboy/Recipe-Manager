using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Recipe_Manager
{
    public partial class frmForgotpwd: Form
    {
        
        public frmForgotpwd()
        {
            InitializeComponent();
           
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            this.Close();

            frmLoginpage frm = new frmLoginpage();
            frm.Show();

        }

        private void btnExit3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void tbxNewpwd_TextChanged(object sender, EventArgs e)
        {
            tbxNewpwd.UseSystemPasswordChar = true;
        }

        private void tbxConfirmpwd_TextChanged(object sender, EventArgs e)
        {
            tbxConfirmpwd2.UseSystemPasswordChar = true;
        }
    }
}
