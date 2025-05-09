using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Hilscher.CifX;

namespace cifXTest
{
    public partial class cifXDeviceOPenDlg : Form
    {
        public event EventHandler DataAccepted;

        private IntPtr _hDriver;
        private IntPtr _hChannel;
        private IntPtr _hSysdevice;

        public IntPtr hChannel { get { return _hChannel; } }
        public IntPtr hSysdevice { get { return _hSysdevice; } }
        

        public cifXDeviceOPenDlg(IntPtr hDriver)
        {
            _hDriver = hDriver;
            InitializeComponent();
            EnumBoards();
            this.trvDevice.ExpandAll();
        }


        private void EnumBoards()
        {
            UInt32                          lret            = 0;
            UInt32                          iBoardCount     = 0;

            do
            {
                cifXUser.BOARD_INFORMATIONtag boardInfo = new cifXUser.BOARD_INFORMATIONtag();
                lret = (UInt32)cifXUser.xDriverEnumBoards(_hDriver, iBoardCount, (UInt32)Marshal.SizeOf(boardInfo), ref boardInfo);
                if (lret == 0)
                {
                    //a valid board is found
                    TreeNodeAdd((int)iBoardCount, (int)boardInfo.ulChannelCnt);
                    iBoardCount++;
                }
            } while (lret == 0);
        }

        private cifXUser.BOARD_INFORMATIONtag GetBoardInformation(UInt32 iBoardNumber)
        {
            Int32                          lret        = 0;
            cifXUser.BOARD_INFORMATIONtag boardInfo = new cifXUser.BOARD_INFORMATIONtag();
            lret = cifXUser.xDriverEnumBoards(_hDriver, iBoardNumber, (UInt32)Marshal.SizeOf(boardInfo), ref boardInfo);

            return boardInfo;
        }

        //private void EnumChannels( UInt32 iBoardNumber, int maxChannelCnt )
        //{
        //    UInt32                          lret            = 0;
        //    int                             iChannelcount   = 0;

        //    for (iChannelcount = 0; iChannelcount < maxChannelCnt; iChannelcount++)
        //    {
        //        lret = cifXUser.xDriverEnumChannels(_hDriver, iBoardNumber, (UInt32)iChannelcount);
        //    }
        //}

        private cifXUser.CHANNEL_INFORMATIONtag GetChannelInformation(IntPtr hChannel)
        {
            Int32 lret = 0;
            cifXUser.CHANNEL_INFORMATIONtag channelInfo = new cifXUser.CHANNEL_INFORMATIONtag();
            lret = cifXUser.xChannelInfo(hChannel, (UInt32)Marshal.SizeOf(channelInfo), ref channelInfo);

            return channelInfo;
        }

        private void TreeNodeAdd(int iBoardCount, int maxChannelCnt)
        {
            int iCnt = 0;
            TreeNode tnParent = new TreeNode();
            tnParent.Text = "cifX" + iBoardCount.ToString();
            for (iCnt = 0; iCnt < maxChannelCnt; iCnt++)
            {
                tnParent.Nodes.Add("Channel" + iCnt.ToString());
            }
            this.trvDevice.Nodes.Add(tnParent);
        }

        private void FillList(cifXUser.BOARD_INFORMATIONtag boardInfo)
        {
            ListViewItem    lstItem         = new ListViewItem();
            string          sPhysicalAddress = string.Format("0x{0:X8}",boardInfo.ulPhysicalAddress);
            this.lstInfo.BeginUpdate();
            this.lstInfo.Items.Clear();

            this.lstInfo.Items.Add(new ListViewItem(new string[] { "Physical Address" ,
                                                                    sPhysicalAddress}));
            this.lstInfo.Items.Add(new ListViewItem(new string[] { "Interrupt" ,
                                                                    boardInfo.ulIrqNumber.ToString()}));
            this.lstInfo.Items.Add(new ListViewItem(new string[] { "Device Number" ,
                                                                    boardInfo.tSystemInfo.ulDeviceNumber.ToString()}));
            this.lstInfo.Items.Add(new ListViewItem(new string[] { "Serial Number" ,
                                                                    boardInfo.tSystemInfo.ulSerialNumber.ToString()}));
            this.lstInfo.Items.Add(new ListViewItem(new string[] { "DPM Size" ,
                                                                    boardInfo.ulDpmTotalSize.ToString()}));            
            this.lstInfo.EndUpdate();
        }

