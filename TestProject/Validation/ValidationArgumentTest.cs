//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace TestProject.Validation
{
    using dotNetExt.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidationArgumentTest
    {
        [TestMethod]
        public void ValidationArgumentTest_001()
        {
            var v = new ValidationArgument<int>("Test", 42);

            Assert.AreEqual("Test", v.Name);
            Assert.AreEqual(42, v.Value);
        }

        [TestMethod]
        public void ValidationArgumentTest_002()
        {
            var v = new ValidationArgument<int>("Test", 42);

            var actual = 1 + v;

            Assert.AreEqual(43, actual);
        }

        [TestMethod]
        public void ValidationArgumentTest_003()
        {
            var v = new ValidationArgument<string>("Test", "Chri");

            var actual = v + "s";

            Assert.AreEqual("Chris", actual);
        }
    }
}
