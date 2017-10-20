//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using dotNetExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;

namespace TestProject
{
    /// <summary>
    ///This is a test class for StreamExtensionsTest and is intended
    ///to contain all StreamExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StreamExtensionsTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
        ///A test for ToByteArray
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest()
        {
            Stream stream = new MemoryStream(); // TODO: Initialize to an appropriate value
            byte[] actual;
            using (var sw = new StreamWriter(stream))
            {
                sw.Write("test");
                sw.Flush();
                stream.Position = 0;
                actual = stream.ToByteArray();
            }
            byte[] expected = new byte[] { 116, 101, 115, 116 }; // TODO: Initialize to an appropriate value
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EncryptTest_001()
        {
            Stream stream = "test".ToStream();
            byte[] key = "12345678".ToByteArray();
            string expected = "SiQu8unOTKY=";
            var actual = stream.Encrypt<System.Security.Cryptography.DESCryptoServiceProvider>(key).ToByteArray().ToBase64String();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EncryptTest_002()
        {
            Stream stream = "test".ToStream();
            byte[] key = "12345678123456781234567812345678".ToByteArray();
            byte[] iv = "1234567812345678".ToByteArray();
            string expected = "zh8PBb14Jbi+dDnpnNOUZg==";
            var actual = stream.Encrypt<System.Security.Cryptography.AesCryptoServiceProvider>(key, iv).ToByteArray().ToBase64String();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DecryptTest_001()
        {
            Stream stream = new MemoryStream(Convert.FromBase64String("SiQu8unOTKY="));
            byte[] key = "12345678".ToByteArray();
            var expected = "test";

            var bytes = stream.Decrypt<System.Security.Cryptography.DESCryptoServiceProvider>(key).ToByteArray();
            var enc = new ASCIIEncoding();
            var actual = enc.GetString(bytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DecryptTest_002()
        {
            Stream stream = new MemoryStream(Convert.FromBase64String("zh8PBb14Jbi+dDnpnNOUZg=="));
            byte[] key = "12345678123456781234567812345678".ToByteArray();
            byte[] iv = "1234567812345678".ToByteArray();
            var expected = "test";

            var bytes = stream.Decrypt<System.Security.Cryptography.AesCryptoServiceProvider>(key, iv).ToByteArray();
            var enc = new ASCIIEncoding();
            var actual = enc.GetString(bytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Stream_ToMD5Hash_001()
        {
            var stream = "abcdefghijklmnopqrstuvwxyz".ToStream();
            Assert.AreEqual("C3FCD3D76192E4007DFB496CCA67E13B", stream.ToMD5Hash());
        }
    }
}
