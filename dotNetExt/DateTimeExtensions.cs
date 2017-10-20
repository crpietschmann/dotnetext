//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotNetExt
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns whether the DateTime is on a Weekend.
        /// </summary>
        /// <param name="dt">Required. The DateTime to evaluate.</param>
        /// <returns>Returns whether the DateTime is on a Weekend.</returns>
        public static bool IsWeekend(this System.DateTime dt)
        {
            return (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday);
        }

        /// <summary>
        /// Returns whether the DateTime is on a Week Day.
        /// </summary>
        /// <param name="dt">Required. The DateTime to evaluate.</param>
        /// <returns>Returns whether the DateTime is on a Week Day.</returns>
        public static bool IsWeekDay(this System.DateTime dt)
        {
            return !dt.IsWeekend();
        }

        /// <summary>
        /// Returns the Date portion of the specified DateTime with the Time set to "23:59:59". The last moment of the day.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static System.DateTime EndOfDay(this System.DateTime dt)
        {
            //return new System.DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            return dt.Date.AddDays(1).AddTicks(-1);
        }

        /// <summary>
        /// Returns the Date portion of the specified DateTime with the Time set to "00:00:00". The first moment of the day.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static System.DateTime StartOfDay(this System.DateTime dt)
        {
            //return new System.DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
            return dt.Date;
        }

        /// <summary>
        /// Returns the Date of the first day in the same Month as the specified DateTime, with the Time set to "00:00:00"
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static System.DateTime StartOfMonth(this System.DateTime dt)
        {
            return new System.DateTime(dt.Year, dt.Month, 1).StartOfDay();
        }

        /// <summary>
        /// Returns the Date of the last day in the same Month as the specified DateTime, with the Time set to "23:59:59"
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static System.DateTime EndOfMonth(this System.DateTime dt)
        {
            return dt.AddMonths(1).StartOfMonth().AddDays(-1).EndOfDay();
        }

        /// <summary>
        /// Returns the Date of the first day in the same year as the specified DateTime, with the Time set to "00:00:00"
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime StartOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1).StartOfDay();
        }

        /// <summary>
        /// Returns the Date of the last day in the same year as the specified DateTime, with the Time set to "23:59:59"
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 12, 31).EndOfDay();
        }

        /// <summary>
        /// Returns the start of day for the first day in the week of the specified DateTime.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startDayOfWeek">Optional. The DayOfWeek that is the first day of the week. Default is Sunday.</param>
        /// <returns></returns>
        public static System.DateTime StartOfWeek(this System.DateTime dt, DayOfWeek startDayOfWeek = DayOfWeek.Sunday)
        {
            var start = dt.StartOfDay();

            if (start.DayOfWeek != startDayOfWeek)
            {
                var d = startDayOfWeek - start.DayOfWeek;
                if (startDayOfWeek <= start.DayOfWeek)
                {
                    return start.AddDays(d);
                }
                else
                {
                    return start.AddDays(-7 + d);
                }
            }

            return start;
        }

        /// <summary>
        /// Returns the start of day for the last day in the week of the specified DateTime.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startDayOfWeek">Optional. The DayOfWeek that is the first day of the week. Default is Sunday.</param>
        /// <returns></returns>
        public static System.DateTime EndOfWeek(this System.DateTime dt, DayOfWeek startDayOfWeek = DayOfWeek.Sunday)
        {
            var end = dt.StartOfDay();
            var endDayOfWeek = startDayOfWeek - 1;
            if (endDayOfWeek < 0)
            {
                endDayOfWeek = DayOfWeek.Saturday;
            }

            if (end.DayOfWeek != endDayOfWeek)
            {
                if (endDayOfWeek < end.DayOfWeek)
                {
                    return end.AddDays(7 - (end.DayOfWeek - endDayOfWeek));
                }
                else
                {
                    return end.AddDays(endDayOfWeek - end.DayOfWeek);
                }
            }

            return end;
        }

        /// <summary>
        /// Rounds the DateTime to the nearest specified number of minutes
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static DateTime RoundToNearest(this DateTime dt, int minutes)
        {
            return dt.RoundToNearest(minutes.Minutes());
        }

        /// <summary>
        /// Rounds the DateTime to the nearest specifie TimeSpan internal
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static DateTime RoundToNearest(this DateTime dt, TimeSpan timeSpan)
        {
            var roundDown = false;
            var mod = (dt.Ticks % timeSpan.Ticks);
            if (mod != 0 && mod < (timeSpan.Ticks / 2))
            {
                roundDown = true;
            }

            var ticks = (((dt.Ticks + timeSpan.Ticks - 1) / timeSpan.Ticks) - (roundDown ? 1 : 0)) * timeSpan.Ticks;

            var addticks = ticks - dt.Ticks;

            return dt.AddTicks(addticks);
        }

        /// <summary>
        /// Returns the number of milliseconds from January 1st, 1970 until the specified DateTime
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static double MillisecondsSince1970(this DateTime dt)
        {
            return dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds;
        }

        /// <summary>
        /// Returns the DateTime of the next week day after the given DateTime.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static System.DateTime NextWeekDay(this System.DateTime dt)
        {
            var dayOfWeek = dt.DayOfWeek;
            double daysToAdd = 1;

            if (dayOfWeek == DayOfWeek.Friday)
            {
                daysToAdd = 3;
            }
            else if (dayOfWeek == DayOfWeek.Saturday)
            {
                daysToAdd = 2;
            }

            return dt.AddDays(daysToAdd);
        }

        /// <summary>
        /// Returns the DateTime of the previous week day before the given DateTime.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static System.DateTime PreviousWeekDay(this System.DateTime dt)
        {
            var dayOfWeek = dt.DayOfWeek;
            double daysToAdd = -1;

            if (dayOfWeek == DayOfWeek.Monday)
            {
                daysToAdd = -3;
            }
            else if (dayOfWeek == DayOfWeek.Sunday)
            {
                daysToAdd = -2;
            }

            return dt.AddDays(daysToAdd);
        }
    }
}
