using Microsoft.Extensions.Configuration;
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
using System.Collections.ObjectModel;
using OpenQA.Selenium.Internal;
using System.Configuration;
using NUnit.Framework;



namespace SeleniumTest
{
    public class TestContext
    {
        public static string OrgUserName { get; set; }
        public static string OrgFname { get; set; }
        public static string OrgLName { get; set; }
        public static string OrgDisplayName { get; set; }
        public static string OrgPassword { get; set; }
        public static string MeetingTitle { get; set; }

        public static string committeeNameInput { get; set; }
        public static string deviceDisplayNameInput { get; set; }
        public static string subcommitteeNameInput { get; set; }
        public static string subdeviceDisplayNameInput1 { get; set; }

        public static string venue { get; set; }
    }


    [TestClass]
    public class BPTest
    {
        private IConfiguration _configuration;
        private string MainURL;
        private string MainURLWithoutTenant;
        private string SysadminPassword;
        private string BoardAdminPassword;
        private string DefaultPassword;
        private string ArtifactDownloadPath;
        private IWebDriver driver;
        private ChromeOptions chromeOptions;
        public  BPTest()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json"); // Load the appsettings.json file

            _configuration = builder.Build();

            MainURL = _configuration["AppSettings:BaseUrl"];
            MainURLWithoutTenant = _configuration["AppSettings:BaseUrlWithoutTenant"];
            SysadminPassword = _configuration["AppSettings:SysadminPassword"];
            BoardAdminPassword = _configuration["AppSettings:BoardAdminPassword"];
            DefaultPassword = _configuration["AppSettings:DefaultPassword"];
            ArtifactDownloadPath = _configuration["AppSettings:ArtifactDownloadPath"];
        }

        

        //static void Main(string[] args)
        //{

        //}

        [SetUp]
        public void Setup()
        {
            // Initialize Chrome Driver
            chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            //chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
        }


        [Test, Order(1)]
        public void A_0_SysadminLogin()
        {
            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = "sysadmin";
            string password = SysadminPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

            // Use the captured message as needed
            Console.WriteLine("sysadmin login successfully");

            // You can add further actions after successful login here
            Thread.Sleep(1000);

            // Close the browser
            //driver.Quit();
        }

        [Test, Order(2)]
        public void A_1_SysadminChecking()
        {

            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = "sysadmin";
            string password = SysadminPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

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
            //driver.Quit();
        }

        [Test, Order(3)]
        public void B_0_BoardadminLogin()
        {

            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = "boardadmin";
            string password = BoardAdminPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

            // Use the captured message as needed
            Console.WriteLine("boardadmin login successfully");

            // You can add further actions after successful login here
            Thread.Sleep(1000);

            // Close the browser
            //driver.Quit();
        }

        [Test, Order(4)]
        public void B_1_BoardadminChecking()
        {

            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = "boardadmin";
            string password = BoardAdminPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

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
            //driver.Quit();
        }

        [Test, Order(5)]
        public void B_2_BoardadminUserCreating()
        {

            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = "boardadmin";
            string password = BoardAdminPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            ////chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200); // Set page load timeout to 30 seconds (example)

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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

            // Define the base username
            string baseUsername = "BP";
            string baseOrgFname = "BP";
            string baseOrgLName = "BoardPAC";
            string baseOrgDisplayName = "BPBoardPAC";

            // Initialize a counter
            int counter = 12;

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
                    Console.WriteLine("User Managment Main Menu is already expanded");
                }
                else
                {
                    // Menu is collapsed, click to expand
                    menu.Click();
                    Console.WriteLine("User Managment Main Menu clicked to expanded");
                    Thread.Sleep(500);
                }

                Thread.Sleep(1500);
                // Find the <a> element for viewing users
                IWebElement viewUserLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/usermgt/viewUsers'][routerlinkactive='active']")));

                if (viewUserLink != null)
                {
                    // Click on the link to view users if it's clickable
                    viewUserLink.Click();
                    Console.WriteLine("User View Menu clicked to expanded");
                    Thread.Sleep(500);
                }
                else
                {
                    // Handle the situation where the link is not clickable
                    Console.WriteLine("View User link is not clickable.");
                    // You can add further actions or error handling here if needed
                }

