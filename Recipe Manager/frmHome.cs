using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Linq;

namespace Recipe_Manager
{
    public partial class frmHome : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private MySqlConnection conn;
        private int userId;

        public frmHome(int userId)
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
            this.userId = userId;
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

            try
            {
                // Load the username
                string query = "SELECT username FROM users WHERE user_id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string username = reader["username"].ToString();
                    btnWelcome.Text = "Welcome, " + username;
                }

                conn.Close();

                // Load user's recipes as buttons
                LoadRecipesToPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecipesToPanel()
        {

            try
            {
                conn.Open();
                string query = @"SELECT r.recipe_id, r.recipe_name FROM recipes r WHERE r.user_id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int recipeId = Convert.ToInt32(reader["recipe_id"]);
                    string recipeName = reader["recipe_name"].ToString();

                    Guna2Button recipeButton = new Guna2Button
                    {
                        Width = 180,
                        Height = 70,
                        Font = new Font("Poppins", 10, FontStyle.Bold),
                        FillColor = Color.FromArgb(65, 100, 74),
                        ForeColor = Color.White,
                        Text = recipeName,
                        Tag = recipeId,
                        Margin = new Padding(10),
                        BorderRadius = 3,
                        Cursor = Cursors.Hand
                    };

                    recipeButton.Click += (s, e) =>
                    {
                        frmViewRecipe frm = new frmViewRecipe(recipeId);
                        this.Hide();
                        frm.Show();
                    };

                    flowRecipeMenu.Controls.Add(recipeButton);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load recipes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

            }

        }


        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            // Optional label event
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {
            // Optional label event
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Optional image event
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Stay on this form
        }

        private void btnAddbreakfast_Click(object sender, EventArgs e)
        {
            frmRecipe frmRecipe = new frmRecipe(userId);
            this.Hide();
            frmRecipe.Show();
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {
            frmRecipe frmRecipe = new frmRecipe(userId);
            this.Hide();
            frmRecipe.Show();
        }

        private void btnPlanner_Click(object sender, EventArgs e)
        {
            // Implement as needed
        }

        private void btnViewRecipe_Click(object sender, EventArgs e)
        {
            // No functionality assigned here for the moment
        }
    }
}
