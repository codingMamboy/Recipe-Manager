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
    public partial class frmLoginpage: Form
    {
        public frmLoginpage()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblForgotpwd.Cursor = Cursors.Hand;
            lblSignin.Cursor = Cursors.Hand;

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            lblForgotpwd.Cursor = Cursors.Hand;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void lblForgotpwd_Enter(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            tbxPwd.UseSystemPasswordChar = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
