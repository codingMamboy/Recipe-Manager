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
        // Update to your database name
        private string connectionString =
            "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private MySqlConnection conn;
        private string verificationCode;

        public frmSignuppage()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
        }

        private void frmSignuppage_Load(object sender, EventArgs e)
        {
            // any designer-time setup
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            new frmLoginpage().Show();
            this.Hide();
        }

        private void tbxPwd2_TextChanged(object sender, EventArgs e)
        {
            tbxPwd2.UseSystemPasswordChar = true;
        }

        private void tbxConfirmpwd_TextChanged(object sender, EventArgs e)
        {
            tbxConfirmpwd.UseSystemPasswordChar = true;
        }


        private void btnSignup_Click(object sender, EventArgs e)
        {
            // 1) Gather inputs
            string username = tbxUsername2.Text.Trim();
            string email = tbxEmail.Text.Trim();      // Make sure you have a Full Name textbox
            string password = tbxPwd2.Text.Trim();
            string confirmPwd = tbxConfirmpwd.Text.Trim();
            string codeInput = tbxCode2.Text.Trim();

            // 2) Basic validation
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(email) || 
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPwd) ||
                string.IsNullOrEmpty(codeInput))
            {
                MessageBox.Show("Please fill all the inputs.", "No input detected",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password != confirmPwd)
            {
                MessageBox.Show("Your passwords do not match. Please try again.", "Password Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (codeInput != verificationCode)
            {
                MessageBox.Show("Incorrect verification code.", "Verification Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();

                // 3) Check for existing username/email
                string checkQuery = @"
                    SELECT COUNT(*) 
                      FROM users 
                     WHERE username = @username 
                        OR email    = @email";
                var checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@username", username);
                checkCmd.Parameters.AddWithValue("@email", email);

                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (userCount > 0)
                {
                    MessageBox.Show("Username or Email already taken.", "Sign-Up Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4) Hash password (no salt)
                string passwordHash = HashPassword(password);

                // 5) Insert user (no password_salt column)
                string insertQuery = @"
                    INSERT INTO users 
                        (username, email, password_hash) 
                    VALUES 
                        (@username, @email, @password_hash)";
                var insertCmd = new MySqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@email", email);
                insertCmd.Parameters.AddWithValue("@password_hash", passwordHash);

                int result = insertCmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Account created successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new frmLoginpage().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sign-up failed. Try again.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Hashes a plain-text password using SHA256 (no salt).
        /// </summary>
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Sends either the verification code or registration confirmation email.
        /// </summary>
        private void SendConfirmationEmail(string recipientEmail, string code = null)
        {
            string senderEmail = "bryandelapaz66850@gmail.com";
            string senderPassword = "lyui gelf lhxq flta";  // Use an app-specific password

            string subject = code == null
                ? "Account Registration Confirmation"
                : "Your Verification Code";
            string body = code == null
                ? "Thank you for registering. Your account has been successfully created!"
                : $"Your verification code is: {code}";

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);

                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    smtp.Send(mail);
                }
            }
        }

        private void btnCodeVerification1_Click(object sender, EventArgs e)
        {
            // 1) Validate email
            string email = tbxEmail.Text.Trim();
            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2) Generate code
            verificationCode = new Random().Next(100000, 999999).ToString();

            // 3) Send it
            SendConfirmationEmail(email, verificationCode);
            MessageBox.Show("Verification code sent. Please check your email.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLoginpage loginpage = new frmLoginpage();
            this.Hide();
            loginpage.ShowDialog();

        }
    }
}
