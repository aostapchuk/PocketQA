using System;

namespace PocketQA
{
    public static class DataHelper
    {
        public static long GetUniqueIndex()
        {
            return (DateTime.Now.Ticks - new DateTime(2017, 1, 1).Ticks)/TimeSpan.TicksPerMillisecond;
        }
    }
}
