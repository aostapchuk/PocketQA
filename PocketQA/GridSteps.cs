using NUnit.Framework;
using TechTalk.SpecFlow;
using PocketQA.Pages;

namespace PocketQA
{
    [Binding]
    public sealed class GridSteps : BaseUiSteps
    {
        private static Grid s_grid;

        [BeforeFeature, Scope(Tag = "Grid")]
        public static void OpenProjectRepository()
        {
            s_grid = new Grid(Driver, TestsSettings.BaseUrl);
        }

        [Then("the grid shows some rows")]
        public void ThenTheGridShowsSomeRows()
        {
            Assert.Greater(s_grid.Rows.Count, 0, "There are no rows in the grid.");
        }

        [Then("the grid shows (\\d+) rows")]
        [Then("the grid shows (\\d+) row")]
        public void ThenTheGridShowsSomeRows(int rowCount)
        {
            Assert.AreEqual(rowCount, s_grid.Rows.Count);
        }

        [Then("the grid shows some columns")]
        public void ThenTheGridShowsSomeColumns()
        {
            Assert.Greater(s_grid.Columns.Count, 2, "There are no colums in the grid.");
        }
    }
}
