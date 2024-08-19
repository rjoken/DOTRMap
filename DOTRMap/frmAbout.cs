using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace DOTRMap.DOTRMap
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void llblSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://buymeacoffee.com/hippochan");
        }

        private void llblGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/rjoken/DOTRMap");
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblAboutText.Text = Constants.VERSION + " built " + Constants.BUILT + "\nCreated by hippochan\nSpecial thanks: GenericMadScientist";
        }
    }
}
