using uDir;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using Microsoft.Scripting.Hosting;
using System.Windows.Forms;

namespace uDir.Tests
{
    
    
    /// <summary>
    ///This is a test class for ModelTest and is intended
    ///to contain all ModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ModelTest
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
        ///A test for ExploreSelectedFolder
        ///</summary>
        [TestMethod()]
        public void ExploreSelectedFolderTest()
        {
            IContainer container = null; // TODO: Initialize to an appropriate value
            Model target = new Model(container); // TODO: Initialize to an appropriate value
            target.ExploreSelectedFolder();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CompileSourceToScope
        ///</summary>
        [TestMethod()]
        [DeploymentItem("uDir.exe")]
        public void CompileSourceToScopeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Model_Accessor target = new Model_Accessor(param0); // TODO: Initialize to an appropriate value
            string filename = string.Empty; // TODO: Initialize to an appropriate value
            ScriptScope scriptScope = null; // TODO: Initialize to an appropriate value
            ScriptScope expected = null; // TODO: Initialize to an appropriate value
            ScriptScope actual;
            actual = target.CompileSourceToScope(filename, scriptScope);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Model Constructor
        ///</summary>
        [TestMethod()]
        public void ModelConstructorTest()
        {
            IContainer container = null; // TODO: Initialize to an appropriate value
            Model target = new Model(container);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetFolderForTorrentFunc
        ///</summary>
        [TestMethod()]
        [DeploymentItem("uDir.exe")]
        public void GetFolderForTorrentFuncTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Model_Accessor target = new Model_Accessor(param0); // TODO: Initialize to an appropriate value
            Func<Torrent, CommonFolder[], CommonFolder> expected = null; // TODO: Initialize to an appropriate value
            Func<Torrent, CommonFolder[], CommonFolder> actual;
            actual = target.GetFolderForTorrentFunc();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("uDir.exe")]
        public void InitializeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Model_Accessor target = new Model_Accessor(param0); // TODO: Initialize to an appropriate value
            IContainer container = null; // TODO: Initialize to an appropriate value
            target.Initialize(container);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Launch
        ///</summary>
        [TestMethod()]
        public void LaunchTest()
        {
            IContainer container = null; // TODO: Initialize to an appropriate value
            Model target = new Model(container); // TODO: Initialize to an appropriate value
            target.Launch();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadSettings
        ///</summary>
        [TestMethod()]
        [DeploymentItem("uDir.exe")]
        public void LoadSettingsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Model_Accessor target = new Model_Accessor(param0); // TODO: Initialize to an appropriate value
            target.LoadSettings();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadTorrent
        ///</summary>
        [TestMethod()]
        public void LoadTorrentTest()
        {
            IContainer container = null; // TODO: Initialize to an appropriate value
            Model target = new Model(container); // TODO: Initialize to an appropriate value
            string filename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadTorrent(filename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PrepareScriptingEngine
        ///</summary>
        [TestMethod()]
        [DeploymentItem("uDir.exe")]
        public void PrepareScriptingEngineTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Model_Accessor target = new Model_Accessor(param0); // TODO: Initialize to an appropriate value
            target.PrepareScriptingEngine();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RaiseError
        ///</summary>
        [TestMethod()]
        [DeploymentItem("uDir.exe")]
        public void RaiseErrorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Model_Accessor target = new Model_Accessor(param0); // TODO: Initialize to an appropriate value
            string message = string.Empty; // TODO: Initialize to an appropriate value
            target.RaiseError(message);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RaiseError
        ///</summary>
        [TestMethod()]
        [DeploymentItem("uDir.exe")]
        public void RaiseErrorTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Model_Accessor target = new Model_Accessor(param0); // TODO: Initialize to an appropriate value
            string message = string.Empty; // TODO: Initialize to an appropriate value
            Exception ex = null; // TODO: Initialize to an appropriate value
            target.RaiseError(message, ex);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RaisePropertyChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("uDir.exe")]
        public void RaisePropertyChangedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Model_Accessor target = new Model_Accessor(param0); // TODO: Initialize to an appropriate value
            string propName = string.Empty; // TODO: Initialize to an appropriate value
            target.RaisePropertyChanged(propName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TryLoadTorrent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("uDir.exe")]
        public void TryLoadTorrentTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Model_Accessor target = new Model_Accessor(param0); // TODO: Initialize to an appropriate value
            string torrentFile = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryLoadTorrent(torrentFile);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Icons
        ///</summary>
        [TestMethod()]
        public void IconsTest()
        {
            IContainer container = null; // TODO: Initialize to an appropriate value
            Model target = new Model(container); // TODO: Initialize to an appropriate value
            ImageList actual;
            actual = target.Icons;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectedDrive
        ///</summary>
        [TestMethod()]
        public void SelectedDriveTest()
        {
            IContainer container = null; // TODO: Initialize to an appropriate value
            Model target = new Model(container); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.SelectedDrive = expected;
            actual = target.SelectedDrive;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectedDriveFreeSpace
        ///</summary>
        [TestMethod()]
        public void SelectedDriveFreeSpaceTest()
        {
            IContainer container = null; // TODO: Initialize to an appropriate value
            Model target = new Model(container); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SelectedDriveFreeSpace;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectedFolder
        ///</summary>
        [TestMethod()]
        public void SelectedFolderTest()
        {
            IContainer container = null; // TODO: Initialize to an appropriate value
            Model target = new Model(container); // TODO: Initialize to an appropriate value
            CommonFolder expected = null; // TODO: Initialize to an appropriate value
            CommonFolder actual;
            target.SelectedFolder = expected;
            actual = target.SelectedFolder;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Settings
        ///</summary>
        [TestMethod()]
        public void SettingsTest()
        {
            IContainer container = null; // TODO: Initialize to an appropriate value
            Model target = new Model(container); // TODO: Initialize to an appropriate value
            Settings actual;
            actual = target.Settings;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Torrent
        ///</summary>
        [TestMethod()]
        public void TorrentTest()
        {
            IContainer container = null; // TODO: Initialize to an appropriate value
            Model target = new Model(container); // TODO: Initialize to an appropriate value
            Torrent actual;
            actual = target.Torrent;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TorrentFile
        ///</summary>
        [TestMethod()]
        public void TorrentFileTest()
        {
            IContainer container = null; // TODO: Initialize to an appropriate value
            Model target = new Model(container); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.TorrentFile = expected;
            actual = target.TorrentFile;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
         */
    }
}
