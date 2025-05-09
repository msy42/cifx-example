using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Hilscher.CifX;

namespace cifXTest
{
    public partial class cifXChannelInfo : Form
    {
        private IntPtr _hChannel;
        private IntPtr _hSysdevice;

        public cifXChannelInfo(IntPtr hChannel, IntPtr hSysdevice)
        {
            InitializeComponent();

            _hChannel = hChannel;
            _hSysdevice = hSysdevice;
        }

        private void cmbInfoSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lstList.BeginUpdate();
            this.lstList.Items.Clear();

            switch (this.cmbInfoSelect.SelectedItem.ToString())
            {
                case "Generic Information":
                    GetGenericInformation();
                    break;
                case "Info Block":
                    GetInfoBlock();
                    break;
                case "Channel Block":
                    GetChannelBlock();
                    break;
                case "Control Block":
                    GetControlBlock();
                    break;
                case "Status Block":
                    GetStatusBlock();
                    break;
                case "I/O Information":
                    GetIOInformation();
                    break;
            }
            this.lstList.EndUpdate();
        }

        private void GetIOInformation()
        {
            Int32 lret = 0;
            cifXUser.CHANNEL_INFORMATIONtag channelInfo = new cifXUser.CHANNEL_INFORMATIONtag();
            lret = cifXUser.xChannelInfo(_hChannel, (uint)Marshal.SizeOf(channelInfo), ref channelInfo);

            UInt32 ulAereaInCnt     = channelInfo.ulIOInAreaCnt;
            UInt32 ulAereaOutCnt    = channelInfo.ulIOOutAreaCnt;

            this.lstList.BeginUpdate();
            this.lstList.Items.Clear();

            cifXUser.CHANNEL_IO_INFORMATIONtag channelIOInfo = new cifXUser.CHANNEL_IO_INFORMATIONtag();
            for (uint i = 0; i < ulAereaInCnt; i++)
            {
                lret = cifXUser.xChannelIOInfo(_hChannel, cifXUser.CIFX_IO_INPUT_AREA, i, (uint)Marshal.SizeOf(channelIOInfo), ref channelIOInfo);
                this.txtError.Text = cifXBase.SetLastError(lret);
                this.lstList.Items.Add(new ListViewItem(new string[] { "I/O Input Aerea " + i, "----------------"}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "Size", channelIOInfo.ulTotalSize.ToString()}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "Used Size", channelIOInfo.ulUsedSize.ToString() }));
                this.lstList.Items.Add(new ListViewItem(new string[] { "I/O Mode", channelIOInfo.ulIOMode.ToString() }));
            }
            for (uint i = 0; i < ulAereaOutCnt; i++)
            {
                lret = cifXUser.xChannelIOInfo(_hChannel, cifXUser.CIFX_IO_OUTPUT_AREA, i, (uint)Marshal.SizeOf(channelIOInfo), ref channelIOInfo);
                this.txtError.Text = cifXBase.SetLastError(lret);
                this.lstList.Items.Add(new ListViewItem(new string[] { "I/O Output Aerea " + i, "----------------" }));
                this.lstList.Items.Add(new ListViewItem(new string[] { "Size", channelIOInfo.ulTotalSize.ToString() }));
                this.lstList.Items.Add(new ListViewItem(new string[] { "Used Size", channelIOInfo.ulUsedSize.ToString() }));
                this.lstList.Items.Add(new ListViewItem(new string[] { "I/O Mode", channelIOInfo.ulIOMode.ToString() }));
            }
            this.lstList.EndUpdate();
        }

        private void GetGenericInformation()
        {
            Int32 lret = 0;
            if (_hChannel != IntPtr.Zero)
            {
                //Read Channel Information
                cifXUser.CHANNEL_INFORMATIONtag channelInfo = new cifXUser.CHANNEL_INFORMATIONtag();
                lret = cifXUser.xChannelInfo(_hChannel, (uint)Marshal.SizeOf(channelInfo), ref channelInfo);
                if (lret == 0)
                {
                    //print the channel information to the list
                    string sFWVersion = string.Format("{0:d}.{1:d}.{3:d}.{2:d} (Build {3:d})",
                                                                    channelInfo.usFWMajor,
                                                                    channelInfo.usFWMinor,
                                                                    channelInfo.usFWRevision,
                                                                    channelInfo.usFWBuild);
                    string sFWDate      = string.Format("{1:d}/{0:d}/{2:d}",
                                                                    channelInfo.bFWDay,
                                                                    channelInfo.bFWMonth,
                                                                    channelInfo.usFWYear);            

                    this.lstList.Items.Add(new ListViewItem(new string[] { "Board Name", channelInfo.abBoardName }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Board Alias", channelInfo.abBoardAlias }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Device Number", channelInfo.ulDeviceNumber.ToString()}));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Serial Number", channelInfo.ulSerialNumber.ToString() }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Firmware Name", channelInfo.abFWName }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Firmware Version", sFWVersion }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Firmware Date", sFWDate }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Channel Error", string.Format("0x{0:X8}",channelInfo.ulChannelError) }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Open Count", channelInfo.ulOpenCnt.ToString() }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Put Packet Count", channelInfo.ulPutPacketCnt.ToString() }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Get Packet Count", channelInfo.ulGetPacketCnt.ToString() }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Mailbox Size", channelInfo.ulMailboxSize.ToString() }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "I/O Input Area Count", channelInfo.ulIOInAreaCnt.ToString() }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "I/O Output Area Count", channelInfo.ulIOOutAreaCnt.ToString() }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Handshake Size", channelInfo.ulHskSize.ToString() }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "netX Status Flags", string.Format("0x{0:X8}",channelInfo.ulNetxFlags) }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Host Status Flags", string.Format("0x{0:X8}",channelInfo.ulHostFlags) }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Host COS Flags", string.Format("0x{0:X8}",channelInfo.ulHostCOSFlags) }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Device COS Flags", string.Format("0x{0:X8}",channelInfo.ulDeviceCOSFlags) }));
                }
                else
                    this.txtError.Text = cifXBase.SetLastError(lret);
            }
            else
            {
                cifXUser.SYSTEM_CHANNEL_SYSTEM_INFORMATIONtag systemInformation = new cifXUser.SYSTEM_CHANNEL_SYSTEM_INFORMATIONtag();
                lret = cifXBase.xSysdeviceInfo<cifXUser.SYSTEM_CHANNEL_SYSTEM_INFORMATIONtag>(_hSysdevice, cifXUser.CIFX_INFO_CMD_SYSTEM_INFORMATION, (uint)Marshal.SizeOf(systemInformation), ref systemInformation);
                if (lret == 0)
                {
                    this.lstList.Items.Add(new ListViewItem(new string[] { "System Error", string.Format("0x{0:X8}", 
                                                                            systemInformation.ulSystemError )}));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "DPM Total Size", 
                                                                            systemInformation.ulDpmTotalSize.ToString() }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Mailbox Size", 
                                                                            systemInformation.ulMBXSize.ToString()}));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Device Number", 
                                                                            systemInformation.ulDeviceNumber.ToString()}));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Serial Number", 
                                                                            systemInformation.ulSerialNumber.ToString()}));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Open Count", 
                                                                            systemInformation.ulOpenCnt.ToString()}));
                    this.txtError.Text = cifXBase.SetLastError(lret);
                }
                else
                    this.txtError.Text = cifXBase.SetLastError(lret);
            }
        }

        private void GetInfoBlock()
        {
            Int32 lret = 0;
            cifXUser.SYSTEM_CHANNEL_SYSTEM_INFO_BLOCKtag systemInfoBlock = new cifXUser.SYSTEM_CHANNEL_SYSTEM_INFO_BLOCKtag();
            lret = cifXBase.xSysdeviceInfo<cifXUser.SYSTEM_CHANNEL_SYSTEM_INFO_BLOCKtag>(_hSysdevice, cifXUser.CIFX_INFO_CMD_SYSTEM_INFO_BLOCK, (uint)Marshal.SizeOf(systemInfoBlock), ref systemInfoBlock);
            if (lret == 0)
            {
                this.lstList.Items.Add(new ListViewItem(new string[] { "Cookie", systemInfoBlock.abCookie }));

                this.lstList.Items.Add(new ListViewItem(new string[] { "DPM Total Size", 
                                                                            systemInfoBlock.ulDpmTotalSize.ToString()}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "Device Number", 
                                                                            systemInfoBlock.ulDeviceNumber.ToString()}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "Serial Number", 
                                                                            systemInfoBlock.ulSerialNumber.ToString()}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "HW Option[0]", string.Format("0x{0:X4}",
                                                                            systemInfoBlock.ausHwOptions[0])}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "HW Option[1]", string.Format("0x{0:X4}",
                                                                            systemInfoBlock.ausHwOptions[1])}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "HW Option[2]", string.Format("0x{0:X4}",
                                                                            systemInfoBlock.ausHwOptions[2])}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "HW Option[3]", string.Format("0x{0:X4}",
                                                                            systemInfoBlock.ausHwOptions[3])}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "Manufacturer",      string.Format("0x{0:X4}",
                                                                            systemInfoBlock.usManufacturer)}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "Production Date",   string.Format("0x{0:X4}",
                                                                            systemInfoBlock.usProductionDate)}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "License Flags 1",   string.Format("0x{0:X8}",
                                                                            systemInfoBlock.ulLicenseFlags1)}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "License Flags 2",   string.Format("0x{0:X8}",
                                                                            systemInfoBlock.ulLicenseFlags2)}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "netX License ID",   string.Format("0x{0:X4}",
                                                                            systemInfoBlock.usNetxLicenseID)}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "netX License Flags",string.Format("0x{0:X4}",
                                                                            systemInfoBlock.usNetxLicenseFlags)}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "Device Class",      string.Format("0x{0:X4}",
                                                                            systemInfoBlock.usDeviceClass)}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "HW Revision", 
                                                                            systemInfoBlock.bHwRevision.ToString()}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "HW Compatibility", 
                                                                            systemInfoBlock.bHwCompatibility.ToString()}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "Device ID", 
                                                                            systemInfoBlock.bDevIdNumber.ToString()}));
                this.txtError.Text = cifXBase.SetLastError(lret);
            }
            else
                this.txtError.Text = cifXBase.SetLastError(lret);
        }

        private void GetChannelBlock()
        {
            Int32 lret = 0;
            cifXUser.SYSTEM_CHANNEL_CHANNEL_INFO_BLOCKtag channelInfoBlock = new cifXUser.SYSTEM_CHANNEL_CHANNEL_INFO_BLOCKtag();
            lret = cifXBase.xSysdeviceInfo<cifXUser.SYSTEM_CHANNEL_CHANNEL_INFO_BLOCKtag>(_hSysdevice, cifXUser.CIFX_INFO_CMD_SYSTEM_CHANNEL_BLOCK, (uint)Marshal.SizeOf(channelInfoBlock), ref channelInfoBlock);
            if(lret == 0)
            {
                for (int iChannelDefinition = 0; iChannelDefinition <= cifXUser.CIFX_MAX_NUMBER_OF_CHANNEL_DEFINITION - 1; iChannelDefinition++)
                {
                    byte[] SizeOfChannel = new byte[4]{ channelInfoBlock.abInfoBlock[iChannelDefinition][4],
                                                        channelInfoBlock.abInfoBlock[iChannelDefinition][5],
                                                        channelInfoBlock.abInfoBlock[iChannelDefinition][6],
                                                        channelInfoBlock.abInfoBlock[iChannelDefinition][7]};

                    byte[] MailboxOffset = new byte[2] { channelInfoBlock.abInfoBlock[iChannelDefinition][10],
                                                        channelInfoBlock.abInfoBlock[iChannelDefinition][11]};

                    byte[] MailboxSize = new byte[2] { channelInfoBlock.abInfoBlock[iChannelDefinition][8],
                                                        channelInfoBlock.abInfoBlock[iChannelDefinition][9]};

                    this.lstList.Items.Add(new ListViewItem(new string[] { "Channel " + iChannelDefinition.ToString(),
                                                                       "--------------" }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Type" , GetChannelType(channelInfoBlock.abInfoBlock[iChannelDefinition][0])
                                                                       }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Number of Blocks" ,
                                                                       channelInfoBlock.abInfoBlock[iChannelDefinition][3].ToString()}));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Size of Channel" ,
                                                                       BitConverter.ToInt32(SizeOfChannel, 0).ToString()}));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Mailbox Start Offset" ,
                                                                       BitConverter.ToInt16(MailboxOffset, 0).ToString() }));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Mailbox Size" ,
                                                                       BitConverter.ToInt16(MailboxSize, 0).ToString()}));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Handshake Width" ,
                                                                       channelInfoBlock.abInfoBlock[iChannelDefinition][2].ToString()}));
                    this.lstList.Items.Add(new ListViewItem(new string[] { "Handshake Pos" ,
                                                                       channelInfoBlock.abInfoBlock[iChannelDefinition][2].ToString() }));
                    this.txtError.Text = cifXBase.SetLastError(lret);
                }
            }
            else
                this.txtError.Text = cifXBase.SetLastError(lret);
        }

        private string GetChannelType(byte bCHType)
        {
            switch (bCHType)
            {
                case 0x00:
                    return "UNDEFINED";
                case 0x01:
                    return "NOT AVAILABLE";
                case 0x02:
                    return "RESERVED";
                case 0x03:
                    return "SYSTEM";
                case 0x04:
                    return "HANDSHAKE";
                case 0x05:
                    return "COMMUNICATION";
                case 0x06:
                    return "APPLICATION";
            }
            return "RESERVED";
        }

        private void GetControlBlock()
        {
            Int32 lret = 0;
            cifXUser.SYSTEM_CHANNEL_SYSTEM_CONTROL_BLOCKtag systemControlBlock = new cifXUser.SYSTEM_CHANNEL_SYSTEM_CONTROL_BLOCKtag();
            lret = cifXBase.xSysdeviceInfo<cifXUser.SYSTEM_CHANNEL_SYSTEM_CONTROL_BLOCKtag>(_hSysdevice, cifXUser.CIFX_INFO_CMD_SYSTEM_CONTROL_BLOCK, (uint)Marshal.SizeOf(systemControlBlock), ref systemControlBlock);
            if (lret == 0)
            {
                this.lstList.Items.Add(new ListViewItem(new string[] { "System Command COS", string.Format("0x{0:X8}",
                                                                            systemControlBlock.ulSystemCommandCOS )}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "Reserved", string.Format("0x{0:X8}",
                                                                            systemControlBlock.ulReserved )}));
                this.txtError.Text = cifXBase.SetLastError(lret);
            }
            else
                this.txtError.Text = cifXBase.SetLastError(lret);
        }

        private void GetStatusBlock()
        {
            Int32 lret = 0;
            cifXUser.SYSTEM_CHANNEL_SYSTEM_STATUS_BLOCKtag systemStatusBlock = new cifXUser.SYSTEM_CHANNEL_SYSTEM_STATUS_BLOCKtag();
            lret = cifXBase.xSysdeviceInfo<cifXUser.SYSTEM_CHANNEL_SYSTEM_STATUS_BLOCKtag>(_hSysdevice, cifXUser.CIFX_INFO_CMD_SYSTEM_STATUS_BLOCK, (uint)Marshal.SizeOf(systemStatusBlock), ref systemStatusBlock);
            if (lret == 0)
            {
                double  dCPU    = systemStatusBlock.usCpuLoad;
                int     iSecond = (int)systemStatusBlock.ulTimeSinceStart;
                int     iDay    = iSecond / 86400;
                int     iHour   = (iSecond - (iDay * 86400)) / 3600;
                int     iMinute = (iSecond - (iDay * 86400) - (iHour * 3600)) / 60;
                int     iSec    = (iSecond - (iDay * 86400) - (iHour * 3600) - (iMinute * 60));   
                

                this.lstList.Items.Add(new ListViewItem(new string[] { "System COS", string.Format("0x{0:X8}",
                                                                            systemStatusBlock.ulSystemCOS)}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "System Status", string.Format("0x{0:X8}",
                                                                            systemStatusBlock.ulSystemStatus)}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "System Error", string.Format("0x{0:X8}",
                                                                            systemStatusBlock.ulSystemError)}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "System Start Time [s]", string.Format("{0:d} ({1:d}d {2:d2}:{3:d2}:{4:d2})",
                                                                            iSecond,iDay,iHour,iMinute, iSec)}));
                this.lstList.Items.Add(new ListViewItem(new string[] { "System CPU Load [%]", string.Format("{0:F2}",
                                                                            dCPU/100)}));
                this.txtError.Text = cifXBase.SetLastError(lret);
            }
            else
                this.txtError.Text = cifXBase.SetLastError(lret);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.lstList.BeginUpdate();
            this.lstList.Items.Clear();

            switch (this.cmbInfoSelect.SelectedItem.ToString())
            {
                case "Generic Information":
                    GetGenericInformation();
                    break;
                case "Info Block":
                    GetInfoBlock();
                    break;
                case "Channel Block":
                    GetChannelBlock();
                    break;
                case "Control Block":
                    GetControlBlock();
                    break;
                case "Status Block":
                    GetStatusBlock();
                    break;
                case "I/O Information":
                    GetIOInformation();
                    break;
            }
            this.lstList.EndUpdate();
        }

        private void cifXChannelInfo_Load(object sender, EventArgs e)
        {
            /* If only the Device is opened you have the following possible selections
             * Generic Information
             * Info Block
             * Channel Block
             * Control Block
             * Status Block
             * --------------------------
             * If a channel is opened the following choices are available
             * Generic Information
             * I/O Information
             */

            this.cmbInfoSelect.BeginUpdate();
            this.cmbInfoSelect.Items.Clear();

            if (_hChannel == IntPtr.Zero)
            {
                this.cmbInfoSelect.Items.Add("Generic Information");
                this.cmbInfoSelect.Items.Add("I/O Information");
                this.cmbInfoSelect.SelectedIndex = 0;
            }
            else
            {
                this.cmbInfoSelect.Items.Add("Generic Information");
                this.cmbInfoSelect.Items.Add("Info Block");
                this.cmbInfoSelect.Items.Add("Channel Block");
                this.cmbInfoSelect.Items.Add("Control Block");
                this.cmbInfoSelect.Items.Add("Status Block");
                this.cmbInfoSelect.SelectedIndex = 0;
            }
            this.cmbInfoSelect.EndUpdate();
        }
    }
}