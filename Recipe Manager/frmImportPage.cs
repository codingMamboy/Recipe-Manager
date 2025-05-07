using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack; // Used for parsing HTML documents

namespace Recipe_Manager
{
    public partial class frmImportPage : Form
    {
        // Stores the user ID passed into this form
        private readonly int userId;

        // Property to store the parsed recipe after importing
        public Recipe ImportedRecipe { get; private set; }

        // Constructor that accepts the user ID and initializes the form
        public frmImportPage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        // When the Import button is clicked
        private async void btnUploadUrl_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();  // Get and trim the entered URL

            // Validate that the URL is not empty or just whitespace
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a valid recipe URL.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Indicate to the user that loading has started
            btnUploadUrl.Enabled = false;
            btnUploadUrl.Text = "Loading...";

            try
            {
                // Call the async method to import the recipe from the URL
                ImportedRecipe = await ImportRecipeAsync(url);

                // If a recipe was successfully parsed, open the recipe form with it
                if (ImportedRecipe != null)
                {
                    frmRecipe recipeForm = new frmRecipe(userId, ImportedRecipe);
                    Hide();  // Hide this form
                    recipeForm.ShowDialog();  // Show the new form as a dialog
                    recipeForm.Dispose();  // Release resources
                    Close();  // Close this form
                }
                else
                {
                    // Recipe could not be parsed
                    MessageBox.Show("Could not parse the recipe. Please check the URL format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP-related errors (e.g., connection timeout)
                MessageBox.Show($"Network error: {ex.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restore button to its original state
                btnUploadUrl.Enabled = true;
                btnUploadUrl.Text = "Import";
            }
        }

        // Asynchronous method to fetch and parse recipe HTML from a URL
        private async Task<Recipe> ImportRecipeAsync(string url)
        {
            HttpClient client = new HttpClient(); // Create an HTTP client
            client.Timeout = TimeSpan.FromSeconds(15); // Set a timeout

            try
            {
                // Download HTML content from the URL
                string htmlContent = await client.GetStringAsync(url);

                // Load the HTML content into an HtmlDocument
                var document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(htmlContent);

                // Create a new Recipe object with extracted values
                return new Recipe
                {
                    Name = ExtractFirstMatch(document, new[]
                    {
                        "//h1", // Header tag
                        "//meta[@property='og:title']/@content", // Open Graph title
                        "//title" // Fallback to <title> tag
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
                        "//meta[@property='og:image']/@content", // Open Graph image
                        "//meta[@name='twitter:image']/@content", // Twitter card image
                        "//img[contains(@class,'recipe')]/@src", // Recipe image by class
                        "//img[contains(@src,'recipe')]/@src" // Recipe image by URL pattern
                    }) ?? string.Empty
                };
            }
            finally
            {
                // Dispose of the client to free up resources
                client.Dispose();
            }
        }

        // Helper method to extract the first matching string from HTML using a list of XPath expressions
        private static string ExtractFirstMatch(HtmlAgilityPack.HtmlDocument document, string[] xpaths)
        {
            foreach (string xpath in xpaths)
            {
                var node = document.DocumentNode.SelectSingleNode(xpath);
                if (node != null)
                {
                    // If XPath points to an attribute (e.g. @content), extract it
                    if (xpath.Contains("@"))
                    {
                        string attrName = xpath.Split('@').Last();
                        return node.GetAttributeValue(attrName, null)?.Trim();
                    }
                    else
                    {
                        return node.InnerText.Trim(); // Otherwise, get the inner text
                    }
                }
            }
            return null; // Nothing matched
        }

        // Helper method to extract multiple values from HTML and return them as a newline-separated string
        private static string ExtractList(HtmlAgilityPack.HtmlDocument document, string[] xpaths)
        {
            foreach (string xpath in xpaths)
            {
                var nodes = document.DocumentNode.SelectNodes(xpath);
                if (nodes != null && nodes.Any())
                {
                    // Join all node texts into a single string separated by newlines
                    return string.Join(Environment.NewLine, nodes.Select(n => n.InnerText.Trim()));
                }
            }
            return null; // Nothing matched
        }

        // Simple model class to store the recipe data
        public class Recipe
        {
            public string Name { get; set; }
            public string Ingredients { get; set; }
            public string Instructions { get; set; }
            public string ImageUrl { get; set; }
        }

        // Event handler for the Back button to return to the main recipe form
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmRecipe recipeForm = new frmRecipe(userId);
            this.Hide();
            recipeForm.Show();
        }

        // Event handler for the Exit button to close the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the app
        }
    }
}
