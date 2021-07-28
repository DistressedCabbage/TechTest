using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace TechTest.Common
{
    public class Context
    {
        public IWebDriver Driver { get; set; }

        public Context(ITestConfiguration testConfiguration)
        {
            var driverOptions = new ChromeOptions();
            driverOptions.AddArguments(GetBrowserArguments());
            Driver = new ChromeDriver(driverOptions);
            GoToUrl(testConfiguration.BaseUrl);
        }

        public void Dispose()
        {
            if(Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }

        public bool ConfirmSite(string url)
        {
            string currentUrl = Driver.Url;
            return currentUrl.Contains(url) ? true : false;
        }

        public void GoToUrl(string url)
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
        }

        private IEnumerable<string> GetBrowserArguments()
        {
            return new List<string>
           {
               "disable-popup-blocking",
               "disable-infobars"
           };
        }
    }
}