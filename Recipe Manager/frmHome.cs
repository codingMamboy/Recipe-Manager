using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_Manager
{
    public partial class frmHome : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private MySqlConnection conn;
        private int userId;

        // Constructor that accepts the userId
        public frmHome(int userId) 
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
            this.userId = userId; // Store the userId for later use in other forms
           
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            try
            {
                // Example: Load user name or data
                string query = "SELECT username FROM users WHERE user_id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string username = reader["username"].ToString();
                    lblWelcome.Text = "Welcome, " + username;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            // Event handler for any label click, you can implement this as needed
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {
            // Event handler for another label click, implement as necessary
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Event handler for a picture click, if applicable
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Stay on this page
        }

        // Navigate to the Recipe form when the Add Breakfast button is clicked
        private void btnAddbreakfast_Click(object sender, EventArgs e)
        {
            frmRecipe frmRecipe = new frmRecipe(userId); // Pass userId to frmRecipe
            this.Hide(); // Hide the current form (Home)
            frmRecipe.Show(); // Show the Recipe form
        }

        // Navigate to the Recipe form when the Recipe button is clicked
        private void btnRecipe_Click(object sender, EventArgs e)
        {
            frmRecipe frmRecipe = new frmRecipe(userId); // Pass userId to frmRecipe
            this.Hide(); // Hide the current form (Home)
            frmRecipe.Show(); // Show the Recipe form
        }

        private void btnPlanner_Click(object sender, EventArgs e)
        {
            // You can implement this function as needed for your planner or other functionalities
        }


    }
}
