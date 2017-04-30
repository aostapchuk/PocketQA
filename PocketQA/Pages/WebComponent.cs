using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PocketQA.Pages
{
    public class WebComponent
    {
        public readonly RemoteWebDriver Driver;

        private WebDriverWait m_wait;

        protected WebDriverWait Wait => m_wait ?? (m_wait = new WebDriverWait(Driver, WaitTimeout));

        private static TimeSpan WaitTimeout => TimeSpan.FromSeconds(TestsSettings.DefaultWaitTimeoutInSeconds);

        public WebComponent(RemoteWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement FindElementById(string id)
        {
            return FindElement(By.Id(id));
        }

        public IWebElement FindElementByTagName(string tagName)
        {
            return FindElement(By.TagName(tagName));
        }

        public IWebElement FindElementByName(string name)
        {
            return FindElement(By.Name(name));
        }

        public IWebElement FindElementByClassName(string className)
        {
            return FindElement(By.ClassName(className));
        }

        public IWebElement FindElementByLinkText(string text)
        {
            return FindElement(By.LinkText(text));
        }

        public IWebElement FindElementByCssSelector(string cssSelector)
        {
            return FindElement(By.CssSelector(cssSelector));
        }

        public IWebElement FindElementByXPath(string xpath)
        {
            return FindElement(By.XPath(xpath));
        }

        public IEnumerable<IWebElement> FindElementsByCssSelector(string cssSelector)
        {
            return FindElements(By.CssSelector(cssSelector));
        }

        public IWebElement FindElement(By by)
        {
            try
            {
                return Wait.Until(d => d.FindElement(by));
            }
            catch (WebDriverException)
            {
                return null;
            }
        }

        public IEnumerable<IWebElement> FindElements(By by)
        {
            try
            {
                return Wait.Until(d => d.FindElements(by));
            }
            catch (WebDriverException)
            {
                return Enumerable.Empty<IWebElement>();
            }
        }

        public static IWebElement FindElementByCssSelector(ISearchContext context, string cssSelector)
        {
            return FindElement(context, By.CssSelector(cssSelector));
        }

        public static IWebElement FindElementByLinkText(ISearchContext context, string linkTextToFind)
        {
            return FindElement(context, By.LinkText(linkTextToFind));
        }

        public static IWebElement FindElementByText(ISearchContext context, string text)
        {
            return FindElement(context, By.XPath($"//*[text() = '{text}']"));
        }

        public static IWebElement FindElementByTextContains(ISearchContext context, string text)
        {
            return FindElement(context, By.XPath($"//*[contains(text(), '{text}')]"));
        }

        public IWebElement FindElementById(ISearchContext context, string id)
        {
            return FindElement(context, By.Id(id));
        }

        private static IWebElement FindElement(ISearchContext context, By by)
        {
            try
            {
                var wait = new DefaultWait<ISearchContext>(context) { Timeout = WaitTimeout };
                var element = wait.Until(c => c.FindElement(by));
                return element;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public static IEnumerable<IWebElement> FindElementsByCssSelector(ISearchContext context, string cssSelector)
        {
            return FindElements(context, By.CssSelector(cssSelector));
        }

        public static IReadOnlyCollection<IWebElement> FindElements(ISearchContext context, By by)
        {
            try
            {
                var wait = new DefaultWait<ISearchContext>(context) { Timeout = WaitTimeout };
                var elements = wait.Until(c => c.FindElements(by));
                return elements;
            }
            catch (NoSuchElementException)
            {
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            }
        }

        protected void TypeFieldValue(string elementId, string value)
        {
            var input = FindElementById(elementId);
            input.SendKeys(value);
        }

        protected string GetFieldValue(string elementId)
        {
            var input = FindElementById(elementId);
            return input.GetAttribute("value");
        }

        public void PressEnter()
        {
            Driver.Keyboard.PressKey(Keys.Enter);
        }

        public void SubmitPage()
        {
            var submitButton = Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[type='submit']")));
            submitButton.Click();
        }
    }
}
