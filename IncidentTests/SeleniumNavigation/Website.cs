using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;

namespace SeleniumNavigation
{
    public class Website
    {
        public Website(string url, string websiteConfirmer, string browserType)
        {
            ClearAllDriverProcesses();
            Url = url;
            WebSiteConfirmer = websiteConfirmer;
            ConfigureWebDriver(browserType);
        }
        public string Url { get; set; }
        public string WebSiteConfirmer { get; set; }
        IWebDriver WebDriver { get; set; }
        string BrowserProcess { get; set; }

        public bool LaunchWebsite()
        {
            WebDriver.Navigate().GoToUrl(Url);
            string currentUrl = WebDriver.Url;
            WebDriver.Manage().Window.Maximize();
            return currentUrl.Contains(WebSiteConfirmer);
        }

        public void EnterUsername(string username, string usernameBarname)
        {
            By userNameBarElement = By.Name(usernameBarname);
            WebDriver.FindElement(userNameBarElement).SendKeys(username);
        }

        public void SaveRecord()
        {
            var saveButtons = WebDriver.FindElements(By.Name("submitButton"));
            var saveAndClose = saveButtons[1];
            saveAndClose.Click();
        }

        public void AddAssessmentDate()
        {
            var todayShortDate = DateTime.Now.ToShortDateString();
            var datePickerButton =  WebDriver.FindElement(By.Id("SheEnvironmental_AssessmentDate"));
            datePickerButton.SendKeys(todayShortDate);
        }

        public void LogOff()
        {
            By userDropDown = By.ClassName("nav-user-name-container");
            WebDriver.FindElement(userDropDown).Click();

            By searchEntry = By.XPath("/html/body/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/ul/li/ul/li[4]/a");
            WebDriver.FindElement(searchEntry).Click();

        }

        public bool SelectAndConfirmItemDeleted()
        {
            /*
             * I was tying to find a smart way to click on search, get the id and delete the record. Unfortunately i could work it out.
             * This means to delete the item you will need to find the record and manually enter it
             */

            //By itemSelected = By.XPath("html/body/div[1]/div[3]/section/div[3]/div[2]/div[3]/div[2]/ul/li[4]/a");
            //WebDriver.FindElement(itemSelected).Click();

            By userNameBarElement = By.CssSelector("#top_bar > span.quickSearchIcon");
            WebDriver.FindElement(userNameBarElement).Click();

            By searchEntry = By.XPath("/html/body/div[1]/div[3]/section/div[2]/div/span/input");
            WebDriver.FindElement(searchEntry).SendKeys("first");

            return WebDriver.FindElement(By.ClassName("dataTables_empty")).Displayed;
        }

        public void EnterPassword(string password, string passwordBarname)
        {
            By passwordBarElement = By.Name(passwordBarname);
            WebDriver.FindElement(passwordBarElement).SendKeys(password);
        }
        public void ClickOnLogin(string loginId)
        {
            By loginIdElement = By.Id(loginId);
            WebDriver.FindElement(loginIdElement).Click();
        }

        public bool ConfirmLoggedIn(string confirmLoggedinPath)
        {
            return WebDriver.FindElement(By.ClassName(confirmLoggedinPath)).Displayed;
        }
        public bool NavigateToDataDisplay()
        {
            WebDriver.FindElement(By.LinkText("Modules")).Click();
            WebDriver.FindElement(By.LinkText("Environment")).Click();

            return WebDriver.FindElement(By.LinkText("Environmental Assessment")).Displayed;
        }

        public bool ClickNewRecordButton()
        {
            WebDriver.FindElement(By.LinkText("New Record")).Click();
            return WebDriver.FindElement(By.ClassName("OrgUnitline")).Displayed;

        }

        public void AddDescription(string description)
        {
            var descriptionTextBox = WebDriver.FindElement(By.Id("SheEnvironmental_Description"));
            descriptionTextBox.Clear();
            descriptionTextBox.SendKeys(description);


        }

        public void TestCleanUp()
        {
            WebDriver.Close();
            WebDriver.Quit();
            WebDriver.Dispose();
        }

        private void ConfigureWebDriver(string browserType)
        {
            switch (browserType)
            {
                case "Chrome":
                    WebDriver = new ChromeDriver();
                    BrowserProcess = "chromedriver";
                    break;
                default:
                    throw new Exception($"{browserType} is not a valid Browser in this test");
            }
        }
        private void ClearAllDriverProcesses()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName(BrowserProcess);
            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();

            }
        }
    }
}
