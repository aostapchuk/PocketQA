namespace PocketQA
{
    public static class UrlHelper
    {
        public static string Combine(string baseUrl, string relativeUrl)
        {
            return baseUrl.TrimEnd('/') + '/' + relativeUrl.TrimStart('/');
        }
    }
}
