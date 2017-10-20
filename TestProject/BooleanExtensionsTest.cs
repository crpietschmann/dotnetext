//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace TestProject
{
    using dotNetExt;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class BooleanExtensionsTest
    {
        [TestMethod()]
        public void ToBinary_001()
        {
            Assert.AreEqual(1, true.ToBinary());
        }

        [TestMethod()]
        public void ToBinary_002()
        {
            Assert.AreEqual(0, false.ToBinary());
        }

        [TestMethod()]
        public void IfTrue_001()
        {
            var v = true;
            bool actual = false;
            v.IfTrue(() => { actual = true; });
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void IfTrue_002()
        {
            var v = false;
            bool actual = false;
            v.IfTrue(() => { actual = true; });
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void IfFalse_001()
        {
            var v = false;
            bool actual = false;
            v.IfFalse(() => { actual = true; });
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void IfFalse_002()
        {
            var v = true;
            bool actual = false;
            v.IfFalse(() => { actual = true; });
            Assert.IsFalse(actual);
        }
    }
}
