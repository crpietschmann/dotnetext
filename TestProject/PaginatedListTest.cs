//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System.Collections.Generic;
using System.Linq;
using dotNetExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class PaginatedListTest
    {
        private static IQueryable<string> GetStringQuery()
        {
            return (new List<string> {
                "Chris","John","Steve","Katie","Sara","Susan","Scott","Kara","Michelle","Mitchel","Bob","Allen","Tim","Tom","Zeo","Chelsea","Sue","Tod","Joe","Bill"
            }).AsQueryable();
        }

        [TestMethod]
        public void PaginatedList_ConstructorTest_001()
        {
            var query = GetStringQuery();
            var page = (IPaginatedList)new PaginatedList(query, 1, 3);

            Assert.AreEqual(20, page.TotalCount);
            Assert.AreEqual(7, page.TotalPages);
            Assert.AreEqual(3, page.PageSize);
            Assert.IsTrue(page.HasNextPage);
            Assert.IsTrue(page.HasPreviousPage);
            Assert.AreEqual("Katie", page[0]);
            Assert.AreEqual("Sara", page[1]);
            Assert.AreEqual("Susan", page[2]);
        }

        [TestMethod]
        public void PaginatedList_ConstructorTest_002()
        {
            var query = GetStringQuery();
            var page = (IPaginatedList)new PaginatedList(query, 0, 3);

            Assert.AreEqual(20, page.TotalCount);
            Assert.AreEqual(7, page.TotalPages);
            Assert.AreEqual(3, page.PageSize);
            Assert.IsTrue(page.HasNextPage);
            Assert.IsFalse(page.HasPreviousPage);
            Assert.AreEqual("Chris", page[0]);
            Assert.AreEqual("John", page[1]);
            Assert.AreEqual("Steve", page[2]);
        }


        [TestMethod]
        public void PaginatedList_ConstructorTest_003()
        {
            var query = GetStringQuery();
            var page = (IPaginatedList)new PaginatedList(query, 6, 3);

            Assert.AreEqual(20, page.TotalCount);
            Assert.AreEqual(7, page.TotalPages);
            Assert.AreEqual(3, page.PageSize);
            Assert.IsFalse(page.HasNextPage);
            Assert.IsTrue(page.HasPreviousPage);
            Assert.AreEqual("Joe", page[0]);
            Assert.AreEqual("Bill", page[1]);
        }

        [TestMethod]
        public void PaginatedList_ConstructorTest_004()
        {
            var query = GetStringQuery();
            var page = (IPaginatedList)new PaginatedList(query, 1, query.Count(), 100);

            Assert.AreEqual(100, page.TotalCount);
            Assert.AreEqual(5, page.TotalPages);
            Assert.AreEqual(20, page.PageSize);
            Assert.IsTrue(page.HasNextPage);
            Assert.IsTrue(page.HasPreviousPage);
            Assert.AreEqual("Chris", page[0]);
            Assert.AreEqual("Bill", page[19]);
        }

        [TestMethod]
        public void PaginatedList_ConstructorTest_005()
        {
            var query = GetStringQuery();
            var page = (IPaginatedList)new PaginatedList(query, 0, query.Count(), 100);

            Assert.AreEqual(100, page.TotalCount);
            Assert.AreEqual(5, page.TotalPages);
            Assert.AreEqual(20, page.PageSize);
            Assert.IsTrue(page.HasNextPage);
            Assert.IsFalse(page.HasPreviousPage);
            Assert.AreEqual("Chris", page[0]);
            Assert.AreEqual("Bill", page[19]);
        }


        [TestMethod]
        public void PaginatedList_ConstructorTest_006()
        {
            var query = GetStringQuery();
            var page = (IPaginatedList)query.ToPaginatedList(4, query.Count(), 100);

            Assert.AreEqual(100, page.TotalCount);
            Assert.AreEqual(5, page.TotalPages);
            Assert.AreEqual(20, page.PageSize);
            Assert.IsFalse(page.HasNextPage);
            Assert.IsTrue(page.HasPreviousPage);
            Assert.AreEqual("Chris", page[0]);
            Assert.AreEqual("Bill", page[19]);
        }

        [TestMethod]
        public void PaginatedList_ConstructorTest_007()
        {
            var query = GetStringQuery();
            var page = (IPaginatedList)query.ToPaginatedList(4, 25, 120);

            Assert.AreEqual(120, page.TotalCount);
            Assert.AreEqual(5, page.TotalPages);
            Assert.AreEqual(25, page.PageSize);
            Assert.IsFalse(page.HasNextPage);
            Assert.IsTrue(page.HasPreviousPage);
            Assert.AreEqual("Chris", page[0]);
            Assert.AreEqual("Bill", page[19]);
        }
    }
}
