using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

using Chitza.Utils;
using Chitza.Utils.Extensions;
using NLog;

namespace uDir
{
	public partial class MainForm : Form
	{
		Model model = null;
		bool errorOnLoad = false;
		Logger logger = null;

		#region Constructor

		public MainForm(string[] args)
		{
			InitializeComponent();

			logger = LogManager.GetLogger("");
			logger.Log(LogLevel.Info, "Starting up...");

			btnExit.Click += delegate { Exit(); };
			btnMinimize.Click += delegate { ShowHide(); };
			showHideToolStripMenuItem.Click += delegate { ShowHide(); };
			exitToolStripMenuItem.Click += delegate { Exit(); };
			notifyIcon.Text = Program.FullName;

			this.Text = Program.FullName;

			model = new Model(this.components, logger);
			HookModel();
			if (!model.Initialize())
			{
				this.Close();
				//Application.Exit();
			}

			PopulateFolderList();
			if (args.Length > 0)
			{
				if (!model.LoadTorrent(args[0]))
					errorOnLoad = true;
			}
		}
		
		#endregion

		private void HookModel()
		{
			model.OnNotify += new EventHandler<EventArgs<string>>(OnModelNotification);
			model.OnError += new EventHandler<Chitza.Utils.EventArgs<ErrorData>>(OnModelError);
			model.OnPropertyChanged += new EventHandler<EventArgs<string>>(OnModelPropertyChanged);
			//model.Logger = this.logger;
			lstFiles.SmallImageList = model.Icons;
		}

		#region Show Notification/ Error

		void OnModelNotification(object sender, EventArgs<string> e)
		{
			ShowNotification(e.Value);
		}

		void OnModelError(object sender, EventArgs<ErrorData> e)
		{
			ShowError(e.Value.Message, e.Value.Exception);
		}

		private void ShowError(string message, Exception ex)
		{
			if (ex != null)
				ShowError(message + "\r\nError: " + ex.Message);
			else
				ShowError(message);
		}

