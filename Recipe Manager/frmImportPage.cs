using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

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
                ImportedRecipe = await ImportRecipeAsync(url);

                if (ImportedRecipe != null)
                {
                    // Manually manage form creation and disposal without 'using' keyword
                    frmRecipe recipeForm = new frmRecipe(userId, ImportedRecipe);
                    Hide();
                    recipeForm.ShowDialog();
                    recipeForm.Dispose();  // Dispose the form manually after it's closed
                    Close();
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

        private async Task<Recipe> ImportRecipeAsync(string url)
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(15);

            try
            {
                string htmlContent = await client.GetStringAsync(url);

                var document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(htmlContent);

                return new Recipe
                {
                    Name = ExtractFirstMatch(document, new[]
                    {
                        "//h1",
                        "//meta[@property='og:title']/@content",
                        "//title"
                    }) ?? "Untitled Recipe",

                    Ingredients = ExtractList(document, new[]
                    {
                        "//li[contains(@class,'ingredient')]",
                        "//ul[contains(@class,'ingredients')]/li",
                        "//section[contains(@class,'ingredients')]//li",
                        "//div[contains(@class,'ingredient')]",
                        "//li[contains(text(),'cup') or contains(text(),'tsp') or contains(text(),'tablespoon') or contains(text(),'gram')]"
                    }) ?? "Ingredients not found.",

                    Instructions = ExtractList(document, new[]
                    {
                        "//li[contains(@class,'instruction')]",
                        "//li[contains(@class,'step')]",
                        "//ol[contains(@class,'instructions')]/li",
                        "//section[contains(@class,'instructions')]//li",
                        "//div[contains(@class,'instruction')]",
                        "//p[contains(text(),'step') or contains(text(),'instruction') or contains(text(),'Step')]"
                    }) ?? "Instructions not found.",

                    ImageUrl = ExtractFirstMatch(document, new[]
                    {
                        "//meta[@property='og:image']/@content",
                        "//meta[@name='twitter:image']/@content",
                        "//img[contains(@class,'recipe')]/@src",
                        "//img[contains(@src,'recipe')]/@src"
                    }) ?? string.Empty
                };
            }
            finally
            {
                // Make sure to dispose the HttpClient after the operation
                client.Dispose();
            }
        }

        private static string ExtractFirstMatch(HtmlAgilityPack.HtmlDocument document, string[] xpaths)
        {
            foreach (string xpath in xpaths)
            {
                var node = document.DocumentNode.SelectSingleNode(xpath);

                if (node != null)
                {
                    if (xpath.Contains("@"))
                    {
                        string attrName = xpath.Split('@').Last();
                        return node.GetAttributeValue(attrName, null)?.Trim();
                    }
                    else
                    {
                        return node.InnerText.Trim();
                    }
                }
            }
            return null;
        }

        private static string ExtractList(HtmlAgilityPack.HtmlDocument document, string[] xpaths)
        {
            foreach (string xpath in xpaths)
            {
                var nodes = document.DocumentNode.SelectNodes(xpath);
                if (nodes != null && nodes.Any())
                {
                    return string.Join(Environment.NewLine, nodes.Select(n => n.InnerText.Trim()));
                }
            }
            return null;
        }

        public class Recipe
        {
            public string Name { get; set; }
            public string Ingredients { get; set; }
            public string Instructions { get; set; }
            public string ImageUrl { get; set; }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmRecipe recipeForm = new frmRecipe(userId);
            this.Hide();
            recipeForm.Show();
        }
    }
}
