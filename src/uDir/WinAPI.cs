using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace uDir
{
    public class WinAPI
    {
        public static readonly uint WM_COPYDATA = 0x004a;

        [DllImport("user32.dll")]
        public static extern UInt32 RegisterWindowMessage(string lpString);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageTimeout(IntPtr windowHandle, uint Msg, 
                                                        IntPtr wParam, ref CopyDataStruct lParam, 
                                                        SendMessageTimeoutFlags flags, uint timeout, out IntPtr result);

        [Flags]
        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CopyDataStruct
        {
            public string ID;
            public int Length;
            public string Data;
        }

        #region SendStringToWindow
        /// <summary>
        /// Sends a string to a window.
        /// </summary>
        /// <param name="destinationHandle">Destination handle</param>
        /// <param name="message">The string to be sent.</param>
        /// <param name="senderHandle">Handle of the sender.</param>
        /// <returns>Returns true if sending the message succeeded.</returns>
        public static bool SendStringToWindow(IntPtr destinationHandle, string message, IntPtr senderHandle, uint timeout = 100)
        {
            WinAPI.CopyDataStruct data = new WinAPI.CopyDataStruct();

            data.ID = "1";
            data.Data = message;
            data.Length = data.Data.Length + 1;

            IntPtr result;
            IntPtr retVal = WinAPI.SendMessageTimeout(destinationHandle, WM_COPYDATA, senderHandle, ref data, SendMessageTimeoutFlags.SMTO_NORMAL, timeout, out result);

            return (retVal != IntPtr.Zero);
        } 
        #endregion
    }
}
