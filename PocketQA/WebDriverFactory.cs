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
                    var options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    return new ChromeDriver(options);

                case "ff":
                case "firefox":
                    var profile = new FirefoxProfile();
                    profile.SetPreference("network.automatic-ntlm-auth.trusted-uris", "https://default.local-dev.spendvu.com");
                    profile.SetPreference("webdriver_assume_untrusted_issuer", false);
                    profile.SetPreference("webdriver_accept_untrusted_certs", true);
                    profile.AcceptUntrustedCertificates = true;
                    profile.AssumeUntrustedCertificateIssuer = false;
                    return new FirefoxDriver(profile);

                case "ie":
                case "internetexplorer":
                    return new InternetExplorerDriver(".", new InternetExplorerOptions(), TimeSpan.FromMinutes(2));

                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, "Browser is not supported.");
            }
        }
    }
}
