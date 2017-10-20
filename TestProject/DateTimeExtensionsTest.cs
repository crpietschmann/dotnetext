//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace TestProject
{
    using System;
    using dotNetExt;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///This is a test class for DateTimeExtensionsTest and is intended
    ///to contain all DateTimeExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DateTimeExtensionsTest
    {
        #region RoundToNearest
        
        [TestMethod]
        public void DateTime_RoundToNearest_001()
        {
            var dt = new DateTime(2012, 1, 26, 10, 06, 0);
            var expected = new DateTime(2012, 1, 26, 10, 0, 0);
            var actual = dt.RoundToNearest(15);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_002()
        {
            var dt = new DateTime(2012, 1, 26, 10, 07, 0);
            var expected = new DateTime(2012, 1, 26, 10, 0, 0);
            var actual = dt.RoundToNearest(15);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_003()
        {
            var dt = new DateTime(2012, 1, 26, 10, 08, 0);
            var expected = new DateTime(2012, 1, 26, 10, 15, 0);
            var actual = dt.RoundToNearest(15);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_004()
        {
            var dt = new DateTime(2012, 1, 26, 10, 16, 0);
            var expected = new DateTime(2012, 1, 26, 10, 15, 0);
            var actual = dt.RoundToNearest(15);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_005()
        {
            var dt = new DateTime(2012, 1, 26, 10, 29, 0);
            var expected = new DateTime(2012, 1, 26, 10, 30, 0);
            var actual = dt.RoundToNearest(15);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_006()
        {
            var dt = new DateTime(2012, 1, 26, 10, 59, 0);
            var expected = new DateTime(2012, 1, 26, 11, 0, 0);
            var actual = dt.RoundToNearest(15);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_007()
        {
            var dt = new DateTime(2012, 1, 26, 10, 06, 0);
            var expected = new DateTime(2012, 1, 26, 10, 0, 0);
            var actual = dt.RoundToNearest(15.Minutes());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_008()
        {
            var dt = new DateTime(2012, 1, 26, 10, 07, 0);
            var expected = new DateTime(2012, 1, 26, 10, 0, 0);
            var actual = dt.RoundToNearest(15.Minutes());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_009()
        {
            var dt = new DateTime(2012, 1, 26, 10, 08, 0);
            var expected = new DateTime(2012, 1, 26, 10, 15, 0);
            var actual = dt.RoundToNearest(15.Minutes());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_010()
        {
            var dt = new DateTime(2012, 1, 26, 10, 16, 0);
            var expected = new DateTime(2012, 1, 26, 10, 15, 0);
            var actual = dt.RoundToNearest(15.Minutes());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_011()
        {
            var dt = new DateTime(2012, 1, 26, 10, 29, 0);
            var expected = new DateTime(2012, 1, 26, 10, 30, 0);
            var actual = dt.RoundToNearest(15.Minutes());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_012()
        {
            var dt = new DateTime(2012, 1, 26, 10, 59, 0);
            var expected = new DateTime(2012, 1, 26, 11, 0, 0);
            var actual = dt.RoundToNearest(15.Minutes());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_013()
        {
            var dt = new DateTime(2012, 1, 26, 10, 59, 0);
            var expected = new DateTime(2012, 1, 26, 11, 0, 0);
            var actual = dt.RoundToNearest(1.Hours());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_014()
        {
            var dt = new DateTime(2012, 1, 26, 10, 15, 0);
            var expected = new DateTime(2012, 1, 26, 10, 0, 0);
            var actual = dt.RoundToNearest(1.Hours());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_015()
        {
            var dt = new DateTime(2012, 1, 26, 10, 30, 0);
            var expected = new DateTime(2012, 1, 26, 11, 0, 0);
            var actual = dt.RoundToNearest(1.Hours());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_016()
        {
            var dt = new DateTime(2012, 1, 26, 11, 0, 5);
            var expected = new DateTime(2012, 1, 26, 11, 0, 10);
            var actual = dt.RoundToNearest(10.Seconds());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_017()
        {
            var dt = new DateTime(2012, 1, 26, 11, 0, 2);
            var expected = new DateTime(2012, 1, 26, 11, 0, 0);
            var actual = dt.RoundToNearest(10.Seconds());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_018()
        {
            var dt = new DateTime(2012, 1, 26, 10, 15, 0);
            var expected = new DateTime(2012, 1, 26, 10, 15, 0);
            var actual = dt.RoundToNearest(15);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_019()
        {
            var dt = new DateTime(2012, 1, 26, 11, 0, 30);
            var expected = new DateTime(2012, 1, 26, 11, 0, 30);
            var actual = dt.RoundToNearest(10.Seconds());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_020()
        {
            var actual = DateTime.UtcNow.RoundToNearest(15);
            Assert.AreEqual(DateTimeKind.Utc, actual.Kind);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_021()
        {
            var actual = DateTime.Now.RoundToNearest(15);
            Assert.AreEqual(DateTimeKind.Local, actual.Kind);
        }

        [TestMethod]
        public void DateTime_RoundToNearest_022()
        {
            var actual = new DateTime(2012, 1, 1, 12, 14, 34);
            Assert.AreEqual(DateTimeKind.Unspecified, actual.Kind);
        }

        #endregion

        #region IsWeekend
        
        /// <summary>
        ///A test for IsWeekend
        ///</summary>
        [TestMethod()]
        public void DateTime_IsWeekend_001()
        {
            DateTime dt = new DateTime(2008, 07, 22);
            bool expected = false;
            bool actual;

            actual = dt.IsWeekend();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DateTime_IsWeekend_002()
        {
            DateTime dt = new DateTime(2008, 07, 20);
            bool expected = true;
            bool actual;

            actual = dt.IsWeekend();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DateTime_IsWeekend_003()
        {
            DateTime dt = new DateTime(2008, 07, 19);
            bool expected = true;
            bool actual;

            actual = dt.IsWeekend();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DateTime_IsWeekend_004()
        {
            DateTime dt = new DateTime(2008, 07, 25);
            bool expected = false;
            bool actual;

            actual = dt.IsWeekend();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region IsWeekDay

        /// <summary>
        ///A test for IsWeekDay
        ///</summary>
        [TestMethod()]
        public void DateTime_IsWeekDay_001()
        {
            DateTime dt = new DateTime(2008, 07, 22);
            bool expected = true;
            bool actual;

            actual = dt.IsWeekDay();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region EndOfDay

        [TestMethod]
        public void DateTime_EndOfDayTest_001()
        {
            var utc = DateTime.UtcNow;
            var d = new DateTime(utc.Year, utc.Month, utc.Day);

            var expected = new DateTime(utc.Year, utc.Month, utc.Day).AddDays(1).AddTicks(-1);
            var actual = d.EndOfDay();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region StartOfDay
        
        [TestMethod]
        public void DateTime_StartOfDayTest_001()
        {
            var utc = DateTime.UtcNow;
            var d = new DateTime(utc.Year, utc.Month, utc.Day);

            var expected = new DateTime(utc.Year, utc.Month, utc.Day, 0, 0, 0);
            var start = d.StartOfDay();

            Assert.AreEqual(expected, start);
        }

        #endregion

        #region StartOfMonth

        [TestMethod]
        public void DateTime_StartOfMonth_001()
        {
            var dt = new DateTime(2012, 1, 20, 15, 34, 13);
            var expected = new DateTime(2012, 1, 1, 0, 0, 0);
            var actual = dt.StartOfMonth();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region EndOfMonth
        
        [TestMethod]
        public void DateTime_EndOfMonth_001()
        {
            var dt = new DateTime(2012, 1, 20, 15, 34, 13);
            var expected = new DateTime(2012, 1, 31).AddDays(1).AddTicks(-1);
            var actual = dt.EndOfMonth();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region StartOfYear
        
        [TestMethod]
        public void DateTime_StartOfYear_001()
        {
            var dt = new DateTime(2012, 7, 20, 15, 34, 13);
            var expected = new DateTime(2012, 1, 1, 0, 0, 0);
            var actual = dt.StartOfYear();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_StartOfYear_002()
        {
            var dt = new DateTime(2012, 12, 31, 23, 59, 59);
            var expected = new DateTime(2012, 1, 1, 0, 0, 0);
            var actual = dt.StartOfYear();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_StartOfYear_003()
        {
            var dt = new DateTime(2012, 1, 1, 0, 0, 0);
            var expected = new DateTime(2012, 1, 1, 0, 0, 0);
            var actual = dt.StartOfYear();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region EndOfYear

        [TestMethod]
        public void DateTime_EndOfYear_001()
        {
            var dt = new DateTime(2012, 7, 20, 15, 34, 13);
            var expected = new DateTime(2012, 12, 31).AddDays(1).AddTicks(-1);
            var actual = dt.EndOfYear();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_EndOfYear_002()
        {
            var dt = new DateTime(2012, 1, 1, 0, 0, 0);
            var expected = new DateTime(2012, 12, 31).AddDays(1).AddTicks(-1);
            var actual = dt.EndOfYear();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTime_EndOfYear_003()
        {
            var dt = new DateTime(2012, 12, 31, 23, 59, 59);
            var expected = new DateTime(2012, 12, 31).AddDays(1).AddTicks(-1);
            var actual = dt.EndOfYear();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region "EndOfWeek Tests"

        [TestMethod]
        public void EndOfWeekTest01()
        {
            var end = (new DateTime(2011, 07, 17)).EndOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 23), end);
        }

        [TestMethod]
        public void EndOfWeekTest02()
        {
            var end = (new DateTime(2011, 07, 18)).EndOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 23), end);
        }

        [TestMethod]
        public void EndOfWeekTest03()
        {
            var end = (new DateTime(2011, 07, 19)).EndOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 23), end);
        }

        [TestMethod]
        public void EndOfWeekTest04()
        {
            var end = (new DateTime(2011, 07, 20)).EndOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 23), end);
        }

        [TestMethod]
        public void EndOfWeekTest05()
        {
            var end = (new DateTime(2011, 07, 21)).EndOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 23), end);
        }

        [TestMethod]
        public void EndOfWeekTest06()
        {
            var end = (new DateTime(2011, 07, 22)).EndOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 23), end);
        }

        [TestMethod]
        public void EndOfWeekTest07()
        {
            var end = (new DateTime(2011, 07, 23)).EndOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 23), end);
        }

        [TestMethod]
        public void EndOfWeekTest08()
        {
            var end = (new DateTime(2011, 07, 23)).EndOfWeek(DayOfWeek.Wednesday);
            Assert.AreEqual(new DateTime(2011, 07, 26), end);
        }

        [TestMethod]
        public void EndOfWeekTest09()
        {
            var end = (new DateTime(2011, 07, 23)).EndOfWeek(DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2011, 07, 28), end);
        }

        [TestMethod]
        public void EndOfWeekTest10()
        {
            var end = (new DateTime(2011, 07, 15)).EndOfWeek(DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2011, 07, 21), end);
        }

        [TestMethod]
        public void EndOfWeekTest11()
        {
            var end = (new DateTime(2011, 08, 19)).EndOfWeek(DayOfWeek.Saturday);
            Assert.AreEqual(new DateTime(2011, 08, 19), end);
        }

        #endregion

        #region "StartOfWeek Tests"

        [TestMethod]
        public void StartOfWeekTest01()
        {
            var start = (new DateTime(2011, 07, 17)).StartOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 17), start);
        }

        [TestMethod]
        public void StartOfWeekTest02()
        {
            var start = (new DateTime(2011, 07, 18)).StartOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 17), start);
        }

        [TestMethod]
        public void StartOfWeekTest03()
        {
            var start = (new DateTime(2011, 07, 19)).StartOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 17), start);
        }

        [TestMethod]
        public void StartOfWeekTest04()
        {
            var start = (new DateTime(2011, 07, 20)).StartOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 17), start);
        }

        [TestMethod]
        public void StartOfWeekTest05()
        {
            var start = (new DateTime(2011, 07, 21)).StartOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 17), start);
        }

        [TestMethod]
        public void StartOfWeekTest06()
        {
            var start = (new DateTime(2011, 07, 22)).StartOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 17), start);
        }

        [TestMethod]
        public void StartOfWeekTest07()
        {
            var start = (new DateTime(2011, 07, 23)).StartOfWeek();
            Assert.AreEqual(new DateTime(2011, 07, 17), start);
        }

        [TestMethod]
        public void StartOfWeekTest08()
        {
            var start = (new DateTime(2011, 07, 23)).StartOfWeek(DayOfWeek.Wednesday);
            Assert.AreEqual(new DateTime(2011, 07, 20), start);
        }

        [TestMethod]
        public void StartOfWeekTest09()
        {
            var start = (new DateTime(2011, 07, 15)).StartOfWeek(DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2011, 07, 15), start);
        }

        [TestMethod]
        public void StartOfWeekTest10()
        {
            var start = (new DateTime(2011, 07, 17)).StartOfWeek(DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2011, 07, 15), start);
        }

        [TestMethod]
        public void StartOfWeekTest11()
        {
            var start = (new DateTime(2011, 07, 18)).StartOfWeek(DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2011, 07, 15), start);
        }

        [TestMethod]
        public void StartOfWeekTest12()
        {
            var start = (new DateTime(2011, 07, 19)).StartOfWeek(DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2011, 07, 15), start);
        }

        [TestMethod]
        public void StartOfWeekTest13()
        {
            var start = (new DateTime(2011, 07, 20)).StartOfWeek(DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2011, 07, 15), start);
        }

        [TestMethod]
        public void StartOfWeekTest14()
        {
            var start = (new DateTime(2011, 07, 21)).StartOfWeek(DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2011, 07, 15), start);
        }

        [TestMethod]
        public void StartOfWeekTest15()
        {
            var start = (new DateTime(2011, 07, 16)).StartOfWeek(DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2011, 07, 15), start);
        }

        #endregion

        #region MillisecondsSince1970

        [TestMethod]
        public void MillisecondsSince1970_001()
        {
            var target = new DateTime(1970, 1, 1, 0, 0, 0);
            double actual = DateTimeExtensions.MillisecondsSince1970(target);
            double expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MillisecondsSince1970_002()
        {
            var target = new DateTime(1969, 12, 31, 23, 59, 0);
            double actual = DateTimeExtensions.MillisecondsSince1970(target);
            double expected = -60000;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MillisecondsSince1970_003()
        {
            var target = new DateTime(2006, 4, 16, 3, 15, 23);
            double actual = DateTimeExtensions.MillisecondsSince1970(target);
            double expected = 1145157323000;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region NextWeekDay

        [TestMethod]
        public void NextWeekDay001()
        {
            var target = new DateTime(2013, 6, 21);
            var actual = target.NextWeekDay();
            var expected = new DateTime(2013, 6, 24);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextWeekDay002()
        {
            var target = new DateTime(2013, 6, 22);
            var actual = target.NextWeekDay();
            var expected = new DateTime(2013, 6, 24);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextWeekDay003()
        {
            var target = new DateTime(2013, 6, 23);
            var actual = target.NextWeekDay();
            var expected = new DateTime(2013, 6, 24);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextWeekDay004()
        {
            var target = new DateTime(2013, 6, 24);
            var actual = target.NextWeekDay();
            var expected = new DateTime(2013, 6, 25);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region PreviousWeekDay

        [TestMethod]
        public void PreviousWeekDay001()
        {
            var target = new DateTime(2013, 6, 24);
            var actual = target.PreviousWeekDay();
            var expected = new DateTime(2013, 6, 21);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PreviousWeekDay002()
        {
            var target = new DateTime(2013, 6, 23);
            var actual = target.PreviousWeekDay();
            var expected = new DateTime(2013, 6, 21);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PreviousWeekDay003()
        {
            var target = new DateTime(2013, 6, 22);
            var actual = target.PreviousWeekDay();
            var expected = new DateTime(2013, 6, 21);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PreviousWeekDay004()
        {
            var target = new DateTime(2013, 6, 21);
            var actual = target.PreviousWeekDay();
            var expected = new DateTime(2013, 6, 20);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
