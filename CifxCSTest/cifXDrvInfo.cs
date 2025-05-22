using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Hilscher.CifX;

namespace cifXTest
{
    public partial class cifXDrvInfo : Form
    {
        private IntPtr _hDriver;
        private IntPtr _hSysdevice;

        public cifXDrvInfo(IntPtr hSysDevice, IntPtr hDriver)
        {
            InitializeComponent();

            _hSysdevice = hSysDevice;
            _hDriver = hDriver;


            cifXUser.DRIVER_INFORMATIONtag driverInfo = new cifXUser.DRIVER_INFORMATIONtag();
            cifXUser.xDriverGetInformation(_hDriver, (UInt32)Marshal.SizeOf(driverInfo), ref driverInfo);

            this.lstList.BeginUpdate();
            this.lstList.Items.Clear();

            this.lstList.Items.Add(new ListViewItem(new string[] { "Driver Version", driverInfo.abDriverVersion }));
            this.lstList.Items.Add(new ListViewItem(new string[] { "Board Count", driverInfo.ulBoardCnt.ToString() }));

            this.lstList.EndUpdate();
            this.lstList.Visible = true;
        }

        private byte[] StringToByteArray(string str)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetBytes(str);
        }

        private string ByteArrayToString(byte[] arr)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetString(arr);
        }

        private void GetGenericInformation()
        {
            Int32 lret = 0;
            cifXUser.SYSTEM_CHANNEL_SYSTEM_INFORMATIONtag systemInformation = new cifXUser.SYSTEM_CHANNEL_SYSTEM_INFORMATIONtag();
            lret = cifXBase.xSysdeviceInfo<cifXUser.SYSTEM_CHANNEL_SYSTEM_INFORMATIONtag>(_hSysdevice, cifXUser.CIFX_INFO_CMD_SYSTEM_INFORMATION, (uint)Marshal.SizeOf(systemInformation), ref systemInformation);
            this.lstList.Items.Add(new ListViewItem(new string[] { "System Error", string.Format("0x{0:x8}", 
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
        }

        private void GetInfoBlock()
        {
            Int32 lret = 0;

            cifXUser.SYSTEM_CHANNEL_SYSTEM_INFO_BLOCKtag systemInfoBlock = new cifXUser.SYSTEM_CHANNEL_SYSTEM_INFO_BLOCKtag();
            lret = cifXBase.xSysdeviceInfo<cifXUser.SYSTEM_CHANNEL_SYSTEM_INFO_BLOCKtag>(_hSysdevice, cifXUser.CIFX_INFO_CMD_SYSTEM_INFO_BLOCK, (uint)Marshal.SizeOf(systemInfoBlock), ref systemInfoBlock);
            this.lstList.Items.Add(new ListViewItem(new string[] { "Cookie", systemInfoBlock.abCookie }));

            this.lstList.Items.Add(new ListViewItem(new string[] { "DPM Total Size", 
                                                                            systemInfoBlock.ulDpmTotalSize.ToString()}));
            this.lstList.Items.Add(new ListViewItem(new string[] { "Device Number", 
                                                                            systemInfoBlock.ulDeviceNumber.ToString()}));
            this.lstList.Items.Add(new ListViewItem(new string[] { "Serial Number", 
                                                                            systemInfoBlock.ulSerialNumber.ToString()}));
            this.lstList.Items.Add(new ListViewItem(new string[] { "HW Option[0]", string.Format("0x{0:x4}",
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
        }

        private void GetChannelBlock()
        {
            Int32 lret = 0;

            cifXUser.SYSTEM_CHANNEL_CHANNEL_INFO_BLOCKtag channelInfoBlock = new cifXUser.SYSTEM_CHANNEL_CHANNEL_INFO_BLOCKtag();
            lret = cifXBase.xSysdeviceInfo<cifXUser.SYSTEM_CHANNEL_CHANNEL_INFO_BLOCKtag>(_hSysdevice, cifXUser.CIFX_INFO_CMD_SYSTEM_CHANNEL_BLOCK, (uint)Marshal.SizeOf(channelInfoBlock), ref channelInfoBlock);
            
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
            }
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
            this.lstList.Items.Add(new ListViewItem(new string[] { "System Command COS", string.Format("0x{0:X8}",
                                                                            systemControlBlock.ulSystemCommandCOS )}));
            this.lstList.Items.Add(new ListViewItem(new string[] { "Reserved", string.Format("0x{0:X8}",
                                                                            systemControlBlock.ulReserved )}));
        }

        private void GetStatusBlock()
        {
            Int32 lret = 0;

            cifXUser.SYSTEM_CHANNEL_SYSTEM_STATUS_BLOCKtag systemStatusBlock = new cifXUser.SYSTEM_CHANNEL_SYSTEM_STATUS_BLOCKtag();
            lret = cifXBase.xSysdeviceInfo<cifXUser.SYSTEM_CHANNEL_SYSTEM_STATUS_BLOCKtag>(_hSysdevice, cifXUser.CIFX_INFO_CMD_SYSTEM_STATUS_BLOCK, (uint)Marshal.SizeOf(systemStatusBlock), ref systemStatusBlock);
            this.lstList.Items.Add(new ListViewItem(new string[] { "System COS", string.Format("0x{0:X8}",
                                                                            systemStatusBlock.ulSystemCOS)}));
            this.lstList.Items.Add(new ListViewItem(new string[] { "System Status", string.Format("0x{0:X8}",
                                                                            systemStatusBlock.ulSystemStatus)}));
            this.lstList.Items.Add(new ListViewItem(new string[] { "System Error", string.Format("0x{0:X8}",
                                                                            systemStatusBlock.ulSystemError)}));
            this.lstList.Items.Add(new ListViewItem(new string[] { "System Start Time [s]", 
                                                                            systemStatusBlock.ulTimeSinceStart.ToString()}));
            this.lstList.Items.Add(new ListViewItem(new string[] { "System CPU Load [%]", string.Format("{0:2%}",
                                                                            systemStatusBlock.usCpuLoad)}));
        }
    }
}