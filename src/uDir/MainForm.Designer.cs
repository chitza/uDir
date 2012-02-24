namespace uDir
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lnkAbout = new System.Windows.Forms.LinkLabel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lstFolders = new System.Windows.Forms.ListBox();
            this.mnuFolders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miExploreFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.miAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFreeSpace = new System.Windows.Forms.Label();
            this.lblSelectedPath = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblContents = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.mnuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notificationPanel = new uDir.NotificationPanel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lnklblLog = new System.Windows.Forms.LinkLabel();
            this.pnlBottom.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.mnuFolders.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.mnuTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lnklblLog);
            this.pnlBottom.Controls.Add(this.btnExit);
            this.pnlBottom.Controls.Add(this.btnMinimize);
            this.pnlBottom.Controls.Add(this.lnkAbout);
            this.pnlBottom.Controls.Add(this.btnSettings);
            this.pnlBottom.Controls.Add(this.btnStart);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 482);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(678, 45);
            this.pnlBottom.TabIndex = 10;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExit.Image = global::uDir.Properties.Resources.cross;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(12, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 31);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMinimize.Image = global::uDir.Properties.Resources.arrow_down;
            this.btnMinimize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMinimize.Location = new System.Drawing.Point(578, 6);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(88, 31);
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.Text = "&Hide";
            this.btnMinimize.UseVisualStyleBackColor = true;
            // 
            // lnkAbout
            // 
            this.lnkAbout.AutoSize = true;
            this.lnkAbout.Location = new System.Drawing.Point(215, 17);
            this.lnkAbout.Name = "lnkAbout";
            this.lnkAbout.Size = new System.Drawing.Size(39, 13);
            this.lnkAbout.TabIndex = 4;
            this.lnkAbout.TabStop = true;
            this.lnkAbout.Text = "About";
            this.lnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAbout_LinkClicked);
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSettings.Image = global::uDir.Properties.Resources.wrench;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(106, 6);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(103, 31);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Se&ttings...";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStart.Image = global::uDir.Properties.Resources.control_play_blue;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(484, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(88, 31);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.OnLaunch);
            // 
            // lstFiles
            // 
            this.lstFiles.AllowDrop = true;
            this.lstFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colSize});
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiles.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lstFiles.FullRowSelect = true;
            this.lstFiles.GridLines = true;
            this.lstFiles.Location = new System.Drawing.Point(0, 27);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(678, 222);
            this.lstFiles.TabIndex = 11;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.Details;
            this.lstFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.lstFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 545;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 101;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lstFolders);
            this.pnlLeft.Controls.Add(this.label3);
            this.pnlLeft.Controls.Add(this.panel2);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(678, 228);
            this.pnlLeft.TabIndex = 15;
            // 
            // lstFolders
            // 
            this.lstFolders.AllowDrop = true;
            this.lstFolders.ContextMenuStrip = this.mnuFolders;
            this.lstFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFolders.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lstFolders.FormattingEnabled = true;
            this.lstFolders.IntegralHeight = false;
            this.lstFolders.ItemHeight = 25;
            this.lstFolders.Location = new System.Drawing.Point(0, 27);
            this.lstFolders.Name = "lstFolders";
            this.lstFolders.Size = new System.Drawing.Size(678, 183);
            this.lstFolders.TabIndex = 16;
            this.lstFolders.SelectedValueChanged += new System.EventHandler(this.lstFolders_SelectedValueChanged);
            this.lstFolders.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.lstFolders.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.lstFolders.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstFolders_MouseUp);
            // 
            // mnuFolders
            // 
            this.mnuFolders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExploreFolder,
            this.miAdd,
            this.miRemove});
            this.mnuFolders.Name = "mnuFolders";
            this.mnuFolders.Size = new System.Drawing.Size(118, 70);
            this.mnuFolders.Opening += new System.ComponentModel.CancelEventHandler(this.mnuFolders_Opening);
            // 
            // miExploreFolder
            // 
            this.miExploreFolder.Image = global::uDir.Properties.Resources.folder_explore2;
            this.miExploreFolder.Name = "miExploreFolder";
            this.miExploreFolder.Size = new System.Drawing.Size(117, 22);
            this.miExploreFolder.Text = "E&xplore";
            this.miExploreFolder.Click += new System.EventHandler(this.miExploreFolder_Click);
            // 
            // miAdd
            // 
            this.miAdd.Image = global::uDir.Properties.Resources.folder_add;
            this.miAdd.Name = "miAdd";
            this.miAdd.Size = new System.Drawing.Size(117, 22);
            this.miAdd.Text = "Add...";
            this.miAdd.Click += new System.EventHandler(this.miAdd_Click);
            // 
            // miRemove
            // 
            this.miRemove.Image = global::uDir.Properties.Resources.folder_delete;
            this.miRemove.Name = "miRemove";
            this.miRemove.Size = new System.Drawing.Size(117, 22);
            this.miRemove.Text = "Remove";
            this.miRemove.Click += new System.EventHandler(this.miRemove_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3);
            this.label3.Size = new System.Drawing.Size(678, 27);
            this.label3.TabIndex = 22;
            this.label3.Text = "Folders";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblFreeSpace);
            this.panel2.Controls.Add(this.lblSelectedPath);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 18);
            this.panel2.TabIndex = 21;
            // 
            // lblFreeSpace
            // 
            this.lblFreeSpace.AutoSize = true;
            this.lblFreeSpace.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFreeSpace.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblFreeSpace.Location = new System.Drawing.Point(602, 0);
            this.lblFreeSpace.Margin = new System.Windows.Forms.Padding(5);
            this.lblFreeSpace.Name = "lblFreeSpace";
            this.lblFreeSpace.Size = new System.Drawing.Size(76, 17);
            this.lblFreeSpace.TabIndex = 22;
            this.lblFreeSpace.Text = "Free space:";
            // 
            // lblSelectedPath
            // 
            this.lblSelectedPath.AutoSize = true;
            this.lblSelectedPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectedPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSelectedPath.Location = new System.Drawing.Point(0, 0);
            this.lblSelectedPath.Margin = new System.Windows.Forms.Padding(5);
            this.lblSelectedPath.Name = "lblSelectedPath";
            this.lblSelectedPath.Size = new System.Drawing.Size(76, 17);
            this.lblSelectedPath.TabIndex = 21;
            this.lblSelectedPath.Text = "Destination:";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.lstFiles);
            this.pnlRight.Controls.Add(this.lblContents);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 233);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(678, 249);
            this.pnlRight.TabIndex = 16;
            // 
            // lblContents
            // 
            this.lblContents.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lblContents.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblContents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblContents.ForeColor = System.Drawing.SystemColors.Window;
            this.lblContents.Location = new System.Drawing.Point(0, 0);
            this.lblContents.Margin = new System.Windows.Forms.Padding(5);
            this.lblContents.Name = "lblContents";
            this.lblContents.Padding = new System.Windows.Forms.Padding(3);
            this.lblContents.Size = new System.Drawing.Size(678, 27);
            this.lblContents.TabIndex = 16;
            this.lblContents.Text = "Torrent contents";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlRight);
            this.pnlContent.Controls.Add(this.splitter1);
            this.pnlContent.Controls.Add(this.pnlLeft);
            this.pnlContent.Controls.Add(this.txtLog);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(678, 482);
            this.pnlContent.TabIndex = 21;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 228);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(678, 5);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // mnuTray
            // 
            this.mnuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mnuTray.Name = "mnuTray";
            this.mnuTray.Size = new System.Drawing.Size(134, 48);
            // 
            // showHideToolStripMenuItem
            // 
            this.showHideToolStripMenuItem.Name = "showHideToolStripMenuItem";
            this.showHideToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.showHideToolStripMenuItem.Text = "Show/Hide";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.mnuTray;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Application title";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notificationPanel
            // 
            this.notificationPanel.BackColor = System.Drawing.SystemColors.Info;
            this.notificationPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.notificationPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.notificationPanel.Location = new System.Drawing.Point(0, 527);
            this.notificationPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.notificationPanel.Message = "ala bala portocala";
            this.notificationPanel.Name = "notificationPanel";
            this.notificationPanel.Size = new System.Drawing.Size(678, 0);
            this.notificationPanel.TabIndex = 17;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(678, 482);
            this.txtLog.TabIndex = 23;
            // 
            // lnklblLog
            // 
            this.lnklblLog.AutoSize = true;
            this.lnklblLog.Location = new System.Drawing.Point(452, 17);
            this.lnklblLog.Name = "lnklblLog";
            this.lnklblLog.Size = new System.Drawing.Size(26, 13);
            this.lnklblLog.TabIndex = 7;
            this.lnklblLog.TabStop = true;
            this.lnklblLog.Text = "Log";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnMinimize;
            this.ClientSize = new System.Drawing.Size(678, 527);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.notificationPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "µDir";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.Resize += new System.EventHandler(this.OnFormResize);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.mnuFolders.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.mnuTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.ListBox lstFolders;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip mnuFolders;
        private System.Windows.Forms.ToolStripMenuItem miExploreFolder;
        private System.Windows.Forms.Label lblFreeSpace;
        private System.Windows.Forms.Label lblSelectedPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnkAbout;
        private NotificationPanel notificationPanel;
        private System.Windows.Forms.ContextMenuStrip mnuTray;
        private System.Windows.Forms.ToolStripMenuItem showHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStripMenuItem miAdd;
        private System.Windows.Forms.ToolStripMenuItem miRemove;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.LinkLabel lnklblLog;
    }
}

