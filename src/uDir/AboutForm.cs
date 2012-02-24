/*
  DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE 
                    Version 2, December 2004 

 Copyright (C) 2010 Chitza <chitza@gmail.com> 

 Everyone is permitted to copy and distribute verbatim or modified 
 copies of this license document, and changing it is allowed as long 
 as the name is changed. 

            DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE 
   TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION 

  0. You just DO WHAT THE FUCK YOU WANT TO. 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uDir
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            lnkFatcow.Links.Add(9, 6, "http://www.fatcow.com/free-icons/");
            lnkCC2.Links.Add(11, 35, "http://creativecommons.org/licenses/by/3.0/us/");
            lblAppName.Text = Program.FullName;
            lblAppNameLarge.Text = Program.Name;
            this.Text = "About " + Program.Name;
        }

        public static void OpenUrl(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening link.\r\nError: " + ex.Message, "About " + Program.Name, MessageBoxButtons.OK);
            }
        }

        private void OnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var lnkLabel = sender as LinkLabel;
            if (lnkLabel != null)
            {
                lnkLabel.Links[lnkLabel.Links.IndexOf(e.Link)].Visited = true;
                string target = e.Link.LinkData as string;
                if (null != target)
                    OpenUrl(target);
            }
        }

    }
}
