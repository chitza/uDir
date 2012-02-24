namespace uDir
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.lnkFatcow = new System.Windows.Forms.LinkLabel();
            this.lnkCC2 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppNameLarge = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(300, 157);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lnkFatcow
            // 
            this.lnkFatcow.AutoSize = true;
            this.lnkFatcow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkFatcow.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.lnkFatcow.Location = new System.Drawing.Point(3, 0);
            this.lnkFatcow.Name = "lnkFatcow";
            this.lnkFatcow.Size = new System.Drawing.Size(94, 15);
            this.lnkFatcow.TabIndex = 4;
            this.lnkFatcow.Text = "Icons by FatCow";
            this.lnkFatcow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnLinkClicked);
            // 
            // lnkCC2
            // 
            this.lnkCC2.AutoSize = true;
            this.lnkCC2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkCC2.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.lnkCC2.Location = new System.Drawing.Point(103, 0);
            this.lnkCC2.Name = "lnkCC2";
            this.lnkCC2.Size = new System.Drawing.Size(145, 15);
            this.lnkCC2.TabIndex = 7;
            this.lnkCC2.Text = "used under CC 3.0 License";
            this.lnkCC2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnLinkClicked);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lnkCC2);
            this.panel1.Controls.Add(this.lnkFatcow);
            this.panel1.Location = new System.Drawing.Point(6, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 25);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblAppNameLarge);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(387, 63);
            this.panel2.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(3, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "© Chitza";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAppName.Location = new System.Drawing.Point(2, 67);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(116, 21);
            this.lblAppName.TabIndex = 11;
            this.lblAppName.Text = "Program.Name";
            // 
            // lblAppNameLarge
            // 
            this.lblAppNameLarge.AutoSize = true;
            this.lblAppNameLarge.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAppNameLarge.Location = new System.Drawing.Point(44, 9);
            this.lblAppNameLarge.Name = "lblAppNameLarge";
            this.lblAppNameLarge.Size = new System.Drawing.Size(213, 37);
            this.lblAppNameLarge.TabIndex = 13;
            this.lblAppNameLarge.Text = "Program.Name";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(387, 192);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Program.Name";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel lnkFatcow;
        private System.Windows.Forms.LinkLabel lnkCC2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppNameLarge;
    }
}