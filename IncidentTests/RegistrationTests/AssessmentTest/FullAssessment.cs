using FluentAssertions;
using SeleniumNavigation;
using System;
using TestData;
using Xunit;

namespace AssessmentTest
{
    public class FullAssessment
    {
        /*
         * Please note: 
         * I was not able to get the delete to work. I would need a better understanding of Selenium
         * There are a few things I would think of abstracting but with YAGNI that abstraction would come with a refactoring when needed.
         * Of course the vast majority of hard coding would be sent down from TFS, Team City or other CI/CD machine
         */

        [Theory]
        [ClassData(typeof(AllConfigurationData))]
        public void CreateANewRecord(string url, string websiteConfirmer, string username, string password,
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

                website.NavigateToDataDisplay();
                website.ClickNewRecordButton().Should().BeTrue();

                website.AddDescription("Conns first attempt at entering text into the Description Box");
                website.AddAssessmentDate();

                website.SaveRecord();

                website.ClickNewRecordButton();
                website.AddDescription("Conns second attempt at entering text into the Description Box");
                website.AddAssessmentDate();

                website.SaveRecord();

                website.SelectAndConfirmItemDeleted().Should().BeTrue();

                website.LogOff();
            }

            finally
            {
                website.TestCleanUp();
            }

        }
    }
}
