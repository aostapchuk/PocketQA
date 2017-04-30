using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace PocketQA
{
    public class TakingScreenshots : BaseUiSteps
    {
        protected static string RootFolderPath;
        protected static int MinimumSupportedBrowserWidth;
        protected static int MinimumSupportedBrowserHeight;

        protected static string FeatureFolderPath;
        protected static string ScenarioFolderPath;
        protected static int StepIndex;

        [BeforeTestRun]
        public static void CreateRootFolder()
        {
            RootFolderPath = ConfigurationManager.AppSettings["ScreenshotsFolder"];

            int.TryParse(ConfigurationManager.AppSettings["MinimumSupportedBrowserWidth"], out MinimumSupportedBrowserWidth);
            int.TryParse(ConfigurationManager.AppSettings["MinimumSupportedBrowserHeight"], out MinimumSupportedBrowserHeight);

            if (string.IsNullOrWhiteSpace(RootFolderPath))
            {
                return;
            }

            RootFolderPath = Path.Combine(RootFolderPath, DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ms"), Browser);
            if (!Directory.Exists(RootFolderPath))
            {
                Directory.CreateDirectory(RootFolderPath);
            }
        }

        [BeforeFeature]
        public static void CreateFeatureFolder()
        {
            if (string.IsNullOrWhiteSpace(RootFolderPath))
            {
                return;
            }

            FeatureFolderPath = Path.Combine(RootFolderPath, ReplaceInvalidFileNameChars(FeatureContext.Current.FeatureInfo.Title));
            if (!Directory.Exists(FeatureFolderPath))
            {
                Directory.CreateDirectory(FeatureFolderPath);
            }
        }

        [BeforeScenario]
        public static void CreateScenarioFolder()
        {
            if (string.IsNullOrWhiteSpace(RootFolderPath))
            {
                return;
            }

            StepIndex = 0;
            ScenarioFolderPath = Path.Combine(FeatureFolderPath, ReplaceInvalidFileNameChars(ScenarioContext.Current.ScenarioInfo.Title));
            if (!Directory.Exists(ScenarioFolderPath))
            {
                Directory.CreateDirectory(ScenarioFolderPath);
            }
        }

        [BeforeStep, AfterStep, Scope(Tag = "UI")]
        public static void TakeScreenshots()
        {
            if (string.IsNullOrWhiteSpace(RootFolderPath))
            {
                return;
            }

            TakeSceenshot();

            if (MinimumSupportedBrowserWidth > 0 && MinimumSupportedBrowserHeight > 0)
            {
                var window = Driver.Manage().Window;
                var originalSize = window.Size;
                window.Size = new Size(MinimumSupportedBrowserWidth, MinimumSupportedBrowserHeight);
                TakeSceenshot();
                window.Size = originalSize;
            }
        }

        private static void TakeSceenshot()
        {
            var window = Driver.Manage().Window;
            var fileName = ReplaceInvalidFileNameChars($"{StepIndex:00} - {ScenarioContext.Current.StepContext.StepInfo.Text}  - {window.Size.Width}x{window.Size.Height}");
            var screenshotPath = Path.Combine(ScenarioFolderPath, $"{fileName}.jpg");
            var screenshot = Driver.GetScreenshot();
            screenshot.SaveAsFile(screenshotPath, ImageFormat.Jpeg);
        }


        private static string ReplaceInvalidFileNameChars(string name)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            return invalidChars.Aggregate(name, (current, invalidChar) => current.Replace(invalidChar.ToString(), ""));
        }
    }
}
