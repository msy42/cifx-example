using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Hilscher.CifX;

namespace cifXTest
{
    public partial class cifXPacketData : Form
    {
        private Regex RX = new Regex(@"[A-Fa-f0-9 ]+$");

        private IntPtr _hChannel;
        private IntPtr _hSysdevice;

        private uint _iRecvCounter = 0;
        private uint _iSendCounter = 0;

        public cifXPacketData(IntPtr hChannel, IntPtr hSysdevice)
        {
            InitializeComponent();

            _hChannel = hChannel;
            _hSysdevice = hSysdevice;

            this.txtSndCmd.Text     = "0x00000000";
            this.txtSndCounter.Text = "0";
            this.txtRcvCounter.Text = "0";
            this.txtSndDest.Text    = "0x00000000";
            this.txtSndDestID.Text  = "0x00000000";
            this.txtSndExt.Text     = "0x00000000";
            this.txtSndID.Text      = "0x00000000";
            this.txtSndLen.Text     = "0";
            this.txtSndRoute.Text   = "0x00000000";
            this.txtSndSrc.Text     = "0x00000000";
            this.txtSndSrcID.Text   = "0x00000000";
            this.txtSndState.Text   = "0x00000000";
        }

        private void RegeExTest(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (RX.IsMatch(e.KeyChar.ToString()) != true)
                    e.Handled = true;
            }
        }

        private void SetHexText(object sender, EventArgs e)
        {
            string sTemp = ((Control)sender).Text;
            UInt32 uiHexValue =0;

            try
            {
                uiHexValue = Convert.ToUInt32(sTemp, 16);
            }
            catch (OverflowException)
            {
                uiHexValue = 0;
            }
            ((Control)sender).Text = "0x" + uiHexValue.ToString("X8");
        }

        private void btnSndPut_Click(object sender, EventArgs e)
        {
            WriteData();
        }

