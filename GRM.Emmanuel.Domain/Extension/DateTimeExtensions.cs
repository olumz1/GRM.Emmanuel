using System;
using System.Globalization;

namespace GRM.Emmanuel.Domain.Extension
{
    public static class DateTimeExtensions
    {
        public static string RemoveSuffix(this string date)
        {
            date = date.Replace("nd", "");
            date = date.Replace("st", "");
            date = date.Replace("rd", "");
            date = date.Replace("th", "");

            return date;
        }

        public static DateTime ToDateTimeFormat(this string date)
        {
            if (DateTime.TryParse(date, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out var dateTime))
            {
                return dateTime;
            }
            else
            {
                throw new Exception("The string cannot be converted to a date format");
            }
        }

        public static string AddSuffixToDay(this int day)
        {
            var suffix = "";

            if (day % 100 >= 11 && day % 100 <= 13)
            {
                suffix = "th";
            }
            else
            {
                switch (day % 10)
                {
                    case 1:
                        suffix = "st";
                        break;
                    case 2:
                        suffix = "nd";
                        break;
                    case 3:
                        suffix = "rd";
                        break;
                    default:
                        suffix = "th";
                        break;
                }
            }

            return $"{day}{suffix}";
        }
    }
}
