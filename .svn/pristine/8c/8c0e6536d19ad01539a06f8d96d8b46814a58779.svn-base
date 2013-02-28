using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaymentKiosk.About
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblCopyright.Text = "Copyright (c) " + DateTime.Now.Year.ToString() + " by Payment Kiosk Systems. All Rights Reserved.";
            lblVersion.Text = AssemblyVersion.GetAssemblyVersion();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
