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
    ///This is a test class for EventHandlerExtensionsTest and is intended
    ///to contain all EventHandlerExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EventHandlerExtensionsTest
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


        public event EventHandler EventHandler_Raise_001_Event;

        /// <summary>
        ///A test for Raise
        ///</summary>
        [TestMethod()]
        public void EventHandler_Raise_001()
        {
            this.EventHandler_Raise_001_Event.Raise(this, EventArgs.Empty);
        }


        public event EventHandler EventHandler_Raise_002_Event;

        /// <summary>
        ///A test for Raise
        ///</summary>
        [TestMethod()]
        public void EventHandler_Raise_002()
        {
            this.EventHandler_Raise_002_Event.Raise(this);
        }


        public event EventHandler<EventArgs> EventHandler_Raise_003_Event;

        /// <summary>
        ///A test for Raise
        ///</summary>
        [TestMethod]
        public void EventHandler_Raise_003()
        {
            this.EventHandler_Raise_003_Event.Raise<EventArgs>(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> EventHandler_Raise_004_Event;

        /// <summary>
        ///A test for Raise
        ///</summary>
        [TestMethod]
        public void EventHandler_Raise_004()
        {
            this.EventHandler_Raise_004_Event.Raise<EventArgs>(this);
        }


        public event EventHandler<EventArgs> EventHandler_Raise_005_Event;

        /// <summary>
        ///A test for Raise
        ///</summary>
        [TestMethod]
        public void EventHandler_Raise_005()
        {
            this.EventHandler_Raise_005_Event += EventHandlerExtensionsTest_EventHandler_Raise_005_Event;
            this.EventHandler_Raise_005_Event.Raise<EventArgs>(this, EventArgs.Empty);
        }

        void EventHandlerExtensionsTest_EventHandler_Raise_005_Event(object sender, EventArgs e)
        {
            Assert.AreEqual(this, sender);
            Assert.AreEqual(e, EventArgs.Empty);
        }

        public event EventHandler EventHandler_Raise_006_Event;

        /// <summary>
        ///A test for Raise
        ///</summary>
        [TestMethod()]
        public void EventHandler_Raise_006()
        {
            this.EventHandler_Raise_006_Event += EventHandlerExtensionsTest_EventHandler_Raise_006_Event;
            this.EventHandler_Raise_006_Event.Raise(this);
        }

        void EventHandlerExtensionsTest_EventHandler_Raise_006_Event(object sender, EventArgs e)
        {
            Assert.AreEqual(this, sender);
            Assert.AreEqual(e, EventArgs.Empty);
        }
    }
}
