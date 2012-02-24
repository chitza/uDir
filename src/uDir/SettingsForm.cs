using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Chitza.Utils.Extensions;

namespace uDir
{
    public partial class SettingsForm : Form
    {
        Settings settings;
        public SettingsForm(Settings settings)
        {
            InitializeComponent();
            this.Text = Program.Name + " Settings";
            this.settings = settings;
            btnOK.Click += delegate { this.DialogResult = System.Windows.Forms.DialogResult.OK; };
            Hook();
        }

        public Settings Settings { get { return this.settings; } }

        #region Un/Hook
        private void Hook()
        {
            chkMonitor.AddBinding("Checked", settings, "MonitorFolder");
            btnBrowse.AddBinding("Enabled", settings, "MonitorFolder");
            txtMonitoredFolder.AddBinding("Enabled", settings, "MonitorFolder");

            txtMonitoredFolder.AddBinding("Text", settings, "LoadTorrentsFrom");
            btnOK.AddBinding("Enabled", settings, "IsDirty");
        }

        void Unhook()
        {
            chkMonitor.DataBindings.Clear();
            btnBrowse.DataBindings.Clear();
            txtMonitoredFolder.DataBindings.Clear();
            btnOK.DataBindings.Clear();
        } 
        #endregion

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (settings == null || string.IsNullOrEmpty(settings.LoadTorrentsFrom)) return;

            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = settings.LoadTorrentsFrom;
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    txtMonitoredFolder.Text = fbd.SelectedPath;
            }
        }
    }
}
