// Required namespaces
using MySql.Data.MySqlClient;  // For interacting with MySQL database
using System;  // Provides base types like Exception
using System.Security.Cryptography;  // For password hashing
using System.Text;  // For string encoding (used in hashing)
using System.Windows.Forms;  // For Windows Forms GUI elements

namespace Recipe_Manager
{
    // Partial class for the login form
    public partial class frmLoginpage : Form
    {
        // Connection string to the MySQL database
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private MySqlConnection conn; // MySQL connection object

        // Constructor - called when the form is initialized
        public frmLoginpage()
        {
            InitializeComponent(); // Sets up the form components
            this.AcceptButton = btnLogin; // Pressing Enter will trigger the login button
            conn = new MySqlConnection(connectionString); // Initialize the database connection
        }

        // Event triggered when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            lblForgotpwd.Cursor = Cursors.Hand; // Makes the "Forgot Password" label clickable
            lblSignin.Cursor = Cursors.Hand; // Makes the "Sign up" label clickable
            tbxPwd.UseSystemPasswordChar = true; // Masks password input with dots or asterisks
        }

        // Login button click handler
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SetLoginButtonState(false, "Loading..."); // Disable button and change text to indicate processing

            string username = tbxUsername.Text.Trim(); // Get entered username
            string password = tbxPwd.Text.Trim(); // Get entered password

            // Basic validation to check if username or password is empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please input username and password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetLoginButtonState(true); // Re-enable the button
                return;
            }

            try
            {
                conn.Open(); // Open database connection

                // SQL query to fetch hashed password and user ID for the given username
                string query = "SELECT user_id, password_hash FROM users WHERE username = @username";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username); // Bind username to query

                    using (MySqlDataReader reader = cmd.ExecuteReader()) // Execute the query and get the result
                    {
                        if (reader.Read()) // If a record is found
                        {
                            int userId = reader.GetInt32("user_id"); // Retrieve user ID
                            string storedHash = reader.GetString("password_hash"); // Retrieve stored password hash
                            string enteredHash = HashPassword(password); // Hash the entered password

                            // Compare the hashed entered password with stored hash
                            if (enteredHash == storedHash)
                            {
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Open the Home form and pass the user ID to it
                                frmHome home = new frmHome(userId);
                                home.Show(); // Show the home form
                                this.Hide(); // Hide the login form
                            }
                            else
                            {
                                ShowLoginFailed(); // If hashes don’t match
                            }
                        }
                        else
                        {
                            ShowLoginFailed(); // If no user was found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle connection or query errors
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetLoginButtonState(true); // Re-enable button
            }
            finally
            {
                conn.Close(); // Ensure the connection is closed
            }
        }

        // Hashes the password using SHA256 (does not use a salt — consider adding one in production)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create()) // Create SHA256 instance
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password); // Convert password string to byte array
                byte[] hash = sha256.ComputeHash(bytes); // Compute the hash
                return Convert.ToBase64String(hash); // Convert hashed byte array to base64 string
            }
        }

        // Exit button handler — closes the entire application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // "Forgot Password" label click handler — opens forgot password form
        private void label1_Click(object sender, EventArgs e)
        {
            frmForgotpwd frm = new frmForgotpwd(); // Create instance of forgot password form
            frm.Show(); // Show the form
            this.Hide(); // Hide current login form
        }

        // "Sign up" label click handler — opens registration form
        private void label2_Click(object sender, EventArgs e)
        {
            frmSignuppage frm = new frmSignuppage(); // Create sign-up form
            frm.Show(); // Show the sign-up form
            this.Hide(); // Hide the login form
        }

        // Displays a standard login failure message and re-enables the login button
        private void ShowLoginFailed()
        {
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SetLoginButtonState(true); // Re-enable button
        }

        // Utility to enable or disable login button and update its text
        private void SetLoginButtonState(bool enabled, string text = "Log in")
        {
            btnLogin.Enabled = enabled;
            btnLogin.Text = text;
        }
    }
}
