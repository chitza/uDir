using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace uDir
{
    [Serializable]
    public class Settings : ICloneable
    {
        #region Constructor
        public Settings()
        {
            CommonFolders = new List<CommonFolder>();
            startMinimized = true;
        } 
        #endregion

        #region Properties

        #region IsDirty
        [NonSerialized]
        private bool isDirty;
        [XmlIgnore]
        public bool IsDirty
        {
            get { return isDirty; }
        }
        #endregion

        #region CommonFolders
        private List<CommonFolder> commonFolders;

        public List<CommonFolder> CommonFolders
        {
            get { return commonFolders; }
            set
            {
                if (value != commonFolders)
                {
                    commonFolders = value;
                    isDirty = true;
                }
            }
        }
        #endregion

        #region uTorrentPath
        private string _uTorrentPath;

        public string uTorrentPath
        {
            get { return _uTorrentPath; }
            set
            {
                if (value != _uTorrentPath)
                {
                    _uTorrentPath = value;
                    isDirty = true;
                }
            }
        }
        #endregion

        #region CommandLine
        private string commandLine;

        public string CommandLine
        {
            get { return commandLine; }
            set
            {
                if (value != commandLine)
                {
                    commandLine = value;
                    isDirty = true;
                }
            }
        }
        #endregion

        #region MonitorFolder
        private bool monitorFolder;

        public bool MonitorFolder
        {
            get { return monitorFolder; }
            set
            {
                if (value != monitorFolder)
                {
                    monitorFolder = value;
                    isDirty = true;
                }
            }
        }
        #endregion

        #region LoadTorrentsFrom
        private string loadTorrentsFrom;

        public string LoadTorrentsFrom
        {
            get { return loadTorrentsFrom; }
            set
            {
                if (value != loadTorrentsFrom)
                {
                    loadTorrentsFrom = value;
                    isDirty = true;
                }
            }
        }
        #endregion 

        #region StartMinimized
        private bool startMinimized;

        public bool StartMinimized
        {
            get { return startMinimized; }
            set
            {
                if (value != startMinimized)
                {
                    startMinimized = value;
                    isDirty = true;
                }
            }
        }
        #endregion

        #endregion

        #region Methods

        public void ResetState()
        {
            isDirty = false;
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            var cl = new Settings();
            cl.CommandLine = this.CommandLine;
            if (this.CommonFolders != null)
                this.CommonFolders.ForEach(f => cl.CommonFolders.Add((CommonFolder)f.Clone()));
            cl.LoadTorrentsFrom = this.LoadTorrentsFrom;
            cl.MonitorFolder = this.MonitorFolder;
            cl.uTorrentPath = this.uTorrentPath;
            cl.startMinimized = this.StartMinimized;
            cl.ResetState();
            return cl;
        }

        #endregion
    }
}
