using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmSignuppage : Form
    {
        // Database connection string
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private MySqlConnection conn;
        private string verificationCode; // Stores the 6-digit verification code

        public frmSignuppage()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
        }

        private void frmSignuppage_Load(object sender, EventArgs e)
        {
            // Placeholder for any logic to be executed when the sign-up form loads
        }

        private void btnExit2_Click(object sender, EventArgs e) => Application.Exit(); // Exit the application

        private void btnSignin_Click(object sender, EventArgs e)
        {
            // Navigate to the login form
            new frmLoginpage().Show();
            this.Hide();
        }

        private void tbxPwd2_TextChanged(object sender, EventArgs e) => tbxPwd2.UseSystemPasswordChar = true; // Mask password input

        private void tbxConfirmpwd_TextChanged(object sender, EventArgs e) => tbxConfirmpwd.UseSystemPasswordChar = true; // Mask confirm password input

        // Handles the sign-up button click event
        private void btnSignup_Click(object sender, EventArgs e)
        {
            SetSignupButtonState(false, "Registering...");

            // Get and trim input values
            string username = tbxUsername2.Text.Trim();
            string email = tbxEmail.Text.Trim();
            string password = tbxPwd2.Text.Trim();
            string confirmPwd = tbxConfirmpwd.Text.Trim();
            string codeInput = tbxCode2.Text.Trim();

            // Validate inputs
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPwd) ||
                string.IsNullOrWhiteSpace(codeInput))
            {
                ShowWarning("All fields are required.");
                return;
            }

            if (!IsValidEmail(email))
            {
                ShowWarning("Please enter a valid email address.");
                return;
            }

            if (password != confirmPwd)
            {
                ShowWarning("Passwords do not match.");
                return;
            }

            if (codeInput != verificationCode)
            {
                ShowError("Incorrect verification code.");
                return;
            }

            try
            {
                conn.Open();

                // Check for existing username or email
                using (var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @username OR email = @email", conn))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    checkCmd.Parameters.AddWithValue("@email", email);

                    if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                    {
                        ShowError("Username or email already exists.");
                        return;
                    }
                }

                // Hash the password
                string hashedPassword = HashPassword(password);

                // Insert new user into the database
                using (var insertCmd = new MySqlCommand("INSERT INTO users (username, email, password_hash) VALUES (@username, @email, @password_hash)", conn))
                {
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@email", email);
                    insertCmd.Parameters.AddWithValue("@password_hash", hashedPassword);

                    if (insertCmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SendConfirmationEmail(email); // Optional confirmation email
                        new frmLoginpage().Show();
                        this.Hide();
                    }
                    else
                    {
                        ShowError("Sign-up failed. Try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle database connection or execution errors
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Ensure connection is always closed
                SetSignupButtonState(true);
            }
        }

        // Handles the Send Code button click (sends 6-digit verification code to email)
        private void btnCodeVerification1_Click(object sender, EventArgs e)
        {
            string email = tbxEmail.Text.Trim();

            if (!IsValidEmail(email))
            {
                ShowWarning("Please enter a valid email address.");
                return;
            }

            SetCodeButtonState(false, "Sending...");

            verificationCode = new Random().Next(100000, 999999).ToString(); // Generate 6-digit code

            SendConfirmationEmail(email, verificationCode); // Send code to email

            MessageBox.Show("Verification code sent. Check your email.", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbxEmail.Enabled = false; // Prevent changing email after code is sent

            SetCodeButtonState(true);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Return to login form
            new frmLoginpage().ShowDialog();
            this.Hide();
        }

        // Hashes password using SHA-256 (no salt - consider using salt in production)
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(sha.ComputeHash(bytes));
            }
        }

        // Sends email (either confirmation or verification)
        private void SendConfirmationEmail(string recipientEmail, string code = null)
        {
            string senderEmail = "bryandelapaz66850@gmail.com";
            string senderPassword = "lyui gelf lhxq flta"; // Gmail App Password (secure in production)

            string subject = code == null ? "Account Registration Confirmation" : "Your Verification Code";
            string body = code == null
                ? "Thank you for registering. Your account has been successfully created!"
                : $"Your verification code is: {code}";

            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    using (var message = new MailMessage(senderEmail, recipientEmail, subject, body))
                    {
                        smtp.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle email sending errors
                MessageBox.Show("Email sending failed: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Validates email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Enables or disables the sign-up button and sets its text
        private void SetSignupButtonState(bool enabled, string text = "Sign up")
        {
            btnSignup.Enabled = enabled;
            btnSignup.Text = text;
        }

        // Enables or disables the verification code button and sets its text
        private void SetCodeButtonState(bool enabled, string text = "Send Code")
        {
            btnCodeVerification1.Enabled = enabled;
            btnCodeVerification1.Text = text;
        }

        // Shows a warning dialog with specified message
        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SetSignupButtonState(true);
        }

        // Shows an error dialog with specified message
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SetSignupButtonState(true);
        }
    }
}
