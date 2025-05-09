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
    public partial class cifXReset : Form
    {
        private IntPtr _hChannel;

        public cifXReset(IntPtr hChannel)
        {
            InitializeComponent();

            _hChannel = hChannel;
        }

        private void cifXReset_Load(object sender, EventArgs e)
        {
            this.cmbMode.BeginUpdate();
            this.cmbMode.Items.Clear();

            if (_hChannel != IntPtr.Zero)
            {
                //a channel is open there for the user can select the mode for reset
                //channel or device
                this.cmbMode.Items.Add("System Start");
                this.cmbMode.Items.Add("Channel Init");
                this.cmbMode.SelectedIndex = 1;   
            }
            else
            {
                //only a device is opened ther for you only can reset the device
                this.cmbMode.Items.Add("System Start");
                this.cmbMode.SelectedIndex = 0;
            }
            this.cmbMode.EndUpdate();
            this.txtTimeout.Text = "10000";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Int32 lret = 0;
            UInt32 ulTimeout = (UInt32)Convert.ToInt32(this.txtTimeout.Text);
            if (this.cmbMode.SelectedIndex == 1)
                lret = cifXUser.xChannelReset(_hChannel, cifXUser.CIFX_CHANNELINIT, ulTimeout);
            else
                lret = cifXUser.xSysdeviceReset(_hChannel, ulTimeout);

            this.txtError.Text = cifXBase.SetLastError(lret);
        }
    }
}