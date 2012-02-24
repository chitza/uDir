using uDir;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace uDir.Tests
{
    
    
    /// <summary>
    ///This is a test class for TorrentTest and is intended
    ///to contain all TorrentTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TorrentTest
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
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            string fileName = string.Empty; // TODO: Initialize to an appropriate value
            Torrent target = new Torrent(fileName); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Torrent Constructor
        ///</summary>
        [TestMethod()]
        public void TorrentConstructorTest()
        {
            string fileName = string.Empty; // TODO: Initialize to an appropriate value
            Torrent target = new Torrent(fileName);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for FileName
        ///</summary>
        [TestMethod()]
        public void FileNameTest()
        {
            string fileName = string.Empty; // TODO: Initialize to an appropriate value
            Torrent target = new Torrent(fileName); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.FileName = expected;
            actual = target.FileName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Files
        ///</summary>
        [TestMethod()]
        public void FilesTest()
        {
            string fileName = string.Empty; // TODO: Initialize to an appropriate value
            Torrent target = new Torrent(fileName); // TODO: Initialize to an appropriate value
            List<SimpleFileInfo> expected = null; // TODO: Initialize to an appropriate value
            List<SimpleFileInfo> actual;
            target.Files = expected;
            actual = target.Files;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MostExtension
        ///</summary>
        [TestMethod()]
        public void MostExtensionTest()
        {
            string fileName = string.Empty; // TODO: Initialize to an appropriate value
            Torrent target = new Torrent(fileName); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.MostExtension;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TotalSize
        ///</summary>
        [TestMethod()]
        public void TotalSizeTest()
        {
            string fileName = string.Empty; // TODO: Initialize to an appropriate value
            Torrent target = new Torrent(fileName); // TODO: Initialize to an appropriate value
            long actual;
            actual = target.TotalSize;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
         * */
    }
}
