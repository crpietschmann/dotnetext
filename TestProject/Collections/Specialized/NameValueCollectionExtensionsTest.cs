//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using dotNetExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace TestProject.Collections.Specialized
{
    [TestClass]
    public class NameValueCollectionExtensionsTest
    {
        [TestMethod]
        public void ToDictionary_001()
        {
            var target = new NameValueCollection();
            target.Add("Key", "One");

            var actual = NameValueCollectionExtensions.ToDictionary(target);

            Assert.IsInstanceOfType(actual, typeof(IDictionary<string, object>));
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("Key", actual.Keys.First());
            Assert.AreEqual("One", actual["Key"]);
        }

        [TestMethod]
        public void ToDictionary_002()
        {
            var target = new NameValueCollection();
            target.Add("Key", "One");
            target.Add("Key2", "TWO");

            var actual = NameValueCollectionExtensions.ToDictionary(target);

            Assert.IsInstanceOfType(actual, typeof(IDictionary<string, object>));
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("One", actual["Key"]);
            Assert.AreEqual("TWO", actual["Key2"]);
        }

        [TestMethod]
        public void ToDictionary_003()
        {
            NameValueCollection target = null;

            var actual = NameValueCollectionExtensions.ToDictionary(target);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IDictionary<string, object>));
            Assert.AreEqual(0, actual.Count);
        }
    }
}
