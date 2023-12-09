using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using System.Diagnostics.Metrics;


namespace SeleniumTest
{
    [TestClass]
    public class BPTest
    {      

        [TestMethod]
        public void A_0_SysadminLogin()
        {

            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "sysadmin";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);

            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

            // Wait for the username field to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            IWebElement usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));

            // Find the password input field and login button
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));

            // Input the username and password
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);

            // Perform the login action
            loginButton.Click();

            // Wait for the next page to load (you may need to adjust the timing)
            wait.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/home")); // Replace "expectedPage" with part of the URL of the next page

            // You can add further actions after successful login here
            Thread.Sleep(1000);

            // Close the browser
            driver.Quit();
        }

        [TestMethod]
        public void A_1_SysadminChecking()
        {

            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "sysadmin";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);

            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

            // Wait for the username field to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            IWebElement usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));

            // Find the password input field and login button
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));

            // Input the username and password
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);

            // Perform the login action
            loginButton.Click();

            // Wait for the next page to load (you may need to adjust the timing)
            wait.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/home")); // Replace "expectedPage" with part of the URL of the next page

            Thread.Sleep(500);
            // Find and click on the menu item
            IWebElement menuItem = driver.FindElement(By.CssSelector("a[routerlink='/settings/sysadminsettings']"));
            menuItem.Click();

            Thread.Sleep(500);

            // Find and click on the menu item inside the tab
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement securityMenuItem = wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[data-toggle='tab'][href='#security-settings']")));
            securityMenuItem.Click();

            Thread.Sleep(500);

            // Find and click on the "Save" button
            IWebElement saveButton = driver.FindElement(By.CssSelector("button.btn.btn-primary-submit"));
            saveButton.Click();

            IWebElement toastMessageElement1 = null;
            // Create a WebDriverWait instance
            WebDriverWait wait11 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the div element containing the toast message
            toastMessageElement1 = wait11.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));

            // Get the text within the div element
            string toastMessage = toastMessageElement1.Text;


            // Use the captured message as needed
            Console.WriteLine("Toast Message2: " + toastMessage);


            Thread.Sleep(1000);

            // Find and click on the "Logout" button  
            IWebElement logoutButton = driver.FindElement(By.CssSelector("li.nav-item.logged-in-ic-wrapper"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", logoutButton);


            // Wait for the next page to load (you may need to adjust the timing)
            Thread.Sleep(1000);

            // Close the browser
            driver.Quit();
        }

        [TestMethod]
        public void B_0_BoardadminLogin()
        {

            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "boardadmin";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);

            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

            // Wait for the username field to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            IWebElement usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));

            // Find the password input field and login button
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));

            // Input the username and password
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);

            // Perform the login action
            loginButton.Click();

            // Wait for the next page to load (you may need to adjust the timing)
            wait.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/home")); // Replace "expectedPage" with part of the URL of the next page

            // You can add further actions after successful login here
            Thread.Sleep(1000);

            // Close the browser
            driver.Quit();
        }

        [TestMethod]
        public void B_1_BoardadminChecking()
        {

            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "boardadmin";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);

            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

            // Wait for the username field to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            IWebElement usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));

            // Find the password input field and login button
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));

            // Input the username and password
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);

            // Perform the login action
            loginButton.Click();

            // Wait for the next page to load (you may need to adjust the timing)
            wait.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/home")); // Replace "expectedPage" with part of the URL of the next page

            Thread.Sleep(500);

            // Find and click on the menu item
            IWebElement menuItem = driver.FindElement(By.CssSelector("a[routerlink='/settings/boardadminsettings']"));
            menuItem.Click();

            Thread.Sleep(500);

            // Find and click on the menu item inside the tab
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement securityMenuItem = wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[data-toggle='tab'][href='#meeting-settings']")));
            securityMenuItem.Click();

            Thread.Sleep(500);

            // Find and click on the "Save" button
            IWebElement saveButton = driver.FindElement(By.CssSelector("button.btn.btn-primary-submit"));
            saveButton.Click();

            Thread.Sleep(500);

            IWebElement toastMessageElement1 = null;
            // Create a WebDriverWait instance
            WebDriverWait wait11 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the div element containing the toast message
            toastMessageElement1 = wait11.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));

            // Get the text within the div element
            string toastMessage = toastMessageElement1.Text;
            
            // Use the captured message as needed
            Console.WriteLine("Toast Message2: " + toastMessage);

            // Wait for the next page to load (you may need to adjust the timing)
            Thread.Sleep(1000);

            // Find and click on the "Logout" button  
            IWebElement logoutButton = driver.FindElement(By.CssSelector("li.nav-item.logged-in-ic-wrapper"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", logoutButton);


            // Wait for the next page to load (you may need to adjust the timing)
            Thread.Sleep(1000);

            // Close the browser
            driver.Quit();
        }

        [TestMethod]
        public void B_2_BoardadminUserCreating()
        {

            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "boardadmin";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            //chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600); // Set page load timeout to 30 seconds (example)

            // Wait for the username field to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(600));
            IWebElement usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));

            // Find the password input field and login button
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));

            // Input the username and password
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);

            // Perform the login action
            loginButton.Click();

            // Wait for the next page to load (you may need to adjust the timing)
            wait.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/home")); // Replace "expectedPage" with part of the URL of the next page

            // Define the base username
            string baseUsername = "Avishka";

            // Initialize a counter
            int counter = 103;

            bool userAdded = false;

            while (!userAdded)
            {
                // Wait for the next page to load (you may need to adjust the timing)
                Thread.Sleep(4000);


                // Create a WebDriverWait instance
                WebDriverWait wait7 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Find the menu element with a waiting strategy
                IWebElement menu = wait7.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='#submenu1'][data-toggle='collapse']")));

                // Check if the menu is expanded or collapsed
                string ariaExpandedAttributeValue = menu.GetAttribute("aria-expanded");

                if (ariaExpandedAttributeValue.Equals("true"))
                {
                    // Menu is expanded, no action needed
                    Console.WriteLine("Menu is already expanded");
                }
                else
                {
                    // Menu is collapsed, click to expand
                    menu.Click();
                    Thread.Sleep(500);
                }

                // Find the <a> element for viewing users
                IWebElement viewUserLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/usermgt/viewUsers'][routerlinkactive='active']")));

                if (viewUserLink != null)
                {
                    // Click on the link to view users if it's clickable
                    viewUserLink.Click();
                    Thread.Sleep(500);
                }
                else
                {
                    // Handle the situation where the link is not clickable
                    Console.WriteLine("View User link is not clickable.");
                    // You can add further actions or error handling here if needed
                }


                // Create a WebDriverWait instance
                WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Find the menu element with a waiting strategy
                IWebElement menu1 = wait8.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='#submenu1'][data-toggle='collapse']")));

                // Check if the menu is expanded or collapsed
                string ariaExpandedAttributeValue1 = menu1.GetAttribute("aria-expanded");

                if (ariaExpandedAttributeValue1.Equals("true"))
                {
                    // Menu is expanded, no action needed
                    Console.WriteLine("Menu is already expanded");
                }
                else
                {
                    // Menu is collapsed, click to expand
                    menu1.Click();
                    Thread.Sleep(500);
                }


                // Find the <a> element for user creation
                IWebElement createUserLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/usermgt/createUser'][routerlinkactive='active']")));

                if (createUserLink != null)
                {
                    // Click on the user creation link if it's clickable
                    createUserLink.Click();
                    Thread.Sleep(500);
                }
                else
                {
                    // Handle the situation where the link is not clickable
                    Console.WriteLine("Create User link is not clickable.");
                    // You can add further actions or error handling here if needed
                }

                //Creating a User
                // Wait for the form to load
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait2.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-body")));

                try
                {                    
                    // Create the next username by appending the counter
                    string nextUsername = baseUsername + counter;

                    // Insert values into the form
                    InsertSalutation(driver, "Mr");
                    InsertUsername(driver, nextUsername);
                    InsertFirstName(driver, "Avishka");
                    InsertLastName(driver, "BoardPAC");
                    InsertPrimaryEmail(driver, "avishkalaki@hotmail.com");
                    InsertDeviceDisplayName(driver, "AvishkaBoardPAC");
                    InsertUserType(driver, "Organizer");

                    Thread.Sleep(500);


                    // Click the submit button (assuming it's initially disabled)
                    IWebElement submitButton = driver.FindElement(By.Id("submitBtn"));
                    if (submitButton.Enabled)
                    {
                        submitButton.Click();
                        Thread.Sleep(500);


                        IWebElement toastMessageElement = null;

                        try
                        {
                            // Create a WebDriverWait instance
                            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                            // Find the div element containing the toast message
                            toastMessageElement = wait5.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));

                            // Get the text within the div element
                            string toastMessage = toastMessageElement.Text;


                            // Use the captured message as needed
                            Console.WriteLine("Toast Message: " + toastMessage);


                            if (toastMessage.Contains("User name " + nextUsername + " is already taken."))
                            {
                                // Increment the counter for the next username
                                counter++;
                                Thread.Sleep(500);
                            }
                            else
                            {
                                userAdded = true;
                                Thread.Sleep(500);

                            }

                        }
                        catch (StaleElementReferenceException)
                        {
                                                       
                            // If the element reference becomes stale, re-find the element and retrieve the text again
                            toastMessageElement = driver.FindElement(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message"));

                            // Get the text within the div element
                            string toastMessage = toastMessageElement.Text;

                            // Use the captured message as needed
                            Console.WriteLine("Toast Message: " + toastMessage);

                            // Wait for the next page to load (you may need to adjust the timing)
                            Thread.Sleep(1000);

                            // Close the browser
                            driver.Quit();
                        }



                    }


                }
                catch (Exception ex)
                {
                    // Handle other exceptions or rethrow the exception
                    throw;
                }
            }

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            // Wait for the next page to load (you may need to adjust the timing)
            wait3.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/usermgt/viewUsers")); // Replace "expectedPage" with part of the URL of the next page


            // Wait for the next page to load (you may need to adjust the timing)
            Thread.Sleep(1000);

            // Close the browser
            driver.Quit();

        }

        [TestMethod]
        public void B_3_BoardadminUserUpdate()
        {
            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "boardadmin";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            //chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600); // Set page load timeout to 30 seconds (example)

            // Wait for the username field to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(600));
            IWebElement usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));

            // Find the password input field and login button
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));

            // Input the username and password
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);

            // Perform the login action
            loginButton.Click();

            // Wait for the next page to load (you may need to adjust the timing)
            wait.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/home")); // Replace "expectedPage" with part of the URL of the next page

            // Create a WebDriverWait instance
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the menu element with a waiting strategy
            IWebElement menu = wait1.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='#submenu1'][data-toggle='collapse']")));

            // Check if the menu is expanded or collapsed
            string ariaExpandedAttributeValue = menu.GetAttribute("aria-expanded");

            if (ariaExpandedAttributeValue.Equals("true"))
            {
                // Menu is expanded, no action needed
                Console.WriteLine("Menu is already expanded");
            }
            else
            {
                // Menu is collapsed, click to expand
                menu.Click();
            }

            // Find the <a> element for viewing users
            IWebElement viewUserLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/usermgt/viewUsers'][routerlinkactive='active']")));

            if (viewUserLink != null)
            {
                // Click on the link to view users if it's clickable
                viewUserLink.Click();
            }
            else
            {
                // Handle the situation where the link is not clickable
                Console.WriteLine("View User link is not clickable.");
                // You can add further actions or error handling here if needed
            }

            //Creating a User
            // Wait for the form to load
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-body")));

            Thread.Sleep(500);

            // Set up an explicit wait with a timeout of 30 seconds
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Wait for the dropdown element to be present, visible, and clickable in the DOM
            IWebElement statusDropdown = wait3.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("select.filter-by-status")));

            // Using SelectElement to handle the dropdown
            SelectElement dropdown = new SelectElement(statusDropdown);

            // Selecting "Active" status by its value
            dropdown.SelectByValue("2");

            // Set up WebDriverWait
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            By tableSelector = By.CssSelector(".ui-table-tbody");

            // Wait for the table body element to be visible
            IWebElement tableBody = wait4.Until(ExpectedConditions.ElementIsVisible(tableSelector));

            // Find the first row of the table within the table body
            IWebElement firstRow = tableBody.FindElement(By.CssSelector("tr"));

            // Find the edit button in the first row
            IWebElement editButton = wait4.Until(ExpectedConditions.ElementToBeClickable(firstRow.FindElement(By.CssSelector(".edit-icon-btn"))));

            // Click the edit button
            editButton.Click();

            Thread.Sleep(500);

            // Wait for the URL to match the expected pattern
            wait4.Until(driver => driver.Url.StartsWith("https://azuredevops.boardpaconline.com/WebClient/usermgt/updateuser"));

            Thread.Sleep(1000);
            // Perform other actions after the URL matches the pattern...
            InsertDeviceDisplayName(driver, "BoardPACTest1");
            Thread.Sleep(1000);
            InsertLastName(driver, "BoardPACNew");
            Thread.Sleep(1000);

            // Click the submit button (assuming it's initially disabled)
            IWebElement submitButton = driver.FindElement(By.Id("submitBtn"));
            if (submitButton.Enabled)
            {
                submitButton.Click();

                Thread.Sleep(500);

                IWebElement toastMessageElement = null;

                try
                {
                    // Create a WebDriverWait instance
                    WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                    // Find the div element containing the toast message
                    toastMessageElement = wait5.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));

                    // Get the text within the div element
                    string toastMessage = toastMessageElement.Text;


                    // Use the captured message as needed
                    Console.WriteLine("Toast Message: " + toastMessage);

                    string targetString = "user is successfully updated.";


                    if (toastMessage.IndexOf(targetString, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine("Toast Message contains: " + targetString);
                        WebDriverWait wait6 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                        // Wait for the next page to load (you may need to adjust the timing)
                        wait6.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/usermgt/viewUsers")); // Replace "expectedPage" with part of the URL of the next page


                        // Wait for the next page to load (you may need to adjust the timing)
                        Thread.Sleep(1000);

                        // Close the browser
                        driver.Quit();

                    }
                    else
                    {
                        Console.WriteLine("Toast Message: " + toastMessage);

                        // Wait for the next page to load (you may need to adjust the timing)
                        Thread.Sleep(1000);

                        // Close the browser
                        driver.Quit();

                    }
                }
                catch (StaleElementReferenceException)
                {

                    // If the element reference becomes stale, re-find the element and retrieve the text again
                    toastMessageElement = driver.FindElement(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message"));

                    // Get the text within the div element
                    string toastMessage = toastMessageElement.Text;

                    // Use the captured message as needed
                    Console.WriteLine("Toast Message: " + toastMessage);

                    // Wait for the next page to load (you may need to adjust the timing)
                    Thread.Sleep(1000);

                    // Close the browser
                    driver.Quit();
                }

            }
        }

        [TestMethod]
        public void B_4_BoardadminCreateCommittee()
        {

            string formattedDate = GetCurrentFormattedDate();

            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "boardadmin";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            //chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600); // Set page load timeout to 30 seconds (example)

            // Wait for the username field to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(600));
            IWebElement usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));

            // Find the password input field and login button
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));

            // Input the username and password
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);

            // Perform the login action
            loginButton.Click();

            // Wait for the next page to load (you may need to adjust the timing)
            wait.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/home")); // Replace "expectedPage" with part of the URL of the next page

            // Find the <a> element for user creation
            IWebElement createCommitteeLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/committeemgt/committees'][routerlinkactive='active']")));

            if (createCommitteeLink != null)
            {
                // Click on the user creation link if it's clickable
                createCommitteeLink.Click();
            }
            else
            {
                // Handle the situation where the link is not clickable
                Console.WriteLine("Create User link is not clickable.");
                // You can add further actions or error handling here if needed
            }

            // Set up a WebDriverWait
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Wait for the button to be clickable
            IWebElement button = wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@title='Click to Create a committee']//button[contains(., 'Create Committee')]")));

            // Click the button
            button.Click();

            // Wait for the dialog window to appear
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait3.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//span[text()='Add Committee']")));


            // Initialize a counter
            int counter = 15;

            bool userAdded = false;

            while (!userAdded)
            {
                // Find input fields for Committee Name and Device Display Name
                IWebElement committeeNameInput = driver.FindElement(By.Id("committeeNameId"));
                IWebElement deviceDisplayNameInput = driver.FindElement(By.Id("committeeDeviceDisplayNameId"));                

                // Enter text into the fields
                committeeNameInput.SendKeys("BPCommittee" + formattedDate+"_"+counter);
                deviceDisplayNameInput.SendKeys("BP" + formattedDate);

                // Wait for the next page to load (you may need to adjust the timing)
                Thread.Sleep(500);

                IWebElement saveButton = driver.FindElement(By.Id("addComBtn"));
                if (saveButton.Enabled)
                {
                    saveButton.Click();
                    userAdded = true;
                    Thread.Sleep(500);
                    
                }
                else
                {
                    committeeNameInput.Clear();
                    deviceDisplayNameInput.Clear();
                    counter++;
                    Thread.Sleep(500);
                    
                }

            }

            string targetCommitteeName = "BPCommittee" + formattedDate + "_" + counter;

            Thread.Sleep(500);

            // Wait for the search icon to be clickable
            WebDriverWait wait6 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchIcon = wait6.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("span.btn.btn-default.input-group-addon.m-d-none")));

            // Click on the search icon to activate the search field
            searchIcon.Click();

            // Find the search input field and input the committee name to search for
            IWebElement searchInput = wait6.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='text']"))); // Replace with your specific input selector

            // Replace 'BPCommittee12082023' with the committee name you want to search
            string committeeName = targetCommitteeName;
            searchInput.SendKeys(committeeName);

            // Press Enter to perform the search
            searchInput.SendKeys(Keys.Enter);

            Thread.Sleep(500);

            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));     

            // Wait for the table to be visible
            IWebElement table = wait4.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("p-table[datakey='id']")));

            // Find the committee name that matches 'BPCommittee12082023'
            IWebElement matchingRow = wait4.Until(ExpectedConditions.ElementExists(By.XPath($"//span[text()='{targetCommitteeName}']/ancestor::tr")));

            // Click the plus sign or add subcommittee button in the same row
            IWebElement addButton = wait4.Until(ExpectedConditions.ElementToBeClickable(matchingRow.FindElement(By.CssSelector("button[icon='pi pi-plus-circle']"))));
            addButton.Click();

            // Initialize a counter
            int counter1 = 0;

            bool userAdded1 = false;

            while (!userAdded1)
            {
                // Find input fields for Committee Name and Device Display Name
                IWebElement committeeNameInput1 = driver.FindElement(By.Id("committeeNameId"));
                IWebElement deviceDisplayNameInput1 = driver.FindElement(By.Id("committeeDeviceDisplayNameId"));

                // Enter text into the fields
                committeeNameInput1.SendKeys("BPSubCommittee" + formattedDate + "_" + counter1);
                deviceDisplayNameInput1.SendKeys("BP" + formattedDate);

                // Wait for the next page to load (you may need to adjust the timing)
                Thread.Sleep(500);

                IWebElement saveButton1 = driver.FindElement(By.Id("addSubcomBtn"));
                if (saveButton1.Enabled)
                {
                    saveButton1.Click();
                    userAdded1 = true;
                    Thread.Sleep(500);

                }
                else
                {
                    committeeNameInput1.Clear();
                    deviceDisplayNameInput1.Clear();
                    counter1++;
                    Thread.Sleep(500);

                }

            }

            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            string targetCommitteeName1 = "BPCommittee" + formattedDate + "_" + counter;
            string targetSubcommitteeName1 = "BPSubCommittee" + formattedDate + "_" + counter1;

            Thread.Sleep(500);

            WebDriverWait wait7 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Find the Committee with name BPCommittee12092023_10
            IWebElement committee = wait7.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(., '"+targetCommitteeName1+"')]")));
            committee.Click();

            // Find the Subcommittee with name BPSubCommittee12092023_0
            IWebElement subcommittee = wait7.Until(ExpectedConditions.ElementExists(By.XPath("//td[contains(., '"+targetSubcommitteeName1+ "')]")));

            // Find the parent <tr> element of the subcommittee
            IWebElement subcommitteeRow = subcommittee.FindElement(By.XPath("./ancestor::tr"));

            // Find the "Assign Roles" button within the subcommittee row
            IWebElement assignRolesButton = subcommitteeRow.FindElement(By.CssSelector(".add-role-icon-btn"));

            Thread.Sleep(500);

            assignRolesButton.Click();

            // Wait for the URL to match the expected pattern
            wait7.Until(driver => driver.Url.StartsWith("https://azuredevops.boardpaconline.com/WebClient/privilegemgt/privilegemgt"));

            Thread.Sleep(2000);

            // Replace with your element ID or appropriate selector
            var dropdownElement = driver.FindElement(By.Id("selectedRole"));

            // Click the dropdown to open options
            dropdownElement.Click();

            Thread.Sleep(500);

            // Find and select the desired option by text
            var optionToSelect = "Board Secretary"; // Replace with the text of the option you want to select
            var dropdownOptions = driver.FindElements(By.CssSelector(".ui-dropdown-item"));

            foreach (var option in dropdownOptions)
            {
                if (option.Text.Trim() == optionToSelect)
                {
                    option.Click();
                }
            }

            // Replace with your element ID or appropriate selector
            var dropdownElement1 = driver.FindElement(By.Id("selectedUsers"));

            // Click the dropdown to open options
            dropdownElement1.Click();

            Thread.Sleep(1000);

            // Replace with appropriate selectors
            var searchInput1 = driver.FindElement(By.CssSelector(".ui-multiselect-filter-container input[type='text']"));
            var dropdownItems1 = driver.FindElements(By.CssSelector(".ui-multiselect-item"));

            // Enter text into the search input
            searchInput1.SendKeys("Avishka");

            string FnameLname = "Avishka BoardPACNew";

            Thread.Sleep(1000);

            // Wait for the options to filter based on search
            WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait8.Until(ExpectedConditions.ElementExists(By.CssSelector(".ui-multiselect-item[aria-label='"+FnameLname+"']")));

            // Find and select "Avishka BoardPAC" based on its label attribute
            var avishkaBoardPac = driver.FindElement(By.CssSelector(".ui-multiselect-item[aria-label='"+FnameLname+"']"));
            avishkaBoardPac.Click();

            Thread.Sleep(500);

            // Set up a WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait9 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            // Wait for the "Add" button to be clickable
            IWebElement adduserButton = wait9.Until(ExpectedConditions.ElementToBeClickable(By.Id("addPriviledge")));

            // Click the "Add" button
            adduserButton.Click();

            IWebElement toastMessageElement2 = null;
            // Create a WebDriverWait instance
            WebDriverWait wait12 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the div element containing the toast message
            toastMessageElement2 = wait12.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));

            // Get the text within the div element
            string toastMessage1 = toastMessageElement2.Text;

            // Use the captured message as needed
            Console.WriteLine("Toast Message1: " + toastMessage1);

            Thread.Sleep(2000);

            // Set up a WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait10 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Wait for the "Save" button to be clickable
            IWebElement saveButton2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.btn.btn-primary-submit[type='button']")));

            // Click the "Save" button
            saveButton2.Click();
            Thread.Sleep(500);

            IWebElement toastMessageElement1 = null;
            // Create a WebDriverWait instance
            WebDriverWait wait11 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the div element containing the toast message
            toastMessageElement1 = wait11.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));

            // Get the text within the div element
            string toastMessage = toastMessageElement1.Text;


            // Use the captured message as needed
            Console.WriteLine("Toast Message2: " + toastMessage);

            Thread.Sleep(1000);

            // Close the browser
            driver.Quit();


        }



        static void InsertSalutation(IWebDriver driver, string salutation)
        {

            // Find the dropdown element with waiting
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement dropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("p-dropdown[formcontrolname='salutation']")));

            // Click on the dropdown to open the options
            dropdown.Click();

            // Find the "Mr" option and click on it with waiting
            IWebElement mrOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//p-dropdownitem[.//span[text()='Mr']]")));
            mrOption.Click();

            // Find the text box and get the selected value with waiting
            IWebElement textBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("p-dropdown[formcontrolname='salutation'] input")));
            string selectedValue = textBox.GetAttribute("value");

        }

        static void InsertUsername(IWebDriver driver, string username)
        {
            IWebElement usernameInput = driver.FindElement(By.Id("userName"));
            usernameInput.SendKeys(username);
        }

        static void InsertFirstName(IWebDriver driver, string firstName)
        {
            IWebElement firstNameInput = driver.FindElement(By.Id("firstName"));
            firstNameInput.SendKeys(firstName);
        }

        static void InsertLastName(IWebDriver driver, string lastName)
        {
            IWebElement lastNameInput = driver.FindElement(By.Id("lastName"));
            lastNameInput.SendKeys(lastName);
        }

        static void InsertPrimaryEmail(IWebDriver driver, string primaryEmail)
        {
            IWebElement primaryEmailInput = driver.FindElement(By.Id("boardEmail"));
            primaryEmailInput.SendKeys(primaryEmail);
        }

        static void InsertDeviceDisplayName(IWebDriver driver, string deviceDisplayName)
        {            
            IWebElement deviceDisplayNameInput = driver.FindElement(By.Id("displayName"));

            // Clear the existing value
            deviceDisplayNameInput.Clear();

            // Send the new value
            deviceDisplayNameInput.SendKeys(deviceDisplayName);
        }

        static void InsertUserType(IWebDriver driver, string userType)
        {
            IWebElement userTypeDropdown = driver.FindElement(By.Id("userType"));
            var selectElement = new SelectElement(userTypeDropdown);
            selectElement.SelectByText(userType);
        }

        static string GetCurrentFormattedDate()
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Format the date as MMddyyyy (12082024 format)
            string formattedDate = currentDate.ToString("MMddyyyy");

            Console.WriteLine("Formatted Date: " + formattedDate);

            return formattedDate;
        }

        //static void InsertMobileNumber(IWebDriver driver, string mobileNumber)
        //{
        //    IWebElement mobileNumberInput = driver.FindElement(By.Id("mobileNumber"));
        //    mobileNumberInput.SendKeys(mobileNumber);
        //}

        //static void InsertOfficeNumber(IWebDriver driver, string officeNumber)
        //{
        //    IWebElement officeNumberInput = driver.FindElement(By.Id("officeNumber"));
        //    officeNumberInput.SendKeys(officeNumber);
        //}

    }
}
