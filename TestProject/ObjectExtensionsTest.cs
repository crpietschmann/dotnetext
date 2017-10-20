//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace TestProject
{
    using System;
    using dotNetExt;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Dynamic;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    /// <summary>
    ///This is a test class for ObjectExtensionsTest and is intended
    ///to contain all ObjectExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ObjectExtensionsTest
    {
        //private TestContext testContextInstance;

        ///// <summary>
        /////Gets or sets the test context which provides
        /////information about and functionality for the current test run.
        /////</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for IsType
        ///</summary>
        [TestMethod()]
        public void IsTypeTest()
        {
            String obj = "";
            Type type = typeof(String);
            bool expected = true;
            bool actual;

            actual = obj.IsType(type);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsDBNull
        ///</summary>
        [TestMethod()]
        public void IsDBNullTest()
        {
            var obj = DBNull.Value;
            bool expected = true;
            bool actual;

            actual = obj.IsDBNull();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsNull()
        {
            object obj = null;
            var expected = true;
            var actual = obj.IsNull();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsDate
        ///</summary>
        [TestMethod()]
        public void IsDateTest()
        {
            var obj = DateTime.Now;
            bool expected = true;
            bool actual;

            actual = obj.IsDate();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsArray
        ///</summary>
        [TestMethod(), ExpectedException(typeof(NullReferenceException))]
        public void IsArrayTest_001()
        {
            byte[] obj = null;
            bool actual = obj.IsArray();
        }

        [TestMethod()]
        public void IsArrayTest_002()
        {
            string[] obj = new string[2];
            bool actual = obj.IsArray();
            Assert.IsTrue(actual);
        }

        #region GetAttribute / GetAttributes

        [TestMethod()]
        public void GetAttributesTest()
        {
            var obj = new GetAttributesTestObject();
            TestAttribute[] actual = obj.GetAttributes<TestAttribute>();
            Assert.AreEqual(3, actual.Length);

            var v = 0;
            foreach (var i in actual)
            {
                v += i.Value;
            }
            Assert.AreEqual(6, v);
        }

        [TestMethod()]
        public void GetAttributeTest()
        {
            var obj = new GetAttributesTestObject();
            var actual = obj.GetAttribute<Test2Attribute>();
            Assert.AreEqual("Highlander", actual.Name);
        }

        [Test2(Name = "Highlander")]
        [Test(1), Test(2), Test(3)]
        public class GetAttributesTestObject { }

        [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
        public class TestAttribute : Attribute
        {
            public TestAttribute(int value)
            {
                this.Value = value;
            }

            public int Value { get; set; }
        }

        [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
        public class Test2Attribute : Attribute
        {
            public string Name { get; set; }
        }

        #endregion

        #region ToDictionary

        [TestMethod]
        public void ToDictionaryTest_001()
        {
            var a = new {
                One = 1,
                Two = 2,
                Name = "Chris"
            };
            var d = a.ToDictionary();
            Assert.AreEqual(a.Name, d["Name"]);
            Assert.AreEqual(a.One, d["One"]);
            Assert.AreEqual(a.Two, d["Two"]);
        }

        [TestMethod]
        public void ToDictionaryTest_002()
        {
            var a = new ToDictionaryTestObject
            {
                FirstName = "Chris",
                LastName = "Pietschmann",
                Age = 30,
                Height = 6.16667
            };
            var d = a.ToDictionary();
            Assert.AreEqual(a.FirstName, d["FirstName"]);
            Assert.AreEqual(a.LastName, d["LastName"]);
            Assert.AreEqual(a.Age, d["Age"]);
            Assert.AreEqual(a.Height, d["Height"]);
        }

        [TestMethod]
        public void ToDictionaryTest_003()
        {
            var a = new ExpandoObject();
            var ad = (IDictionary<string, object>)a;
            ad["FirstName"] = "Chris";
            ad["Age"] = 0;
            ad["Height"] = 6.16667;

            var d = a.ToDictionary();

            Assert.AreEqual("Chris", d["FirstName"]);
            Assert.AreEqual(0, d["Age"]);
            Assert.AreEqual(6.16667, d["Height"]);
        }

        [TestMethod]
        public void ToDictionaryTest_004()
        {
            var a = new Dictionary<string, object>();
            a["FirstName"] = "Chris";
            a["Age"] = 0;
            a["Height"] = 6.16667;

            var d = a.ToDictionary();

            Assert.AreEqual("Chris", d["FirstName"]);
            Assert.AreEqual(0, d["Age"]);
            Assert.AreEqual(6.16667, d["Height"]);
        }

        [TestMethod]
        public void ToDictionaryTest_005()
        {
            Dictionary<string, object> a = null;
            var actual = a.ToDictionary();

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Dictionary<string, object>));
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void ToDictionaryTest_006()
        {
            object target = new NameValueCollection();
            var actual = target.ToDictionary();

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Dictionary<string, object>));
            Assert.AreEqual(0, actual.Count);
        }

        public class ToDictionaryTestObject
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public double Height { get; set; }
        }

        #endregion

        #region CastAs

        [TestMethod]
        public void CastAsTest_001()
        {
            var a = new {
                FirstName = "John",
                LastName = "Doe",
                Age = 54,
                Height = 5.333
            };
            CastAsTest_001_Helper(a);
        }

        private void CastAsTest_001_Helper(Object obj)
        {
            // Anonymous Type
            var a = new {
                FirstName = string.Empty,
                LastName = string.Empty,
                Age = 0,
                Height = 0.0
            };

            // CastAs
            a = obj.CastAs(a);

            Assert.AreEqual(a.FirstName, "John");
            Assert.AreEqual(a.LastName, "Doe");
            Assert.AreEqual(a.Age, 54);
            Assert.AreEqual(a.Height, 5.333);
        }

        #endregion

        #region CallMethodByName

        public class CallMethodByNameTestObject
        {
            public string Name { get; set; }

            public string GetName()
            {
                return this.Name;
            }

            public string GetNamePlus(string one, string two)
            {
                return this.Name + one + two;
            }
        }

        [TestMethod]
        public void CallMethodByNameTest_001()
        {
            var v = new CallMethodByNameTestObject { Name = "Chris" };
            var actual = v.CallMethodByName("GetName");
            Assert.AreEqual("Chris", actual);
        }

        [TestMethod]
        public void CallMethodByNameTest_002()
        {
            var v = new CallMethodByNameTestObject { Name = "Chris" };
            var actual = v.CallMethodByName("GetNamePlus", "A", "B");
            Assert.AreEqual("ChrisAB", actual);
        }

        [TestMethod]
        public void CallMethodByNameTest_003()
        {
            var v = new CallMethodByNameTestObject { Name = "Chris" };
            var actual = v.CallMethodByName<string>("GetName");
            Assert.AreEqual("Chris", actual);
        }

        [TestMethod]
        public void CallMethodByNameTest_004()
        {
            var v = new CallMethodByNameTestObject { Name = "Chris" };
            var actual = v.CallMethodByName<string>("GetNamePlus", "A", "B");
            Assert.AreEqual("ChrisAB", actual);
        }

        #endregion

        #region ConvertType

        [TestMethod]
        public void ConvertType_001()
        {
            var actual = ObjectExtensions.ConvertType<int>("23");
            int expected = 23;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertType_002()
        {
            var actual = ObjectExtensions.ConvertType<double>("23.567");
            double expected = 23.567;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertType_003()
        {
            var actual = ObjectExtensions.ConvertType<int>(23.567);
            double expected = 24;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void ConvertType_004()
        {
            ObjectExtensions.ConvertType<int>("5.455");
        }

        #endregion
    }
}
