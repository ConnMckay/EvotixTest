using System;
using Xunit;

namespace TestData
{
    public class AllConfigurationData : TheoryData<string, string, string, string, string, string, string, string, string>
    {
        public AllConfigurationData()
        {
            //Url, Website Confirmation, Username, Password, UsernameBarName, PasswordBarName, Login Id, Logged In Confirmation
            AddRow("https://stirling.she-development.net/automation", "stirling.she-development.net", "cmckay", "QHG961!", "username", "password", 
                "login", "she-user-info");
    }
        public const long urlIndex = 0;
        public const long websiteConfirmationIndex = 1;
        public const long usernameIndex = 2;
        public const long passwordIndex = 3;
        public const long usernameBarIndex = 4;
        public const long passwordBarIndex = 5;
        public const long logInIndex = 6;
        public const long loggedInConfirmIndex = 7;
    }
}
