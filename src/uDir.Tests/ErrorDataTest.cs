using uDir;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace uDir.Tests
{
    
    
    /// <summary>
    ///This is a test class for ErrorDataTest and is intended
    ///to contain all ErrorDataTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ErrorDataTest
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

/*
        /// <summary>
        ///A test for ErrorData Constructor
        ///</summary>
        [TestMethod()]
        public void ErrorDataConstructorTest()
        {
            string message = string.Empty; // TODO: Initialize to an appropriate value
            Exception ex = null; // TODO: Initialize to an appropriate value
            ErrorData target = new ErrorData(message, ex);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Exception
        ///</summary>
        [TestMethod()]
        public void ExceptionTest()
        {
            string message = string.Empty; // TODO: Initialize to an appropriate value
            Exception ex = null; // TODO: Initialize to an appropriate value
            ErrorData target = new ErrorData(message, ex); // TODO: Initialize to an appropriate value
            Exception expected = null; // TODO: Initialize to an appropriate value
            Exception actual;
            target.Exception = expected;
            actual = target.Exception;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageTest()
        {
            string message = string.Empty; // TODO: Initialize to an appropriate value
            Exception ex = null; // TODO: Initialize to an appropriate value
            ErrorData target = new ErrorData(message, ex); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Message = expected;
            actual = target.Message;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }*/
    }
}
