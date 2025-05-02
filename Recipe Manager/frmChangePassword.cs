using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Recipe_Manager
{
    public partial class frmChangePassword : Form
    {
        // Stores the currently logged-in user's ID and connection string
        private int userId;
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";

        // Constructor initializes form and assigns the userId
        public frmChangePassword(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        // Set password fields to hide characters for security
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtOldPassword.UseSystemPasswordChar = true;
        }

        // Handles password change logic when the "Change Password" button is clicked
        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Check if the new password and confirmation match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New passwords do not match.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Fetch the stored hashed password for the current user
                string selectQuery = "SELECT password_hash FROM users WHERE user_id = @userId";
                MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn);
                selectCmd.Parameters.AddWithValue("@userId", userId);
                string storedHash = selectCmd.ExecuteScalar()?.ToString();

                // Hash the entered old password for comparison
                string inputOldPasswordHash = HashPassword(oldPassword);

                // Compare stored and input old password hashes
                if (storedHash != null && storedHash == inputOldPasswordHash)
                {
                    // Hash and update the new password in the database
                    string newPasswordHash = HashPassword(newPassword);
                    string updateQuery = "UPDATE users SET password_hash = @newHash WHERE user_id = @userId";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@newHash", newPasswordHash);
                    updateCmd.Parameters.AddWithValue("@userId", userId);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Password changed successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Old password is incorrect.");
                }
            }
        }

        // Hashes a password using SHA-256 and returns it as a Base64 string
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Handles the "Back" button to return to the profile form
        private void btnBack2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmProfile frmProfile = new frmProfile(userId))
            {
                frmProfile.ShowDialog();
            }
            this.Close();
        }

        // Exits the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
