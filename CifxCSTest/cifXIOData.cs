using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Hilscher.CifX;

namespace cifXTest
{
    public partial class cifXIOData : Form
    {
        private Regex RX = new Regex(@"[A-Fa-f0-9]+$");

        private IntPtr _hChannel;

        private cifXUser.PFN_NOTIFY_CALLBACK _pNotificationCallback = null;


        public cifXIOData(IntPtr hChannel)
        {
            InitializeComponent();

            _hChannel = hChannel;
        }

        private void StartTimer()
        {
            this.TimerIn.Enabled = true;
        }

        private void InitTimerIn()
        {
            string sTemp = this.cmbTimerIntervall.SelectedItem.ToString();
            this.TimerIn.Interval = Convert.ToInt32(sTemp);
            this.TimerOut.Interval = Convert.ToInt32(sTemp);
        }

        private void cifXIOData_Load(object sender, EventArgs e)
        {
            _pNotificationCallback = NotifyCallback;
            cifXUser.xChannelRegisterNotification(_hChannel, 3, _pNotificationCallback, UIntPtr.Zero);
            

            this.cmbInArea.Items.Add("0");
            this.cmbInArea.Items.Add("1");
            this.cmbInArea.SelectedIndex = 0;

            this.cmbOutArea.Items.Add("0");
            this.cmbOutArea.Items.Add("1");
            this.cmbOutArea.SelectedIndex = 0;

            this.cmbTimerIntervall.Items.Add("1");
            this.cmbTimerIntervall.Items.Add("2");
            this.cmbTimerIntervall.Items.Add("5");
            this.cmbTimerIntervall.Items.Add("10");
            this.cmbTimerIntervall.Items.Add("20");
            this.cmbTimerIntervall.Items.Add("50");
            this.cmbTimerIntervall.Items.Add("100");
            this.cmbTimerIntervall.Items.Add("200");
            this.cmbTimerIntervall.Items.Add("500");
            this.cmbTimerIntervall.Items.Add("1000");
            this.cmbTimerIntervall.SelectedIndex = 4;

            this.txtInLen.Text      = "0";
            this.txtInOffset.Text   = "0";
            this.txtOutOffset.Text  = "0";
            this.txtOutLen.Text     = "0";

            this.Dock = DockStyle.Fill;
            InitTimerIn();
            StartTimer();
        }

        private void NotifyCallback(UInt32 ulNotification, UInt32 ulDataLen, UIntPtr pvData, UIntPtr pvUser)
        {
            Console.WriteLine("Catch Notification: {0}", DateTime.Now.ToString("hh:mm:ss.ffff"));
        }

        private void TimerIn_Tick(object sender, EventArgs e)
        {
            ReadData();
        }

        private void TimerOut_Tick(object sender, EventArgs e)
        {
            WriteData();
        }

        private void ReadData()
        {
            Int32 lret = 0;
            UInt32 ulOffset = 0;
            UInt32 ulDataLen = 0;

            UInt32 ulAreaNumber = Convert.ToUInt32(this.cmbInArea.SelectedItem);
            if (this.txtInOffset.Text != "")
                ulOffset = Convert.ToUInt32(this.txtInOffset.Text);
            if(this.txtInLen.Text!="")
                ulDataLen = Convert.ToUInt32(this.txtInLen.Text);

            if (ulDataLen > 0)
            {
                byte[] pvData = new byte[ulDataLen];

                lret = cifXUser.xChannelIORead(_hChannel, ulAreaNumber, ulOffset, ulDataLen, pvData, cifXUser.CIFX_IO_WAIT_TIMEOUT);
                if (lret != 0)
                    this.txtLastInError.Text = cifXBase.SetLastError(lret);

                this.txtInputData.Text = "";
                foreach (byte sByte in pvData)
                    this.txtInputData.Text += string.Format("{0:X2}", sByte) + " ";
            }
        }

        private void WriteData()
        {
            Int32 lret         = 0;
            UInt32 ulOffset     = 0;
            string sTemp        = "";
            UInt32 ulAreaNumber = Convert.ToUInt32(this.cmbOutArea.SelectedItem);

            if (this.txtOutOffset.Text != "")
                ulOffset = Convert.ToUInt32(this.txtOutOffset.Text);
            
            byte[] pvData = cifXBase.CreateOutputData(this.txtOutputData.Text,this.chkAutoInc.Checked);
            foreach (byte SB in pvData)
            {
                sTemp += string.Format("{0:X2}", SB) + " ";
            }
            this.txtOutputData.Text = sTemp.ToUpper();
            this.txtOutLen.Text = pvData.Length.ToString();

            if (pvData.Length > 0)
            {
                lret = cifXUser.xChannelIOWrite(_hChannel, ulAreaNumber, ulOffset, (UInt32)pvData.Length, pvData, cifXUser.CIFX_IO_WAIT_TIMEOUT);
                if (lret != 0)
                    this.txtLastOutError.Text = cifXBase.SetLastError(lret);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            WriteData();
        }

        private void cmbTimerIntervall_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitTimerIn();
        }

        private void txtOutputData_TextChanged(object sender, EventArgs e)
        {
            this.txtOutLen.Text = this.txtOutputData.Text.Length.ToString();
        }

        private void txtOutputData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (RX.IsMatch(e.KeyChar.ToString()) != true)
                    e.Handled = true;
            }
        }

        private void chkAutoInc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoInc.Checked != true)
                this.txtOutputData.Enabled = true;
            else
                this.txtOutputData.Enabled = false;
        }

        private void chkCyclic_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkCyclic.Checked == true)
                this.TimerOut.Enabled = true;
            else
                this.TimerOut.Enabled = false;
        }

        private void cifXIOData_FormClosing(object sender, FormClosingEventArgs e)
        {
            cifXUser.xChannelUnregisterNotification(_hChannel, 3);
        }
    }
}