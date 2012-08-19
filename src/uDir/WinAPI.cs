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
														IntPtr wParam, IntPtr lParam, 
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
			public IntPtr dwData;
			public int cbData;
			public IntPtr lpData;
		}

		public static IntPtr CreateCopyDataObj(string message)
		{
			IntPtr lpData = Marshal.StringToHGlobalUni(message);

			CopyDataStruct data = new CopyDataStruct();
			data.dwData = IntPtr.Zero;
			data.cbData = message.Length * 2;
			data.lpData = lpData;

			IntPtr lpStruct = Marshal.AllocHGlobal(Marshal.SizeOf(data));

			Marshal.StructureToPtr(data, lpStruct, false);

			return lpStruct;
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
			IntPtr data = WinAPI.CreateCopyDataObj(message);

			IntPtr result;
			IntPtr retVal = WinAPI.SendMessageTimeout(destinationHandle, WM_COPYDATA, senderHandle, data, SendMessageTimeoutFlags.SMTO_NORMAL, timeout, out result);

			return (retVal != IntPtr.Zero);
		} 
		#endregion
	}
}
