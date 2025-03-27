using System;
using System.Windows.Forms;

namespace Recipe_Manager
{
    public partial class frmLoginpage : Form
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
            this.Hide();
            frmSignuppage frm = new frmSignuppage();
            frm.Show();


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

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
