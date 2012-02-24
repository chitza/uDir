using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

using Chitza.Utils.Extensions;
using NLog;

namespace uDir
{
    static class Program
    {
        #region Dll Imports
        public const int HWND_BROADCAST = 0xFFFF;
        public static readonly int WM_ACTIVATEAPP = RegisterWindowMessage("WM_ACTIVATEAPP" + Program.Name);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
        #endregion Dll Imports

        #region Members

        private static readonly string MUTEX_NAME = "µDir";
        public static readonly string Name = "µDir";
        public static readonly int ProgramId = 23;//some number to uniquely identify this application
        public static string Version;
        public static string FullName { get { return string.Format("{0} v{1}", Name, Version); } }
        public static readonly string SettingsFile = "uDir.config";
        public static string RootFolder;
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //check if it's a new instance or there's already an instance running
            //in which case, notify the main window that it should make itself visible to the user
            bool createdNew = true;
            using (Mutex mutex = new Mutex(true, MUTEX_NAME, out createdNew))
            {
                if (createdNew)
                {
                    RootFolder = Path.GetDirectoryName(Application.ExecutablePath);
                    Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    var frm = new MainForm(args);
                    if (frm != null && !frm.IsDisposed)
                        Application.Run(frm);
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    string processName = current.ProcessName;

                    foreach (Process process in Process.GetProcessesByName(processName))
                    {
                        if (process.Id != current.Id)
                        {
                            IntPtr handle = process.MainWindowHandle;

                            if (args.Length > 0)
                                WinAPI.SendStringToWindow((IntPtr)HWND_BROADCAST, args[0], handle);

                            //SetForegroundWindow(handle);
                            PostMessage((IntPtr)HWND_BROADCAST, WM_ACTIVATEAPP, new IntPtr(ProgramId), IntPtr.Zero);
                            break;
                        }
                    }
                }
            }
        }
    }
}
