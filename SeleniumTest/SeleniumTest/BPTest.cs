﻿using OpenQA.Selenium.Chrome;
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
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

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

            // Use the captured message as needed
            Console.WriteLine("sysadmin login successfully");

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
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

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
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

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

            // Use the captured message as needed
            Console.WriteLine("boardadmin login successfully");

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
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

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
            chromeOptions.AddArgument("--headless");
            //chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

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
                    Console.WriteLine("User Managment Main Menu is already expanded");
                }
                else
                {
                    // Menu is collapsed, click to expand
                    menu.Click();
                    Console.WriteLine("User Managment Main Menu clicked to expanded");
                    Thread.Sleep(500);
                }

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

                //Creating a User
                // Wait for the form to load
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
                wait2.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-body")));

                Thread.Sleep(2000);
                try
                {                    
                    // Create the next username by appending the counter
                    string nextUsername = baseUsername + counter;

                    Console.WriteLine("starting to add MR");
                    // Insert values into the form
                    InsertSalutation(driver, "Mr");

                    Thread.Sleep(200);

                    InsertUsername(driver, nextUsername);

                    Thread.Sleep(200);

                    InsertFirstName(driver, "Avishka");

                    Thread.Sleep(200);

                    InsertLastName(driver, "BoardPAC");

                    Thread.Sleep(200);

                    InsertPrimaryEmail(driver, "avishkalaki@hotmail.com");

                    Thread.Sleep(200);

                    InsertDeviceDisplayName(driver, "AvishkaBoardPAC");

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
            chromeOptions.AddArgument("--headless");
            //chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

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
            chromeOptions.AddArgument("--headless");
            //chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
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

        [TestMethod]
        public void C_0_OrganizerLogin()
        {
            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "BPUser1";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size

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

            // Use the captured message as needed
            Console.WriteLine("Oraginzer login successfully");

            // You can add further actions after successful login here
            Thread.Sleep(1000);

            // Close the browser
            driver.Quit();
        }

        [TestMethod]
        public void C_1_OrganizerVenueCreate()
        {
            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "BPUser1";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);
            
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
            wait2.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/venue/venues")); // Replace "expectedPage" with part of the URL of the next page

            Thread.Sleep(500);

            chromeOptions.AddArgument("--enable-precise-geolocation");
            driver.Navigate().Refresh();

            // Execute JavaScript to simulate granting permission for geolocation
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("navigator.geolocation.getCurrentPosition = function(success) { var position = { coords: {latitude: 12.976230, longitude: 77.603290}}; success(position); }");



            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            // Wait for the next page to load (you may need to adjust the timing)
            wait3.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/venue/venues")); // Replace "expectedPage" with part of the URL of the next page


            // Wait for the button to be clickable
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement createVenueButton = wait4.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(., 'Create Venue')]")));

            createVenueButton.Click();

            // Initialize a counter
            int counter = 0;

            bool userAdded = false;

            while (!userAdded)
            {
                Thread.Sleep(1500);

                WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                // Find the venue name input field by ID
                IWebElement venueNameInput = wait5.Until(ExpectedConditions.ElementIsVisible(By.Id("venueName")));

                venueNameInput.Clear();

                Thread.Sleep(500);

                // Type the venue name into the input field
                venueNameInput.SendKeys("BoardPACADOVenue_"+counter);

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
            wait8.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/venue/venues")); // Replace "expectedPage" with part of the URL of the next page
                                                                                                                          // Wait for the next page to load (you may need to adjust the timing)
            Thread.Sleep(1000);

            // Close the browser
            driver.Quit();

        }

        [TestMethod]
        public void C_2_OrganizerMeetingCreate()
        {
            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "BPUser1";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

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
                Console.WriteLine("Create Meeting clicked to expanded");
                Thread.Sleep(500);
            }
            else
            {
                // Handle the situation where the link is not clickable
                Console.WriteLine("Create Meeting link is not clickable.");
                // You can add further actions or error handling here if needed
            }


            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            // Wait for the next page to load (you may need to adjust the timing)
            wait2.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/meeting/createmeeting")); // Replace "expectedPage" with part of the URL of the next page

            Thread.Sleep(1500);

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            FillTitle(driver, wait3, "BPM");

            Thread.Sleep(500);

            SelectCommittee(driver, wait3, "boardpactest");

            Thread.Sleep(500);

            SelectSubCommittee(driver, wait3, "boardpacsub");

            Thread.Sleep(500);

            FillOrganizer(driver, wait3, "BPUserOne BoardPAC");

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

            FillSearchLocation(driver, wait3, "BoardPACADOVenue_0");

            Thread.Sleep(500);

            FillMeetingRoom(driver, wait3, "BoardRoom");

            Thread.Sleep(500);

            FillVideoConferencingOption(driver, wait3, "None");

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
            wait5.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/meeting/meetings")); // Replace "expectedPage" with part of the URL of the next page
                                                                                                                              // Wait for the next page to load (you may need to adjust the timing)
            Thread.Sleep(1000);

            // Close the browser
            driver.Quit();

        }

        [TestMethod]
        public void C_3_OrganizerMeetingschedule()
        {
            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "BPUser1";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

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
            wait2.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/meeting/meetings")); // Replace "expectedPage" with part of the URL of the next page

            // Wait for the form to load
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait3.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-body")));

            Thread.Sleep(500);

            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the input field by its class name
            IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.form-control.search-input")));

            // Type the meeting name into the input field
            string meetingName = "BPM12112023"; // Replace this with the actual meeting name
            searchInput.SendKeys(meetingName);

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
            driver.Quit();


        }

        [TestMethod]
        public void C_4_OrganizerAgendaUpload()
        {
            // URL of the login page
            string loginUrl = "https://azuredevops.boardpaconline.com/WebClient/AzureDevOpsStaging/login";

            // Credentials for login
            string username = "BPUser1";
            string password = "123";

            // Initialize Chrome Driver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--start-maximized"); // Optional: Start the browser maximized
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Set a standard window size
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
            // Open the login page
            driver.Navigate().GoToUrl(loginUrl);

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
            wait2.Until(ExpectedConditions.UrlContains("https://azuredevops.boardpaconline.com/WebClient/meeting/meetings")); // Replace "expectedPage" with part of the URL of the next page

            // Wait for the form to load
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait3.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card-body")));

            Thread.Sleep(500);

            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the input field by its class name
            IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.form-control.search-input")));

            // Type the meeting name into the input field
            string meetingName = "BPM12112023"; // Replace this with the actual meeting name
            searchInput.SendKeys(meetingName);

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
            wait4.Until(driver => driver.Url.StartsWith("https://azuredevops.boardpaconline.com/WebClient/meeting/agenda"));

            Thread.Sleep(500);

            // Set up WebDriverWait with a timeout of 10 seconds
            WebDriverWait wait6 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the upload button by its class and tag
            IWebElement uploadButton = wait6.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a.btn.btn-upload")));

            // Click the upload button
            uploadButton.Click();

            // Set up WebDriverWait with a timeout of 10 seconds
            //WebDriverWait wait7 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            //IWebElement folderRadioButton = wait7.Until(ExpectedConditions.ElementExists(By.XPath("//p-radiobutton[@name='uploadSelection']/div/div[contains(@class, 'ui-radiobutton-box')]/span[contains(@class, 'pi-circle-on')]")));

            //// Check if the folder radio button is not already selected
            //if (!folderRadioButton.Selected)
            //{
            //    // Click the folder radio button to activate it
            //    folderRadioButton.Click();
            //}

            string solutionDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../");
            string folderPathRelativeToSolution = @"UploadDoc/TestDoc";

            string folderAbsolutePath = Path.Combine(solutionDirectory, folderPathRelativeToSolution);

            // Specify the source folder path (inside the solution directory)
            string sourceFolderPath = Path.Combine(folderAbsolutePath, "Agenda");

            string path = "TestDoc" + GetCurrentFormattedDate();
            // Specify the destination folder path in the C drive
            string destinationFolderPath = @"C:\"+path+@"\Agenda";

            // Copy the folder and its contents recursively to the destination
            CopyFolder(sourceFolderPath, destinationFolderPath);

            WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            Thread.Sleep(2000);

            // Wait for the file input element to be available
            IWebElement fileInput = wait8.Until(ExpectedConditions.ElementExists(By.CssSelector("input[name='UploadFiles'][directory='true']")));

            Thread.Sleep(2000);
            // Send the folder path to the file input element
            fileInput.SendKeys(destinationFolderPath);

            Thread.Sleep(1000);

            // Find the checkbox element by its ID
            IWebElement publishAllCheckbox = driver.FindElement(By.Id("inlineCheckbox1"));

            // Check the checkbox if it's not already selected
            if (!publishAllCheckbox.Selected)
            {
                publishAllCheckbox.Click();
            }

            Thread.Sleep(500);
            // Find the upload button by its ID
            IWebElement uploadButton2 = driver.FindElement(By.Id("btnSubmit"));

            // Click the upload button
            uploadButton2.Click();
            Thread.Sleep(2000);

            IWebElement toastMessageElement1 = null;
            // Create a WebDriverWait instance
            WebDriverWait wait9 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Find the div element containing the toast message
            toastMessageElement1 = wait9.Until(ExpectedConditions.ElementExists(By.CssSelector("div.overlay-container div#toast-container.toast-top-right div.toast-message")));

            // Get the text within the div element
            string toastMessage = toastMessageElement1.Text;

            // Use the captured message as needed
            Console.WriteLine("Toast Message2: " + toastMessage);

            // Wait for the next page to load (you may need to adjust the timing)
            Thread.Sleep(1000);

            // Close the browser
            driver.Quit();



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
            firstNameInput.SendKeys(firstName);
            Console.WriteLine("add the firstName");
        }

        static void InsertLastName(IWebDriver driver, string lastName)
        {
            IWebElement lastNameInput = driver.FindElement(By.Id("lastName"));
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
            Thread.Sleep(1000);
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

        static void FillSearchLocation(IWebDriver driver, WebDriverWait wait, string location)
        {
            // Locate the dropdown element
            IWebElement dropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("p-dropdown[formcontrolname='venue']")));

            // Click the dropdown to open options
            dropdown.Click();
            Thread.Sleep(500);
            // Find the desired option element by its text
            string itemToSelect = location;
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

        static void FillMeetingRoom(IWebDriver driver, WebDriverWait wait, string meetingRoom)
        {
            Thread.Sleep(500);
            IWebElement meetingRoomDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("p-dropdown[formcontrolname='meetingRoom']")));
            meetingRoomDropdown.Click();
            Thread.Sleep(1000);
            // Find the desired option element by its text
            string itemToSelect = meetingRoom;
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

        static void FillVideoConferencingOption(IWebDriver driver, WebDriverWait wait, string option)
        {
            Thread.Sleep(500);
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
    }
}