		private void ShowError(string message)
		{
			LogError(message);
			MessageBox.Show(message, Program.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void ShowInfo(string message)
		{
			Info(message);
			MessageBox.Show(message, Program.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ShowNotification(string message)
		{
			Trace("ShowNotification: " + message);
			notificationPanel.Show(message);
		}

		#endregion

		#region OnModelPropertyChanged
		void OnModelPropertyChanged(object sender, EventArgs<string> e)
		{
			if (e.Value == "SelectedFolder")
			{
				OnTorrentFileChanged();
				if (model.SelectedFolder != null)
				{
					lblSelectedPath.InvokeIfNeeded( () => lblSelectedPath.Text = model.SelectedFolder.Path);
					int idx = lstFolders.Items.IndexOf(model.SelectedFolder);
					if (idx >= 0)
						lstFolders.InvokeIfNeeded( () => lstFolders.SelectedIndex = idx);
				}

				string notifyMsg = "Selected folder changed to " + ((model.SelectedFolder == null) ? "NULL" : model.SelectedFolder.Name);
				ShowNotification(notifyMsg);
			}

			else if (e.Value == "TorrentFile")
				OnTorrentFileChanged();
			else if (e.Value == "SelectedDrive")
				lblFreeSpace.Text = string.Format(Strings.FreeSpaceFormat, model.SelectedDriveFreeSpace);
			else if (e.Value == "Torrent")
				PopulateFileList();
			else if (e.Value == "Settings")
			{
				PopulateFolderList();
				ShowNotification("Settings changed");
			}
		} 
		#endregion

		#region Populate*List

		private void PopulateFileList()
		{
			if (model.Torrent == null)
				return;

			try
			{
				lstFiles.InvokeIfNeeded( () => lstFiles.BeginUpdate());
				lstFiles.InvokeIfNeeded( () => lstFiles.Items.Clear());
				foreach (var f in model.Torrent.Files)
				{
					var li = new ListViewItem(f.Path);
					li.SubItems.Add(f.Length.GetHumanReadableSize());
					li.ImageKey = f.Ext;
					lstFiles.InvokeIfNeeded( () => lstFiles.Items.Add(li));
				}
			}
			finally
			{
				lstFiles.InvokeIfNeeded( () => lstFiles.EndUpdate());
			}

			this.InvokeIfNeeded( () => this.Text = Path.GetFileNameWithoutExtension(model.TorrentFile) );
		}

		private void PopulateFolderList()
		{
			if (model.Settings == null)
				return;

			try
			{
				lstFolders.BeginUpdate();
				lstFolders.Items.Clear();
				foreach (var fldr in model.Settings.CommonFolders)
					lstFolders.Items.Add(fldr);

			}
			finally
			{
				lstFolders.EndUpdate();
			}
		}

		private void OnTorrentFileChanged()
		{
			lblContents.InvokeIfNeeded(() => lblContents.Text = string.Format(uDir.Properties.Resources.TorrentContents, model.TorrentTitle));
			btnStart.InvokeIfNeeded( () => btnStart.Enabled = model.SelectedFolder != null && model.TorrentFile != null);
		}
		#endregion

		#region Show / Hide window
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == Program.WM_ACTIVATEAPP && m.WParam.ToInt32() == Program.ProgramId)
				ShowWindow();
			else if (m.Msg == WinAPI.WM_COPYDATA)
			{
				ShowWindow();
				logger.Log(LogLevel.Trace, "Received message WM_COPYDATA");
				try
				{

					WinAPI.CopyDataStruct data = (WinAPI.CopyDataStruct)m.GetLParam(typeof(WinAPI.CopyDataStruct));
					string message = string.Empty;
					unsafe
					{
						message = new string((char*)(data.lpData), 0, data.cbData / 2);
					}
					logger.Log(LogLevel.Trace, "\tdata: " + message);

					m.Result = new IntPtr(1); //return "True" to caller

					ShowNotification("Received message: " + message);
					if (!model.LoadTorrent(message))
						ShowNotification("Error loading torrent " + message);
				}
				catch (Exception ex)
				{
					logger.Log(LogLevel.Error, "Error retrieving message data");
				}
			}
			else
				base.WndProc(ref m);
		}

		private void ShowWindow()
		{
			if (!this.Visible)
			{
				logger.Log(LogLevel.Trace, "ShowWindow: was not visible!");
				this.Show();
			}
			else
			{
				if (this.WindowState == FormWindowState.Minimized)
				{
					logger.Log(LogLevel.Trace, "ShowWindow: was minimized, restoring!");
					this.WindowState = FormWindowState.Normal;
				}
			}
		}

		private void Exit()
		{
			if (CanExit())
				Application.Exit();
		}

		private bool CanExit()
		{
			return GetConfirmation("Close " + Program.Name + "?", Program.Name) == DialogResult.Yes;
		}

		private DialogResult GetConfirmation(string question, string caption)
		{
			return MessageBox.Show(question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		private DialogResult GetConfirmation(string question)
		{
			return GetConfirmation(question, Program.Name);
		}

		private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ShowHide();//sender, e);
		}

		private void ShowHide()//(object sender, EventArgs e)
		{
			if (this.Visible)
				this.Hide();
			else
				ShowWindow();
		}
		#endregion

		#region UI Events

		private void OnFormLoad(object sender, EventArgs e)
		{
			if (errorOnLoad)
				Close();
		}

		private void OnFormResize(object sender, EventArgs e)
		{
			colName.Width = lstFiles.Width - colSize.Width - SystemInformation.VerticalScrollBarWidth - 10;
		}

		private void OnLaunch(object sender, EventArgs e)
		{
			model.Launch();
			ShowHide();
		}

		private void lstFolders_SelectedValueChanged(object sender, EventArgs e)
		{
			var fldr = lstFolders.SelectedItem as CommonFolder;
			if (fldr != null)
				model.SelectedFolder = fldr;
		}

		private void lstFolders_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int idx = lstFolders.IndexFromPoint(e.Location);
				if (idx != -1)
					lstFolders.SelectedIndex = idx;
			}
		}

		#region Context menu
		private void mnuFolders_Opening(object sender, CancelEventArgs e)
		{
			miExploreFolder.Enabled = !(model.SelectedFolder == null);
		}

		private void miExploreFolder_Click(object sender, EventArgs e)
		{
			model.ExploreSelectedFolder();
		}

		private void miAdd_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				fbd.ShowNewFolderButton = true;
				fbd.Description = "Select folder";
				if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					model.AddCommonFolder(fbd.SelectedPath);
				}
			}
		}

		private void miRemove_Click(object sender, EventArgs e)
		{
			var fldr = lstFolders.SelectedItem as CommonFolder;
			if (fldr == null) return;

			if (GetConfirmation(string.Format("Delete folder [{0}]", fldr.Name)) == DialogResult.Yes)
			{
				model.RemoveCommonFolder(fldr);
			}
		} 
		#endregion

		private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			notificationPanel.Close();
			using (var frm = new AboutForm())
			{
				frm.ShowDialog();
			}
		}

		#region Drag'n'Drop

		private bool IsValidTorrentFile(string filename)
		{
			return (!string.IsNullOrEmpty(filename) && File.Exists(filename) && filename.EndsWith("torrent"));
		}

		private void OnDragDrop(object sender, DragEventArgs e)
		{
			string fn = WinForms.GetDraggedFilename(e.Data);

			if (IsValidTorrentFile(fn))
				model.LoadTorrent(fn);
		}

		private void OnDragOver(object sender, DragEventArgs e)
		{
			DragDropEffects ret = DragDropEffects.None;

			if (IsValidTorrentFile(WinForms.GetDraggedFilename(e.Data)))
				ret = DragDropEffects.Link;

			e.Effect = ret;
		} 

		#endregion

		private void btnSettings_Click(object sender, EventArgs e)
		{
			//ShowNotification("Nothing to configure yet...");
			var settings = (Settings)model.Settings.Clone();
			using (var frm = new SettingsForm(settings))
			{
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					model.Settings = frm.Settings;
					model.SaveSettings();
				}
			}
		}

		#endregion

		#region Logging

		private void LogError(string message)
		{
			if (logger == null) return;

			logger.Log(LogLevel.Error, message);
		}

		private void Info(string message)
		{
			if (logger == null) return;

			logger.Log(LogLevel.Info, message);
		}

		private void Debug(string message)
		{
			if (logger == null) return;

			logger.Log(LogLevel.Debug, message);
		}

		private void Trace(string message)
		{
			if (logger == null) return;

			logger.Log(LogLevel.Trace, message);
		}

		#endregion
	}
}
