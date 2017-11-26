using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    public partial class DonateForm : Form
    {
        private const String PME_LINK = "http://paypal.me/sabaat";

        public DonateForm()
        {
            InitializeComponent();
            linkLblPayPal.Text = PME_LINK;
        }

        private void linkLblPayPal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(PME_LINK);
        }
    }
}
