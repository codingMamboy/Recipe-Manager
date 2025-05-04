using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_Manager
{
    public partial class frmViewPlan : Form
    {
        private int planId;
        private int userId;

        public frmViewPlan(int planId, int userId)
        {
            InitializeComponent();
            this.planId = planId;
            this.userId = userId;
        }

        // Use planId to load plan details on load
        private void frmViewPlan_Load(object sender, EventArgs e)
        {
            string connectionString = @"server=localhost;user=root;password=12345;database=recipe_managerv2;";
            string query = @"
        SELECT 
            p.plan_date,
            p.notes,
            r.recipe_name,
            c.category_name,
            r.image_path
        FROM plans p
        INNER JOIN recipes r ON p.recipe_id = r.recipe_id
        INNER JOIN categories c ON r.category_id = c.category_id
        WHERE p.plan_id = @planId AND p.user_id = @userId";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@planId", planId);
                        command.Parameters.AddWithValue("@userId", userId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblDate.Text = Convert.ToDateTime(reader["plan_date"]).ToString("dddd, d MMMM yyyy");
                                lblRecipeName.Text = reader["recipe_name"].ToString();
                                lblCourse.Text = reader["category_name"].ToString();
                                txtNotes.Text = reader["notes"].ToString(); // Add this line for showing notes

                                string imagePath = reader["image_path"].ToString();
                                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                                {
                                    pictureboxRecipe.SizeMode = PictureBoxSizeMode.StretchImage;  // Zoom instead of Stretch
                                    pictureboxRecipe.Image = Image.FromFile(imagePath);
                                }
                                else
                                {
                                    pictureboxRecipe.Image = null;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Plan not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading plan: " + ex.Message);
            }
        }

        private void btnDeletePLam_Click(object sender, EventArgs e)
        {
            // Ask for confirmation
            if (MessageBox.Show(
                    "Are you sure you want to delete this plan?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                ) != DialogResult.Yes)
                return;

            // Delete from DB
            string cs = @"server=localhost;uid=root;pwd=12345;database=recipe_managerv2;";
            try
            {
                using (var conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM plans WHERE plan_id = @planId AND user_id = @userId";
                        cmd.Parameters.AddWithValue("@planId", planId);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("Plan deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No matching plan found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting plan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Close this view and return to your planner form, which will refresh itself
            this.Close();
            
            var frmPlanner = new frmPlanner(userId);
            frmPlanner.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frmPlanner = new frmPlanner(userId);
            this.Close();
            frmPlanner.Show();
        }
    }
}
