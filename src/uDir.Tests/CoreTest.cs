using uDir;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MonoTorrent.BEncoding;
using System.Collections.Generic;

namespace uDir.Tests
{
    
    
    /// <summary>
    ///This is a test class for CoreTest and is intended
    ///to contain all CoreTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CoreTest
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
        ///A test for GetCommandLine
        ///</summary>
        [TestMethod()]
        public void GetCommandLineTest()
        {
            string format = string.Empty; // TODO: Initialize to an appropriate value
            string directory = string.Empty; // TODO: Initialize to an appropriate value
            string torrent = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = Utils.GetCommandLine(format, directory, torrent);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUTorrentPath
        ///</summary>
        [TestMethod()]
        public void GetUTorrentPathTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = Utils.GetUTorrentPath();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadTorrentFileList
        ///</summary>
        [TestMethod()]
        public void ReadTorrentFileListTest()
        {
            string torrentFile = string.Empty; // TODO: Initialize to an appropriate value
            List<SimpleFileInfo> expected = null; // TODO: Initialize to an appropriate value
            List<SimpleFileInfo> actual;
            actual = Utils.ReadTorrentFileList(torrentFile);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
        */
    }
}
