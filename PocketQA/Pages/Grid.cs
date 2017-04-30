using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace PocketQA.Pages
{
    public class Grid : Page
    {
        public Grid(RemoteWebDriver driver, string baseUrl) : base(driver, baseUrl)
        {
        }

        public override string Url
        {
            get { throw new NotSupportedException(); }
        }

        protected IWebElement GridElement => FindElementByCssSelector(".k-grid.k-reorderable");

        public IReadOnlyCollection<IWebElement> Rows
        {
            get
            {
                var rows = FindElements(GridElement, By.CssSelector("tbody tr"));
                return rows;
            }
        }

        public IReadOnlyCollection<IWebElement> Columns
        {
            get
            {
                var columns = FindElements(GridElement, By.CssSelector(".k-grid-header .k-header"));
                return columns;
            }
        }
    }
}
