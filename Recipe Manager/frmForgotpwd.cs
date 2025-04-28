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
        string connectionString = "server=localhost; uid=root; pwd=12345; database=recipe_managerv2";
        MySqlConnection conn;
        private string verificationCode;
        private string verifiedEmail; // To lock the email after verification

        public frmForgotpwd()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            frmLoginpage frm = new frmLoginpage();
            frm.Show();
            this.Close();
        }

        private void btnExit3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbxNewpwd_TextChanged(object sender, EventArgs e)
        {
            tbxNewpwd.UseSystemPasswordChar = true;
        }

        private void tbxConfirmpwd_TextChanged(object sender, EventArgs e)
        {
            tbxConfirmpwd2.UseSystemPasswordChar = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string codeInput = tbxCode.Text.Trim();
            string newPassword = tbxNewpwd.Text.Trim();
            string confirmPwd = tbxConfirmpwd2.Text.Trim();

            btnCodeVerification2.Text = "Loading...";
            btnCodeVerification2.Enabled = false;

            if (string.IsNullOrEmpty(codeInput) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPwd))
            {
                MessageBox.Show("Please fill all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnCodeVerification2.Text = "Confirm";
                btnCodeVerification2.Enabled = true;

                return;
            }

            if (verifiedEmail == null)
            {
                MessageBox.Show("Please verify your email first.", "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnCodeVerification2.Text = "Confirm";
                btnCodeVerification2.Enabled = true;

                return;
            }

            if (codeInput != verificationCode)
            {
                MessageBox.Show("Incorrect verification code. Please try again.", "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnCodeVerification2.Text = "Confirm";
                btnCodeVerification2.Enabled = true;

                return;
            }

            if (newPassword != confirmPwd)
            {
                MessageBox.Show("Your passwords do not match. Please try again.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnCodeVerification2.Text = "Confirm";
                btnCodeVerification2.Enabled = true;

                return;
            }

            try
            {
                string passwordHash = HashPassword(newPassword);

                conn.Open();
                string updateQuery = "UPDATE users SET password_hash = @password_hash WHERE email = @email";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@password_hash", passwordHash);
                updateCmd.Parameters.AddWithValue("@email", verifiedEmail);

                int result = updateCmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Password reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLoginpage frm = new frmLoginpage();
                    frm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error resetting password. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    btnCodeVerification2.Text = "Confirm";
                    btnCodeVerification2.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnCodeVerification2.Text = "Confirm";
                btnCodeVerification2.Enabled = true;
            }
            finally
            {
                conn.Close();
            }
        }

        // Hash the password (no salt)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }



        private void SendVerificationCodeEmail(string recipientEmail)
        {
            string senderEmail = "bryandelapaz66850@gmail.com";
            string senderPassword = "lyui gelf lhxq flta"; // Gmail App Password

            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(senderEmail);
                        mail.To.Add(recipientEmail);
                        mail.Subject = "Password Reset Verification Code";
                        mail.Body = $"Your password reset verification code is: {verificationCode}";

                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCodeVerification2_Click_1(object sender, EventArgs e)
        {
            string email = tbxEmail3.Text.Trim();

            btnCodeVerification2.Text = "Sending";
            btnCodeVerification2.Enabled = false;

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
                string checkQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@email", email);
                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount == 0)
                {
                    MessageBox.Show("Email not found. Please check the email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Email exists, generate verification code
                Random rnd = new Random();
                verificationCode = rnd.Next(100000, 999999).ToString();

                SendVerificationCodeEmail(email);

                verifiedEmail = email; // Lock the email here
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
            }

        }


        // Empty event handlers (safe to leave as-is or delete if not needed)
    }
}
