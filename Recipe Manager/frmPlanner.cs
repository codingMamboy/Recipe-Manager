using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmPlanner : Form
    {
        private readonly int userId;
        private readonly MySqlConnection conn; 
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";

        public frmPlanner(int userId)
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
            this.userId = userId;
        }

        private void frmPlanner_Load(object sender, EventArgs e)
        {
            cboRecipes.MaxDropDownItems = 5;
            try
            {
                // Query to get the logged-in user's username
                string query = "SELECT username FROM users WHERE user_id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Display welcome message using username
                    btnWelcome.Text = "Welcome, " + reader["username"].ToString();
                }
                conn.Close();

                // Load the list of recipes into the panel
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Configure date picker
            dtpPlanDate.Format = DateTimePickerFormat.Custom;
            dtpPlanDate.CustomFormat = "dddd, d MMMM yyyy";
            dtpPlanDate.Value = DateTime.Today;

            LoadRecipes();
            LoadPlans();
        }

        private void LoadRecipes()
        {
            // Populate recipe dropdown with recipe_id, name & category_id
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        SELECT recipe_id, recipe_name, category_id 
                        FROM recipes 
                        WHERE user_id = @userId";
                    cmd.Parameters.AddWithValue("@userId", userId);

                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    cboRecipes.DataSource = dt;
                    cboRecipes.DisplayMember = "recipe_name";
                    cboRecipes.ValueMember = "recipe_id";
                }

                // When recipe changes, show its original category
                cboRecipes.SelectedIndexChanged += cboRecipes_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recipes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPlans()
        {
            flowRecipeMenu.Controls.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        SELECT 
                            p.plan_id,
                            p.recipe_id,
                            r.recipe_name,
                            c.category_name,
                            p.notes
                        FROM plans p
                        JOIN recipes r ON p.recipe_id = r.recipe_id
                        JOIN categories c ON p.category_id = c.category_id
                        WHERE p.user_id = @userId
                            AND p.plan_date = @date";
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@date", dtpPlanDate.Value.Date);

                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Display text
                        string text = $"{reader["recipe_name"]} ({reader["category_name"]})";
                        int planId = reader.GetInt32("plan_id");

                        var card = new Guna2Button
                        {
                            Width = 180,
                            Height = 70,
                            Font = new Font("Poppins", 10),
                            FillColor = Color.FromArgb(233, 118, 43),
                            ForeColor = Color.White,
                            Text = text,
                            Margin = new Padding(18),
                            BorderRadius = 3,
                            Cursor = Cursors.Hand,
                            Tag = planId,
                            Animated = true
                        };

                        // Open frmViewPlan on click
                        card.Click += (s, ev) =>
                        {
                            int selectedPlanId = (int)((Guna2Button)s).Tag;

                            var viewForm = new frmViewPlan(selectedPlanId, userId);
                            this.Hide();
                            viewForm.ShowDialog();

                            // Optional: Refresh the list after returning
                            LoadPlans();
                        };

                        flowRecipeMenu.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading plans: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            // Require a selected recipe
            if (cboRecipes.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtCourse.Text))
            {
                MessageBox.Show("Please select a recipe and category.");
                return;
            }

            int recipeId = Convert.ToInt32(cboRecipes.SelectedValue);
            string notes = txtRecipeNotes.Text.Trim();
            DateTime date = dtpPlanDate.Value.Date;

            // Lookup category_id from the course textbox
            int categoryId = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        SELECT category_id 
                        FROM categories 
                        WHERE category_name = @catName
                        LIMIT 1";
                    cmd.Parameters.AddWithValue("@catName", txtCourse.Text.Trim());

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null) categoryId = Convert.ToInt32(result);
                }

                if (categoryId == 0)
                {
                    MessageBox.Show("Invalid category.");
                    return;
                }

                // Insert new plan
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO plans
                          (user_id, recipe_id, category_id, plan_date, notes)
                        VALUES
                          (@uid, @rid, @cid, @pd, @nt)";
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@rid", recipeId);
                    cmd.Parameters.AddWithValue("@cid", categoryId);
                    cmd.Parameters.AddWithValue("@pd", date);
                    cmd.Parameters.AddWithValue("@nt", notes);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Reset fields
                cboRecipes.SelectedIndex = -1;
                txtCourse.Clear();
                txtRecipeNotes.Clear();

                LoadPlans();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding recipe to plan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpPlanDate_ValueChanged(object sender, EventArgs e)
            => LoadPlans();

        private void btnHome_Click(object sender, EventArgs e)
        {
            Hide();
            using (frmHome home = new frmHome(userId))
            {
                home.ShowDialog();
            }
            Close();
        }

        private void cboRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When a recipe is picked, fetch & display its original category
            if (cboRecipes.SelectedItem is DataRowView rv)
            {
                int catId = Convert.ToInt32(rv["category_id"]);
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        MySqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = @"
                            SELECT category_name
                            FROM categories
                            WHERE category_id = @cid
                            LIMIT 1";
                        cmd.Parameters.AddWithValue("@cid", catId);

                        conn.Open();
                        var r = cmd.ExecuteScalar();
                        txtCourse.Text = r?.ToString() ?? "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {
            var frmRecipe = new frmRecipe(userId);
            this.Hide();
            frmRecipe.ShowDialog();
        }

        private void btnWelcome_Click(object sender, EventArgs e)
        {
            var frmProfile = new frmProfile(userId);
            this.Hide();
            frmProfile.Show();
        }
    }
}
