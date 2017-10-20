//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace TestProject
{
    using dotNetExt;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    /// <summary>
    ///This is a test class for StringExtensionsTest and is intended
    ///to contain all StringExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void String_IsEmpty_001()
        {
            string s = null;
            var actual = s.IsEmpty();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void String_IsEmpty_002()
        {
            string s = string.Empty;
            var actual = s.IsEmpty();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void String_IsEmpty_003()
        {
            string s = " ";
            var actual = s.IsEmpty();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void String_IsEmpty_004()
        {
            string s = "some arbitrary string value";
            var actual = s.IsEmpty();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void String_Repeat_001()
        {
            string s = null;
            var actual = s.Repeat(0);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void String_Repeat_002()
        {
            string s = null;
            var actual = s.Repeat(5);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void String_Repeat_003()
        {
            string s = "Test";
            var actual = s.Repeat(0);
            var expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void String_Repeat_004()
        {
            string s = "Test";
            var actual = s.Repeat(1);
            var expected = "Test";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void String_Repeat_005()
        {
            string s = "Test";
            var actual = s.Repeat(3);
            var expected = "TestTestTest";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void String_Repeat_006()
        {
            string s = string.Empty;
            var actual = s.Repeat(3);
            var expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void String_Repeat_007()
        {
            string s = string.Empty;
            var actual = s.Repeat(-3);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void String_Repeat_008()
        {
            string s = "test";
            var actual = s.Repeat(-3);
        }

        [TestMethod]
        public void String_ToMD5Hash_001()
        {
            var hash = "abcdefghijklmnopqrstuvwxyz".ToMD5Hash();
            Assert.AreEqual("C3FCD3D76192E4007DFB496CCA67E13B", hash);
        }

        [TestMethod()]
        public void String_IsNullOrWhiteSpaceTest_001()
        {
            string v = null;
            var actual = v.IsNullOrWhiteSpace();
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void String_IsNullOrWhiteSpaceTest_002()
        {
            string v = "";
            var actual = v.IsNullOrWhiteSpace();
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void String_IsNullOrWhiteSpaceTest_003()
        {
            string v = " ";
            var actual = v.IsNullOrWhiteSpace();
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void String_IsNullOrWhiteSpaceTest_004()
        {
            string v = "test";
            var actual = v.IsNullOrWhiteSpace();
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for ToStream
        ///</summary>
        [TestMethod()]
        public void ToStreamTest1()
        {
            string str = "test";
            var expected = new byte[] { 116, 101, 115, 116 };
            var actual = StringExtensions.ToStream<System.Text.ASCIIEncoding>(str).ToByteArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToStream
        ///</summary>
        [TestMethod()]
        public void ToStreamTest()
        {
            var str = "test";
            var expected = new byte[] { 116, 101, 115, 116 };
            var actual = StringExtensions.ToStream(str).ToByteArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToByteArray
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest1()
        {
            string str = "test";
            byte[] expected = new byte[] { 116, 101, 115, 116 };
            byte[] actual = StringExtensions.ToByteArray(str);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToByteArray
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest()
        {
            string str = "test";
            byte[] expected = new byte[] { 116, 101, 115, 116 };
            byte[] actual = StringExtensions.ToByteArray<System.Text.ASCIIEncoding>(str);
            CollectionAssert.AreEqual(expected, actual);
        }

        #region Right

        /// <summary>
        ///A test for Right
        ///</summary>
        [TestMethod()]
        public void RightTest_001()
        {
            string s = "John";
            string expected = "hn";
            string actual = s.Right(2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RightTest_002()
        {
            string s = "John";
            string expected = "John";
            string actual = s.Right(4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RightTest_003()
        {
            string s = null;
            string expected = null;
            string actual = s.Right(4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RightTest_004()
        {
            string s = string.Empty;
            string expected = string.Empty;
            string actual = s.Right(4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RightTest_005()
        {
            string s = "test";
            string expected = "test";
            string actual = s.Right(7);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RightTest_006()
        {
            string s = "test";
            string expected = "test";
            string actual = s.Right(-5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RightTest_007()
        {
            string s = "test";
            string expected = string.Empty;
            string actual = s.Right(0);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Left

        /// <summary>
        ///A test for Left
        ///</summary>
        [TestMethod()]
        public void LeftTest_001()
        {
            string s = "John";
            string expected = "Joh";
            string actual = s.Left(3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LeftTest_002()
        {
            string s = "John";
            string expected = "John";
            string actual = s.Left(4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LeftTest_003()
        {
            string s = null;
            string expected = null;
            string actual = s.Left(4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LeftTest_004()
        {
            string s = string.Empty;
            string expected = string.Empty;
            string actual = s.Left(4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LeftTest_005()
        {
            string s = "test";
            string expected = "test";
            string actual = s.Left(7);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LeftTest_006()
        {
            string s = "test";
            string expected = "test";
            string actual = s.Left(-5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LeftTest_007()
        {
            string s = "test";
            string expected = string.Empty;
            string actual = s.Left(0);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        [TestMethod()]
        public void EncryptTest_001()
        {
            string str = "test";
            string key = "12345678";
            string expected = "SiQu8unOTKY=";
            string actual = str.Encrypt<System.Security.Cryptography.DESCryptoServiceProvider>(key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EncryptTest_002()
        {
            string str = "test";
            string key = "12345678123456781234567812345678";
            string iv = "1234567812345678";
            string expected = "zh8PBb14Jbi+dDnpnNOUZg==";
            string actual = str.Encrypt<System.Security.Cryptography.AesCryptoServiceProvider>(key, iv);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for EncodeUrl
        ///</summary>
        [TestMethod()]
        public void EncodeUrlTest()
        {
            string str = "V=Test Value+2";
            string expected = "V%3dTest+Value%2b2";
            string actual = str.EncodeUrl();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for EncodeHtml
        ///</summary>
        [TestMethod()]
        public void EncodeHtmlTest()
        {
            string str = "<div>Some <b>Html</b> String &amp;</div>"; // TODO: Initialize to an appropriate value
            string expected = "&lt;div&gt;Some &lt;b&gt;Html&lt;/b&gt; String &amp;amp;&lt;/div&gt;"; // TODO: Initialize to an appropriate value
            string actual = str.EncodeHtml();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for EncodeBase64
        ///</summary>
        [TestMethod()]
        public void EncodeBase64Test()
        {
            string str = "Some Text String 1234";
            string expected = "U29tZSBUZXh0IFN0cmluZyAxMjM0";
            string actual = str.EncodeBase64();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DecryptTest_001()
        {
            string str = "SiQu8unOTKY=";
            string key = "12345678";
            string expected = "test";
            string actual = str.Decrypt<System.Security.Cryptography.DESCryptoServiceProvider>(key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DecryptTest_002()
        {
            string str = "zh8PBb14Jbi+dDnpnNOUZg==";
            string key = "12345678123456781234567812345678";
            string iv = "1234567812345678";
            string expected = "test";
            string actual = str.Decrypt<System.Security.Cryptography.AesCryptoServiceProvider>(key, iv);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DecodeUrl
        ///</summary>
        [TestMethod()]
        public void DecodeUrlTest()
        {
            string str = "V%3dTest+Value%2b2";
            string expected = "V=Test Value+2";
            string actual = str.DecodeUrl();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DecodeHtml
        ///</summary>
        [TestMethod()]
        public void DecodeHtmlTest()
        {
            string str = "&lt;div&gt;Some &lt;b&gt;Html&lt;/b&gt; String &amp;amp;&lt;/div&gt;";
            string expected = "<div>Some <b>Html</b> String &amp;</div>";
            string actual = str.DecodeHtml();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DecodeBase64
        ///</summary>
        [TestMethod()]
        public void DecodeBase64Test()
        {
            string str = "U29tZSBUZXh0IFN0cmluZyAxMjM0";
            string expected = "Some Text String 1234";
            string actual = str.DecodeBase64();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void String_IsNullOrEmpty_001()
        {
            string v = null;
            var actual = v.IsNullOrEmpty();
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void String_IsNullOrEmpty_002()
        {
            string v = "";
            var actual = v.IsNullOrEmpty();
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void String_IsNullOrEmpty_003()
        {
            string v = " ";
            var actual = v.IsNullOrEmpty();
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void String_IsNullOrEmpty_004()
        {
            string v = "test";
            var actual = v.IsNullOrEmpty();
            Assert.IsFalse(actual);
        }

        #region RemoveAll

        [TestMethod]
        public void RemoveAll_001()
        {
            var target = "121212";
            var actual = StringExtensions.RemoveAll(target, "1");
            var expected = "222";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll_002()
        {
            var target = "121212";
            var actual = StringExtensions.RemoveAll(target, "1", "2");
            var expected = "";
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
