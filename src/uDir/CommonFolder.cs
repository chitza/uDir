using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uDir
{
    public class CommonFolder : ICloneable
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            return Name;
        }

        #region ICloneable Members

        public object Clone()
        {
            var cl = new CommonFolder();
            cl.Name = this.Name;
            cl.Path = this.Path;
            return cl;
        }

        #endregion
    }
}
