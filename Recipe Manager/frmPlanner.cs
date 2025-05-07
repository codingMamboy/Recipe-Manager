using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Recipe_Manager
{
    public partial class frmPlanner : Form
    {
        private readonly int userId;
        private readonly MySqlConnection conn;
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";

        // Constructor to initialize the form with user ID and connection details
        public frmPlanner(int userId)
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
            this.userId = userId;
        }

        // Form load event - populates user details, recipe dropdown, and plans
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

                // Load the list of recipes and existing plans
                LoadRecipes();
                LoadPlans();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Configure date picker to show date in "weekday, day month year" format
            dtpPlanDate.Format = DateTimePickerFormat.Custom;
            dtpPlanDate.CustomFormat = "dddd, d MMMM yyyy";
            dtpPlanDate.Value = DateTime.Today;
        }

        // Loads the user's recipes into the combo box
        private void LoadRecipes()
        {
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

                // When a recipe is selected, show its category
                cboRecipes.SelectedIndexChanged += cboRecipes_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recipes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Loads existing plans for the selected date and displays them in cards
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
                        // Display each plan as a button (card) in the flow layout
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

                        // Open the plan details when clicked
                        card.Click += (s, ev) =>
                        {
                            int selectedPlanId = (int)((Guna2Button)s).Tag;
                            var viewForm = new frmViewPlan(selectedPlanId, userId);
                            this.Hide();
                            viewForm.ShowDialog();
                            LoadPlans();  // Optionally refresh plans after viewing
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

        // Adds a new recipe to the plan on button click
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (cboRecipes.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtCourse.Text))
            {
                MessageBox.Show("Please select a recipe and category.");
                return;
            }

            int recipeId = Convert.ToInt32(cboRecipes.SelectedValue);
            string notes = txtRecipeNotes.Text.Trim();
            DateTime date = dtpPlanDate.Value.Date;

            // Get the category ID from the category text box
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

                // Insert new plan into the database
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

                // Clear the inputs after adding the recipe
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

        // Refresh the plan view when the date changes
        private void dtpPlanDate_ValueChanged(object sender, EventArgs e)
            => LoadPlans();

        // Navigate to the home screen
        private void btnHome_Click(object sender, EventArgs e)
        {
            Hide();
            using (frmHome home = new frmHome(userId))
            {
                home.ShowDialog();
            }
            Close();
        }

        // Display the selected recipe's category in the category text box
        private void cboRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        // Navigate to the Recipe screen
        private void btnRecipe_Click(object sender, EventArgs e)
        {
            var frmRecipe = new frmRecipe(userId);
            this.Hide();
            frmRecipe.ShowDialog();
        }

        // Navigate to the Profile screen
        private void btnWelcome_Click(object sender, EventArgs e)
        {
            var frmProfile = new frmProfile(userId);
            this.Hide();
            frmProfile.Show();
        }
    }
}
