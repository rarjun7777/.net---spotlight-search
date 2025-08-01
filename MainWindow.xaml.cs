#nullable enable
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SearchApp
{
    public partial class MainWindow : Window
    {
        private static ChromeDriver? driver;
        private static bool isInitialized = false;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => SearchTextBox.Focus();
            // Removed TextBox drag logic to prevent accidental new search windows
        }

        public void ShowAndFocus()
        {
            this.Show();
            this.Activate();
            this.Topmost = true;
            SearchTextBox.Focus();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private async void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var query = SearchTextBox.Text.Trim();
                if (!string.IsNullOrEmpty(query))
                {
                    await SearchGeminiAsync(query);
                }
                // Hide the window instead of closing it to prevent new instances
                this.Hide();
                // Clear the text for next use
                SearchTextBox.Text = string.Empty;
            }
            else if (e.Key == Key.Escape)
            {
                // Hide the window instead of closing it to prevent new instances
                this.Hide();
                // Clear the text for next use
                SearchTextBox.Text = string.Empty;
            }
        }

        private async Task SearchGeminiAsync(string query)
        {
            try
            {
                await Task.Run(() =>
                {
                    // Initialize Chrome driver only once
                    if (driver == null || !isInitialized)
                    {
                        try
                        {
                            // Close existing driver if any
                            if (driver != null)
                            {
                                try { driver.Quit(); } catch { }
                                driver = null;
                            }

                            // Basic Chrome options without profile integration
                            var options = new ChromeOptions();
                            options.AddArgument("--no-sandbox");
                            options.AddArgument("--disable-dev-shm-usage");
                            options.AddArgument("--disable-blink-features=AutomationControlled");
                            options.AddExcludedArgument("enable-automation");
                            options.AddAdditionalOption("useAutomationExtension", false);
                            
                            // Suppress logging
                            options.AddArgument("--log-level=3");
                            options.AddArgument("--silent");
                            
                            // Create ChromeDriverService
                            var service = ChromeDriverService.CreateDefaultService();
                            service.HideCommandPromptWindow = true;
                            
                            // Initialize the driver
                            driver = new ChromeDriver(service, options);
                            
                            // Remove automation indicators
                            ((IJavaScriptExecutor)driver).ExecuteScript("Object.defineProperty(navigator, 'webdriver', {get: () => undefined})");
                            
                            isInitialized = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to initialize Chrome: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                    // Navigate to Gemini
                    driver!.Navigate().GoToUrl("https://gemini.google.com/");
                    
                    // Wait for navigation to complete and page to load
                    System.Threading.Thread.Sleep(3000);
                    
                    // Wait for page to load
                    var wait = new WebDriverWait(driver!, TimeSpan.FromSeconds(15));
                    
                    // Wait for the search input to be available and try different selectors
                    IWebElement searchInput = wait.Until(d => 
                    {
                        try
                        {
                            // Try different possible selectors for the Gemini input field
                            var selectors = new[]
                            {
                                "textarea[placeholder*='Ask']",
                                "textarea[placeholder*='Message']",
                                "textarea[aria-label*='Ask']",
                                "textarea[aria-label*='Message']",
                                "div[contenteditable='true'][role='textbox']",
                                "div[contenteditable='true']",
                                "textarea",
                                "input[type='text']"
                            };

                            foreach (var selector in selectors)
                            {
                                try
                                {
                                    var element = d.FindElement(By.CssSelector(selector));
                                    if (element != null && element.Displayed && element.Enabled)
                                    {
                                        return element;
                                    }
                                }
                                catch { continue; }
                            }
                            return null;
                        }
                        catch
                        {
                            return null;
                        }
                    });

                    if (searchInput == null)
                    {
                        MessageBox.Show("Could not find the input field on Gemini page", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Clear any existing text and type the query
                    searchInput.Clear();
                    searchInput.SendKeys(query);
                    
                    // Wait a moment for the text to be entered
                    System.Threading.Thread.Sleep(1000);
                    
                    // Verify the text was entered
                    var enteredText = searchInput.GetAttribute("value") ?? searchInput.Text;
                    if (string.IsNullOrEmpty(enteredText))
                    {
                        // Try alternative method for contenteditable elements
                        searchInput.SendKeys(Keys.Control + "a"); // Select all
                        searchInput.SendKeys(Keys.Delete); // Clear
                        searchInput.SendKeys(query);
                        System.Threading.Thread.Sleep(500);
                    }
                    
                    // Press Enter to submit
                    searchInput.SendKeys(Keys.Enter);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching Gemini: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            // Don't close the driver here - keep it open for subsequent searches
            base.OnClosed(e);
        }
    }
} 