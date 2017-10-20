//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using dotNetExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject
{
    [TestClass]
    public class IPaginatedListExtensionsTest
    {
        [TestMethod]
        public void IPaginatedListExtensions_ToDataPage_001()
        {
            var arr = new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            };
            IPaginatedList<string> page = IEnumerableExtensions.ToPaginatedList(arr, 0, 5, 100);

            var actual = page.ToDataPage();

            Assert.AreEqual(page, actual.Data);
        }

        [TestMethod]
        public void IPaginatedListExtensions_ToDataPage_002()
        {
            var arr = new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            };
            IPaginatedList page = IEnumerableExtensions.ToPaginatedList(arr, 0, 5, 100);

            var actual = page.ToDataPage();

            Assert.AreEqual(page, actual.Data);
        }

        [TestMethod]
        public void IPaginatedListExtensions_ToDataPage_003()
        {
            var arr = new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            };
            IPaginatedList<string> page = IEnumerableExtensions.ToPaginatedList(arr, 0, 5, 100);

            var actual = ((IPaginatedList)page).ToDataPage();

            Assert.AreEqual(page, actual.Data);
        }
    }
}
