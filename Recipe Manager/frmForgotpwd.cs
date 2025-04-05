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
            

            frmLoginpage frm = new frmLoginpage();
            frm.Show();
            this.Close();

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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSignintext2_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void lblConfirmpwd_Click(object sender, EventArgs e)
        {

        }

        private void lblNewpwd_Click(object sender, EventArgs e)
        {

        }

        private void tbxCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCode_Click(object sender, EventArgs e)
        {

        }

        private void tbxEmail3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmail3_Click(object sender, EventArgs e)
        {

        }

        private void frmForgotpwd_Load(object sender, EventArgs e)
        {

        }
    }
}
