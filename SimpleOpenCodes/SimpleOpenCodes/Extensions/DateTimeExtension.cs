using System;

namespace SimpleOpenCodes.Extensions
{
    /// <summary>
    /// The extension methods of the DateTime structure.
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Returns a new DateTime instance that is a copy of this instance. 
        /// </summary>
        public static DateTime Copy(this DateTime source)
        {
            var value = new DateTime(source.Ticks);
            return value;
        }

        /// <summary>
        /// Returns a new DateTime that is the beginning of the year of this instance.
        /// </summary>
        public static DateTime GetBeginningOfTheYear(this DateTime source)
        {
            var year = source.Year;
            var value = new DateTime(year, 1, 1);
            return value;
        }

        /// <summary>
        /// Returns a new DateTime that is the end of the year of this instance.
        /// </summary>
        public static DateTime GetEndOfTheYear(this DateTime source)
        {
            var year = source.Year;
            var value = source.GetBeginningOfTheYear().AddYears(1).AddDays(-1);
            return value;
        }

        /// <summary>
        /// Returns a new DateTime that is the beginning of the month of this instance.
        /// </summary>
        public static DateTime GetBeginningOfTheMonth(this DateTime source)
        {
            var year = source.Year;
            var month = source.Month;
            var value = new DateTime(year, month, 1);
            return value;
        }

        /// <summary>
        /// Returns a new DateTime that is the end of the month of this instance.
        /// </summary>
        public static DateTime GetEndOfTheMonth(this DateTime source)
        {
            var value = source.GetBeginningOfTheMonth().AddMonths(1).AddDays(-1);
            return value;
        }

        /// <summary>
        /// Returns a new DateTime that is the beginning of the week of this instance.
        /// </summary>
        public static DateTime GetBeginningOfTheWeek(this DateTime source)
        {
            var dow = source.DayOfWeek;
            var offset = 0;
            // offset = (int)dow; // do not code like this.
            switch (dow)
            {
                case DayOfWeek.Sunday:
                    offset = 0;
                    break;
                case DayOfWeek.Monday:
                    offset = 1;
                    break;
                case DayOfWeek.Tuesday:
                    offset = 2;
                    break;
                case DayOfWeek.Wednesday:
                    offset = 3;
                    break;
                case DayOfWeek.Thursday:
                    offset = 4;
                    break;
                case DayOfWeek.Friday:
                    offset = 5;
                    break;
                case DayOfWeek.Saturday:
                    offset = 6;
                    break;
            }
            var year = source.Year;
            var month = source.Month;
            var day = source.Day - offset;
            var value = new DateTime(year, month, day);
            return value;
        }

        /// <summary>
        /// Returns a new DateTime that is the end of the week of this instance.
        /// </summary>
        public static DateTime GetEndOfTheWeek(this DateTime source)
        {
            var value = source.GetBeginningOfTheWeek().AddDays(7 - 1);
            return value;
        }
    }
}
