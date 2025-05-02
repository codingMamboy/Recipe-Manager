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
        // Stores the user ID for later use in the recipe upload process
        private readonly int userId;

        // Property to hold the imported recipe after parsing
        public Recipe ImportedRecipe { get; private set; }

        // Constructor to initialize the form with the user's ID
        public frmImportPage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        // Click event handler for importing a recipe from a URL
        private async void btnUploadUrl_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();  // Retrieve the URL entered by the user

            // Validate if the URL is provided
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a valid recipe URL.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Disable the button and change text to indicate loading
            btnUploadUrl.Enabled = false;
            btnUploadUrl.Text = "Loading...";

            try
            {
                // Try to import the recipe asynchronously
                ImportedRecipe = await ImportRecipeAsync(url);

                // If the recipe is successfully imported, open the recipe form
                if (ImportedRecipe != null)
                {
                    frmRecipe recipeForm = new frmRecipe(userId, ImportedRecipe);
                    Hide();  // Hide the current form
                    recipeForm.ShowDialog();  // Show the new recipe form
                    recipeForm.Dispose();  // Dispose of the recipe form after use
                    Close();  // Close the current form
                }
                else
                {
                    // If the recipe is not parsed, show an error message
                    MessageBox.Show("Could not parse the recipe. Please check the URL format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle network errors
                MessageBox.Show($"Network error: {ex.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable the button and reset the text back to "Import"
                btnUploadUrl.Enabled = true;
                btnUploadUrl.Text = "Import";
            }
        }

        // Asynchronous method that retrieves and parses the recipe from the given URL
        private async Task<Recipe> ImportRecipeAsync(string url)
        {
            // Create an HTTP client with a 15-second timeout
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(15);

            try
            {
                // Fetch the HTML content from the URL
                string htmlContent = await client.GetStringAsync(url);

                // Create an HTML document and load the HTML content
                var document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(htmlContent);

                // Return a new Recipe object populated with extracted data
                return new Recipe
                {
                    // Extract the recipe name using various XPath queries
                    Name = ExtractFirstMatch(document, new[]
                    {
                        "//h1",
                        "//meta[@property='og:title']/@content",
                        "//title"
                    }) ?? "Untitled Recipe",

                    // Extract ingredients using XPath queries
                    Ingredients = ExtractList(document, new[]
                    {
                        "//li[contains(@class,'ingredient')]",
                        "//ul[contains(@class,'ingredients')]/li",
                        "//section[contains(@class,'ingredients')]//li",
                        "//div[contains(@class,'ingredient')]",
                        "//li[contains(text(),'cup') or contains(text(),'tsp') or contains(text(),'tablespoon') or contains(text(),'gram')]"
                    }) ?? "Ingredients not found.",

                    // Extract instructions using XPath queries
                    Instructions = ExtractList(document, new[]
                    {
                        "//li[contains(@class,'instruction')]",
                        "//li[contains(@class,'step')]",
                        "//ol[contains(@class,'instructions')]/li",
                        "//section[contains(@class,'instructions')]//li",
                        "//div[contains(@class,'instruction')]",
                        "//p[contains(text(),'step') or contains(text(),'instruction') or contains(text(),'Step')]"
                    }) ?? "Instructions not found.",

                    // Extract image URL if available
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
                // Ensure to dispose of the HTTP client after the operation
                client.Dispose();
            }
        }

        // Helper method to extract the first matching value from the document using multiple XPath queries
        private static string ExtractFirstMatch(HtmlAgilityPack.HtmlDocument document, string[] xpaths)
        {
            foreach (string xpath in xpaths)
            {
                var node = document.DocumentNode.SelectSingleNode(xpath);

                // If a node is found, extract either inner text or attribute value
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

        // Helper method to extract a list of values (like ingredients or instructions) from the document
        private static string ExtractList(HtmlAgilityPack.HtmlDocument document, string[] xpaths)
        {
            foreach (string xpath in xpaths)
            {
                var nodes = document.DocumentNode.SelectNodes(xpath);
                if (nodes != null && nodes.Any())
                {
                    // Combine all matching values into a single string
                    return string.Join(Environment.NewLine, nodes.Select(n => n.InnerText.Trim()));
                }
            }
            return null;
        }

        // Inner class to represent a recipe with its properties
        public class Recipe
        {
            public string Name { get; set; }
            public string Ingredients { get; set; }
            public string Instructions { get; set; }
            public string ImageUrl { get; set; }
        }

        // Button click event handler to navigate back to the recipe form
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmRecipe recipeForm = new frmRecipe(userId);
            this.Hide();  // Hide the current form
            recipeForm.Show();  // Show the recipe form
        }

        // Button click event handler to exit the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Exit the application
        }
    }
}
