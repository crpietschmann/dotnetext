//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using dotNetExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class DataPageTests
    {
        [TestMethod]
        public void DataPage_Constructor_001()
        {
            var arr = new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            };
            var page = arr.ToPaginatedList(0, 5, 100);
            var target = new DataPage(page);
            Assert.AreEqual(page, target.Data);
        }

        [TestMethod]
        public void DataPage_PageIndex_001()
        {
            var page = new PaginatedList(new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            }, 0, 5, 100);
            var target = new DataPage(page);
            Assert.AreEqual(0, target.PageIndex);
        }

        [TestMethod]
        public void DataPage_TotalCount_001()
        {
            var page = new PaginatedList(new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            }, 0, 5, 100);
            var target = new DataPage(page);
            Assert.AreEqual(100, target.TotalCount);
        }

        [TestMethod]
        public void DataPage_TotalPages_001()
        {
            var page = new PaginatedList(new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            }, 0, 5, 100);
            var target = new DataPage(page);
            Assert.AreEqual(20, target.TotalPages);
        }

        [TestMethod]
        public void DataPage_Generic_Constructor_001()
        {
            var arr = (new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            }).AsQueryable();
            var page = arr.ToPaginatedList(0, 5, 100);
            var target = new DataPage<string>(page);
            Assert.AreEqual(page, target.Data);
        }

        [TestMethod]
        public void DataPage_Generic_Constructor_002()
        {
            var arr = (new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            }).AsQueryable();
            var page = arr.ToPaginatedList(0, 5, 100);
            var target = new DataPage<string>(page);
            Assert.AreEqual(page, ((IDataPage)target).Data);
        }

        [TestMethod]
        public void DataPage_Generic_PageIndex_001()
        {
            var page = new PaginatedList<string>((new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            }).AsQueryable(), 0, 5, 100);
            var target = new DataPage<string>(page);
            Assert.AreEqual(0, target.PageIndex);
        }

        [TestMethod]
        public void DataPage_Generic_TotalCount_001()
        {
            var page = new PaginatedList<string>((new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            }).AsQueryable(), 0, 5, 100);
            var target = new DataPage<string>(page);
            Assert.AreEqual(100, target.TotalCount);
        }

        [TestMethod]
        public void DataPage_Generic_TotalPages_001()
        {
            var page = new PaginatedList<string>((new string[]{
                "ONE", "TWO", "THREE", "FOUR", "FIVE"
            }).AsQueryable(), 0, 5, 100);
            var target = new DataPage<string>(page);
            Assert.AreEqual(20, target.TotalPages);
        }
    }
}