        private void ReadData()
        {
            Int32 lret = 0;
            UInt32 RecvPktCnt = 0;
            UInt32 SendPktCnt = 0;

            cifXUser.CIFX_PACKETtag tPacket = new cifXUser.CIFX_PACKETtag();
            if (_hChannel != IntPtr.Zero)
            {
                lret = cifXUser.xChannelGetMBXState(_hChannel, ref RecvPktCnt, ref SendPktCnt);
                if (lret == 0 && RecvPktCnt > 0)
                {
                    lret = cifXUser.xChannelGetPacket(_hChannel, (uint)Marshal.SizeOf(tPacket), ref tPacket, cifXUser.CIFX_PACKET_WAIT_TIMEOUT);
                    if (lret != 0)
                    {
                        txtRcvError.Text = cifXBase.SetLastError(lret);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                lret = cifXUser.xSysdeviceGetMBXState(_hSysdevice, ref RecvPktCnt, ref SendPktCnt);
                if (lret == 0 && RecvPktCnt > 0)
                {
                    lret = cifXUser.xSysdeviceGetPacket(_hSysdevice, (uint)Marshal.SizeOf(tPacket), ref tPacket, cifXUser.CIFX_PACKET_WAIT_TIMEOUT);
                    if (lret != 0)
                    {
                        txtRcvError.Text = cifXBase.SetLastError(lret);
                    }
                }
            }

            _iRecvCounter++;
            this.txtRcvCounter.Text = _iRecvCounter.ToString();

            if (lret == 0)
            {
                this.txtRcvCmd.Text = "0x" + tPacket.tHeader.ulCmd.ToString("X8");
                this.txtRcvDest.Text = "0x" + tPacket.tHeader.ulDest.ToString("X8");
                this.txtRcvDestID.Text = "0x" + tPacket.tHeader.ulDestId.ToString("X8");
                this.txtRcvExt.Text = "0x" + tPacket.tHeader.ulExt.ToString("X8");
                this.txtRcvID.Text = "0x" + tPacket.tHeader.ulId.ToString("X8");
                this.txtRcvRoute.Text = "0x" + tPacket.tHeader.ulRout.ToString("X8");
                this.txtRcvSrc.Text = "0x" + tPacket.tHeader.ulSrc.ToString("X8");
                this.txtRcvSrcID.Text = "0x" + tPacket.tHeader.ulSrcId.ToString("X8");
                this.txtRcvState.Text = "0x" + tPacket.tHeader.ulState.ToString("X8");
                if (tPacket.abData.Length != 0)
                {
                    this.txtInData.Text = "";
                    for (UInt32 ulIdx = 0; ulIdx < tPacket.tHeader.ulLen; ulIdx++)
                        this.txtInData.Text += string.Format("{0:X2}", tPacket.abData[ulIdx]) + " ";
                }
            }
        }

        private void WriteData()
        {
            Int32 lret = 0;
            
            string sTemp = "";
            cifXUser.CIFX_PACKETtag tPacket = new cifXUser.CIFX_PACKETtag();

            tPacket.tHeader.ulCmd = Convert.ToUInt32(this.txtSndCmd.Text, 16);
            tPacket.tHeader.ulDest = Convert.ToUInt32(this.txtSndDest.Text, 16);
            tPacket.tHeader.ulDestId = Convert.ToUInt32(this.txtSndDestID.Text, 16);
            tPacket.tHeader.ulExt = Convert.ToUInt32(this.txtSndExt.Text, 16);
            try
            {
                tPacket.tHeader.ulId = Convert.ToUInt32(this.txtSndID.Text, 16);
            }
            catch (OverflowException)
            {
                tPacket.tHeader.ulId = 0;
            }
            tPacket.tHeader.ulRout = Convert.ToUInt32(this.txtSndRoute.Text, 16);
            tPacket.tHeader.ulSrc = Convert.ToUInt32(this.txtSndSrc.Text, 16);
            tPacket.tHeader.ulSrcId = Convert.ToUInt32(this.txtSndSrcID.Text, 16);
            tPacket.tHeader.ulState = Convert.ToUInt32(this.txtSndState.Text, 16);


            byte[] pvData = cifXBase.CreateOutputData(this.txtOutData.Text, false);
            tPacket.abData = new byte[cifXUser.CIFX_MAX_DATA_SIZE];
            // Set all data into packet
            Array.Copy(pvData, tPacket.abData, pvData.Length);

            tPacket.tHeader.ulLen = (UInt32)pvData.Length;

            foreach (byte SB in pvData)
            {
                sTemp += string.Format("{0:X2}", SB) + " ";
            }
            this.txtOutData.Text = sTemp.ToUpper();
            this.txtSndLen.Text = pvData.Length.ToString();

            if (_hChannel != IntPtr.Zero)
            {
                //a channel is open so you will send the packets via xChannelPutPacket
                lret = cifXUser.xChannelPutPacket(_hChannel, ref tPacket, cifXUser.CIFX_PACKET_WAIT_TIMEOUT);
            }
            else
            {
                //no channel is open so you will send the packets via xSysdevicePutPacket
                lret = cifXUser.xSysdevicePutPacket(_hSysdevice, ref tPacket, cifXUser.CIFX_PACKET_WAIT_TIMEOUT);
            }

            _iSendCounter++;
            this.txtSndCounter.Text = _iSendCounter.ToString();


            if (this.chkSndAutoInc.Checked == true)
            {
                Int32 iSndId = (Int32)tPacket.tHeader.ulId++;
                this.txtSndID.Text = "0x" + (++iSndId).ToString("X8");
            }
            if (lret != 0)
                this.txtSndError.Text = cifXBase.SetLastError(lret);
            else
                this.txtSndError.Text = "";
        }

        private void TimerOut_Tick(object sender, EventArgs e)
        {
            WriteData();
        }

        private void chkSndCyclic_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSndCyclic.Checked == true)
                this.TimerOut.Enabled = true;
            else
                this.TimerOut.Enabled = false;
        }

        private void btnRcvGet_Click(object sender, EventArgs e)
        {
            ReadData();
        }

        private void chkRcvCyclic_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkRcvCyclic.Checked == true)
                this.TimerIn.Enabled = true;
            else
                this.TimerIn.Enabled = false;
        }

        private void TimerIn_Tick(object sender, EventArgs e)
        {
            ReadData();
        }

        private void btnSndResetCnt_Click(object sender, EventArgs e)
        {
            _iSendCounter = 0;
        }

        private void btnRcvResetCnt_Click(object sender, EventArgs e)
        {
            _iRecvCounter = 0;
        }
    }
}