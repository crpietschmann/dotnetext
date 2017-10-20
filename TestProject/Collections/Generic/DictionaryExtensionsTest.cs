//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotNetExt;

namespace TestProject.Collections.Generic
{
    [TestClass]
    public class DictionaryExtensionsTest
    {
        [TestMethod]
        public void SortTest_001()
        {
            var d = new Dictionary<int, string>();
            d.Add(30, "Chris");
            d.Add(54, "Rick");
            d.Add(28, "Steve");

            var actual = d.Sort();

            Assert.AreEqual("Steve", actual.First().Value);
            Assert.AreEqual(54, actual.Last().Key);
        }

        public class SortTestComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return (-x).CompareTo(-y);
            }
        }

        [TestMethod]
        public void SortTest_002()
        {
            var d = new Dictionary<int, string>();
            d.Add(30, "Chris");
            d.Add(54, "Rick");
            d.Add(28, "Steve");

            var actual = d.Sort(new SortTestComparer());
            Assert.AreEqual("Steve", actual.Last().Value);
            Assert.AreEqual(54, actual.First().Key);
        }
    }
}
