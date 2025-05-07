// Required namespaces for database connection, email handling, cryptography, and UI controls
using MySql.Data.MySqlClient;
using System;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Recipe_Manager
{
    public partial class frmForgotpwd : Form
    {
        // Connection string to connect to the MySQL database
        private readonly string connectionString = "server=localhost; uid=root; pwd=12345; database=recipe_managerv2";

        // Connection object used throughout the form
        private readonly MySqlConnection conn;

        // Stores the generated verification code
        private string verificationCode;

        // Stores the email after it is verified (used to prevent changing email mid-process)
        private string verifiedEmail;

        // Constructor to initialize the form and database connection
        public frmForgotpwd()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
        }

        // Navigates back to the login form when "Back" button is clicked
        private void btnBack2_Click(object sender, EventArgs e)
        {
            new frmLoginpage().Show();
            this.Close(); // Close the current form
        }

        // Exits the entire application when "Exit" button is clicked
        private void btnExit3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Enables password character masking for the new password textbox
        private void tbxNewpwd_TextChanged(object sender, EventArgs e)
        {
            tbxNewpwd.UseSystemPasswordChar = true;
        }

        // Enables password character masking for the confirm password textbox
        private void tbxConfirmpwd_TextChanged(object sender, EventArgs e)
        {
            tbxConfirmpwd2.UseSystemPasswordChar = true;
        }

        // CONFIRM BUTTON: Verifies the code and resets the password
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Get user input values
            string codeInput = tbxCode.Text.Trim();
            string newPassword = tbxNewpwd.Text.Trim();
            string confirmPwd = tbxConfirmpwd2.Text.Trim();

            // Change button text and disable to prevent multiple clicks
            btnCodeVerification2.Text = "Loading...";
            btnCodeVerification2.Enabled = false;

            // Check for empty fields
            if (string.IsNullOrEmpty(codeInput) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPwd))
            {
                MessageBox.Show("Please fill all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetConfirmButton();
                return;
            }

            // Ensure the email has been verified
            if (verifiedEmail == null)
            {
                MessageBox.Show("Please verify your email first.", "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetConfirmButton();
                return;
            }

            // Check if entered code matches generated code
            if (codeInput != verificationCode)
            {
                MessageBox.Show("Incorrect verification code. Please try again.", "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetConfirmButton();
                return;
            }

            // Confirm that new password and confirmation match
            if (newPassword != confirmPwd)
            {
                MessageBox.Show("Your passwords do not match. Please try again.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetConfirmButton();
                return;
            }

            try
            {
                // Hash the password using SHA256
                string passwordHash = HashPassword(newPassword);

                // Open the connection and update the password
                conn.Open();
                string updateQuery = "UPDATE users SET password_hash = @password_hash WHERE email = @email";

                using (var updateCmd = new MySqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@password_hash", passwordHash);
                    updateCmd.Parameters.AddWithValue("@email", verifiedEmail);

                    int result = updateCmd.ExecuteNonQuery();

                    // Show result message
                    if (result > 0)
                    {
                        MessageBox.Show("Password reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        new frmLoginpage().Show(); // Go back to login
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error resetting password. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetConfirmButton();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors during database interaction
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetConfirmButton();
            }
            finally
            {
                conn.Close(); // Always close the connection
            }
        }

        // Resets the confirm button to its default state
        private void ResetConfirmButton()
        {
            btnCodeVerification2.Text = "Confirm";
            btnCodeVerification2.Enabled = true;
        }

        // Hashes the password using SHA256 (no salt)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password); // Convert to byte array
                byte[] hash = sha256.ComputeHash(bytes);         // Get hash bytes
                return Convert.ToBase64String(hash);             // Return as Base64 string
            }
        }

        // Sends the verification code to the provided email address
        private void SendVerificationCodeEmail(string recipientEmail)
        {
            // Sender email and Gmail app-specific password
            string senderEmail = "bryandelapaz66850@gmail.com";
            string senderPassword = "lyui gelf lhxq flta"; // App password

            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true; // Enable SSL
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    using (var mail = new MailMessage(senderEmail, recipientEmail))
                    {
                        mail.Subject = "Password Reset Verification Code";
                        mail.Body = $"Your password reset verification code is: {verificationCode}";
                        smtp.Send(mail); // Send the email
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error if email couldn't be sent
                MessageBox.Show("Error sending email: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SEND VERIFICATION CODE BUTTON CLICK
        private void btnCodeVerification2_Click_1(object sender, EventArgs e)
        {
            string email = tbxEmail3.Text.Trim();

            // Indicate that sending is in progress
            btnCodeVerification2.Text = "Sending...";
            btnCodeVerification2.Enabled = false;

            // Validate email format
            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCodeVerification2.Text = "Send Code";
                btnCodeVerification2.Enabled = true;
                return;
            }

            try
            {
                conn.Open();

                // Check if the email exists in the users table
                string checkQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                using (var checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@email", email);
                    int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userCount == 0)
                    {
                        MessageBox.Show("Email not found. Please check the email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnCodeVerification2.Text = "Send Code";
                        btnCodeVerification2.Enabled = true;
                        return;
                    }
                }

                // Generate a random 6-digit verification code
                verificationCode = new Random().Next(100000, 999999).ToString();

                // Send verification code to the user
                SendVerificationCodeEmail(email);

                // Lock the email field and store the verified email
                verifiedEmail = email;
                tbxEmail3.Enabled = false;

                MessageBox.Show("Verification code sent. Please check your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                btnCodeVerification2.Text = "Send Code";
                btnCodeVerification2.Enabled = true;
            }
        }

        // Only allow numeric input for the verification code textbox
        private void tbxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-numeric input
            }
        }
    }
}
