using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Recipe_Manager
{
    public partial class frmLoginpage : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2"; // Update if needed
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Text = "Loading...";
            btnLogin.Enabled = false;

            string username = tbxUsername.Text.Trim();
            string password = tbxPwd.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please input username and password");

                btnLogin.Text = "Log in";
                btnLogin.Enabled = true;

                return;
            }

            try
            {
                conn.Open();
                // Modified query to get password_hash only, using username
                string query = "SELECT user_id, password_hash FROM users WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int userId = reader.GetInt32("user_id"); // Retrieve userId
                    string storedHash = reader.GetString("password_hash");

                    string enteredHash = HashPassword(password); // Hash entered password to compare

                    if (enteredHash == storedHash)
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Pass userId to frmHome and show it
                        frmHome home = new frmHome(userId); // Pass the userId to frmHome
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        btnLogin.Text = "Log in";
                        btnLogin.Enabled = true;

                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    btnLogin.Text = "Log in";
                    btnLogin.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnLogin.Text = "Log in";
                btnLogin.Enabled = true;
            }
            finally
            {
                conn.Close();
            }

        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash); // Return the hashed password as a Base64 string
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            lblForgotpwd.Cursor = Cursors.Hand;
            frmForgotpwd frm = new frmForgotpwd();
            frm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmSignuppage frm = new frmSignuppage();
            frm.Show();
            this.Hide();
        }
    }
}
