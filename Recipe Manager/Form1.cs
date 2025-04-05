using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;



namespace Recipe_Manager
{
    public partial class frmLoginpage : Form
    {
        private string connectionString = "server = localhost; uid = root; pwd = 12345; database = login";
        private MySqlConnection conn;

        public frmLoginpage()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblForgotpwd.Cursor = Cursors.Hand;
            lblSignin.Cursor = Cursors.Hand;
            tbxPwd.UseSystemPasswordChar = true;

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

            frmForgotpwd frm2 = new frmForgotpwd();
            frm2.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            frmSignuppage frm = new frmSignuppage();
            frm.Show();
            this.Hide();
        }

        private void lblForgotpwd_Enter(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
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

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text.Trim();
            string password = tbxPwd.Text.Trim();  

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please input username and password");
                return;
            }

            try
            {
                conn.Open();
                string query = "SELECT * FROM users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmHome frmhome = new frmHome();
                    frmhome.Show();
                    this.Hide();


                } 

                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }

            catch (Exception ex) {

                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            finally
            {
                conn.Close();
            }

        }
    }
}
