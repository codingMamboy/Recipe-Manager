using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

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
            txtSearchbar.TextChanged += txtSearchbar_TextChanged;
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
                    btnWelcome.Text = "Welcome, " + reader["username"].ToString();

                conn.Close();

                // Load user's recipes as buttons
                LoadRecipesToPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecipesToPanel(string search = "")
        {
            flowRecipeMenu.Controls.Clear();

            try
            {
                conn.Open();
                string query = @"
                    SELECT recipe_id, recipe_name
                    FROM recipes
                    WHERE user_id = @userId
                      AND recipe_name LIKE @search";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int recipeId = Convert.ToInt32(reader["recipe_id"]);
                        string recipeName = reader["recipe_name"].ToString();

                        var recipeButton = new Guna2Button
                        {
                            Width = 180,
                            Height = 70,
                            Font = new Font("Poppins", 10, FontStyle.Regular),
                            FillColor = Color.FromArgb(233, 118, 43),
                            ForeColor = Color.White,
                            Text = recipeName,
                            Tag = recipeId,
                            Margin = new Padding(10),
                            BorderRadius = 3,
                            Cursor = Cursors.Hand
                        };

                        recipeButton.Click += (s, e) =>
                        {
                            var viewForm = new frmViewRecipe(recipeId);
                            this.Hide();
                            viewForm.Show();
                        };

                        flowRecipeMenu.Controls.Add(recipeButton);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load recipes: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void txtSearchbar_TextChanged(object sender, EventArgs e)
        {
            LoadRecipesToPanel(txtSearchbar.Text.Trim());
        }

        // Other UI event handlers (left empty if unused)
        private void btnRecipe_Click(object sender, EventArgs e)
        {
            var addForm = new frmRecipe(userId);
            this.Hide();
            addForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e) { }
        private void btnPlanner_Click(object sender, EventArgs e) { }
        private void btnViewRecipe_Click(object sender, EventArgs e) { }
        private void guna2HtmlLabel2_Click(object sender, EventArgs e) { }
        private void guna2HtmlLabel3_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e) { }

        private void guna2HtmlLabel2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
