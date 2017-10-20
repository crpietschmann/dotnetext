//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace TestProject
{
    using System;
    using dotNetExt;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    /// <summary>
    ///This is a test class for IEnumerableExtensionsTest and is intended
    ///to contain all IEnumerableExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IEnumerableExtensionsTest
    {
        #region ToPaginatedList

        private static IList<string> GetStringQuery()
        {
            return (new List<string> {
                "Chris","John","Steve","Katie","Sara","Susan","Scott","Kara","Michelle","Mitchel","Bob","Allen","Tim","Tom","Zeo","Chelsea","Sue","Tod","Joe","Bill"
            });
        }

        [TestMethod]
        public void ToPaginatedListTest_001()
        {
            var query = GetStringQuery();
            var page = query.AsEnumerable().ToPaginatedList(1, 3);

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
        public void ToPaginatedListTest_002()
        {
            var query = GetStringQuery();
            var page = query.AsEnumerable().ToPaginatedList(0, 3);

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
        public void ToPaginatedListTest_003()
        {
            var query = GetStringQuery();
            var page = query.AsEnumerable().ToPaginatedList(6, 3);

            Assert.AreEqual(20, page.TotalCount);
            Assert.AreEqual(7, page.TotalPages);
            Assert.AreEqual(3, page.PageSize);
            Assert.IsFalse(page.HasNextPage);
            Assert.IsTrue(page.HasPreviousPage);
            Assert.AreEqual("Joe", page[0]);
            Assert.AreEqual("Bill", page[1]);
        }

        [TestMethod]
        public void ToPaginatedListTest_004()
        {
            var query = GetStringQuery();
            var page = query.AsEnumerable().ToPaginatedList(1, query.Count(), 100);

            Assert.AreEqual(100, page.TotalCount);
            Assert.AreEqual(5, page.TotalPages);
            Assert.AreEqual(20, page.PageSize);
            Assert.IsTrue(page.HasNextPage);
            Assert.IsTrue(page.HasPreviousPage);
            Assert.AreEqual("Chris", page[0]);
            Assert.AreEqual("Bill", page[19]);
        }

        [TestMethod]
        public void ToPaginatedListTest_005()
        {
            var query = GetStringQuery();
            var page = query.AsEnumerable().ToPaginatedList(0, query.Count(), 100);

            Assert.AreEqual(100, page.TotalCount);
            Assert.AreEqual(5, page.TotalPages);
            Assert.AreEqual(20, page.PageSize);
            Assert.IsTrue(page.HasNextPage);
            Assert.IsFalse(page.HasPreviousPage);
            Assert.AreEqual("Chris", page[0]);
            Assert.AreEqual("Bill", page[19]);
        }


        [TestMethod]
        public void ToPaginatedListTest_006()
        {
            var query = GetStringQuery();
            var page = query.AsEnumerable().ToPaginatedList(4, query.Count(), 100);

            Assert.AreEqual(100, page.TotalCount);
            Assert.AreEqual(5, page.TotalPages);
            Assert.AreEqual(20, page.PageSize);
            Assert.IsFalse(page.HasNextPage);
            Assert.IsTrue(page.HasPreviousPage);
            Assert.AreEqual("Chris", page[0]);
            Assert.AreEqual("Bill", page[19]);
        }

        [TestMethod]
        public void ToPaginatedListTest_007()
        {
            var query = GetStringQuery().ToArray();
            var page = query.ToPaginatedList(1, 3);

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
        public void ToPaginatedListTest_008()
        {
            var query = GetStringQuery().ToArray();
            var page = query.ToPaginatedList(4, query.Count(), 100);

            Assert.AreEqual(100, page.TotalCount);
            Assert.AreEqual(5, page.TotalPages);
            Assert.AreEqual(20, page.PageSize);
            Assert.IsFalse(page.HasNextPage);
            Assert.IsTrue(page.HasPreviousPage);
            Assert.AreEqual("Chris", page[0]);
            Assert.AreEqual("Bill", page[19]);
        }

        #endregion

        #region Each

        [TestMethod]
        public void EachTest001()
        {
            var arr = new string[] {
                "Chris", "Steve", "John"
            };

            var totalLength = 0;

            arr.Each(d => totalLength += d.Length);

            Assert.AreEqual(14, totalLength);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void EachTest002()
        {
            string[] arr = null;
            var i = 0;
            arr.Each(d => i = d.Length);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void EachTest003()
        {
            var arr = new int[] { 1, 2, 3 };
            arr.Each(null);
        }

        [TestMethod]
        public void EachTest004()
        {
            IEnumerable arr = new string[] {
                "Chris", "Steve", "John"
            };

            var totalLength = 0;

            arr.Each(d => totalLength += d.ToString().Length);

            Assert.AreEqual(14, totalLength);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void EachTest005()
        {
            IEnumerable arr = null;
            var i = 0;
            arr.Each(d => i = d.ToString().Length);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void EachTest006()
        {
            IEnumerable arr = new string[] { "1", "2", "3" };
            arr.Each(null);
        }

        #endregion

        #region Contains

        [TestMethod]
        public void ContainsTest001()
        {
            var arr = new string[]
            {
                "Chris", "John", "Steve"
            };
            Assert.IsTrue(arr.Contains(d => d == "Chris"));
            Assert.IsTrue(arr.Contains(d => d.StartsWith("Ste")));
            Assert.IsFalse(arr.Contains(d => d == "Miley"));
            Assert.IsFalse(arr.Contains(d => d.EndsWith("z")));
        }

        public class ContainsTestObject
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        [TestMethod]
        public void ContainsTest002()
        {
            IEnumerable<ContainsTestObject> arr = new List<ContainsTestObject>
            {
                new ContainsTestObject { FirstName = "Chris", LastName = "Pietschmann", Age = 30 },
                new ContainsTestObject { FirstName = "John", LastName = "Doe", Age = 54 },
                new ContainsTestObject { FirstName = "Steve", LastName = "Johnson", Age = 28 }
            };
            Assert.IsTrue(arr.Contains(d => d.FirstName == "Chris"));
            Assert.IsTrue(arr.Contains(d => d.Age <= 30));
            Assert.IsFalse(arr.Contains(d => d.FirstName.EndsWith("z")));
            Assert.IsFalse(arr.Contains(d => d.Age > 65));
        }

        #endregion

        #region "IsEmpty Tests"

        [TestMethod]
        public void IsEmptyTest01()
        {
            var arr = new string[0];
            Assert.IsTrue(arr.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyTest02()
        {
            var arr = new string[] { "Chris", "John" };
            Assert.IsFalse(arr.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsEmptyTest03()
        {
            string[] arr = null;
            arr.IsEmpty();
        }

        [TestMethod]
        public void IsEmptyTest04()
        {
            System.Collections.IEnumerable v = new int[] { 1, 2, 3 };
            var actual = v.IsEmpty();
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void IsEmptyTest05()
        {
            System.Collections.IEnumerable v = new int[0];
            var actual = v.IsEmpty();
            Assert.AreEqual(true, actual);
        }

        #endregion

        #region "IsNullOrEmpty Tests"

        [TestMethod]
        public void IsNullOrEmptyTest01()
        {
            var arr = new string[0];
            Assert.IsTrue(arr.IsNullOrEmpty());
        }

        [TestMethod]
        public void IsNullOrEmptyTest02()
        {
            var arr = new string[] { "Chris", "John" };
            Assert.IsFalse(arr.IsNullOrEmpty());
        }

        [TestMethod]
        public void IsNullOrEmptyTest03()
        {
            string[] arr = null;
            Assert.IsTrue(arr.IsNullOrEmpty());
        }

        [TestMethod]
        public void IsNullOrEmptyTest04()
        {
            Assert.IsTrue(string.Empty.IsNullOrEmpty());
        }

        [TestMethod]
        public void IsNullOrEmptyTest05()
        {
            Assert.IsFalse("Chris".IsNullOrEmpty());
        }

        [TestMethod]
        public void IsNullOrEmptyTest06()
        {
            string str = null;
            Assert.IsTrue(str.IsNullOrEmpty());
        }

        #endregion
    }
}
