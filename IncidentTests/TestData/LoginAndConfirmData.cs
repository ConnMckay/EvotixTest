using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestData
{
    public class LoginAndConfirmData : TheoryData<string>
    {
        public LoginAndConfirmData()
        {
            AllConfigurationData allData = new AllConfigurationData();
            foreach (object[] dataElement in allData)
            {
                AddRow(dataElement[AllConfigurationData.urlIndex], dataElement[AllConfigurationData.websiteConfirmationIndex],
                    dataElement[AllConfigurationData.usernameIndex], dataElement[AllConfigurationData.passwordIndex],
                        dataElement[AllConfigurationData.usernameBarIndex], dataElement[AllConfigurationData.passwordBarIndex],
                        dataElement[AllConfigurationData.loggedInConfirmIndex]);
            }
        }  
    }
}
