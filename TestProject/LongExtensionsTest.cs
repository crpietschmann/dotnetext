//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using dotNetExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class LongExtensionsTest
    {
        [TestMethod]
        public void ConvertFromUnixTimestamp_001()
        {
            long target = 30;
            var actual = LongExtensions.ConvertFromUnixTimestamp(target);
            var expected = new DateTime(1970, 1, 1, 0, 0, 30);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertFromUnixTimestamp_002()
        {
            long target = 90;
            var actual = LongExtensions.ConvertFromUnixTimestamp(target);
            var expected = new DateTime(1970, 1, 1, 0, 1, 30);
            Assert.AreEqual(expected, actual);
        }
    }
}
