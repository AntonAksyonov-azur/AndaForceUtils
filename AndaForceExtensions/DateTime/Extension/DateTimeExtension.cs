using System;
using System.Globalization;
using AndaForceUtils.Variables;
using AndaForceUtils.Variables.Extension;

namespace AndaForceUtils.DateTime.Extension
{
    public static class DateTimeExtension
    {
        public const String RU = "ru-RU";
        public const String EN = "en-EN";

        public static String GetRussianAbbreviationDayOfWeek(this System.DateTime dateTime)
        {
            var culture = new CultureInfo("ru-RU");
            String shortDayOfWeek = culture.DateTimeFormat.GetAbbreviatedDayName(dateTime.DayOfWeek);

            return shortDayOfWeek;
        }

        public static String GetRussianMonthName(this System.DateTime dateTime)
        {
            var culture = new CultureInfo("ru-RU");
            String fullMonthName = culture.DateTimeFormat.GetMonthName(dateTime.Month);

            return fullMonthName;
        }

        public static bool IsTomorrowOfDate(this System.DateTime dateTime, System.DateTime potentialDayAfter)
        {
            var thisDateTime = new System.DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            var comparedDateTime = new System.DateTime(potentialDayAfter.Year, potentialDayAfter.Month, potentialDayAfter.Day);

            var resultDays = (comparedDateTime - thisDateTime).TotalDays;
            return resultDays.BetweenIE(1.0f, 2.0f);
        }

        public static System.DateTime GetDateOfHolidays(this System.DateTime date)
        {
            var currentDayOfWeek = date.DayOfWeek;
            var daysToHolidays = 5 - (int) currentDayOfWeek;

            return System.DateTime.Now.AddDays(daysToHolidays);
        }

        public static String GetHumanDateString(this System.DateTime date, System.DateTime today)
        {
            var dmyChecked = new System.DateTime(date.Year, date.Month, date.Day);
            var dmyCurrent = new System.DateTime(today.Year, today.Month, today.Day);

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