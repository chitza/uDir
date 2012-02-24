using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

using Chitza.Utils;
using Chitza.Utils.ShellIcon;
using Chitza.Utils.Extensions;
using NLog;

namespace uDir
{
    public class Model
    {
        #region Members

        bool engineInitialized = false;
        ScriptEngine engine;
        ScriptScope scope;
        Func<Torrent, CommonFolder[], CommonFolder> func;
        readonly string ScriptFile = "Python\\Common.py";

        DelayedFileSystemWatcher fileWatcher;

        #endregion

        #region Constructor
        public Model(IContainer container, Logger logger)
        {
            InternalInitialize(container);
            this.logger = logger;
        }
        #endregion

        #region Properties

        #region SelectedFolder
        CommonFolder selectedFolder;
        public CommonFolder SelectedFolder
        {
            get { return selectedFolder; }
            set
            {
                if (selectedFolder != value)
                {
                    selectedFolder = value;
                    RaisePropertyChanged("SelectedFolder");

                    if (selectedFolder != null)
                        SelectedDrive = Path.GetPathRoot(selectedFolder.Path);
                }
            }
        }
        #endregion

        #region SelectedDrive
        string selectedDrive;
        public string SelectedDrive
        {
            get { return selectedDrive; }
            set
            {
                if (selectedDrive != value)
                {
                    selectedDrive = value;
                    try
                    {
                        var di = new DriveInfo(selectedDrive);
                        freeSpace = di.TotalFreeSpace.GetHumanReadableSize();
                    }
                    catch
                    {
                        freeSpace = "?!?";
                    }
                    RaisePropertyChanged("SelectedDrive");
                }
            }
        }

        private string freeSpace;
        public string SelectedDriveFreeSpace
        {
            get { return freeSpace; }
        }
        #endregion

        #region TorrentFile
        string torrentFile;
       
        public string TorrentFile
        {
            get { return torrentFile; }
            set
            {
                if (value != torrentFile)
                {
                    torrentFile = value;
                    RaisePropertyChanged("TorrentFile");
                }
            }
        }

        public string TorrentTitle
        {
            get { 
                if (!string.IsNullOrEmpty(torrentFile))
                    return Path.GetFileNameWithoutExtension(torrentFile); 
                return null;
            }
        }
        #endregion 

        #region Torrent
        Torrent torrent;
        public Torrent Torrent
        {
            get { return torrent; }
            set
            {
                if (torrent != value)
                {
                    torrent = value;
                    RaisePropertyChanged("Torrent");
                }
            }
        } 
        #endregion

        #region Settings
        Settings settings;
        public Settings Settings
        {
            get { return settings; }
            set
            {
                if (settings != value)
                {
                    settings = value;
                    RaisePropertyChanged("Settings");
                }
            }
        } 
        #endregion

        #region Icons
        ImageList icons;
        public ImageList Icons
        {
            get { return icons; }
        } 
        #endregion

        #region Logger
        Logger logger = null;
        public Logger Logger
        {
            get { return logger; }
            //set
            //{

            //    if (logger != value)
            //    {
            //        logger = value;
            //        RaisePropertyChanged("Logger");
            //    }
            //}
        } 
        #endregion

        #endregion

        #region Events

        private EventHandler<EventArgs<string>> onPropertyChanged;
        public event EventHandler<EventArgs<string>> OnPropertyChanged
        {
            add { onPropertyChanged += value; }
            remove { onPropertyChanged -= value; }
        }

        private EventHandler<EventArgs<ErrorData>> onError;
        public event EventHandler<EventArgs<ErrorData>> OnError
        {
            add { onError += value; }
            remove { onError -= value; }
        }

        private EventHandler<EventArgs<string>> onNotify;
        public event EventHandler<EventArgs<string>> OnNotify
        {
            add { onNotify += value; }
            remove { onNotify -= value; }
        }
        
        #endregion

        #region Methods

        #region Initialize

        private void InternalInitialize(IContainer container)
        {
            icons = new ImageList(container);
            icons.TransparentColor = Color.Transparent;
            icons.ImageSize = new Size(16, 16);
            icons.ColorDepth = ColorDepth.Depth32Bit;

            
            //Initialize();
        }

        public bool Initialize()
        {
            try
            {
                LoadSettings();
                PrepareScriptingEngine();
                if (settings != null)
                    StartMonitoringFolder(settings.LoadTorrentsFrom);
            }
            catch (Exception ex)
            {
                RaiseError("Starting up", ex);
                return false;
            }

            return true;
        }

        private void StartMonitoringFolder(string path)
        {
            if (!Directory.Exists(path))
                return;

            fileWatcher = new DelayedFileSystemWatcher(path);//, "*.torrent");
            
            fileWatcher.Created += new FileSystemEventHandler(OnFileCreated);
            fileWatcher.EnableRaisingEvents = true;
        }

        void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            if (!settings.MonitorFolder)
                return;

            if (e.ChangeType != WatcherChangeTypes.Created)
                return;
            RaiseNotification(string.Format("File [{0}] added to monitored folder", e.FullPath));

            //TODO: determine destination folder, move torrent to sub-folder (e.g.: Filme), then launch
            if (LoadTorrent(e.FullPath))
                Launch();
        } 

        #endregion

        #region LoadTorrent

        public bool LoadTorrent(string filename)
        {
            TorrentFile = filename;

            try
            {
                if (!TryLoadTorrent(torrentFile))
                    return false;
            }
            catch (Exception ex)
            {
                RaiseError("Error loading torrent", ex);
                return false;
            }

            try
            {
                var folder = func(torrent, settings.CommonFolders.ToArray());
                if (folder == null)
                    RaiseError("Cannot determine destination folder!");

                SelectedFolder = folder;
            }
            catch (Exception ex)
            {
                RaiseError("Error processing torrent", ex);
                return false;
            }

            return true;
        }