                Thread.Sleep(1500);
                // Create a WebDriverWait instance
                WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Find the menu element with a waiting strategy
                IWebElement menu1 = wait8.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='#submenu1'][data-toggle='collapse']")));

                // Check if the menu is expanded or collapsed
                string ariaExpandedAttributeValue1 = menu1.GetAttribute("aria-expanded");

                if (ariaExpandedAttributeValue1.Equals("true"))
                {
                    // Menu is expanded, no action needed
                    Console.WriteLine("User Managment Main Menu is already expanded");
                }
                else
                {
                    // Menu is collapsed, click to expand
                    menu1.Click();
                    Console.WriteLine("User Managment Main Menu clicked to expanded");
                    Thread.Sleep(500);
                }
                Thread.Sleep(1500);

                // Find the <a> element for user creation
                IWebElement createUserLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/usermgt/createUser'][routerlinkactive='active']")));

                if (createUserLink != null)
                {
                    // Click on the user creation link if it's clickable
                    createUserLink.Click();
                    Console.WriteLine("Create User Menu clicked to expanded");
                    Thread.Sleep(500);
                }
                else
                {
                    // Handle the situation where the link is not clickable
                    Console.WriteLine("Create User link is not clickable.");
                    // You can add further actions or error handling here if needed
                }
                Thread.Sleep(1500);
                //Creating a User
                // Wait for the form to load
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
                wait2.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-body")));

                Thread.Sleep(2000);
                try
                {
                    // Create the next username by appending the counter
                    string nextUsername = baseUsername + counter;
                    string nextOrgFname = baseOrgFname + counter;
                    string nextOrgLName = baseOrgLName + counter;
                    string nextOrgDisplayName = baseOrgDisplayName + counter;
                    Thread.Sleep(500);

                    Console.WriteLine("starting to add MR");
                    // Insert values into the form
                    InsertSalutation(driver, "Mr");

                    Thread.Sleep(200);

                    InsertUsername(driver, nextUsername);

                    Thread.Sleep(200);

                    InsertFirstName(driver, nextOrgFname);

                    Thread.Sleep(200);

                    InsertLastName(driver, nextOrgLName);

                    Thread.Sleep(200);

                    InsertPrimaryEmail(driver, "support@boardpac.co");

                    Thread.Sleep(200);

                    InsertDeviceDisplayName(driver, nextOrgDisplayName);

                    Thread.Sleep(200);

                    InsertUserType(driver, "Organizer");

                    Thread.Sleep(200);



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
                            Thread.Sleep(500);

                            if (toastMessage.Contains("User name " + nextUsername + " is already taken."))
                            {
                                // Increment the counter for the next username
                                counter++;
                                Thread.Sleep(500);
                            }
                            else
                            {
                                userAdded = true;

                                TestContext.OrgUserName = nextUsername;
                                TestContext.OrgFname = nextOrgFname;
                                TestContext.OrgLName = nextOrgLName;
                                TestContext.OrgDisplayName = nextOrgDisplayName;

                                Console.WriteLine("UserName: " + TestContext.OrgUserName);
                                Console.WriteLine("OrgFname: " + TestContext.OrgFname);
                                Console.WriteLine("OrgLName: " + TestContext.OrgLName);
                                Console.WriteLine("OrgDisplayName: " + TestContext.OrgDisplayName);


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
                            //driver.Quit();
                        }



                    }


                }
                catch (Exception ex)
                {
                    // Handle other exceptions or rethrow the exception
                    Console.WriteLine("Toast Message: " + ex);
                    throw;
                }
            }

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            // Wait for the next page to load (you may need to adjust the timing)
            wait3.Until(ExpectedConditions.UrlContains(MainURLWithoutTenant + @"/usermgt/viewUsers")); // Replace "expectedPage" with part of the URL of the next page


            // Wait for the next page to load (you may need to adjust the timing)
            Thread.Sleep(1000);

            // Close the browser
            //driver.Quit();

        }

        [Test, Order(6)]
        public void B_3_BoardadminUserUpdate()
        {
            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = "boardadmin";
            string password = BoardAdminPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            ////chromeOptions.AddArgument("--headless");
            ////chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200); // Set page load timeout to 30 seconds (example)

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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

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
            wait4.Until(driver1 => driver.Url.StartsWith(MainURLWithoutTenant + @"/usermgt/updateuser"));
            //string Add = "A";

            Console.WriteLine("TestContextOrgDisplayName: " + TestContext.OrgDisplayName);
            Console.WriteLine("TestContextOrgLName: " + TestContext.OrgLName);

            string OrgDisplayName2 = TestContext.OrgDisplayName + "A";
            string OrgLName2 = TestContext.OrgLName + "A";

            Console.WriteLine("OrgDisplayName: " + OrgDisplayName2);
            Console.WriteLine("OrgLName: " + OrgLName2);

            Thread.Sleep(1000);
            // Perform other actions after the URL matches the pattern...
            InsertDeviceDisplayName(driver, OrgDisplayName2);
            Thread.Sleep(1000);
            InsertLastName(driver, OrgLName2);
            Thread.Sleep(1000);

            TestContext.OrgLName = OrgLName2;
            TestContext.OrgDisplayName = OrgDisplayName2;

            Thread.Sleep(500);
            Console.WriteLine("OrgDisplayNamefinal: " + TestContext.OrgDisplayName);
            Console.WriteLine("OrgLNamefinal: " + TestContext.OrgLName);

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
                        wait6.Until(ExpectedConditions.UrlContains(MainURLWithoutTenant + @"/usermgt/viewUsers")); // Replace "expectedPage" with part of the URL of the next page


                        // Wait for the next page to load (you may need to adjust the timing)
                        Thread.Sleep(1000);

                        // Close the browser
                        //driver.Quit();

                    }
                    else
                    {
                        Console.WriteLine("Toast Message: " + toastMessage);

                        // Wait for the next page to load (you may need to adjust the timing)
                        Thread.Sleep(1000);

                        // Close the browser
                        //driver.Quit();

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
                    //driver.Quit();
                }

            }
        }

        [Test, Order(7)]
        public void B_4_BoardadminCreateCommittee()
        {

            string formattedDate = GetCurrentFormattedDate();

            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = "boardadmin";
            string password = BoardAdminPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            ////chromeOptions.AddArgument("--headless");
            ////chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200); // Set page load timeout to 30 seconds (example)

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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

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
            int counter = 1;

            bool userAdded = false;

            while (!userAdded)
            {
                // Find input fields for Committee Name and Device Display Name
                IWebElement committeeNameInput = driver.FindElement(By.Id("committeeNameId"));
                IWebElement deviceDisplayNameInput = driver.FindElement(By.Id("committeeDeviceDisplayNameId"));

                string committeeName3 = "BPCommittee" + formattedDate + "_" + counter;
                string displaycommitteeName3 = "BP" + formattedDate;

                // Enter text into the fields
                committeeNameInput.SendKeys(committeeName3);
                deviceDisplayNameInput.SendKeys(displaycommitteeName3);

                // Wait for the next page to load (you may need to adjust the timing)
                Thread.Sleep(500);

                IWebElement saveButton = driver.FindElement(By.Id("addComBtn"));
                if (saveButton.Enabled)
                {
                    saveButton.Click();

                    TestContext.committeeNameInput = committeeName3;
                    TestContext.deviceDisplayNameInput = displaycommitteeName3;

                    Console.WriteLine("committeeNameInput: " + TestContext.committeeNameInput);
                    Console.WriteLine("deviceDisplayNameInput: " + TestContext.deviceDisplayNameInput);

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

            string targetCommitteeName = TestContext.committeeNameInput;

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

                string subcommitteeNameInput1 = "BPSubCommittee" + formattedDate + "_" + counter1;
                string subdeviceDisplayNameInput1 = "BP" + formattedDate;

                // Enter text into the fields
                committeeNameInput1.SendKeys(subcommitteeNameInput1);
                deviceDisplayNameInput1.SendKeys(subdeviceDisplayNameInput1);

                // Wait for the next page to load (you may need to adjust the timing)
                Thread.Sleep(500);

                IWebElement saveButton1 = driver.FindElement(By.Id("addSubcomBtn"));
                if (saveButton1.Enabled)
                {
                    saveButton1.Click();
                    userAdded1 = true;
                    TestContext.subcommitteeNameInput = subcommitteeNameInput1;
                    TestContext.subdeviceDisplayNameInput1 = subdeviceDisplayNameInput1;

                    Console.WriteLine("subcommitteeNameInput: " + TestContext.subcommitteeNameInput);
                    Console.WriteLine("subdeviceDisplayNameInput1: " + TestContext.subdeviceDisplayNameInput1);

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

            string targetCommitteeName1 = TestContext.committeeNameInput;
            string targetSubcommitteeName1 = TestContext.subcommitteeNameInput;

            Thread.Sleep(500);

            WebDriverWait wait7 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Find the Committee with name BPCommittee12092023_10
            IWebElement committee = wait7.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(., '" + targetCommitteeName1 + "')]")));
            committee.Click();

            // Find the Subcommittee with name BPSubCommittee12092023_0
            IWebElement subcommittee = wait7.Until(ExpectedConditions.ElementExists(By.XPath("//td[contains(., '" + targetSubcommitteeName1 + "')]")));

            // Find the parent <tr> element of the subcommittee
            IWebElement subcommitteeRow = subcommittee.FindElement(By.XPath("./ancestor::tr"));

            // Find the "Assign Roles" button within the subcommittee row
            IWebElement assignRolesButton = subcommitteeRow.FindElement(By.CssSelector(".add-role-icon-btn"));

            Thread.Sleep(500);

            assignRolesButton.Click();

            // Wait for the URL to match the expected pattern
            wait7.Until(driver1 => driver.Url.StartsWith(MainURLWithoutTenant + @"/privilegemgt/privilegemgt"));

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

            Console.WriteLine("OrgFname: " + TestContext.OrgFname);
            string Fname = TestContext.OrgFname;
            // Enter text into the search input
            searchInput1.SendKeys(Fname);

            string FnameLname = TestContext.OrgFname + " " + TestContext.OrgLName;

            Console.WriteLine("FnameLname: " + FnameLname);

            Thread.Sleep(1000);

            // Wait for the options to filter based on search
            WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait8.Until(ExpectedConditions.ElementExists(By.CssSelector(".ui-multiselect-item[aria-label='" + FnameLname + "']")));

            // Find and select "Avishka BoardPAC" based on its label attribute
            var avishkaBoardPac = driver.FindElement(By.CssSelector(".ui-multiselect-item[aria-label='" + FnameLname + "']"));
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
            //driver.Quit();


        }

        [Test, Order(8)]
        public void C_0_0_OrganizerLoginPasswordReset()
        {
            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = TestContext.OrgUserName;
            string password = DefaultPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/changepassword")); // Replace "expectedPage" with part of the URL of the next page

            // You can add further actions after successful login here
            Thread.Sleep(1500);

            // Wait for the form to load
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-body")));
            Thread.Sleep(2500);
            // Find the current password, new password, and confirm password fields
            IWebElement currentPasswordField = driver.FindElement(By.Id("currentPassword"));
            IWebElement newPasswordField = driver.FindElement(By.Id("newPassword"));
            IWebElement confirmPasswordField = driver.FindElement(By.Id("confirmPassword"));

            // Replace these strings with the passwords you want to use
            string currentPassword = DefaultPassword;
            string newPassword = @"Qwerty$4.0";
            IWebElement toastMessageElement2 = null;



            // Enter passwords into the respective fields
            currentPasswordField.SendKeys(currentPassword);
            Thread.Sleep(500);
            newPasswordField.SendKeys(newPassword);
            Thread.Sleep(500);
            confirmPasswordField.SendKeys(newPassword); // Confirm password by entering it again
            Thread.Sleep(500);

            // Assuming there's a submit button, find and click it
            // Replace 'submitButtonId' with the actual ID of your submit button
            IWebElement submitButton = driver.FindElement(By.Id("changePasswordBtn"));
            submitButton.Click();

            Thread.Sleep(500);


            // Create a WebDriverWait instance
            WebDriverWait wait11 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the div element containing the toast message
            toastMessageElement2 = wait11.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));

            // Get the text within the div element
            string toastMessage = toastMessageElement2.Text;


            // Use the captured message as needed
            Console.WriteLine("Toast Message: " + toastMessage);

            TestContext.OrgPassword = newPassword;
            Thread.Sleep(500);
            Console.WriteLine("OrgPassword: " + TestContext.OrgPassword);
            Thread.Sleep(1000);
        }

        [Test, Order(9)]
        public void C_0_OrganizerLogin()
        {
            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = TestContext.OrgUserName;
            string password = TestContext.OrgPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

            // Use the captured message as needed
            Console.WriteLine("Oraginzer login successfully");

            // You can add further actions after successful login here
            Thread.Sleep(1000);

            // Close the browser
            //driver.Quit();
        }

        [Test, Order(10)]
        public void C_1_OrganizerVenueCreate()
        {
            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = TestContext.OrgUserName;
            string password = TestContext.OrgPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

            Thread.Sleep(500);

            // Find the <a> element for viewing users
            IWebElement viewUserLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/venue/venues'][routerlinkactive='active']")));

            if (viewUserLink != null)
            {
                // Click on the link to view users if it's clickable
                viewUserLink.Click();
                Console.WriteLine("Venue Menu clicked to expanded");
                Thread.Sleep(500);
            }
            else
            {
                // Handle the situation where the link is not clickable
                Console.WriteLine("Venue Menu link is not clickable.");
                // You can add further actions or error handling here if needed
            }


            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            // Wait for the next page to load (you may need to adjust the timing)
            wait2.Until(ExpectedConditions.UrlContains(MainURLWithoutTenant + @"/venue/venues")); // Replace "expectedPage" with part of the URL of the next page

            Thread.Sleep(500);

            chromeOptions.AddArgument("--enable-precise-geolocation");
            driver.Navigate().Refresh();

            // Execute JavaScript to simulate granting permission for geolocation
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("navigator.geolocation.getCurrentPosition = function(success) { var position = { coords: {latitude: 12.976230, longitude: 77.603290}}; success(position); }");



            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            // Wait for the next page to load (you may need to adjust the timing)
            wait3.Until(ExpectedConditions.UrlContains(MainURLWithoutTenant + @"/venue/venues")); // Replace "expectedPage" with part of the URL of the next page


            // Wait for the button to be clickable
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement createVenueButton = wait4.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(., 'Create Venue')]")));

            createVenueButton.Click();

            // Initialize a counter
            int counter = 20;

            bool userAdded = false;

            while (!userAdded)
            {
                Thread.Sleep(1500);

                WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                // Find the venue name input field by ID
                IWebElement venueNameInput = wait5.Until(ExpectedConditions.ElementIsVisible(By.Id("venueName")));

                venueNameInput.Clear();

                Thread.Sleep(500);

                string venue = "BoardPACADOVenue_" + counter;

                // Type the venue name into the input field
                venueNameInput.SendKeys(venue);

                Thread.Sleep(500);

                // Find the search input field
                IWebElement searchInput = wait5.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[placeholder='Search']")));

                // Type 'BoardPAC' into the search input field
                searchInput.SendKeys("BoardPAC");

                Thread.Sleep(500);

                // Wait for the dropdown to appear
                IWebElement dropdown = wait5.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("ul.ui-autocomplete-list")));

                // Find and select the specific option
                IWebElement option = dropdown.FindElement(By.XPath("//span[text()='BoardPAC Global Innovation Center, Nawam Mawatha, Colombo, Sri Lanka']"));
                option.Click();

                Thread.Sleep(500);

                // Find the meeting room input field
                IWebElement meetingRoomInput = wait5.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input#venueMeetingRoomInput")));

                // Type 'BoardRoom' into the meeting room input field
                meetingRoomInput.SendKeys("BoardRoom");

                // Simulate pressing the Enter key
                Actions action = new Actions(driver);
                action.SendKeys(Keys.Enter).Perform();

                Thread.Sleep(1000);

                WebDriverWait wait6 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Find the Save button element
                IWebElement saveButton = wait6.Until(ExpectedConditions.ElementToBeClickable(By.Id("venueSave")));

                // Check if the Save button is enabled
                if (saveButton.Enabled)
                {
                    // Click on the Save button
                    saveButton.Click();
                    Console.WriteLine("Save button clicked!");

                    IWebElement toastMessageElement1 = null;
                    // Create a WebDriverWait instance
                    WebDriverWait wait7 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                    // Find the div element containing the toast message
                    toastMessageElement1 = wait7.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));

                    // Get the text within the div element
                    string toastMessage = toastMessageElement1.Text;

                    // Use the captured message as needed
                    Console.WriteLine("Toast Message2: " + toastMessage);

                    if (toastMessage.Contains("'Venue name' field must be unique"))
                    {
                        // Increment the counter for the next username
                        counter++;
                        Thread.Sleep(500);
                    }
                    else
                    {
                        userAdded = true;
                        TestContext.venue = venue;

                        Thread.Sleep(500);

                    }


                }
                else
                {
                    Console.WriteLine("Save button is disabled.");
                }

            }

            WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            // Wait for the next page to load (you may need to adjust the timing)
            wait8.Until(ExpectedConditions.UrlContains(MainURLWithoutTenant + @"/venue/venues")); // Replace "expectedPage" with part of the URL of the next page
                                                                                                  // Wait for the next page to load (you may need to adjust the timing)
            Thread.Sleep(1000);

            // Close the browser
            //driver.Quit();

        }

        [Test, Order(11)]
        public void C_2_OrganizerMeetingCreate()
        {
            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = TestContext.OrgUserName;
            string password = TestContext.OrgPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

            Thread.Sleep(500);

            // Create a WebDriverWait instance
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the menu element with a waiting strategy
            IWebElement menu = wait1.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='#submenu3'][data-toggle='collapse']")));

            // Check if the menu is expanded or collapsed
            string ariaExpandedAttributeValue = menu.GetAttribute("aria-expanded");

            if (ariaExpandedAttributeValue.Equals("true"))
            {
                // Menu is expanded, no action needed
                Console.WriteLine("Meeting Managment Main Menu is already expanded");
            }
            else
            {
                // Menu is collapsed, click to expand
                menu.Click();
                Console.WriteLine("Meeting Managment Main Menu clicked to expanded");
                Thread.Sleep(500);
            }

            // Find the <a> element for viewing users
            IWebElement viewUserLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/meeting/createmeeting'][routerlinkactive='active']")));

            if (viewUserLink != null)
            {
                // Click on the link to view users if it's clickable
                viewUserLink.Click();
                Console.WriteLine("Venue clicked to expanded");
                Thread.Sleep(500);
            }
            else
            {
                // Handle the situation where the link is not clickable
                Console.WriteLine("Venue link is not clickable.");
                // You can add further actions or error handling here if needed
            }


            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            // Wait for the next page to load (you may need to adjust the timing)
            wait2.Until(ExpectedConditions.UrlContains(MainURLWithoutTenant + @"/meeting/createmeeting")); // Replace "expectedPage" with part of the URL of the next page

            Thread.Sleep(1500);

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            FillTitle(driver, wait3, "BPM");

            Thread.Sleep(500);

            SelectCommittee(driver, wait3, TestContext.committeeNameInput);

            Thread.Sleep(500);

            SelectSubCommittee(driver, wait3, TestContext.subcommitteeNameInput);

            Thread.Sleep(500);

            string FullName = TestContext.OrgFname + " " + TestContext.OrgLName;

            FillOrganizer(driver, wait3, FullName);

            Thread.Sleep(500);

            FillDescription(driver, wait3, "Your Description");

            Thread.Sleep(500);

            FillTimeZone(driver, "(UTC+05:30) Sri Jayawardenepura");

            Thread.Sleep(500);

            FillMeetingDate(driver, "26", "Feb", "2024");

            Thread.Sleep(500);

            FillStartTime(driver, "11", "30", "AM"); // Change values accordingly

            Thread.Sleep(500);

            FillEndTime(driver, "02", "00", "PM"); // Change values accordingly

            Thread.Sleep(500);

            FillSearchLocation(driver, TestContext.venue);

            Thread.Sleep(500);

            FillMeetingRoom(driver, "BoardRoom");

            Thread.Sleep(500);

            FillVideoConferencingOption(driver, "None");

            Thread.Sleep(1500);

            IWebElement saveButton = driver.FindElement(By.Id("addMeetingBtn"));
            if (saveButton.Enabled)
            {
                saveButton.Click();
                Thread.Sleep(500);
                IWebElement toastMessageElement1 = null;
                // Create a WebDriverWait instance
                WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Find the div element containing the toast message
                toastMessageElement1 = wait4.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));

                // Get the text within the div element
                string toastMessage = toastMessageElement1.Text;

                // Use the captured message as needed
                Console.WriteLine("Toast Message2: " + toastMessage);

            }



            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            // Wait for the next page to load (you may need to adjust the timing)
            wait5.Until(ExpectedConditions.UrlContains(MainURLWithoutTenant + @"/meeting/meetings")); // Replace "expectedPage" with part of the URL of the next page
                                                                                                      // Wait for the next page to load (you may need to adjust the timing)
            Thread.Sleep(1000);

            // Close the browser
            //driver.Quit();

        }

        [Test, Order(12)]
        public void C_3_OrganizerMeetingschedule()
        {
            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = TestContext.OrgUserName;
            string password = TestContext.OrgPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            //// Open the login page
            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

            Thread.Sleep(500);

            // Create a WebDriverWait instance
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the menu element with a waiting strategy
            IWebElement menu = wait1.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='#submenu3'][data-toggle='collapse']")));

            // Check if the menu is expanded or collapsed
            string ariaExpandedAttributeValue = menu.GetAttribute("aria-expanded");

            if (ariaExpandedAttributeValue.Equals("true"))
            {
                // Menu is expanded, no action needed
                Console.WriteLine("Meeting Managment Main Menu is already expanded");
            }
            else
            {
                // Menu is collapsed, click to expand
                menu.Click();
                Console.WriteLine("Meeting Managment Main Menu clicked to expanded");
                Thread.Sleep(500);
            }

            // Find the <a> element for viewing users
            IWebElement viewUserLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/meeting/meetings'][routerlinkactive='active']")));

            if (viewUserLink != null)
            {
                // Click on the link to view users if it's clickable
                viewUserLink.Click();
                Console.WriteLine("Meeting clicked to expanded");
                Thread.Sleep(500);
            }
            else
            {
                // Handle the situation where the link is not clickable
                Console.WriteLine("Meeting link is not clickable.");
                // You can add further actions or error handling here if needed
            }


            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            // Wait for the next page to load (you may need to adjust the timing)
            wait2.Until(ExpectedConditions.UrlContains(MainURLWithoutTenant + @"/meeting/meetings")); // Replace "expectedPage" with part of the URL of the next page

            // Wait for the form to load
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait3.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-body")));

            Thread.Sleep(500);

            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the input field by its class name
            IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.form-control.search-input")));

            // Type the meeting name into the input field
            string meetingName = TestContext.MeetingTitle; // Replace this with the actual meeting name
            searchInput.SendKeys(meetingName);
            Console.WriteLine("searched meeting title is:" + meetingName);
            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Wait for the table rows to be present
            ReadOnlyCollection<IWebElement> tableRows = wait5.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("tbody.ui-table-tbody > tr")));

            // Select the first row (index 0)
            IWebElement firstRow = tableRows[0];

            // Find the button within the row by its class name
            IWebElement button = firstRow.FindElement(By.CssSelector("button.table-icon-btn.alt-img"));

            // Click the button
            button.Click();

            Thread.Sleep(500);

            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait6 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Wait for the popup to be present
            IWebElement popup = wait6.Until(ExpectedConditions.ElementExists(By.ClassName("ui-dialog-content")));

            // Find the dropdown menu within the popup
            IWebElement dropdown = popup.FindElement(By.CssSelector("p-dropdown"));

            // Click the dropdown to open the options
            dropdown.Click();

            // Wait for the dropdown options to be visible
            IWebElement dropdownOptions = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.ui-dropdown-items-wrapper")));

            // Select the option "Scheduled" (you can change this based on your requirement)
            IWebElement optionScheduled = dropdownOptions.FindElement(By.XPath("//span[text()='Scheduled']"));
            optionScheduled.Click();

            Thread.Sleep(500);

            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait7 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Wait for the "Save" button to be clickable
            IWebElement saveButton = wait7.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ui-dialog-footer button.btn.btn-primary-submit")));

            // Click the "Save" button
            saveButton.Click();

            IWebElement toastMessageElement1 = null;
            // Create a WebDriverWait instance
            WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the div element containing the toast message
            toastMessageElement1 = wait8.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));

            // Get the text within the div element
            string toastMessage = toastMessageElement1.Text;

            // Use the captured message as needed
            Console.WriteLine("Toast Message2: " + toastMessage);

            // Wait for the next page to load (you may need to adjust the timing)
            Thread.Sleep(1000);

            // Close the browser
            //driver.Quit();


        }

        [Test, Order(13)]
        public void C_4_OrganizerAgendaUpload()
        {
            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = TestContext.OrgUserName;
            string password = TestContext.OrgPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1200);
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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

            Thread.Sleep(500);

            // Create a WebDriverWait instance
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the menu element with a waiting strategy
            IWebElement menu = wait1.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='#submenu3'][data-toggle='collapse']")));

            // Check if the menu is expanded or collapsed
            string ariaExpandedAttributeValue = menu.GetAttribute("aria-expanded");

            if (ariaExpandedAttributeValue.Equals("true"))
            {
                // Menu is expanded, no action needed
                Console.WriteLine("Meeting Managment Main Menu is already expanded");
            }
            else
            {
                // Menu is collapsed, click to expand
                menu.Click();
                Console.WriteLine("Meeting Managment Main Menu clicked to expanded");
                Thread.Sleep(500);
            }

            // Find the <a> element for viewing users
            IWebElement viewUserLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/meeting/meetings'][routerlinkactive='active']")));

            if (viewUserLink != null)
            {
                // Click on the link to view users if it's clickable
                viewUserLink.Click();
                Console.WriteLine("Meeting clicked to expanded");
                Thread.Sleep(500);
            }
            else
            {
                // Handle the situation where the link is not clickable
                Console.WriteLine("Meeting link is not clickable.");
                // You can add further actions or error handling here if needed
            }


            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            // Wait for the next page to load (you may need to adjust the timing)
            wait2.Until(ExpectedConditions.UrlContains(MainURLWithoutTenant + @"/meeting/meetings")); // Replace "expectedPage" with part of the URL of the next page

            // Wait for the form to load
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait3.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-body")));

            Thread.Sleep(500);

            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the input field by its class name
            IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.form-control.search-input")));

            // Type the meeting name into the input field
            string meetingName = TestContext.MeetingTitle; // Replace this with the actual meeting name
            searchInput.SendKeys(meetingName);
            Console.WriteLine("searched meeting title is:" + meetingName);
            Thread.Sleep(1000);

            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Wait for the table rows to be present
            ReadOnlyCollection<IWebElement> tableRows = wait5.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("tbody.ui-table-tbody > tr")));

            // Select the first row (index 0)
            IWebElement firstRow = tableRows[0];

            // Find the button within the row by its class name
            IWebElement button = firstRow.FindElement(By.CssSelector("button.table-icon-btn.ng-star-inserted > i.pi.pi-list"));

            // Click the button
            button.Click();

            Thread.Sleep(500);

            // Wait for the URL to match the expected pattern
            wait4.Until(driver1 => driver.Url.StartsWith(MainURLWithoutTenant + @"/meeting/agenda"));

            Thread.Sleep(500);

            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait6 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the upload button by its class and tag
            IWebElement uploadButton = wait6.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a.btn.btn-upload")));

            // Click the upload button
            uploadButton.Click();

            string artifactlocation = ArtifactDownloadPath;
            string solutionDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../");
            string folderPathRelativeToSolution = artifactlocation;
            Console.WriteLine("Artifact Path: " + folderPathRelativeToSolution);
            string folderAbsolutePath = Path.Combine(solutionDirectory, folderPathRelativeToSolution);
            Console.WriteLine("Aftifact full path: " + folderAbsolutePath);

            // Specify the source folder path (inside the solution directory)
            string sourceFolderPath = Path.Combine(folderAbsolutePath, "Agenda");
            Console.WriteLine("Aftifact full path for source: " + sourceFolderPath);
            string path = "TestDoc" + GetCurrentFormattedDate();
            // Specify the destination folder path in the C drive
            string destinationFolderPath = @"C:\" + path + @"\Agenda";
            Console.WriteLine("destinationFolderPath: " + destinationFolderPath);
            // Copy the folder and its contents recursively to the destination
            CopyFolder(sourceFolderPath, destinationFolderPath);
            Console.WriteLine("copy files to destination server");
            WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            Thread.Sleep(2000);

            // Wait for the file input element to be available
            IWebElement fileInput = wait8.Until(ExpectedConditions.ElementExists(By.CssSelector("input[name='UploadFiles'][directory='true']")));

            Thread.Sleep(2000);
            // Send the folder path to the file input element
            fileInput.SendKeys(destinationFolderPath);
            Console.WriteLine("start uploading files");
            Thread.Sleep(2000);
            IWebElement toastMessageElement2 = null;
            //// Find the checkbox element by its ID
            IWebElement publishAllCheckbox = driver.FindElement(By.Id("inlineCheckbox1"));
            
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", publishAllCheckbox);
            Console.WriteLine("clicked on publish button");

            Thread.Sleep(500);
            // Find the upload button by its ID
            IWebElement uploadButton2 = driver.FindElement(By.Id("btnSubmit"));

            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("arguments[0].click();", uploadButton2);
            Console.WriteLine("clicked on submit button");
            Thread.Sleep(1000);
            // Click the upload button
            Console.WriteLine("waiting for toaste message");

            // Create a WebDriverWait instance
            WebDriverWait wait11 = new WebDriverWait(driver, TimeSpan.FromSeconds(180));

            // Find the div element containing the toast message
            toastMessageElement2 = wait11.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));
            Console.WriteLine("found the toaste message");
            // Get the text within the div element
            string toastMessage = toastMessageElement2.Text;


            // Use the captured message as needed
            Console.WriteLine("Toast Message: " + toastMessage);

            Thread.Sleep(1000);

            // Close the browser
            // driver.Quit();



        }

        [Test, Order(14)]
        public void C_5_OrganizerDocumentPackDownload()
        {
            // URL of the login page
            string loginUrl = MainURL + @"/login";

            // Credentials for login
            string username = TestContext.OrgUserName;
            string password = TestContext.OrgPassword;

            //// Initialize Chrome Driver
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            //// Open the login page
            driver.Navigate().GoToUrl(loginUrl);

            // Wait for the username field to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1200));
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
            wait.Until(ExpectedConditions.UrlContains(MainURL + @"/home")); // Replace "expectedPage" with part of the URL of the next page

            Thread.Sleep(500);

            // Create a WebDriverWait instance
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the menu element with a waiting strategy
            IWebElement menu = wait1.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='#submenu3'][data-toggle='collapse']")));

            // Check if the menu is expanded or collapsed
            string ariaExpandedAttributeValue = menu.GetAttribute("aria-expanded");

            if (ariaExpandedAttributeValue.Equals("true"))
            {
                // Menu is expanded, no action needed
                Console.WriteLine("Meeting Managment Main Menu is already expanded");
            }
            else
            {
                // Menu is collapsed, click to expand
                menu.Click();
                Console.WriteLine("Meeting Managment Main Menu clicked to expanded");
                Thread.Sleep(500);
            }

            // Find the <a> element for viewing users
            IWebElement viewUserLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/meeting/meetings'][routerlinkactive='active']")));

            if (viewUserLink != null)
            {
                // Click on the link to view users if it's clickable
                viewUserLink.Click();
                Console.WriteLine("Meeting clicked to expanded");
                Thread.Sleep(500);
            }
            else
            {
                // Handle the situation where the link is not clickable
                Console.WriteLine("Meeting link is not clickable.");
                // You can add further actions or error handling here if needed
            }


            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            // Wait for the next page to load (you may need to adjust the timing)
            wait2.Until(ExpectedConditions.UrlContains(MainURLWithoutTenant + @"/meeting/meetings")); // Replace "expectedPage" with part of the URL of the next page

            // Wait for the form to load
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait3.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-body")));

            Thread.Sleep(500);

            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the input field by its class name
            IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.form-control.search-input")));
            //TestContext.MeetingTitle
            // Type the meeting name into the input field
            string meetingName = TestContext.MeetingTitle; // Replace this with the actual meeting name
            searchInput.SendKeys(meetingName);
            Console.WriteLine("searched meeting title is:" + meetingName);

            Thread.Sleep(500);
            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Wait for the table rows to be present
            ReadOnlyCollection<IWebElement> tableRows = wait5.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("tbody.ui-table-tbody > tr")));

            // Select the first row (index 0)
            IWebElement firstRow = tableRows[0];

            // Find the button within the row by its class name
            IWebElement button = firstRow.FindElement(By.CssSelector("button.table-icon-btn.ng-star-inserted > i.pi.pi-list"));

            // Click the button
            button.Click();

            Thread.Sleep(500);

            // Wait for the URL to match the expected pattern
            wait4.Until(driver1 => driver.Url.StartsWith(MainURLWithoutTenant + @"/meeting/agenda"));

            Thread.Sleep(500);

            // Find the checkbox by CSS selector
            IWebElement checkbox = driver.FindElement(By.CssSelector("div.e-checkbox-wrapper.e-css"));

            // Click the checkbox
            checkbox.Click();

            Thread.Sleep(500);

            // Find the button element with the nested <i> tag
            IWebElement buttonWithIcon = driver.FindElement(By.CssSelector("button.btn.btn-default.ng-star-inserted > i.pi.pi-copy"));

            // Perform an action on the button or the icon
            // For instance, to click the button
            buttonWithIcon.Click();
            Console.WriteLine("document pack download button clicked");
            Thread.Sleep(2500);

            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait6 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            // Define the expected condition for the dialog box to be present
            By dialogBoxLocator = By.ClassName("ui-dialog-mask");

            // Wait for the dialog box to be present on the page
            wait6.Until(ExpectedConditions.ElementIsVisible(dialogBoxLocator));

            Thread.Sleep(3000);
            // Find the download button by its ID
            IWebElement downloadButton = driver.FindElement(By.Id("submitBtn"));

            // Perform an action on the button, like clicking it
            downloadButton.Click();
            Console.WriteLine("download button clicked");

            Thread.Sleep(2000);

            // Close the browser
            //driver.Quit();

        }

        static void InsertSalutation(IWebDriver driver, string salutation)
        {

            Console.WriteLine("Find the dropdown element with waiting");
            // Find the dropdown element with waiting
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement dropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("p-dropdown[formcontrolname='salutation']")));

            Console.WriteLine("Click on the dropdown to open the options");
            // Click on the dropdown to open the options
            try
            {
                dropdown.Click();
            }
            catch (ElementClickInterceptedException)
            {
                // Handle the click interception, for example, scrolling to the element
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", dropdown);
                // Attempt the click again
                dropdown.Click();
            }

            Thread.Sleep(500); // Consider using explicit waits instead of Thread.Sleep

            Console.WriteLine("Find the 'Mr' option and click on it with waiting");
            // Find the "Mr" option and click on it with waiting
            IWebElement mrOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//p-dropdownitem[.//span[text()='Mr']]")));
            mrOption.Click();

            Thread.Sleep(500); // Consider using explicit waits instead of Thread.Sleep

            Console.WriteLine("Find the text box and get the selected value with waiting");
            // Find the text box and get the selected value with waiting
            IWebElement textBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("p-dropdown[formcontrolname='salutation'] input")));
            string selectedValue = textBox.GetAttribute("value");

            Console.WriteLine("Add the salutation");
            // Perform further actions as needed after selecting the salutation


        }

        static void InsertUsername(IWebDriver driver, string username)
        {
            IWebElement usernameInput = driver.FindElement(By.Id("userName"));
            usernameInput.SendKeys(username);
            Console.WriteLine("add the username");
        }

        static void InsertFirstName(IWebDriver driver, string firstName)
        {
            IWebElement firstNameInput = driver.FindElement(By.Id("firstName"));
            firstNameInput.Clear();
            firstNameInput.SendKeys(firstName);
            Console.WriteLine("add the firstName");
        }

        static void InsertLastName(IWebDriver driver, string lastName)
        {
            IWebElement lastNameInput = driver.FindElement(By.Id("lastName"));
            lastNameInput.Clear();
            lastNameInput.SendKeys(lastName);
            Console.WriteLine("add the lastName");
        }

        static void InsertPrimaryEmail(IWebDriver driver, string primaryEmail)
        {
            IWebElement primaryEmailInput = driver.FindElement(By.Id("boardEmail"));
            primaryEmailInput.SendKeys(primaryEmail);
            Console.WriteLine("add the primaryEmail");
        }

        static void InsertDeviceDisplayName(IWebDriver driver, string deviceDisplayName)
        {
            IWebElement deviceDisplayNameInput = driver.FindElement(By.Id("displayName"));

            // Clear the existing value
            deviceDisplayNameInput.Clear();

            // Send the new value
            deviceDisplayNameInput.SendKeys(deviceDisplayName);

            Console.WriteLine("add the deviceDisplayName");
        }

        static void InsertUserType(IWebDriver driver, string userType)
        {
            IWebElement userTypeDropdown = driver.FindElement(By.Id("userType"));
            var selectElement = new SelectElement(userTypeDropdown);
            selectElement.SelectByText(userType);
            Console.WriteLine("add the userType");
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

        static void FillTitle(IWebDriver driver, WebDriverWait wait, string title)
        {
            string titlenew = title + GetCurrentFormattedDate();
            IWebElement titleInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input#title")));
            TestContext.MeetingTitle = titlenew;
            Console.WriteLine("searched meeting title is set to variable:" + TestContext.MeetingTitle);
            titleInput.SendKeys(titlenew);
        }

        static void SelectCommittee(IWebDriver driver, WebDriverWait wait, string committeeName)
        {
            IWebElement committeeDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("select#committee")));
            SelectElement committeeSelect = new SelectElement(committeeDropdown);
            committeeSelect.SelectByText(committeeName);
        }

        static void SelectSubCommittee(IWebDriver driver, WebDriverWait wait, string subCommitteeName)
        {
            IWebElement subCommitteeDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("select#subCommittee")));
            SelectElement subCommitteeSelect = new SelectElement(subCommitteeDropdown);
            subCommitteeSelect.SelectByText(subCommitteeName);
        }

        static void FillOrganizer(IWebDriver driver, WebDriverWait wait, string organizerName)
        {
            IWebElement organizerDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("p-dropdown#organizer")));
            organizerDropdown.Click();
            IWebElement organizerOption = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), '" + organizerName + "')]")));
            organizerOption.Click();
        }

        static void FillDescription(IWebDriver driver, WebDriverWait wait, string description)
        {
            IWebElement descriptionTextarea = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("textarea#exampleFormControlTextarea1")));
            descriptionTextarea.SendKeys(description);
        }

        static void FillTimeZone(IWebDriver driver, string timezone)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60)); // Increased wait time

            try
            {
                // Click on the timezone dropdown
                IWebElement timezoneDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("p-dropdown[formcontrolname='timeZone']")));
                timezoneDropdown.Click();

                // Wait for the options to load
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("ul.ui-dropdown-items li span")));

                // Find all the options
                IList<IWebElement> options = driver.FindElements(By.CssSelector("ul.ui-dropdown-items li span"));

                // Locate the specific timezone option and click it
                foreach (IWebElement option in options)
                {
                    if (option.Text.Trim().Equals(timezone))
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", option); // Scroll into view if needed
                        option.Click();
                        break;
                    }
                }
            }
            catch (WebDriverTimeoutException ex)
            {
                // Print the page source or relevant information for debugging
                Console.WriteLine(driver.PageSource);
                Console.WriteLine("Exception: " + ex.Message);
                // You might add additional handling or logging here
                throw; // Re-throw the exception to indicate test failure
            }
        }

        static void FillMeetingDate(IWebDriver driver, string desiredDate, string desiredMonth, string desiredYear)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Find the datepicker element by its ID
            IWebElement datepicker = driver.FindElement(By.Id("ej2-datepicker_0_input"));
            //Thread.Sleep(1000);
            // Click on the datepicker to open the calendar
            datepicker.Click();
            Thread.Sleep(500);
            // Execute JavaScript to set the desired date directly in the datepicker
            js.ExecuteScript($"document.querySelector('#ej2-datepicker_0_input').value = '{desiredDate}/{desiredMonth.Substring(0, 3)}/{desiredYear.Substring(2)}';");
            Thread.Sleep(500);

        }

        static void FillStartTime(IWebDriver driver, string hours, string minutes, string meridian)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Wait for the timepicker element to be clickable
            IWebElement timepicker = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("startTime")));

            // Find the hour input field and set the hours
            IWebElement hourInput = timepicker.FindElement(By.CssSelector(".ngb-tp-hour input"));
            hourInput.Clear();
            hourInput.SendKeys(hours);

            // Find the minute input field and set the minutes
            IWebElement minuteInput = timepicker.FindElement(By.CssSelector(".ngb-tp-minute input"));
            minuteInput.Clear();
            minuteInput.SendKeys(minutes);

            // Find the meridian (AM/PM) button
            IWebElement meridianBtn = timepicker.FindElement(By.CssSelector(".ngb-tp-meridian button"));

            // Continuously click the meridian button until the desired meridian is selected
            while (meridianBtn.Text.Trim() != meridian)
            {
                meridianBtn.Click();
                // Add a short delay to allow the timepicker to update before checking again
                System.Threading.Thread.Sleep(500); // Adjust delay time if needed
            }
        }

        static void FillEndTime(IWebDriver driver, string hours, string minutes, string meridian)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Wait for the timepicker element to be clickable
            IWebElement timepicker = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("endTime")));

            // Find the hour input field and set the hours
            IWebElement hourInput = timepicker.FindElement(By.CssSelector(".ngb-tp-hour input"));
            hourInput.Clear();
            hourInput.SendKeys(hours);

            // Find the minute input field and set the minutes
            IWebElement minuteInput = timepicker.FindElement(By.CssSelector(".ngb-tp-minute input"));
            minuteInput.Clear();
            minuteInput.SendKeys(minutes);

            // Find the meridian (AM/PM) button
            IWebElement meridianBtn = timepicker.FindElement(By.CssSelector(".ngb-tp-meridian button"));

            // Continuously click the meridian button until the desired meridian is selected
            while (meridianBtn.Text.Trim() != meridian)
            {
                meridianBtn.Click();
                // Add a short delay to allow the timepicker to update before checking again
                System.Threading.Thread.Sleep(500); // Adjust delay time if needed
            }
        }

        static void FillSearchLocation(IWebDriver driver, string location)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            // Locate the dropdown element
            IWebElement dropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("p-dropdown[formcontrolname='venue']")));

            // Click the dropdown to open options
            dropdown.Click();
            // Find the desired option element by its text
            string itemToSelect = location;
            Console.WriteLine("meeting location title is set to variable:" + itemToSelect);
            Thread.Sleep(500);
            By optionLocator = By.XPath($"//div[contains(@class, 'country-item')]//*[contains(text(), '{itemToSelect}')]");
            Thread.Sleep(500);

            try
            {
                IWebElement option = wait.Until(ExpectedConditions.ElementToBeClickable(optionLocator));
                Thread.Sleep(500);
                // Click the option to select it
                option.Click();
                Thread.Sleep(500);

                // Perform actions with the selected option if needed
                // ...
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("Element not found within the specified timeframe.");
                Console.WriteLine(ex.ToString());
            }
        }

        static void FillMeetingRoom(IWebDriver driver, string meetingRoom)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement meetingRoomDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("p-dropdown[formcontrolname='meetingRoom']")));
            Thread.Sleep(1000);
            meetingRoomDropdown.Click();
            Thread.Sleep(1000);
            // Find the desired option element by its text
            string itemToSelect = meetingRoom;
            By optionLocator = By.XPath($"//div[contains(@class, 'country-item')]//*[contains(text(), '{itemToSelect}')]");
            Thread.Sleep(1500);

            try
            {
                IWebElement option = wait.Until(ExpectedConditions.ElementToBeClickable(optionLocator));
                Thread.Sleep(500);
                // Click the option to select it
                option.Click();
                Thread.Sleep(500);

                // Perform actions with the selected option if needed
                // ...
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("Element not found within the specified timeframe.");
                Console.WriteLine(ex.ToString());
            }

        }

        static void FillVideoConferencingOption(IWebDriver driver, string option)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement videoConferencingDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("p-dropdown[formcontrolname='videoConferencingList']")));
            videoConferencingDropdown.Click();
            Thread.Sleep(1000);
            // Locate the dropdown options and select the desired one based on the provided 'option' parameter
            IWebElement optionToSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='" + option + "']")));
            Thread.Sleep(500);
            optionToSelect.Click();
            Thread.Sleep(500);
        }

        static void CopyFolder(string sourceFolder, string destinationFolder)
        {
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            foreach (string file in Directory.GetFiles(sourceFolder))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationFolder, fileName);
                File.Copy(file, destFile, true);
            }

            foreach (string subFolder in Directory.GetDirectories(sourceFolder))
            {
                string folderName = Path.GetFileName(subFolder);
                string destFolder = Path.Combine(destinationFolder, folderName);
                CopyFolder(subFolder, destFolder);
            }
        }

        [TearDown]
        public void Teardown()
        {
            // Quit the WebDriver session after all tests
            driver.Quit();
        }

    }
}
