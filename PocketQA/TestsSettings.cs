using System;
using System.ComponentModel;
using System.Configuration;

namespace PocketQA
{
    public static class TestsSettings
    {
        public static string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];

        public static string WebApiHost => ConfigurationManager.AppSettings["WebApiHost"];

        public static string Browser => ConfigurationManager.AppSettings["Browser"];

        public static string ScreenshotsFolder => ConfigurationManager.AppSettings["ScreenshotsFolder"];

        public static int DefaultWaitTimeoutInSeconds => Setting<int>("DefaultWaitTimeoutInSeconds");

        public static int DefaultWaitForPageRedirectInSeconds => Setting<int>("DefaultWaitForPageRedirectInSeconds");

        public static string ValidUserEmail => ConfigurationManager.AppSettings["ValidUserEmail"];

        public static string ValidUserPassword => ConfigurationManager.AppSettings["ValidUserPassword"];

        public static T Setting<T>(string name)
        {
            var value = ConfigurationManager.AppSettings[name];

            if (value == null)
            {
                throw new Exception($"Could not find setting '{name}',");
            }

            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(value);
        }
    }
}
