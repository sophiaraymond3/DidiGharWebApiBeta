using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi
{
    public static class ExtensionMethod
    {
        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 18, 0, 0, 0);
        }

        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 9, 0, 0, 0);
        }
    }
}