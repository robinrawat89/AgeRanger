using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace AgeRangerWebUi.Utilities
{
    public class DriverFactory
    {
        public static IWebDriver InitiateWebDriver(string browser)
        {
            //IWebDriver driver = null;
            if (browser.Equals(CommonConstants.DriverSettings.ChromeBrowser))
            {
                Steps.BaseClass.driver = new ChromeDriver();
            }
            else if (browser.Equals(CommonConstants.DriverSettings.FireFoxBrowser))
            {
                Steps.BaseClass.driver = new FirefoxDriver();
            }
            else if (browser.Equals(CommonConstants.DriverSettings.FireFoxBrowser))
            {
                Steps.BaseClass.driver = new InternetExplorerDriver();
            }


            Steps.BaseClass.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CommonConstants.DriverSettings.DefaultWaitTime);
            Steps.BaseClass.driver.Manage().Window.Maximize();
            return Steps.BaseClass.driver;
        }
    }
}
