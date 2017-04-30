using OpenQA.Selenium;

namespace PocketQA
{
    public static class WebElementExtensions
    {
        public static IWebElement GetParent(this IWebElement e)
        {
            return e.FindElement(By.XPath(".."));
        }
    }
}
