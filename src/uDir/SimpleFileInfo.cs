using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace uDir
{
    public class SimpleFileInfo
    {
        public readonly string Path;
        public readonly long Length;
        public readonly string Ext;
        public readonly string Name;

        public SimpleFileInfo(string path, long length)
        {
            Path = path;
            Length = length;
            Ext = System.IO.Path.GetExtension(this.Path);
            if (Ext.StartsWith("."))
                Ext = Ext.Substring(1);
            Name = System.IO.Path.GetFileName(this.Path);
        }
    }
}
