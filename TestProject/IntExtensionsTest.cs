//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace TestProject
{
    using System;
    using dotNetExt;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntExtensionsTest
    {
        #region IsOdd Tests
        
        [TestMethod]
        public void IntTest_IsOdd_001()
        {
            Assert.IsTrue(3.IsOdd());
        }

        [TestMethod]
        public void IntTest_IsOdd_002()
        {
            Assert.IsTrue(1.IsOdd());
        }

        [TestMethod]
        public void IntTest_IsOdd_003()
        {
            Assert.IsTrue(105.IsOdd());
        }

        [TestMethod]
        public void IntTest_IsOdd_004()
        {
            Assert.IsFalse(12.IsOdd());
        }

        #endregion

        #region IsEven Tests

        [TestMethod]
        public void IntTest_IsEven_001()
        {
            Assert.IsTrue(4.IsEven());
        }

        [TestMethod]
        public void IntTest_IsEven_002()
        {
            Assert.IsTrue(42.IsEven());
        }

        [TestMethod]
        public void IntTest_IsEven_003()
        {
            Assert.IsFalse(15.IsEven());
        }

        #endregion

        #region WeekdayName Tests

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IntExtensionsTest_WeekdayNameTest001()
        {
            var day = 0.WeekdayName();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IntExtensionsTest_WeekdayNameTest002()
        {
            var day = 8.WeekdayName();
        }

        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest003()
        {
            var day = 1.WeekdayName();
            Assert.AreEqual("Sunday", day);
        }

        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest004()
        {
            var day = 2.WeekdayName();
            Assert.AreEqual("Monday", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest005()
        {
            var day = 3.WeekdayName();
            Assert.AreEqual("Tuesday", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest006()
        {
            var day = 4.WeekdayName();
            Assert.AreEqual("Wednesday", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest007()
        {
            var day = 5.WeekdayName();
            Assert.AreEqual("Thursday", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest008()
        {
            var day = 6.WeekdayName();
            Assert.AreEqual("Friday", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest009()
        {
            var day = 7.WeekdayName();
            Assert.AreEqual("Saturday", day);
        }

        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest010()
        {
            var day = 1.WeekdayName(true);
            Assert.AreEqual("Sun", day);
        }

        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest011()
        {
            var day = 2.WeekdayName(true);
            Assert.AreEqual("Mon", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest012()
        {
            var day = 3.WeekdayName(true);
            Assert.AreEqual("Tue", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest013()
        {
            var day = 4.WeekdayName(true);
            Assert.AreEqual("Wed", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest0014()
        {
            var day = 5.WeekdayName(true);
            Assert.AreEqual("Thu", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest015()
        {
            var day = 6.WeekdayName(true);
            Assert.AreEqual("Fri", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest016()
        {
            var day = 7.WeekdayName(true);
            Assert.AreEqual("Sat", day);
        }
        
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest017()
        {
            var day = 1.WeekdayName(true, DayOfWeek.Monday);
            Assert.AreEqual("Mon", day);
        }

        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest018()
        {
            var day = 2.WeekdayName(true, DayOfWeek.Monday);
            Assert.AreEqual("Tue", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest019()
        {
            var day = 3.WeekdayName(true, DayOfWeek.Monday);
            Assert.AreEqual("Wed", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest020()
        {
            var day = 4.WeekdayName(true, DayOfWeek.Monday);
            Assert.AreEqual("Thu", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest021()
        {
            var day = 5.WeekdayName(true, DayOfWeek.Monday);
            Assert.AreEqual("Fri", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest022()
        {
            var day = 6.WeekdayName(true, DayOfWeek.Monday);
            Assert.AreEqual("Sat", day);
        }
        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest023()
        {
            var day = 7.WeekdayName(true, DayOfWeek.Monday);
            Assert.AreEqual("Sun", day);
        }

        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest024()
        {
            var day = 7.WeekdayName(true, DayOfWeek.Tuesday);
            Assert.AreEqual("Mon", day);
        }

        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest025()
        {
            var day = 7.WeekdayName(true, DayOfWeek.Wednesday);
            Assert.AreEqual("Tue", day);
        }

        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest026()
        {
            var day = 7.WeekdayName(true, DayOfWeek.Thursday);
            Assert.AreEqual("Wed", day);
        }

        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest027()
        {
            var day = 7.WeekdayName(true, DayOfWeek.Friday);
            Assert.AreEqual("Thu", day);
        }

        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest028()
        {
            var day = 7.WeekdayName(true, DayOfWeek.Saturday);
            Assert.AreEqual("Fri", day);
        }

        [TestMethod]
        public void IntExtensionsTest_WeekdayNameTest029()
        {
            var day = 7.WeekdayName(true, DayOfWeek.Sunday);
            Assert.AreEqual("Sat", day);
        }

        #endregion

        #region "MonthName Tests"

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void IntExtensionsTest_MonthNameTest00()
        {
            var month = 0.MonthName();
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest01()
        {
            var month = 1.MonthName();
            Assert.AreEqual("January", month);
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest02()
        {
            var month = 2.MonthName();
            Assert.AreEqual("February", month);
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest03()
        {
            var month = 3.MonthName();
            Assert.AreEqual("March", month);
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest04()
        {
            var month = 4.MonthName();
            Assert.AreEqual("April", month);
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest05()
        {
            var month = 5.MonthName();
            Assert.AreEqual("May", month);
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest06()
        {
            var month = 6.MonthName();
            Assert.AreEqual("June", month);
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest07()
        {
            var month = 7.MonthName();
            Assert.AreEqual("July", month);
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest08()
        {
            var month = 8.MonthName();
            Assert.AreEqual("August", month);
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest09()
        {
            var month = 9.MonthName();
            Assert.AreEqual("September", month);
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest10()
        {
            var month = 10.MonthName();
            Assert.AreEqual("October", month);
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest11()
        {
            var month = 11.MonthName();
            Assert.AreEqual("November", month);
        }

        [TestMethod]
        public void IntExtensionsTest_MonthNameTest12()
        {
            var month = 12.MonthName();
            Assert.AreEqual("December", month);
        }

        #endregion

        #region "Between Tests"

        [TestMethod]
        public void IntExtensionsTest_BetweenTest01()
        {
            Assert.IsTrue(1.Between(0, 2));
        }

        [TestMethod]
        public void IntExtensionsTest_BetweenTest02()
        {
            Assert.IsTrue((-1).Between(-2, 0));
        }


        [TestMethod]
        public void IntExtensionsTest_BetweenTest03()
        {
            Assert.IsTrue(42.Between(0, 100));
        }


        [TestMethod]
        public void IntExtensionsTest_BetweenTest04()
        {
            Assert.IsFalse(1.Between(50, 100));
        }


        [TestMethod]
        public void IntExtensionsTest_BetweenTest05()
        {
            Assert.IsFalse(1.Between(100, 50));
        }

        #endregion

        #region "Times Tests"

        [TestMethod]
        public void IntExtensionsTest_TimesTest01()
        {
            var count = 0;
            5.Times(i => count++);
            Assert.AreEqual(5, count);
        }

        [TestMethod]
        public void IntExtensionsTest_TimesTest02()
        {
            var total = 0;
            var count = 0;
            10.Times(i =>
            {
                total += i;
                count++;
            });
            Assert.AreEqual(45, total);
            Assert.AreEqual(10, count);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IntExtensionsTest_TimesTest03()
        {
            (-6).Times(i => { });
        }

        #endregion

        #region "TimeSpan Tests"

        [TestMethod]
        public void IntExtensionsTest_MillisecondsTest01()
        {
            var ts = 50.Milliseconds();
            Assert.AreEqual(new TimeSpan(0, 0, 0, 0, 50), ts);
        }

        [TestMethod]
        public void IntExtensionsTest_SecondsTest01()
        {
            var ts = 15.Seconds();
            Assert.AreEqual(new TimeSpan(0, 0, 15), ts);
        }

        [TestMethod]
        public void IntExtensionsTest_HoursTest01()
        {
            var ts = 2.Hours();
            Assert.AreEqual(new TimeSpan(2, 0, 0), ts);
        }

        [TestMethod]
        public void IntExtensionsTest_DaysTest01()
        {
            var ts = 3.Days();
            Assert.AreEqual(new TimeSpan(3, 0, 0, 0), ts);
        }

        [TestMethod]
        public void IntExtensionsTest_WeeksTest01()
        {
            var ts = 3.Weeks();
            Assert.AreEqual(new TimeSpan(21, 0, 0, 0), ts);
        }

        [TestMethod]
        public void IntExtensionsTest_MinutesTest01()
        {
            var ts = 5.Minutes();
            Assert.AreEqual(new TimeSpan(0, 5, 0), ts);
        }

        #endregion

        #region "UpTo Tests"

        [TestMethod]
        public void IntExtensionsTest_UpToTest01()
        {
            var expected = 15;
            var actual = 0;
            var count = 0;
            1.UpTo(5, (i) =>
            {
                actual += i;
                count++;
            });
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(5, count);
        }

        #endregion
    }
}
