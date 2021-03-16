using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi
{
    public static class ExtensionMethod
    {
        public static DateTime EndOfDay(this DateTime date, DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 18, 0, 0, 0);
        }

        public static DateTime StartOfDay(this DateTime date, DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 9, 0, 0, 0);
        }
    }
}