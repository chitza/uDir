using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using MonoTorrent.BEncoding;
using System.Drawing;

namespace uDir
{
    public class Torrent
    {
        #region Constructor
        public Torrent(string fileName)
        {
            FileName = fileName;
            Files = Utils.ReadTorrentFileList(fileName);
            Announce = Utils.ReadAnnounceList(fileName);
        }

        #endregion

        #region Properties

        public string FileName { get; set; }

        public List<SimpleFileInfo> Files { get; set; }
        public List<string> Announce { get; set; }
        
        public long TotalSize
        {
            get
            {
                return this.Files.Sum(f => f.Length);
            }
        }

        public string MostRelevantExtension
        {
            get
            {
                var exts =
                        from f in Files
                        group f by f.Ext into g
                        select new { Ext = g.Key, Count = g.Count(), TotalSize = g.Sum( f => f.Length) };

                var mostRelevant = exts
                                   .OrderByDescending(e => e.TotalSize)
                                   .ThenByDescending(e => e.Count)
                                   .FirstOrDefault();

                if (mostRelevant != null)
                    return mostRelevant.Ext.Trim().ToLower();

                return string.Empty;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return this.FileName;
        }

        #endregion
    
    }
}
