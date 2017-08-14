using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace PocketQA
{
    public static class WebElementExtensions
    {
        public static IWebElement GetParent(this IWebElement e)
        {
            return e.FindElement(By.XPath(".."));
        }

        public static IEnumerable<IWebElement> FindDescendants(this IWebElement element, By by)
        {
            var elements = element.FindElements(by);
            return elements.Where(el => el.HasAncestor(element));
        }

        public static bool HasAncestor(this IWebElement element, IWebElement ancestor)
        {
            while (!element.TagName.Equals("html", StringComparison.OrdinalIgnoreCase))
            {
                if (ancestor.Equals(element.GetParent()))
                {
                    return true;
                }

                element = element.GetParent();
            }

            return false;
        }
    }
}
