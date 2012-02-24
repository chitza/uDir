namespace uDir
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAssoc = new System.Windows.Forms.Button();
            this.gbFolderMonitor = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtMonitoredFolder = new System.Windows.Forms.TextBox();
            this.chkMonitor = new System.Windows.Forms.CheckBox();
            this.gbLogging = new System.Windows.Forms.GroupBox();
            this.chkInfo = new System.Windows.Forms.CheckBox();
            this.chkError = new System.Windows.Forms.CheckBox();
            this.chkWarning = new System.Windows.Forms.CheckBox();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.pnlBottom.SuspendLayout();
            this.gbFolderMonitor.SuspendLayout();
            this.gbLogging.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 180);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(727, 45);
            this.pnlBottom.TabIndex = 11;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOK.Location = new System.Drawing.Point(533, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 31);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.Location = new System.Drawing.Point(627, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 31);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAssoc
            // 
            this.btnAssoc.Enabled = false;
            this.btnAssoc.Location = new System.Drawing.Point(6, 89);
            this.btnAssoc.Name = "btnAssoc";
            this.btnAssoc.Size = new System.Drawing.Size(167, 23);
            this.btnAssoc.TabIndex = 12;
            this.btnAssoc.Text = "Associate with .torrent files";
            this.btnAssoc.UseVisualStyleBackColor = true;
            // 
            // gbFolderMonitor
            // 
            this.gbFolderMonitor.Controls.Add(this.btnBrowse);
            this.gbFolderMonitor.Controls.Add(this.txtMonitoredFolder);
            this.gbFolderMonitor.Controls.Add(this.chkMonitor);
            this.gbFolderMonitor.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFolderMonitor.Location = new System.Drawing.Point(0, 0);
            this.gbFolderMonitor.Name = "gbFolderMonitor";
            this.gbFolderMonitor.Size = new System.Drawing.Size(727, 83);
            this.gbFolderMonitor.TabIndex = 13;
            this.gbFolderMonitor.TabStop = false;
            this.gbFolderMonitor.Text = "Monitor folder";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Image = global::uDir.Properties.Resources.folder;
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.Location = new System.Drawing.Point(640, 43);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtMonitoredFolder
            // 
            this.txtMonitoredFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonitoredFolder.Location = new System.Drawing.Point(6, 44);
            this.txtMonitoredFolder.Name = "txtMonitoredFolder";
            this.txtMonitoredFolder.Size = new System.Drawing.Size(628, 22);
            this.txtMonitoredFolder.TabIndex = 1;
            // 
            // chkMonitor
            // 
            this.chkMonitor.AutoSize = true;
            this.chkMonitor.Location = new System.Drawing.Point(6, 21);
            this.chkMonitor.Name = "chkMonitor";
            this.chkMonitor.Size = new System.Drawing.Size(156, 17);
            this.chkMonitor.TabIndex = 0;
            this.chkMonitor.Text = "Load torrents from folder";
            this.chkMonitor.UseVisualStyleBackColor = true;
            // 
            // gbLogging
            // 
            this.gbLogging.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLogging.Controls.Add(this.chkInfo);
            this.gbLogging.Controls.Add(this.chkError);
            this.gbLogging.Controls.Add(this.chkWarning);
            this.gbLogging.Controls.Add(this.chkDebug);
            this.gbLogging.Location = new System.Drawing.Point(12, 118);
            this.gbLogging.Name = "gbLogging";
            this.gbLogging.Size = new System.Drawing.Size(703, 52);
            this.gbLogging.TabIndex = 14;
            this.gbLogging.TabStop = false;
            this.gbLogging.Text = " Logging ";
            // 
            // chkInfo
            // 
            this.chkInfo.AutoSize = true;
            this.chkInfo.Checked = true;
            this.chkInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInfo.Location = new System.Drawing.Point(6, 21);
            this.chkInfo.Name = "chkInfo";
            this.chkInfo.Size = new System.Drawing.Size(47, 17);
            this.chkInfo.TabIndex = 5;
            this.chkInfo.Text = "Info";
            this.chkInfo.UseVisualStyleBackColor = true;
            // 
            // chkError
            // 
            this.chkError.AutoSize = true;
            this.chkError.Checked = true;
            this.chkError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkError.Enabled = false;
            this.chkError.Location = new System.Drawing.Point(208, 21);
            this.chkError.Name = "chkError";
            this.chkError.Size = new System.Drawing.Size(56, 17);
            this.chkError.TabIndex = 2;
            this.chkError.Text = "Errors";
            this.chkError.UseVisualStyleBackColor = true;
            // 
            // chkWarning
            // 
            this.chkWarning.AutoSize = true;
            this.chkWarning.Checked = true;
            this.chkWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWarning.Location = new System.Drawing.Point(126, 21);
            this.chkWarning.Name = "chkWarning";
            this.chkWarning.Size = new System.Drawing.Size(76, 17);
            this.chkWarning.TabIndex = 1;
            this.chkWarning.Text = "Warnings";
            this.chkWarning.UseVisualStyleBackColor = true;
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.Checked = true;
            this.chkDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDebug.Location = new System.Drawing.Point(59, 21);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(61, 17);
            this.chkDebug.TabIndex = 0;
            this.chkDebug.Text = "Debug";
            this.chkDebug.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(727, 225);
            this.Controls.Add(this.gbLogging);
            this.Controls.Add(this.gbFolderMonitor);
            this.Controls.Add(this.btnAssoc);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.pnlBottom.ResumeLayout(false);
            this.gbFolderMonitor.ResumeLayout(false);
            this.gbFolderMonitor.PerformLayout();
            this.gbLogging.ResumeLayout(false);
            this.gbLogging.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAssoc;
        private System.Windows.Forms.GroupBox gbFolderMonitor;
        private System.Windows.Forms.CheckBox chkMonitor;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtMonitoredFolder;
        private System.Windows.Forms.GroupBox gbLogging;
        private System.Windows.Forms.CheckBox chkInfo;
        private System.Windows.Forms.CheckBox chkError;
        private System.Windows.Forms.CheckBox chkWarning;
        private System.Windows.Forms.CheckBox chkDebug;
    }
}