using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmChangeEmail : Form
    {
        private int userId;               // Stores the user ID
        private string currentEmail;      // Stores the current email address
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";  // Connection string for MySQL database
        private string verificationCode; // Holds the generated verification code
        private string verifiedEmail;    // Stores the new email to be verified

        // Constructor initializes user ID and current email
        public frmChangeEmail(int userId, string currentEmail)
        {
            InitializeComponent();
            this.userId = userId;
            this.currentEmail = currentEmail;
        }

        // Hide password characters on form load
        private void frmChangeEmail_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;  // Ensure password field hides input characters
        }

        // Sends a 6-digit verification code to the new email
        private void btnSendCode_Click(object sender, EventArgs e)
        {
            string newEmail = txtEmail.Text.Trim();

            btnSendCode.Text = "Sending...";  // Change button text to indicate sending
            btnSendCode.Enabled = false;     // Disable the button while sending

            // Basic email format validation
            if (string.IsNullOrEmpty(newEmail) || !newEmail.Contains("@") || !newEmail.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.");
                ResetSendCodeButton(); // Reset button if validation fails
                return;
            }

            try
            {
                // Check if email already exists in the database
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string checkEmailQuery = "SELECT COUNT(*) FROM users WHERE email = @newEmail";
                    using (MySqlCommand cmd = new MySqlCommand(checkEmailQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@newEmail", newEmail);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("This email is already taken. Please choose another one.");
                            ResetSendCodeButton(); // Reset button if email exists
                            return;
                        }
                    }
                }

                // Generate a random 6-digit verification code
                verificationCode = new Random().Next(100000, 999999).ToString();

                // Attempt to send the verification code email
                SendVerificationCodeEmail(newEmail);
                MessageBox.Show("Verification code sent to the new email.");

                // Lock email field after sending
                txtEmail.Enabled = false;
                verifiedEmail = newEmail;  // Store the new email to be verified
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending code: " + ex.Message); // Display error if sending fails
            }
            finally
            {
                ResetSendCodeButton(); // Reset the button regardless of success or failure
            }
        }

        // Updates the email in the database after verification
        private void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            string inputCode = txtCode.Text.Trim();  // Get the entered verification code
            string inputPassword = txtPassword.Text.Trim();  // Get the entered password

            // Ensure email was verified first
            if (verifiedEmail == null)
            {
                MessageBox.Show("Please verify your email first.");
                return;
            }

            // Check if the verification code matches
            if (inputCode != verificationCode)
            {
                MessageBox.Show("Incorrect verification code.");
                return;
            }

            // Require password entry
            if (string.IsNullOrEmpty(inputPassword))
            {
                MessageBox.Show("Please enter your password.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if the password matches the one stored in the database
                    string checkQuery = "SELECT password_hash FROM users WHERE user_id = @userId";
                    MySqlCommand cmd = new MySqlCommand(checkQuery, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    string storedHash = cmd.ExecuteScalar()?.ToString();

                    if (storedHash == null || storedHash != HashPassword(inputPassword))
                    {
                        MessageBox.Show("Incorrect password.");
                        return;
                    }

                    // Update the email in the database
                    string updateQuery = "UPDATE users SET email = @newEmail WHERE user_id = @userId";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@newEmail", verifiedEmail);
                    updateCmd.Parameters.AddWithValue("@userId", userId);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Email updated successfully.");

                    // Navigate back to profile form
                    frmProfile profileForm = new frmProfile(userId);
                    profileForm.Show();

                    this.Close(); // Close the current form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Display error if database operation fails
            }
        }

        // Sends an email containing the verification code
        private void SendVerificationCodeEmail(string recipientEmail)
        {
            string senderEmail = "bryandelapaz66850@gmail.com";  // Sender email
            string senderPassword = "lyui gelf lhxq flta"; // Gmail app password

            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.EnableSsl = true;  // Enable SSL encryption
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);

                using (MailMessage mail = new MailMessage(senderEmail, recipientEmail))
                {
                    mail.Subject = "Change Email Verification Code";
                    mail.Body = $"Your code to confirm the email change is: {verificationCode}";
                    smtp.Send(mail);  // Send the email
                }
            }
        }

        // Hashes a plain password using SHA-256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash); // Return the hashed password
            }
        }

        // Resets the "Send Code" button to its default state
        private void ResetSendCodeButton()
        {
            btnSendCode.Text = "Send Code";  // Reset the button text
            btnSendCode.Enabled = true;      // Re-enable the button
        }

        // Navigates back to the profile form
        private void btnBack2_Click(object sender, EventArgs e)
        {
            this.Hide();  // Hide the current form

            using (frmProfile frmProfile = new frmProfile(userId))  // Create a new profile form instance
            {
                frmProfile.ShowDialog();  // Show the profile form
            }

            this.Close();  // Close the current form
        }

        // Exits the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Exit the application
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control characters (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the input
            }
        }
    }
}
