using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoTorrent.BEncoding;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace uDir
{
    public static class Extensions
    {
        #region BEncode extensions

        public static T Item<T>(this BEncodedDictionary dic, string key) where T : BEncodedValue
        {
            var encodedKey = new BEncodedString(key);
            return (T)dic[encodedKey];
        }

        //public static T Item<T>(this BEncodedList list, int idx) where T : BEncodedValue
        //{
        //    return (T)list[idx];
        //}

        #endregion
    }
}
