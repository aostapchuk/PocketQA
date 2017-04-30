using System;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace PocketQA.Pages
{
    public abstract class Page : WebComponent
    {
        public string BaseUrl { get; }

        protected Page(RemoteWebDriver driver, string baseUrl)
            : base(driver)
        {
            BaseUrl = baseUrl;
        }

        public abstract string Url { get; }

        public virtual void Open()
        {
            NavigateTo(Url);
            WaitForRedirect();
        }

        protected virtual void WaitForRedirect()
        {
            Thread.Sleep(TimeSpan.FromSeconds(TestsSettings.DefaultWaitForPageRedirectInSeconds));
        }

        public void NavigateTo(string relativeUrl)
        {
            var url = GetAbsoluteUrl(relativeUrl);
            Driver.Navigate().GoToUrl(url);
        }

        protected string GetAbsoluteUrl(string relativeUrl)
        {
            return UrlHelper.Combine(BaseUrl, relativeUrl);
        }
    }
}
