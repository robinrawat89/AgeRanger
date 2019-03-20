using AgeRangerWebUi.Steps;
using TechTalk.SpecFlow;

namespace AgeRangerWebUi.Utilities
{
    [Binding]
    public class Hooks : BaseClass
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = DriverFactory.InitiateWebDriver(CommonConstants.DriverSettings.ChromeBrowser);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
