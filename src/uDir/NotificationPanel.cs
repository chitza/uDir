using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chitza.Utils.Extensions;

namespace uDir
{
    public partial class NotificationPanel : UserControl
    {
        int sign = 1;

        const int speed = 7;
        const int acceleration = 3;

        private int dy = speed;
        int maxHeight = 45;
        Timer autoClose;
        int autoCloseInterval = 10000;//10s

        public NotificationPanel()
        {
            InitializeComponent();
            autoClose = new Timer(this.components);
            autoClose.Interval = autoCloseInterval;
            autoClose.Tick += new EventHandler(OnAutoCloseTimer);
            timer.Interval = 20;
        }

        #region Properties
        public string Message
        {
            get { return lblMessage.Text; }
            set
            {
                lblMessage.InvokeIfNeeded(() => lblMessage.Text = value);
            }
        }

        private Icon Icon
        {
            set
            {
                if (value != null)
                    picIcon.Image = value.ToBitmap();
            }
        } 
        #endregion

        private Icon GetSystemIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Information: return SystemIcons.Information;
                case MessageBoxIcon.Warning: return SystemIcons.Warning;
                case MessageBoxIcon.Question: return SystemIcons.Question;
                case MessageBoxIcon.Error: return SystemIcons.Error;
                default: return SystemIcons.Application;
            }
        }

        public void Show(string message, MessageBoxIcon icon)
        {
            Message = message;
            this.Icon = GetSystemIcon(icon);
            autoClose.Enabled = true;
            Animate(false);
        }

        public void Show(string message)
        {
            Show(message, MessageBoxIcon.Information);
        }

        public void Close()
        {
            OnAutoCloseTimer(null, EventArgs.Empty);
        }

        private void Animate(bool close)
        {
            sign = close ? -1 : 1;
            dy = speed * sign;
            timer.Enabled = true;
        }

        private void OnAnimateTimer(object sender, EventArgs e)
        {
            if ((dy > 0 && Height + dy > maxHeight + dy) || (dy < 0 && Height + dy < dy - 1))
            {
                timer.Enabled = false;
                return;
            }

            Height += dy;
            dy += sign * acceleration;
        }

        private void OnAutoCloseTimer(object sender, EventArgs e)
        {
            Animate(true);
            autoClose.Enabled = false;
        }

        private void OnClick(object sender, EventArgs e)
        {
            Animate(true);
        }

        private void picClose_MouseHover(object sender, EventArgs e)
        {
            this.picClose.Image = global::uDir.Properties.Resources.cross_red;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            this.picClose.Image = global::uDir.Properties.Resources.cross_grayscale;
        }
    }
}
