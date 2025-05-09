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
    public partial class cifXMBXState : Form
    {
        private IntPtr _hSysdevice;

        public cifXMBXState(IntPtr hSysdevice)
        {
            InitializeComponent();
            _hSysdevice = hSysdevice;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            GetMbxState();
        }

        private void cifXMBXState_Load(object sender, EventArgs e)
        {
            GetMbxState();
        }

        private void GetMbxState()
        {
            Int32 lret = 0;
            UInt32 RcvPktCnt = 0;
            UInt32 SndPktCnt = 0;

            lret = cifXUser.xSysdeviceGetMBXState(_hSysdevice, ref RcvPktCnt, ref SndPktCnt);
            if (lret == 0)
            {
                this.txtRcvPacket.Text = RcvPktCnt.ToString();
                this.txtSndPacket.Text = SndPktCnt.ToString();
            }
            else
                this.txtError.Text = cifXBase.SetLastError(lret);

        }
    }
}