        #endregion

        #region Raise*
        private void RaisePropertyChanged(string propName)
        {
            if (onPropertyChanged != null)
                onPropertyChanged(this, new EventArgs<string>(propName));
        }

        private void RaiseError(string message, Exception ex)
        {
            if (onError != null)
                onError(this, new EventArgs<ErrorData>(new ErrorData(message, ex)));
        }

        private void RaiseError(string message)
        {
            RaiseError(message, null);
        }

        private void RaiseNotification(string message)
        {
            if (onNotify != null)
                onNotify(this, new EventArgs<string>(message));
        } 
        #endregion

        #region Load/SaveSettings

        private void LoadSettings()
        {
            try
            {
                Settings = Chitza.Utils.SerializationHelper.DeserializeObjectFromFile<Settings>(Path.Combine(Program.RootFolder, Program.SettingsFile));
                //settings = new Settings();
                //settings.CommonFolders.Add(new CommonFolder() { Name = "Filme", Path = @"d:\Filme" });
                //settings.CommonFolders.Add(new CommonFolder() { Name = "Muzica", Path = @"d:\Muzica" });
                //settings.CommonFolders.Add(new CommonFolder() { Name = "Poze", Path = @"d:\Poze" });
                //settings.uTorrentPath = @"C:\Program Files (x86)\uTorrent\uTorrent.exe";
                //Chitza.Utils.SerializationHelper.SerializeObjectToFile(settings, Program.SettingsFile);
            }

            catch (Exception ex)
            {
                RaiseError("Error loading settings", ex);
            }
        }

        internal void SaveSettings()
        {
            try
            {
                Chitza.Utils.SerializationHelper.SerializeObjectToFile(settings, Program.SettingsFile);
            }

            catch (Exception ex)
            {
                RaiseError("Error saving settings", ex);
            }
        }

        #endregion

        #region TryLoadTorrent
        bool TryLoadTorrent(string torrentFile)
        {
            if (!File.Exists(torrentFile))
            {
                RaiseError("Torrent file [" + torrentFile + "] does not exist");
                return false;
            }
            
            var tmp = new Torrent(torrentFile);

            //add file icons
            foreach (var file in tmp.Files)
            {
                string ext = file.Ext;
                if (!icons.Images.ContainsKey(file.Ext))
                    try
                    {
                        var iconContainer = ShellIcons.GetIconForFile(file.Path, true, false);
                        if (iconContainer != null && iconContainer.Icon != null)
                            icons.Images.Add(file.Ext, iconContainer.Icon.ToBitmap());
                    }
                    catch { }
            }

            Torrent = tmp;

            return true;
        }
        #endregion

        #region Scripting stuff

        Func<Torrent, CommonFolder[], CommonFolder> GetFolderForTorrentFunc()
        {
            string scriptFile = Path.Combine(Program.RootFolder, ScriptFile);
            if (!File.Exists(scriptFile))
                RaiseError("Cannot find script file " + scriptFile, new FileNotFoundException());
            return CompileSourceToScope(scriptFile, scope).GetVariable<Func<Torrent, CommonFolder[], CommonFolder>>("getFolderForTorrent");
        }

        ScriptScope CompileSourceToScope(string filename, ScriptScope scriptScope)
        {
            ScriptSource source = engine.CreateScriptSourceFromFile(filename);
            source.Execute(scriptScope);
            return scriptScope;
        }

        #region PrepareScriptingEngine
        void PrepareScriptingEngine()
        {
            if (engineInitialized)
                return;

            Dictionary<string, object> options = new Dictionary<string, object>();
            options["Debug"] = true;
            engine = Python.CreateEngine(options);
            scope = engine.CreateScope();
            func = GetFolderForTorrentFunc();

            engineInitialized = true;
        }
        #endregion 

        #endregion

        internal void Launch()
        {
            try
            {
                string cmdLine = Utils.GetCommandLine(settings.CommandLine, selectedFolder.Path.Quote(), torrentFile.Quote());
                Process.Start(new ProcessStartInfo(settings.uTorrentPath.Quote(), cmdLine));
            }
            catch (Exception ex)
            {
                RaiseError("Error launching", ex);
            }
        }

        internal void ExploreSelectedFolder()
        {
            try
            {
                if (selectedFolder == null) return;

                Process.Start(selectedFolder.Path);
            }
            catch (Exception ex)
            {
                RaiseError("Error navigating to folder [" + selectedFolder.Path + "]", ex);
            }
        }

        internal void AddCommonFolder(string path)
        {
            string[] parts = path.Split(Path.DirectorySeparatorChar);
            string leaf = parts[parts.Length - 1];
            var cf = new CommonFolder() { Name = leaf, Path = path };
            settings.CommonFolders.Add(cf);
            RaisePropertyChanged("Settings");
            SaveSettings();
        }

        internal void RemoveCommonFolder(CommonFolder folder)
        {
            if (folder == null) return;

            var fldr = settings.CommonFolders.FirstOrDefault(f => f.Path == folder.Path);
            if (fldr != null)
            {
                int idx = settings.CommonFolders.IndexOf(fldr);
                if (idx != -1)
                {
                    settings.CommonFolders.RemoveAt(idx);
                    RaisePropertyChanged("Settings");
                    SaveSettings();
                }
            }
        }

        #endregion

    }
}