        private void FillSubList(cifXUser.CHANNEL_INFORMATIONtag channelInfo)
        {
            string sFWVersion = string.Format("{0:d}.{1:d}.{3:d}.{2:d} (Build {3:d})",
                                                                    channelInfo.usFWMajor,
                                                                    channelInfo.usFWMinor,
                                                                    channelInfo.usFWRevision,
                                                                    channelInfo.usFWBuild);
            string sFWDate      = string.Format("{1:d}/{0:d}/{2:d}",
                                                                    channelInfo.bFWDay,
                                                                    channelInfo.bFWMonth,
                                                                    channelInfo.usFWYear);            

            this.lstInfo.BeginUpdate();

            this.lstInfo.Items.Add(new ListViewItem(new string[] { "Firmware Name" , channelInfo.abFWName}));
            this.lstInfo.Items.Add(new ListViewItem(new string[] { "Firmware Version" , sFWVersion }));
            this.lstInfo.Items.Add(new ListViewItem(new string[] { "Firmware Date" , sFWDate }));
                                                    
            this.lstInfo.EndUpdate();
        }

        private void trvDevice_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //a valid board is selected to show the board information
            int                             iBoard              = -1;
            int                             iChannel            = -1;
            string                          sBoardName          = "";

            if (e.Node.Text.StartsWith("Channel"))
            {
                iBoard      = Int32.Parse(e.Node.Parent.Text.Substring(e.Node.Parent.Text.Length - 1));
                sBoardName  = e.Node.Parent.Text;
                iChannel    = Int32.Parse(e.Node.Text.Substring(e.Node.Text.Length - 1));
            }
            else
                iBoard = Int32.Parse(e.Node.Text.Substring((e.Node.Text.Length - 1)));

            
            FillList(GetBoardInformation((UInt32)iBoard));
            if (iChannel != -1)
            {
                Int32 lret = 0;
                IntPtr hChannel = IntPtr.Zero;
                lret = cifXUser.xChannelOpen(_hDriver, sBoardName, (uint)iChannel, ref hChannel);
                if (lret == 0)
                {
                    cifXMain.ActiveChannel = iChannel;
                    FillSubList(GetChannelInformation(hChannel));
                }
                cifXUser.xChannelClose(hChannel);
                hChannel = IntPtr.Zero;
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string sTreeNodeSelected    = this.trvDevice.SelectedNode.Text;
            string sTreeNodeParent      = null;
            if(this.trvDevice.SelectedNode.Parent != null)
                sTreeNodeParent      = this.trvDevice.SelectedNode.Parent.Text;

            Int32 lret                 = 0;

            if (sTreeNodeParent != null)
            {
                //a subnode is selected (channel), so you have to call the xChannelOpen function
                int iChannel = Int32.Parse(sTreeNodeSelected.Substring(sTreeNodeSelected.Length - 1));
                //Open the Sysdevice to get the handle
                
                lret = cifXUser.xSysdeviceOpen(_hDriver, sTreeNodeParent, ref _hSysdevice);
                //Open the channel to get the handle
                lret = cifXUser.xChannelOpen(_hDriver, sTreeNodeParent, (uint)iChannel, ref _hChannel);
                if (lret == 0)
                {
                    //The channel is succesfully opened. The channel Number will be stored in ActiveChannel
                    cifXMain.ActiveChannel  = iChannel;
                    cifXMain.ActiveBoard    = sTreeNodeParent;
                    MdiParent.Text = "cifX Test Application for C# " + cifXMain.ActiveBoard.ToString() + " Channel" + cifXMain.ActiveChannel.ToString();
                }
                DataAccepted(this, e);
                this.Close();
            }
            else
            {
                //a parent node is selected (device), so you have to call the xSysdeviceOpen function
                lret = cifXUser.xSysdeviceOpen(_hDriver, sTreeNodeSelected, ref _hSysdevice);
                if (lret == 0)
                {
                    cifXMain.ActiveChannel = 0;
                    //cifXUser.hChannel = 0;
                    cifXMain.ActiveBoard = sTreeNodeSelected;
                    MdiParent.Text = "cifX Test Application for C# " + sTreeNodeSelected;
                }
                this.Close();
            }
        }

    }
}