//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using dotNetExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class TypeExtensionsTest
    {
        [TestMethod]
        public void TypeTest_CreateInstance_001()
        {
            var t = typeof(Person);

            var p = t.CreateInstance();

            Assert.IsTrue(p is Person);
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void TypeTest_CreateInstance_002()
        {
            var t = typeof(Person);

            Person p = t.CreateInstance<Person>();

            Assert.IsTrue(p is Person);
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void TypeTest_CreateInstance_003()
        {
            var t = typeof(Person);

            var p = t.CreateInstance("John", "Doe");

            Assert.IsTrue(p is Person);
            Assert.IsNotNull(p);
            Assert.AreEqual("John", ((Person)p).FirstName);
            Assert.AreEqual("Doe", ((Person)p).LastName);
        }

        [TestMethod]
        public void TypeTest_CreateInstance_004()
        {
            var t = typeof(Person);

            Person p = t.CreateInstance<Person>("Billy", "Idol");

            Assert.IsTrue(p is Person);
            Assert.IsNotNull(p);
            Assert.AreEqual("Billy", p.FirstName);
            Assert.AreEqual("Idol", p.LastName);
        }

        public class Person
        {
            public Person()
            { }

            public Person(string firstName, string lastName)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
