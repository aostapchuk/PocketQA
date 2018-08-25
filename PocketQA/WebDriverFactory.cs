using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace PocketQA
{
    public static class WebDriverFactory
    {
        public static RemoteWebDriver CreateWebDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                {
                    var options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    return new ChromeDriver(options);
                }

                case "ff":
                case "firefox":
                {
                    var options = new FirefoxOptions
                    {
                        AcceptInsecureCertificates = true
                    };
                    return new FirefoxDriver(options);
                }

                case "ie":
                case "internetexplorer":
                {
                    var options = new InternetExplorerOptions();
                    return new InternetExplorerDriver(options);
                }

                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, "Browser is not supported.");
            }
        }
    }
}
