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
        public void A_SysadminLogin()
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

            // Close the browser
            driver.Quit();
        }

        [TestMethod]
        public void B_SysadminChecking()
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

            // Find and click on the menu item
            IWebElement menuItem = driver.FindElement(By.CssSelector("a[routerlink='/settings/sysadminsettings']"));
            menuItem.Click();

            // Find and click on the menu item inside the tab
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement securityMenuItem = wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[data-toggle='tab'][href='#security-settings']")));
            securityMenuItem.Click();

            // Find and click on the "Save" button
            IWebElement saveButton = driver.FindElement(By.CssSelector("button.btn.btn-primary-submit"));
            saveButton.Click();

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
        public void C_BoardadminLogin()
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

            // Close the browser
            driver.Quit();
        }

        [TestMethod]
        public void D_0_BoardadminChecking()
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

            // Find and click on the menu item
            IWebElement menuItem = driver.FindElement(By.CssSelector("a[routerlink='/settings/boardadminsettings']"));
            menuItem.Click();

            // Find and click on the menu item inside the tab
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement securityMenuItem = wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[data-toggle='tab'][href='#meeting-settings']")));
            securityMenuItem.Click();

            // Find and click on the "Save" button
            IWebElement saveButton = driver.FindElement(By.CssSelector("button.btn.btn-primary-submit"));
            saveButton.Click();

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
        public void D_1_BoardadminUserCreating()
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
            int counter = 98;

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
                }


                // Find the <a> element for user creation
                IWebElement createUserLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                    .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[routerlink='/usermgt/createUser'][routerlinkactive='active']")));

                if (createUserLink != null)
                {
                    // Click on the user creation link if it's clickable
                    createUserLink.Click();
                }
                else
                {
                    // Handle the situation where the link is not clickable
                    Console.WriteLine("Create User link is not clickable.");
                    // You can add further actions or error handling here if needed
                }

                //Creating a User
                // Wait for the form to load
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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




                    // Click the submit button (assuming it's initially disabled)
                    IWebElement submitButton = driver.FindElement(By.Id("submitBtn"));
                    if (submitButton.Enabled)
                    {
                        submitButton.Click();


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

                            }
                            else
                            {
                                userAdded = true;                                

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
        public void D_2_BoardadminUserUpdate()
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

            // Wait for the URL to match the expected pattern
            wait4.Until(driver => driver.Url.StartsWith("https://azuredevops.boardpaconline.com/WebClient/usermgt/updateuser"));

            // Perform other actions after the URL matches the pattern...
            InsertDeviceDisplayName(driver, "AvishkaBoardPACnew");
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

                        //// Close the browser
                        //driver.Quit();

                    }
                    else
                    {
                        Console.WriteLine("Toast Message: " + toastMessage);

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
                }

            }
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
