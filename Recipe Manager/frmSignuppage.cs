using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions    ;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmSignuppage : Form
    {
        string connectionString = "server = localhost; uid = root; pwd = 12345; database = login";
        MySqlConnection conn;
        public frmSignuppage()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
        }

        private void frmSignuppage_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLoginpage frm = new frmLoginpage();
            frm.Show();
        }

        private void tbxPwd2_TextChanged(object sender, EventArgs e)
        {
            tbxPwd2.UseSystemPasswordChar = true;
        }

        private void tbxConfirmpwd_TextChanged(object sender, EventArgs e)
        {
            tbxConfirmpwd.UseSystemPasswordChar = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {

            string username = tbxUsername2.Text.Trim();
            string password = tbxPwd2.Text.Trim();
            string confirmPwd = tbxConfirmpwd.Text.Trim();
            string email = tbxEmail.Text.Trim();


            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(confirmPwd))
            {

                MessageBox.Show("Please fill the inputs", "No input detected", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPwd) {

                MessageBox.Show("Your password does not match, please try again", "Password Error" ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);

                checkCmd.Parameters.AddWithValue("@email", email);
                checkCmd.Parameters.AddWithValue("@username", username);
                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount > 0)
                {
                    MessageBox.Show("Username or Email already taken.", "Sign-Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string insertQuery = "INSERT INTO users (username, email, password) VALUES (@username, @email, @password)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);

                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@password", password);
                insertCmd.Parameters.AddWithValue("@email", email);

                int result = insertCmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    frmLoginpage frm = new frmLoginpage();
                    this.Close();
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("Sign-up failed. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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


    }

}


