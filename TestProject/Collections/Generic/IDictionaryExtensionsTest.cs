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
using System.Dynamic;

namespace TestProject.Collections.Generic
{
    [TestClass]
    public class IDictionaryExtensionsTest
    {
        [TestMethod]
        public void IDictionaryTest_ToExpando_001()
        {
            var d = new Dictionary<string, object>();
            var id = Guid.NewGuid();
            d.Add("ID", id);
            d.Add("FirstName", "Chris");
            d.Add("LastName", "Pietschmann");

            var expando = d.ToExpando();
            var dyn = (dynamic)expando;

            Assert.AreEqual(3, expando.Count());
            Assert.AreEqual(id, (Guid)dyn.ID);
            Assert.AreEqual("Chris", (string)dyn.FirstName);
            Assert.AreEqual("Pietschmann", (string)dyn.LastName);
        }

        [TestMethod]
        public void IDictionaryTest_ToExpando_002()
        {
            var id = Guid.NewGuid();
            var dt = DateTime.Now;

            var d = new Dictionary<string, object>();
            d.Add("ID", id);
            d.Add("FirstName", "Chris");
            d.Add("LastName", "Pietschmann");

            d.Add("Obj", new Dictionary<string, object>
            {
                { "ID", 1 },
                { "Company", "ExpandoCom" },
                { "Date", dt },
                { "YearFounded", 2012 }
            });


            var expando = d.ToExpando();
            var dyn = (dynamic)expando;

            Assert.AreEqual(4, expando.Count());
            Assert.AreEqual(id, (Guid)dyn.ID);
            Assert.AreEqual("Chris", (string)dyn.FirstName);
            Assert.AreEqual("Pietschmann", (string)dyn.LastName);

            var dyn2 = dyn.Obj;
            Assert.AreEqual(4, ((ExpandoObject)dyn2).Count());
            Assert.AreEqual(1, (int)dyn2.ID);
            Assert.AreEqual("ExpandoCom", (string)dyn2.Company);
            Assert.AreEqual(dt, (DateTime)dyn2.Date);
            Assert.AreEqual(2012, (int)dyn2.YearFounded);
        }

        [TestMethod]
        public void IDictionaryTest_ToNameValueCollection_001()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>{
                { "One", "1" },
                { "Two", "22" }
            };

            var actual = dict.ToNameValueCollection();

            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("1", actual[0]);
            Assert.AreEqual("1", actual["One"]);
            Assert.AreEqual("22", actual[1]);
            Assert.AreEqual("22", actual["Two"]);
        }

        [TestMethod]
        public void IDictionaryTest_ToNameValueCollection_002()
        {
            IDictionary<string, string> dict = null;

            var actual = dict.ToNameValueCollection();

            Assert.IsNull(actual);
        }
    }
}
