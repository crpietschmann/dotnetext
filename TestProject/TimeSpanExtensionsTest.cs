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
    public class TimeSpanExtensionsTest
    {
        #region "Ago & UtcAgo Tests"

        [TestMethod]
        public void AgoTest01()
        {
            var actual = 3.Days().Ago();
            var expected = DateTime.Now.Subtract(3.Days());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AgoTest02()
        {
            var actual = 3.Minutes().Ago();
            actual.AddMilliseconds(-(actual.Millisecond));

            var expected = DateTime.Now.Subtract(3.Minutes());
            expected.AddMilliseconds(-(expected.Millisecond));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UtcAgoTest01()
        {
            var actual = 3.Days().UtcAgo();
            var expected = DateTime.UtcNow.Subtract(3.Days());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UtcAgoTest02()
        {
            var actual = 3.Minutes().UtcAgo();
            var expected = DateTime.UtcNow.Subtract(3.Minutes());
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region "FromNow & UtcFromNow Tests"

        [TestMethod]
        public void FromNowTest01()
        {
            var actual = 3.Minutes().FromNow();
            var expected = DateTime.Now.Add(3.Minutes());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FromNowTest02()
        {
            var actual = 3.Days().FromNow();
            var expected = DateTime.Now.Add(3.Days());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UtcFromNowTest01()
        {
            var actual = 3.Minutes().UtcFromNow();
            var expected = DateTime.UtcNow.Add(3.Minutes());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UtcFromNowTest02()
        {
            var actual = 3.Days().UtcFromNow();
            var expected = DateTime.UtcNow.Add(3.Days());
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
