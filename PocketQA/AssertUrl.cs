using NUnit.Framework;
using System;

namespace PocketQA
{
    public static class AssertUrl
    {
        public static void Relative(string expectedRelativeUrl, string currentUrl)
        {
            var expectedUrl = UrlHelper.Combine(TestsSettings.BaseUrl, expectedRelativeUrl);
            expectedUrl = NormalizeUrl(expectedUrl);
            currentUrl = NormalizeUrl(currentUrl);

            Assert.AreEqual(expectedUrl.Trim('/').ToLower(), currentUrl.Trim('/').ToLower());
        }

        private static string NormalizeUrl(string url)
        {
            return url.Trim('/').ToLower();
        }
    }
}
