using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;  // Make sure this is only here
using System.Linq;

namespace Recipe_Manager
{
    public partial class frmImportPage : Form
    {
        private readonly int userId;
        public Recipe ImportedRecipe { get; private set; }

        public frmImportPage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private async void btnUploadUrl_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a valid recipe URL.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnUploadUrl.Enabled = false;
            btnUploadUrl.Text = "Loading...";

            try
            {
                ImportedRecipe = await GetRecipeFromUrlAsync(url);

                if (ImportedRecipe != null)
                {

                    using (var recipeForm = new frmRecipe(userId, ImportedRecipe))
                    {
                        this.Hide();
                        recipeForm.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Could not parse the recipe. Please check the URL format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnUploadUrl.Enabled = true;
                btnUploadUrl.Text = "Import";
            }
        }

        private async Task<Recipe> GetRecipeFromUrlAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(10);

                var html = await client.GetStringAsync(url);

                var doc = new HtmlAgilityPack.HtmlDocument();  // Use fully qualified name
                doc.LoadHtml(html);  // Load the HTML from the URL

                var recipe = new Recipe
                {
                    Name = ExtractText(doc, "//h1") ?? ExtractText(doc, "//title") ?? "Untitled Recipe",
                    Ingredients = ExtractList(doc, "//li[contains(@class,'ingredient')]") ?? "Ingredients not found.",
                    Instructions = ExtractList(doc, "//li[contains(@class,'instruction') or contains(@class,'step')]") ?? "Instructions not found.",
                    ImageUrl = ExtractImageUrl(doc) ?? string.Empty
                };

                return recipe;
            }
        }

        private static string ExtractText(HtmlAgilityPack.HtmlDocument doc, string xpath)
        {
            var node = doc.DocumentNode.SelectSingleNode(xpath);
            return node?.InnerText.Trim();
        }

        private static string ExtractList(HtmlAgilityPack.HtmlDocument doc, string xpath)
        {
            var nodes = doc.DocumentNode.SelectNodes(xpath);
            if (nodes != null && nodes.Any())
            {
                return string.Join(Environment.NewLine, nodes.Select(n => n.InnerText.Trim()));
            }
            return null;
        }

        private static string ExtractImageUrl(HtmlAgilityPack.HtmlDocument doc)
        {
            var imgNode = doc.DocumentNode.SelectSingleNode("//meta[@property='og:image']");
            return imgNode?.GetAttributeValue("content", null);
        }

        public class Recipe
        {
            public string Name { get; set; }
            public string Ingredients { get; set; }
            public string Instructions { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}
