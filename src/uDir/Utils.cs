using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

using MonoTorrent.BEncoding;

namespace uDir
{
    public static class Utils
    {
        public static string GetUTorrentPath()
        {
            string ret = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(ret, "uTorrent");
        }

        public static string GetCommandLine(string format, string directory, string torrent)
        {
            string ret = format;
            ret = ret.Replace("{Directory}", directory);
            ret = ret.Replace("{Torrent}", torrent);

            return ret;
        }

        #region ReadTorrentFileList
        #region .torrent structure
        //  .torrent
        //      |
        //      |--- info (dictionary)
        //             |--- files (list)
        //                     |
        //                     |--- item 1
        //                     |      |--- path (list)
        //                     |      |      |--- "Dir1"
        //                     |      |      |--- "SubDir1"
        //                     |      |      |--- "filename1.rar"
        //                     |      |
        //                     |      |--- length (number) 
        //                     |
        //                     |--- item 2
        //                            |--- path (list)
        //                            |      |--- "Dir2"
        //                            |      |--- "SubDir2"
        //                            |      |--- "filename2.rar"
        //                            |
        //                            |--- length (number)
        #endregion
        /// <summary>
        /// Reads the file list from a .torrent file.
        /// </summary>
        /// <param name="downloadPath"></param>
        /// <returns></returns>
        public static List<SimpleFileInfo> ReadTorrentFileList(string torrentFile)
        {
            if (!File.Exists(torrentFile))
                throw new FileNotFoundException("Can't find file " + torrentFile);

            var ret = new List<SimpleFileInfo>();

            //read and decode the .torrent file
            byte[] torrentBytes = File.ReadAllBytes(torrentFile);
            var torrentData = BEncodedValue.Decode<BEncodedDictionary>(torrentBytes);

            BEncodedList fileList = new BEncodedList();

            try
            {
                fileList = torrentData.Item<BEncodedDictionary>("info").Item<BEncodedList>("files");
            }
            catch { };

            foreach (var fileItem in fileList)
            {
                var fileData = fileItem as BEncodedDictionary;

                string filePath = BuildPathFromDirectoryList(fileData.Item<BEncodedList>("path"));
                long length = fileData.Item<BEncodedNumber>("length").Number;

                ret.Add(new SimpleFileInfo(filePath, length));
            }
            ret.Sort( new Comparison<SimpleFileInfo>( FileNameComparison));

            return ret;
        }
        #endregion

        #region ReadAnnounceList

        #region .torrent structure
        //  .torrent
        //      |
        //      |--- announce (string)
        //      |--- announce-list (string)
        #endregion

        /// <summary>
        /// Reads the file list from a .torrent file.
        /// </summary>
        /// <param name="downloadPath"></param>
        /// <returns></returns>
        public static List<string> ReadAnnounceList(string torrentFile)
        {
            if (!File.Exists(torrentFile))
                throw new FileNotFoundException("Can't find file " + torrentFile);

            var ret = new List<string>();

            //read and decode the .torrent file
            byte[] torrentBytes = File.ReadAllBytes(torrentFile);
            var torrentData = BEncodedValue.Decode<BEncodedDictionary>(torrentBytes);

            try
            {
                string announce = (torrentData["announce"] as BEncodedString).Text;
                ret.Add(announce);

                var announceList = torrentData.Item<BEncodedList>("announce-list");
                foreach (BEncodedList urlList in announceList)
                    foreach (BEncodedString url in urlList)
                        ret.Add(url.Text);
            }
            catch { };

            return ret.Distinct().ToList();
        }
        #endregion

        private static int FileNameComparison(SimpleFileInfo fi1, SimpleFileInfo fi2)
        {
            if (fi1 == null || fi2 == null) return 0;
            return fi1.Path.CompareTo(fi2.Path);
        }

        #region BuildPathFromDirectoryList
        #region Example
        //input:
        //  path (list)
        //    |--- "Dir2" (BEncodedString)
        //    |--- "SubDir2" (BEncodedString)
        //    |--- "filename2.rar" (BEncodedString) 
        //
        // output: "Dir2\SubDir2\filename2.rar"
        #endregion
        /// <summary>
        /// Builds an complete path from a list of directories.
        /// </summary>
        /// <param name="pathParts"></param>
        /// <returns></returns>
        private static string BuildPathFromDirectoryList(BEncodedList pathParts)
        {
            string ret = string.Empty;

            foreach (var p in pathParts)
                ret = Path.Combine(ret, (p as BEncodedString).Text);

            return ret;
        } 
        #endregion

        public static void AssociateWithTorrents()
        {
            //
        }
    }
    
}
