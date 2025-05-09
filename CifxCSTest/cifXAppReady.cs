using System;
using System.Windows.Forms;
using Hilscher.CifX;


namespace cifXTest
{
    public partial class cifXAppReady : Form
    {
        private UInt32 pulState = 0;

        private IntPtr _hChannel;

        public cifXAppReady(IntPtr hChannel)
        {
            InitializeComponent();

            _hChannel = hChannel;

            this.cmbNewState.Items.Add("Application NOT Ready");
            this.cmbNewState.Items.Add("Application Ready");
            this.cmbNewState.SelectedIndex = 0;
            this.txtTimeout.Text = "0";

            GetAppStatus();

        }

        private void GetAppStatus()
        {
            Int32 lret = 0;
            UInt32 ulTimeout = (UInt32)Convert.ToInt32(this.txtTimeout.Text);

            lret = cifXUser.xChannelHostState(_hChannel, cifXUser.CIFX_HOST_STATE_READ, ref pulState, ulTimeout);
            if (pulState == cifXUser.CIFX_HOST_STATE_NOT_READY)
                this.txtActState.Text = "Application NOT Ready";
            else
                this.txtActState.Text = "Application Ready";

            this.txtError.Text = cifXBase.SetLastError(lret);
        }

        private void SetAppStatus()
        {
            Int32  lret        = 0;
            UInt32  ulTimeout   = (UInt32)Convert.ToInt32(this.txtTimeout.Text);
            int     iSetStatus  = this.cmbNewState.SelectedIndex;

            if (iSetStatus == 0)
                cifXUser.xChannelHostState(_hChannel, cifXUser.CIFX_HOST_STATE_NOT_READY, ref pulState, ulTimeout);
            else
                cifXUser.xChannelHostState(_hChannel, cifXUser.CIFX_HOST_STATE_READY, ref pulState, ulTimeout);

            GetAppStatus();
            this.txtError.Text = cifXBase.SetLastError(lret);
        }

        private void btnGetAppState_Click(object sender, EventArgs e)
        {
            GetAppStatus();
        }

        private void btnSetAppState_Click(object sender, EventArgs e)
        {
            SetAppStatus();
        }
    }
}