//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace dotNetExt
{
    using System;

    public static class IntExtensions
    {
        #region "IsOdd"

        /// <summary>
        /// Returns a boolean indicating whether this Integer is an Odd number.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool IsOdd(this int i)
        {
            return (i % 2) != 0;
        }

        #endregion

        #region "IsEven"

        /// <summary>
        /// Returns a boolean indicating whether this Integer is an Even number.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool IsEven(this int i)
        {
            return (i % 2) == 0;
        }

        #endregion

        #region "UpTo"

        /// <summary>
        /// Iterates from the Int through the specified stopAt and calls the specified Action for each passing in the iterator.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="stopAt"></param>
        /// <param name="action"></param>
        public static void UpTo(this int i, int stopAt, Action<int> action)
        {
            for (var a = i; a <= stopAt; a++)
            {
                action(a);
            }
        }

        #endregion

        #region WeekdayName
        
        /// <summary>
        /// Returns a string value containing the name of the specified weekday.
        /// </summary>
        /// <param name="i">The numeric designation for the weekday, from 1 through 7; 1 indicates the first day of the week and 7 indicates the last day of the week</param>
        /// <param name="abbreviation">Optional. Boolean value that indicates if the weekday name is to be abbreviated. Default is False</param>
        /// <returns></returns>
        public static string WeekdayName(this int i, bool abbreviation = false, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            if (i < 1 || i > 7)
            {
                throw new ArgumentOutOfRangeException("i", "Invalid value (" + i + "). Numeric weekday designation must be from 1 through 7.");
            }
            return Microsoft.VisualBasic.DateAndTime.WeekdayName(i, abbreviation, ConvertToFirstDayOfWeek(firstDayOfWeek));
        }

        private static Microsoft.VisualBasic.FirstDayOfWeek ConvertToFirstDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return Microsoft.VisualBasic.FirstDayOfWeek.Monday;
                case DayOfWeek.Tuesday:
                    return Microsoft.VisualBasic.FirstDayOfWeek.Tuesday;
                case DayOfWeek.Wednesday:
                    return Microsoft.VisualBasic.FirstDayOfWeek.Wednesday;
                case DayOfWeek.Thursday:
                    return Microsoft.VisualBasic.FirstDayOfWeek.Thursday;
                case DayOfWeek.Friday:
                    return Microsoft.VisualBasic.FirstDayOfWeek.Friday;
                case DayOfWeek.Saturday:
                    return Microsoft.VisualBasic.FirstDayOfWeek.Saturday;
                case DayOfWeek.Sunday:
                default:
                    return Microsoft.VisualBasic.FirstDayOfWeek.Sunday;
            }
        }
        #endregion

        #region "MonthName"

        /// <summary>
        /// Returns a string value containing the name of the specified month.
        /// </summary>
        /// <param name="i">The month number</param>
        /// <param name="abbreviation">Optional. Boolean value that indicates if the month name is to be abbreviated. Default is False</param>
        /// <returns></returns>
        public static string MonthName(this int i, bool abbreviation = false)
        {
            return Microsoft.VisualBasic.DateAndTime.MonthName(i, abbreviation);
        }

        #endregion

        #region "Between"

        /// <summary>
        /// Returns a boolean value indicating that the integer is "between" the low and high values specified. Ex: 1 is between 0 and 2, but 0 or 2 are not.
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static bool Between(this int i, int low, int high)
        {
            return i > low && i < high;
        }

        #endregion

        #region Times

        /// <summary>
        /// Executes the specified action the specified number of times, passing in the iterator value each time.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="action"></param>
        public static void Times(this int i, Action<int> action)
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException("i", "i must be not be less than zero.");
            }

            for (var c = 0; c < i; c++)
            {
                action(c);
            }
        }

        #endregion

        #region "TimeSpan extensions"

        /// <summary>
        /// Returns a TimeSpan that represents the integer in milliseconds
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static System.TimeSpan Milliseconds(this int i)
        {
            return TimeSpan.FromMilliseconds(i);
        }

        /// <summary>
        /// Returns a TimeSpan that represents the integer in seconds
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static System.TimeSpan Seconds(this int i)
        {
            return TimeSpan.FromSeconds(i);
        }

        /// <summary>
        /// Returns a TimeSpan that represents the integer in minutes
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static System.TimeSpan Minutes(this int i)
        {
            return TimeSpan.FromMinutes(i);
        }

        /// <summary>
        /// Returns a TimeSpan that represents the integer in hours
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static System.TimeSpan Hours(this int i)
        {
            return TimeSpan.FromHours(i);
        }

        /// <summary>
        /// Returns a TimeSpan that represents the integer in days
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static System.TimeSpan Days(this int i)
        {
            return TimeSpan.FromDays(i);
        }

        /// <summary>
        /// Returns a TimeSpan that represents the integer in weeks
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static System.TimeSpan Weeks(this int i)
        {
            return ((TimeSpanWrapper)i.Days() * 7);
        }

        #endregion
    }
}
