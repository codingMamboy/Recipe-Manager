using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Recipe_Manager
{
    public partial class frmLoginpage : Form
    {
        // Connection string to your MySQL database
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private MySqlConnection conn;

        public frmLoginpage()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin; // Allow pressing Enter to trigger login
            conn = new MySqlConnection(connectionString); // Initialize connection
        }

        // Form Load event handler
        private void Form1_Load(object sender, EventArgs e)
        {
            lblForgotpwd.Cursor = Cursors.Hand;
            lblSignin.Cursor = Cursors.Hand;
            tbxPwd.UseSystemPasswordChar = true; // Mask password input
        }

        // Login button click event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SetLoginButtonState(false, "Loading...");

            string username = tbxUsername.Text.Trim();
            string password = tbxPwd.Text.Trim();

            // Basic input validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please input username and password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetLoginButtonState(true);
                return;
            }

            try
            {
                conn.Open();

                // SQL to get hashed password using the entered username
                string query = "SELECT user_id, password_hash FROM users WHERE username = @username";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32("user_id");
                            string storedHash = reader.GetString("password_hash");
                            string enteredHash = HashPassword(password); // Hash entered password

                            if (enteredHash == storedHash)
                            {
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Open Home Form and pass user ID
                                frmHome home = new frmHome(userId);
                                home.Show();
                                this.Hide();
                            }
                            else
                            {
                                ShowLoginFailed();
                            }
                        }
                        else
                        {
                            ShowLoginFailed();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetLoginButtonState(true);
            }
            finally
            {
                conn.Close(); // Ensure connection is closed
            }
        }

        // Securely hash the password using SHA256 (Note: Adding salt is recommended in production)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash); // Return hashed string
            }
        }

        // Exit button: closes the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // "Forgot Password" label click
        private void label1_Click(object sender, EventArgs e)
        {
            frmForgotpwd frm = new frmForgotpwd();
            frm.Show();
            this.Hide();
        }

        // "Sign up" label click
        private void label2_Click(object sender, EventArgs e)
        {
            frmSignuppage frm = new frmSignuppage();
            frm.Show();
            this.Hide();
        }

        // Reset login form state after failure
        private void ShowLoginFailed()
        {
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SetLoginButtonState(true);
        }

        // Helper to set the login button text and state
        private void SetLoginButtonState(bool enabled, string text = "Log in")
        {
            btnLogin.Enabled = enabled;
            btnLogin.Text = text;
        }


    }
}
