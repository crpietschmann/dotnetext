using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotNetExt;

namespace TestProject
{
    [TestClass]
    public class CharExtensionsTest
    {
        [TestMethod]
        public void Char_Repeat_001()
        {
            var c = 's';
            var actual = c.Repeat(5);
            var expected = "sssss";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Char_Repeat_002()
        {
            var c = 's';
            var actual = c.Repeat(0);
            var expected = "";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Char_Repeat_003()
        {
            var c = 's';
            var actual = c.Repeat(-2);
        }
    }
}
