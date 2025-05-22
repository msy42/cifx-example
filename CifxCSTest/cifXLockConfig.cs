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
    public partial class cifXLockConfig : Form
    {
        private UInt32   pulState     = 0;

        private IntPtr _hChannel;

        public cifXLockConfig(IntPtr hChannel)
        {
            InitializeComponent();

            _hChannel = hChannel;

            this.cmbNewState.Items.Add("Config Lock");
            this.cmbNewState.Items.Add("Config Unlock");
            this.cmbNewState.SelectedIndex = 0;
            this.txtTimeout.Text = "2000";

            GetConfigStatus();
        }

        private void GetConfigStatus()
        {
            Int32 lret = 0;
            UInt32 ulTimeout = (UInt32)Convert.ToInt32(this.txtTimeout.Text);

            lret = cifXUser.xChannelConfigLock(_hChannel, cifXUser.CIFX_CONFIGURATION_GETLOCKSTATE, ref pulState, ulTimeout);
            if (pulState == cifXUser.CIFX_CONFIGURATION_LOCK)
                this.txtActState.Text = "Config LOCKED";
            else
                this.txtActState.Text = "Config NOT LOCKED";

            this.txtError.Text = cifXBase.SetLastError(lret);
        }

        private void SetConfigStatus()
        {
            Int32  lret        = 0;
            UInt32  ulTimeout   = (UInt32)Convert.ToInt32(this.txtTimeout.Text);
            int     iSetStatus  = this.cmbNewState.SelectedIndex;

            if (iSetStatus == 0)
                cifXUser.xChannelConfigLock(_hChannel, cifXUser.CIFX_CONFIGURATION_LOCK, ref pulState, ulTimeout);
            else
                cifXUser.xChannelConfigLock(_hChannel, cifXUser.CIFX_CONFIGURATION_UNLOCK, ref pulState, ulTimeout);

            GetConfigStatus();
            this.txtError.Text = cifXBase.SetLastError(lret);
        }

        private void btnGetLockState_Click(object sender, EventArgs e)
        {
            GetConfigStatus();
        }

        private void btnSetLockState_Click(object sender, EventArgs e)
        {
            SetConfigStatus();
        }
    }
}