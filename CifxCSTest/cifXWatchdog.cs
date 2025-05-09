using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hilscher.CifX;

namespace cifXTest
{
    public partial class cifXWatchdog : Form
    {
        private int iWatchdogState = 0;

        private IntPtr _hChannel;

        public cifXWatchdog(IntPtr hChannel)
        {
            InitializeComponent();
            _hChannel = hChannel;

            this.txtInterval.Text = "500";
        }

        private void btnStartWatchdog_Click(object sender, EventArgs e)
        {
            ChangeState();
        }

        private void ChangeState()
        {
            Int32 lret = 0;
            UInt32 pulTrigger = (UInt32)Convert.ToInt32(this.txtInterval.Text);
            switch (iWatchdogState)
            {
                case 0:
                    lret = cifXUser.xChannelWatchdog(_hChannel, cifXUser.CIFX_WATCHDOG_START, ref pulTrigger);
                    break;

                case 1:
                    break;
            }
            if (lret == 0 && iWatchdogState == 0)
                this.btnStartWatchdog.Text = "Stop Watchdog";
            else
                this.btnStartWatchdog.Text = "start Watchdog";

            this.txtError.Text = cifXBase.SetLastError(lret);
        }
    }
}