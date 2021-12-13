using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestData
{
    public class UrlAndConfirmData : TheoryData<string>
    {
        public UrlAndConfirmData()
        {
            AllConfigurationData allData = new AllConfigurationData();
            foreach (object[] dataElement in allData)
            {
                AddRow(dataElement[AllConfigurationData.urlIndex], dataElement[AllConfigurationData.websiteConfirmationIndex]);
            }
        }  
    }
}
