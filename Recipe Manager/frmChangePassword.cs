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
        // Stores the currently logged-in user's ID and the connection string for the MySQL database
        private int userId;
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";  // Connection string to connect to MySQL database

        // Constructor initializes the form and assigns the userId to the form
        public frmChangePassword(int userId)
        {
            InitializeComponent();
            this.userId = userId;  // Store the userId for later use
        }

        // Set password fields to hide characters for security when the form loads
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = true;  // Hide the password characters in the confirm password textbox
            txtNewPassword.UseSystemPasswordChar = true;      // Hide the password characters in the new password textbox
            txtOldPassword.UseSystemPasswordChar = true;      // Hide the password characters in the old password textbox
        }

        // Handles the password change logic when the "Change Password" button is clicked
        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text.Trim();     // Get the old password entered by the user
            string newPassword = txtNewPassword.Text.Trim();     // Get the new password entered by the user
            string confirmPassword = txtConfirmPassword.Text.Trim();  // Get the confirmed new password

            // Check if the new password and confirmation password match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New passwords do not match.");  // Display an error if they don't match
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))  // Establish a connection to the database
            {
                conn.Open();  // Open the connection to the database

                // Query to fetch the stored hashed password for the current user
                string selectQuery = "SELECT password_hash FROM users WHERE user_id = @userId";
                MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn);
                selectCmd.Parameters.AddWithValue("@userId", userId);  // Use the userId to fetch the user's password
                string storedHash = selectCmd.ExecuteScalar()?.ToString();  // Get the stored password hash

                // Hash the entered old password for comparison with the stored hash
                string inputOldPasswordHash = HashPassword(oldPassword);

                // Compare the stored and entered old password hashes
                if (storedHash != null && storedHash == inputOldPasswordHash)  // If the hashes match
                {
                    // Hash the new password and update it in the database
                    string newPasswordHash = HashPassword(newPassword);
                    string updateQuery = "UPDATE users SET password_hash = @newHash WHERE user_id = @userId";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@newHash", newPasswordHash);  // Pass the new hashed password
                    updateCmd.Parameters.AddWithValue("@userId", userId);  // Use the userId to update the password for the correct user
                    updateCmd.ExecuteNonQuery();  // Execute the update query

                    MessageBox.Show("Password changed successfully.");  // Display success message
                    this.Close();  // Close the current form after updating the password
                }
                else
                {
                    MessageBox.Show("Old password is incorrect.");  // Display error if the old password is incorrect
                }
            }
        }

        // Hashes a password using SHA-256 and returns it as a Base64 string
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())  // Create an instance of the SHA-256 hashing algorithm
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);  // Convert the password to bytes using UTF-8 encoding
                byte[] hash = sha256.ComputeHash(bytes);  // Compute the hash of the password
                return Convert.ToBase64String(hash);  // Return the hash as a Base64 string
            }
        }

        // Handles the "Back" button to return to the profile form
        private void btnBack2_Click(object sender, EventArgs e)
        {
            this.Hide();  // Hide the current form
            using (frmProfile frmProfile = new frmProfile(userId))  // Create a new instance of the profile form
            {
                frmProfile.ShowDialog();  // Show the profile form and wait for it to close
            }
            this.Close();  // Close the current form after the profile form is closed
        }

        // Exits the application when the "Exit" button is clicked
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Exit the application
        }
    }
}
