//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using dotNetExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class EnumExtensionsTest
    {
        public enum TestEnum1
        {
            [System.ComponentModel.Description("1")]
            First,

            Second
        }

        [TestMethod]
        public void ToDescriptionString_001()
        {
            var actual = EnumExtensions.ToDescriptionString(TestEnum1.First);
            var expected = "1";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDescriptionString_002()
        {
            var actual = EnumExtensions.ToDescriptionString(TestEnum1.Second);
            var expected = "Second";
            Assert.AreEqual(expected, actual);
        }
    }
}
