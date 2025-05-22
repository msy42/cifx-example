using System;
using System.Windows.Forms;
using Hilscher.CifX;

namespace cifXTest
{
    public partial class cifXBusState : Form
    {
        private UInt32   pulState     = 0;

        private IntPtr _hChannel;

        public cifXBusState(IntPtr hChannel)
        {
            InitializeComponent();

            _hChannel = hChannel;

            this.cmbNewState.Items.Add("Bus OFF");
            this.cmbNewState.Items.Add("Bus ON");
            this.cmbNewState.SelectedIndex = 0;
            this.txtTimeout.Text = "0";

            GetBusStatus();
        }

        private void GetBusStatus()
        {
            Int32 lret = 0;
            UInt32 ulTimeout = (UInt32)Convert.ToInt32(this.txtTimeout.Text);

            lret = cifXUser.xChannelBusState(_hChannel, cifXUser.CIFX_BUS_STATE_GETSTATE, ref pulState, ulTimeout);
            if (pulState == cifXUser.CIFX_BUS_STATE_OFF)
                this.txtActState.Text = "Bus OFF";
            else
                this.txtActState.Text = "Bus ON";

            this.txtError.Text = cifXBase.SetLastError(lret);
        }

        private void SetBusStatus()
        {
            Int32  lret        = 0;
            UInt32  ulTimeout   = (UInt32)Convert.ToInt32(this.txtTimeout.Text);
            int     iSetStatus  = this.cmbNewState.SelectedIndex;

            if (iSetStatus == 0)
                cifXUser.xChannelBusState(_hChannel, cifXUser.CIFX_BUS_STATE_OFF, ref pulState, ulTimeout);
            else
                cifXUser.xChannelBusState(_hChannel, cifXUser.CIFX_BUS_STATE_ON, ref pulState, ulTimeout);

            GetBusStatus();
            this.txtError.Text = cifXBase.SetLastError(lret);
        }

        private void btnGetBusState_Click(object sender, EventArgs e)
        {
            GetBusStatus();
        }

        private void btnSetBusState_Click(object sender, EventArgs e)
        {
            SetBusStatus();
        }
    }
}