using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace PocketQA.Steps
{
    [Binding]
    public class BaseUiSteps
    {
        protected static string Browser => TestsSettings.Browser;

        protected static RemoteWebDriver Driver { get; private set; }

        [BeforeTestRun(Order = 0)]
        public static void BeforeTestRun()
        {
            Driver = WebDriverFactory.CreateWebDriver(Browser);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {   
            if (Driver != null)
            {
                Driver.Close();
                Driver.Dispose();
            }
        }

        public string CurrentUrl => Driver.Url;
    }
}
