using System;
using System.Globalization;
using AndaForceExtensions.com.andaforce.arazect.variables;

namespace AndaForceExtensions.com.andaforce.arazect.datetime
{
    public static class DateTimeExtension
    {
        public const String RU = "ru-RU";
        public const String EN = "en-EN";

        public static String GetRussianAbbreviationDayOfWeek(this DateTime dateTime)
        {
            var culture = new CultureInfo("ru-RU");
            String shortDayOfWeek = culture.DateTimeFormat.GetAbbreviatedDayName(dateTime.DayOfWeek);

            return shortDayOfWeek;
        }

        public static String GetRussianMonthName(this DateTime dateTime)
        {
            var culture = new CultureInfo("ru-RU");
            String fullMonthName = culture.DateTimeFormat.GetMonthName(dateTime.Month);

            return fullMonthName;
        }

        public static bool IsTomorrowOfDate(this DateTime dateTime, DateTime potentialDayAfter)
        {
            var thisDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            var comparedDateTime = new DateTime(potentialDayAfter.Year, potentialDayAfter.Month, potentialDayAfter.Day);

            var resultDays = (comparedDateTime - thisDateTime).TotalDays;
            return resultDays.BetweenIE(1.0f, 2.0f);
        }

        public static DateTime GetDateOfHolidays(this DateTime date)
        {
            var currentDayOfWeek = date.DayOfWeek;
            var daysToHolidays = 5 - (int) currentDayOfWeek;

            return DateTime.Now.AddDays(daysToHolidays);
        }

        public static String GetHumanDateString(this DateTime date, DateTime today)
        {
            var dmyChecked = new DateTime(date.Year, date.Month, date.Day);
            var dmyCurrent = new DateTime(today.Year, today.Month, today.Day);

            if ((int) (dmyCurrent - dmyChecked).TotalDays == 0)
            {
                return "Сегодня";
            }

            if ((int) (dmyCurrent - dmyChecked).TotalDays == 1)
            {
                return "Вчера";
            }

            return String.Format("{0} {1}", dmyChecked.Day, dmyChecked.GetRussianMonthName().ToLower());
        }
    }
}