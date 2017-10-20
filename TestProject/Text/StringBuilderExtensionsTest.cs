//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotNetExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class StringBuilderExtensionsTest
    {
        [TestMethod]
        public void AppendLineFormatTest_001()
        {
            var sb = new StringBuilder();
            sb.AppendLineFormat("Test {0} Test {1}", "a", "b");
            Assert.AreEqual("Test a Test b" + Environment.NewLine, sb.ToString());
        }
    }
}
