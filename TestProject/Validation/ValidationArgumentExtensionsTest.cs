//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace TestProject.Validation
{
    using System;
    using System.Collections.Generic;
    using dotNetExt;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidationArgumentExtensionsTest
    {
        #region RequireArgument
        
        [TestMethod]
        public void ValidationArgumentExtensionsTest_RequireArgument_001()
        {
            var s = "Test";

            var v = s.RequireArgument("Name");

            Assert.AreEqual("Name", v.Name);
            Assert.AreEqual(s, v.Value);
        }

        #endregion

        #region NotNull

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentNullException))]
        public void ValidationArgumentExtensionsTest_NotNull_001()
        {
            string v = null;
            v.RequireArgument("Name").NotNull();
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_NotNull_002()
        {
            string v = "value";
            v.RequireArgument("Name").NotNull();
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_NotNull_003()
        {
            int? v = 42;
            v.RequireArgument("Name").NotNull();
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentNullException))]
        public void ValidationArgumentExtensionsTest_NotNull_004()
        {
            int? v = null;
            v.RequireArgument("Name").NotNull();
        }

        #endregion

        #region NotEmpty

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentNullException))]
        public void ValidationArgumentExtensionsTest_NotEmpty_001()
        {
            int[] v = null;
            v.RequireArgument("Name").NotEmpty();
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_NotEmpty_002()
        {
            int[] v = new int[] { 1, 2, 3 };
            v.RequireArgument("Name").NotEmpty();
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentNullException))]
        public void ValidationArgumentExtensionsTest_NotEmpty_003()
        {
            List<int> v = null;
            v.RequireArgument("Name").NotEmpty();
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_NotEmpty_004()
        {
            List<double> v = new List<double> { 1, 2, 3 };
            v.RequireArgument("Name").NotEmpty();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_NotEmpty_005()
        {
            List<double> v = new List<double>();
            v.RequireArgument("Name").NotEmpty();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_NotEmpty_006()
        {
            var v = new string[0];
            v.RequireArgument("Name").NotEmpty();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_NotEmpty_007()
        {
            string v = string.Empty;
            v.RequireArgument("Name").NotEmpty();

        }
        [TestMethod]
        public void ValidationArgumentExtensionsTest_NotEmpty_008()
        {
            var v = "test";
            v.RequireArgument("Name").NotEmpty();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_NotEmpty_009()
        {
            var v = Guid.Empty;
            v.RequireArgument("Name").NotEmpty();
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_NotEmpty_010()
        {
            var v = Guid.NewGuid();
            v.RequireArgument("Name").NotEmpty();
        }

        #endregion

        #region NotNullOrWhiteSpace

        [TestMethod]
        public void ValidationArgumentExtensionsTest_NotNullOrWhiteSpace_001()
        {
            var v = "Test";
            v.RequireArgument("Name").NotNullOrWhiteSpace();
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_NotNullOrWhiteSpace_002()
        {
            var v = "";
            v.RequireArgument("Name").NotNullOrWhiteSpace();
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_NotNullOrWhiteSpace_003()
        {
            string v = null;
            v.RequireArgument("Name").NotNullOrWhiteSpace();
        }

        #endregion

        #region InRange

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_001()
        {
            int i = 1;
            i.RequireArgument("Name").InRange(0, 2);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_002()
        {
            int i = 1;
            i.RequireArgument("Name").InRange(1, 10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_003()
        {
            int i = 1;
            i.RequireArgument("Name").InRange(-10, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_004()
        {
            int i = 1;
            i.RequireArgument("Name").InRange(2, 100);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_005()
        {
            double i = 1;
            i.RequireArgument("Name").InRange(0, 2);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_006()
        {
            double i = 1;
            i.RequireArgument("Name").InRange(1, 10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_007()
        {
            double i = 1;
            i.RequireArgument("Name").InRange(-10, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_008()
        {
            double i = 1;
            i.RequireArgument("Name").InRange(2, 100);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_009()
        {
            int? i = 1;
            i.RequireArgument("Name").InRange(0, 2);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_010()
        {
            int? i = 1;
            i.RequireArgument("Name").InRange(1, 10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_011()
        {
            int? i = 1;
            i.RequireArgument("Name").InRange(-10, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_012()
        {
            int? i = 1;
            i.RequireArgument("Name").InRange(2, 100);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_013()
        {
            double? i = 1;
            i.RequireArgument("Name").InRange(0, 2);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_014()
        {
            double? i = 1;
            i.RequireArgument("Name").InRange(1, 10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_015()
        {
            double? i = 1;
            i.RequireArgument("Name").InRange(-10, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_016()
        {
            double? i = 1;
            i.RequireArgument("Name").InRange(2, 100);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_017()
        {
            Int16 i = 1;
            i.RequireArgument("Name").InRange(0, 2);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_018()
        {
            Int16 i = 1;
            i.RequireArgument("Name").InRange(1, 10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_019()
        {
            Int16 i = 1;
            i.RequireArgument("Name").InRange(-10, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_020()
        {
            Int16 i = 1;
            i.RequireArgument("Name").InRange(2, 100);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_021()
        {
            Int16? i = 1;
            i.RequireArgument("Name").InRange(0, 2);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_022()
        {
            Int16? i = 1;
            i.RequireArgument("Name").InRange(1, 10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_023()
        {
            Int16? i = 1;
            i.RequireArgument("Name").InRange(-10, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_024()
        {
            Int16? i = 1;
            i.RequireArgument("Name").InRange(2, 100);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_025()
        {
            float i = 1;
            i.RequireArgument("Name").InRange(0, 2);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_026()
        {
            float i = 1;
            i.RequireArgument("Name").InRange(1, 10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_027()
        {
            float i = 1;
            i.RequireArgument("Name").InRange(-10, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_028()
        {
            float i = 1;
            i.RequireArgument("Name").InRange(2, 100);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_029()
        {
            float? i = 1;
            i.RequireArgument("Name").InRange(0, 2);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_030()
        {
            float? i = 1;
            i.RequireArgument("Name").InRange(1, 10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_031()
        {
            float? i = 1;
            i.RequireArgument("Name").InRange(-10, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_032()
        {
            float? i = 1;
            i.RequireArgument("Name").InRange(2, 100);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_033()
        {
            Int64 i = 1;
            i.RequireArgument("Name").InRange(0, 2);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_034()
        {
            Int64 i = 1;
            i.RequireArgument("Name").InRange(1, 10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_035()
        {
            Int64 i = 1;
            i.RequireArgument("Name").InRange(-10, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_036()
        {
            Int64 i = 1;
            i.RequireArgument("Name").InRange(2, 100);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_037()
        {
            Int64? i = 1;
            i.RequireArgument("Name").InRange(0, 2);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_038()
        {
            Int64? i = 1;
            i.RequireArgument("Name").InRange(1, 10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_039()
        {
            Int64? i = 1;
            i.RequireArgument("Name").InRange(-10, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_040()
        {
            Int64? i = 1;
            i.RequireArgument("Name").InRange(2, 100);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_041()
        {
            IComparable i = 1;
            i.RequireArgument("Name").InRange(0, 2);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_InRange_042()
        {
            IComparable i = 1;
            i.RequireArgument("Name").InRange(1, 10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_043()
        {
            IComparable i = 1;
            i.RequireArgument("Name").InRange(-10, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_InRange_044()
        {
            IComparable i = 1;
            i.RequireArgument("Name").InRange(2, 100);
        }

        #endregion

        #region StartsWith

        [TestMethod]
        public void ValidationArgumentExtensionsTest_StartsWith_001()
        {
            string s = "Chris";
            s.RequireArgument("Name").StartsWith("Ch");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_StartsWith_002()
        {
            string s = "Chris";
            s.RequireArgument("Name").StartsWith("St");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_StartsWith_003()
        {
            string s = "Chris";
            s.RequireArgument("Name").StartsWith("ch");
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_StartsWith_004()
        {
            string s = "Chris";
            s.RequireArgument("Name").StartsWith("Ch", StringComparison.InvariantCultureIgnoreCase);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_StartsWith_005()
        {
            string s = "Chris";
            s.RequireArgument("Name").StartsWith("St", StringComparison.InvariantCultureIgnoreCase);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_StartsWith_006()
        {
            string s = "Chris";
            s.RequireArgument("Name").StartsWith("ch", StringComparison.InvariantCultureIgnoreCase);
        }

        #endregion

        #region EndsWith

        [TestMethod]
        public void ValidationArgumentExtensionsTest_EndsWith_001()
        {
            string s = "Chris";
            s.RequireArgument("Name").EndsWith("is");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_EndsWith_002()
        {
            string s = "Chris";
            s.RequireArgument("Name").EndsWith("even");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_EndsWith_003()
        {
            string s = "Chris";
            s.RequireArgument("Name").EndsWith("IS");
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_EndsWith_004()
        {
            string s = "Chris";
            s.RequireArgument("Name").EndsWith("is", StringComparison.InvariantCultureIgnoreCase);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_EndsWith_005()
        {
            string s = "Chris";
            s.RequireArgument("Name").EndsWith("even", StringComparison.InvariantCultureIgnoreCase);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_EndsWith_006()
        {
            string s = "Chris";
            s.RequireArgument("Name").EndsWith("IS", StringComparison.InvariantCultureIgnoreCase);
        }

        #endregion

        #region Contains

        [TestMethod]
        public void ValidationArgumentExtensionsTest_Contains_001()
        {
            string s = "Chris";
            s.RequireArgument("Name").Contains("hri");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_Contains_002()
        {
            string s = "Chris";
            s.RequireArgument("Name").Contains("even");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_Contains_003()
        {
            string s = "Chris";
            s.RequireArgument("Name").Contains("IS");
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_Contains_004()
        {
            string s = "Chris";
            s.RequireArgument("Name").Contains("ris");
        }

        #endregion

        #region LessThan

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LessThan_001()
        {
            int v = 42;
            v.RequireArgument("Name").LessThan(50);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_002()
        {
            int v = 42;
            v.RequireArgument("Name").LessThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_003()
        {
            int v = 42;
            v.RequireArgument("Name").LessThan(30);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LessThan_004()
        {
            short v = 42;
            v.RequireArgument("Name").LessThan(50);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_005()
        {
            short v = 42;
            v.RequireArgument("Name").LessThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_006()
        {
            short v = 42;
            v.RequireArgument("Name").LessThan(30);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LessThan_007()
        {
            long v = 42;
            v.RequireArgument("Name").LessThan(50);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_008()
        {
            long v = 42;
            v.RequireArgument("Name").LessThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_009()
        {
            long v = 42;
            v.RequireArgument("Name").LessThan(30);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LessThan_010()
        {
            double v = 42;
            v.RequireArgument("Name").LessThan(50);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_011()
        {
            double v = 42;
            v.RequireArgument("Name").LessThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_012()
        {
            double v = 42;
            v.RequireArgument("Name").LessThan(30);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LessThan_013()
        {
            float v = 42;
            v.RequireArgument("Name").LessThan(50);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_014()
        {
            float v = 42;
            v.RequireArgument("Name").LessThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_015()
        {
            float v = 42;
            v.RequireArgument("Name").LessThan(30);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LessThan_016()
        {
            int? v = 42;
            v.RequireArgument("Name").LessThan(50);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_017()
        {
            int? v = 42;
            v.RequireArgument("Name").LessThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_018()
        {
            int? v = 42;
            v.RequireArgument("Name").LessThan(30);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LessThan_019()
        {
            short? v = 42;
            v.RequireArgument("Name").LessThan(50);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_020()
        {
            short? v = 42;
            v.RequireArgument("Name").LessThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_021()
        {
            short? v = 42;
            v.RequireArgument("Name").LessThan(30);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LessThan_022()
        {
            long? v = 42;
            v.RequireArgument("Name").LessThan(50);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_023()
        {
            long? v = 42;
            v.RequireArgument("Name").LessThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_024()
        {
            long? v = 42;
            v.RequireArgument("Name").LessThan(30);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LessThan_025()
        {
            double? v = 42;
            v.RequireArgument("Name").LessThan(50);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_026()
        {
            double? v = 42;
            v.RequireArgument("Name").LessThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_027()
        {
            double? v = 42;
            v.RequireArgument("Name").LessThan(30);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LessThan_028()
        {
            float? v = 42;
            v.RequireArgument("Name").LessThan(50);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_029()
        {
            float? v = 42;
            v.RequireArgument("Name").LessThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_030()
        {
            float? v = 42;
            v.RequireArgument("Name").LessThan(30);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LessThan_031()
        {
            IComparable v = 42;
            v.RequireArgument("Name").LessThan(50);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_032()
        {
            IComparable v = 42;
            v.RequireArgument("Name").LessThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_LessThan_033()
        {
            IComparable v = 42;
            v.RequireArgument("Name").LessThan(30);
        }

        #endregion

        #region GreaterThan

        [TestMethod]
        public void ValidationArgumentExtensionsTest_GreaterThan_001()
        {
            int v = 42;
            v.RequireArgument("Name").GreaterThan(30);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_002()
        {
            int v = 42;
            v.RequireArgument("Name").GreaterThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_003()
        {
            int v = 42;
            v.RequireArgument("Name").GreaterThan(50);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_GreaterThan_004()
        {
            short v = 42;
            v.RequireArgument("Name").GreaterThan(30);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_005()
        {
            short v = 42;
            v.RequireArgument("Name").GreaterThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_006()
        {
            short v = 42;
            v.RequireArgument("Name").GreaterThan(50);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_GreaterThan_007()
        {
            long v = 42;
            v.RequireArgument("Name").GreaterThan(30);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_008()
        {
            long v = 42;
            v.RequireArgument("Name").GreaterThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_009()
        {
            long v = 42;
            v.RequireArgument("Name").GreaterThan(50);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_GreaterThan_010()
        {
            double v = 42;
            v.RequireArgument("Name").GreaterThan(30);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_011()
        {
            double v = 42;
            v.RequireArgument("Name").GreaterThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_012()
        {
            double v = 42;
            v.RequireArgument("Name").GreaterThan(50);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_GreaterThan_013()
        {
            float v = 42;
            v.RequireArgument("Name").GreaterThan(30);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_014()
        {
            float v = 42;
            v.RequireArgument("Name").GreaterThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_015()
        {
            float v = 42;
            v.RequireArgument("Name").GreaterThan(50);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_GreaterThan_016()
        {
            int? v = 42;
            v.RequireArgument("Name").GreaterThan(30);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_017()
        {
            int? v = 42;
            v.RequireArgument("Name").GreaterThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_018()
        {
            int? v = 42;
            v.RequireArgument("Name").GreaterThan(50);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_GreaterThan_019()
        {
            short? v = 42;
            v.RequireArgument("Name").GreaterThan(30);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_020()
        {
            short? v = 42;
            v.RequireArgument("Name").GreaterThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_021()
        {
            short? v = 42;
            v.RequireArgument("Name").GreaterThan(50);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_GreaterThan_022()
        {
            long? v = 42;
            v.RequireArgument("Name").GreaterThan(30);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_023()
        {
            long? v = 42;
            v.RequireArgument("Name").GreaterThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_024()
        {
            long? v = 42;
            v.RequireArgument("Name").GreaterThan(50);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_GreaterThan_025()
        {
            double? v = 42;
            v.RequireArgument("Name").GreaterThan(30);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_026()
        {
            double? v = 42;
            v.RequireArgument("Name").GreaterThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_027()
        {
            double? v = 42;
            v.RequireArgument("Name").GreaterThan(50);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_GreaterThan_028()
        {
            float? v = 42;
            v.RequireArgument("Name").GreaterThan(30);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_029()
        {
            float? v = 42;
            v.RequireArgument("Name").GreaterThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_030()
        {
            float? v = 42;
            v.RequireArgument("Name").GreaterThan(50);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_GreaterThan_031()
        {
            IComparable v = 42;
            v.RequireArgument("Name").GreaterThan(30);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_032()
        {
            IComparable v = 42;
            v.RequireArgument("Name").GreaterThan(42);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidationArgumentExtensionsTest_GreaterThan_033()
        {
            IComparable v = 42;
            v.RequireArgument("Name").GreaterThan(50);
        }

        #endregion

        #region ShorterThan

        [TestMethod]
        public void ValidationArgumentExtensionsTest_ShorterThan_001()
        {
            var s = "Test";
            s.RequireArgument("Name").ShorterThan(10);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_ShorterThan_002()
        {
            var s = "Test";
            s.RequireArgument("Name").ShorterThan(4);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_ShorterThan_003()
        {
            var s = "Test";
            s.RequireArgument("Name").ShorterThan(3);
        }

        #endregion

        #region LongerThan

        [TestMethod]
        public void ValidationArgumentExtensionsTest_LongerThan_001()
        {
            var s = "Test";
            s.RequireArgument("Name").LongerThan(3);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_LongerThan_002()
        {
            var s = "Test";
            s.RequireArgument("Name").LongerThan(4);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_LongerThan_003()
        {
            var s = "Test";
            s.RequireArgument("Name").LongerThan(10);
        }

        #endregion

        #region IsMatch

        private const string emailRegEx = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        [TestMethod]
        public void ValidationArgumentExtensionsTest_IsMatch_001()
        {
            var v = "test@test.com";
            v.RequireArgument("Email").IsMatch(emailRegEx);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_IsMatch_002()
        {
            var v = "test";
            v.RequireArgument("Email").IsMatch(emailRegEx);
        }

        [TestMethod]
        public void ValidationArgumentExtensionsTest_IsMatch_003()
        {
            var v = "test@test.com";
            v.RequireArgument("Email").IsMatch(emailRegEx, System.Text.RegularExpressions.RegexOptions.None);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ValidationArgumentExtensionsTest_IsMatch_004()
        {
            var v = "test";
            v.RequireArgument("Email").IsMatch(emailRegEx, System.Text.RegularExpressions.RegexOptions.None);
        }

        #endregion
    }
}
