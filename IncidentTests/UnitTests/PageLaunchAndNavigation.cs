using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumNavigation;
using System;
using System.Threading;
using TestData;
using Xunit;

namespace UnitTests
{
    public class PageLaunchAndNavigation
    {
        [Theory]
        [ClassData(typeof(UrlAndConfirmData))]
        public void Launch_webpage_confirm_and_close_successfully(string url, string websiteConfirmer)
        {
            Website website = new Website(url, websiteConfirmer, "Chrome");

            try
            {
                website.LaunchWebsite().Should().BeTrue();
            }
            finally
            {
                website.TestCleanUp();
            }

        }

        [Theory]
        [ClassData(typeof(AllConfigurationData))]
        public void Login_and_confirm_successfully(string url, string websiteConfirmer, string username, string password, 
                                        string usernameBarName, string passwordBarName, string loginId, string confirmLoggedinPath)
        {
            Website website = new Website(url, websiteConfirmer, "Chrome");

            try
            {
                website.LaunchWebsite().Should().BeTrue();
                website.EnterUsername(username, usernameBarName);
                website.EnterPassword(password, passwordBarName);
                website.ClickOnLogin(loginId);

                _ = website.ConfirmLoggedIn(confirmLoggedinPath).Should().BeTrue();
            }
            finally
            {
                website.TestCleanUp();
            }
        }
        [Theory]
        [ClassData(typeof(AllConfigurationData))]
        public void Navigate_to_data_display_page_successfully(string url, string websiteConfirmer, string username, string password,
                                string usernameBarName, string passwordBarName, string loginId, string confirmLoggedinPath)
        {
            Website website = new Website(url, websiteConfirmer, "Chrome");

            try
            {
                website.LaunchWebsite().Should().BeTrue();
                website.EnterUsername(username, usernameBarName);
                website.EnterPassword(password, passwordBarName);
                website.ClickOnLogin(loginId);

                _ = website.ConfirmLoggedIn(confirmLoggedinPath).Should().BeTrue();

                website.NavigateToDataDisplay().Should().BeTrue();
            }
            finally
            {
                website.TestCleanUp();
            }
        }

        [Theory]
        [ClassData(typeof(AllConfigurationData))]
        public void Click_on_new_record_button_successfully(string url, string websiteConfirmer, string username, string password,
                         string usernameBarName, string passwordBarName, string loginId, string confirmLoggedinPath)
        {
            Website website = new Website(url, websiteConfirmer, "Chrome");

            try
            {
                website.LaunchWebsite().Should().BeTrue();
                website.EnterUsername(username, usernameBarName);
                website.EnterPassword(password, passwordBarName);
                website.ClickOnLogin(loginId);

                _ = website.ConfirmLoggedIn(confirmLoggedinPath);

                _ = website.NavigateToDataDisplay();

                website.ClickNewRecordButton().Should().BeTrue();



            }
            finally
            {
                website.TestCleanUp();
            }
        }
    }
}
