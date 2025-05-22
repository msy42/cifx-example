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
    public partial class cifXMain : Form
    {
        public static int ActiveChannel { get; set; }
        public static string ActiveBoard { get; set; }

        private IntPtr _hDriver;
        private IntPtr _hChannel;
        private IntPtr _hSysdevice;

        public cifXMain()
        {
            InitializeComponent();
        }

        private void cifXMain_Load(object sender, EventArgs e)
        {
            AppStart();
            OpenDriver();
            this.Text = "cifX Test Application for C#";
        }

        private void cifXMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_hChannel != IntPtr.Zero)
            {
                cifXUser.xChannelClose(_hChannel);
                _hChannel = IntPtr.Zero;
            }
            if(_hSysdevice != IntPtr.Zero)
            {
                cifXUser.xSysdeviceClose(_hSysdevice);
                _hSysdevice = IntPtr.Zero;
            }
            if(_hDriver != IntPtr.Zero)
            {
                cifXUser.xDriverClose(_hDriver);
                _hDriver = IntPtr.Zero;
            }
        }

        private void applicationReadyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXAppReady CIFXAPPREADY = new cifXAppReady(_hChannel);
            CIFXAPPREADY.MdiParent = this;
            CIFXAPPREADY.Dock = DockStyle.Fill;
            CIFXAPPREADY.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXDownload CIFXDOWNLOAD = new cifXDownload(_hChannel, _hSysdevice);
            CIFXDOWNLOAD.MdiParent = this;
            CIFXDOWNLOAD.Dock = DockStyle.Fill;
            CIFXDOWNLOAD.Show();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXReset CIFXRESET = new cifXReset(_hChannel);
            CIFXRESET.MdiParent = this;
            CIFXRESET.Dock = DockStyle.Fill;
            CIFXRESET.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 lret = 0;

            if (_hChannel != IntPtr.Zero)
            {
                //a channel is open and must be closed first
                lret = cifXUser.xChannelClose(_hChannel);
                _hChannel = IntPtr.Zero;
            }
            else if (_hSysdevice != IntPtr.Zero)
            {
                //a sysdevice is open and must be closed first
                lret = cifXUser.xSysdeviceClose(_hSysdevice);
                _hSysdevice = IntPtr.Zero;
            }
        }

        private void menuStrip1_MenuActivate(object sender, EventArgs e)
        {
            foreach (Form fChild in MdiChildren)
                fChild.Close();

            if (_hSysdevice != IntPtr.Zero && _hChannel == IntPtr.Zero)
                SysDeviceOpened();
            else if (_hSysdevice != IntPtr.Zero && _hChannel != IntPtr.Zero)
                ChannelOpened();
            else
                AppStart();
        }

        private void applicationReadyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cifXAppReady APPREADY = new cifXAppReady(_hChannel);
            APPREADY.MdiParent = this;
            APPREADY.Dock = DockStyle.Fill;
            APPREADY.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXDeviceOPenDlg CIFXDEVICEOPENDLG = new cifXDeviceOPenDlg(_hDriver);
            CIFXDEVICEOPENDLG.MdiParent = this;
            CIFXDEVICEOPENDLG.Dock = DockStyle.Fill;
            CIFXDEVICEOPENDLG.DataAccepted += CIFXDEVICEOPENDLG_DataAccepted;
                        
            CIFXDEVICEOPENDLG.Show();
        }

        private void CIFXDEVICEOPENDLG_DataAccepted(object sender, EventArgs e)
        {
            _hChannel = ((cifXDeviceOPenDlg)sender).hChannel;
            _hSysdevice = ((cifXDeviceOPenDlg)sender).hSysdevice;
        }

        private void driverInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXDrvInfo CIFXINFO = new cifXDrvInfo(_hSysdevice, _hDriver);
            CIFXINFO.MdiParent = this;
            CIFXINFO.Dock = DockStyle.Fill;
            CIFXINFO.Show();
        }

        private void channelInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXChannelInfo CIFXCHNINFO = new cifXChannelInfo(_hChannel, _hSysdevice);
            CIFXCHNINFO.MdiParent = this;
            CIFXCHNINFO.Dock = DockStyle.Fill;
            CIFXCHNINFO.Show();
        }

        private void busStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXBusState CIFXBUSSTATE = new cifXBusState(_hChannel);
            CIFXBUSSTATE.MdiParent = this;
            CIFXBUSSTATE.Dock = DockStyle.Fill;
            CIFXBUSSTATE.Show();
        }

        private void configLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXLockConfig CIFXCONFLOCK = new cifXLockConfig(_hChannel);
            CIFXCONFLOCK.MdiParent = this;
            CIFXCONFLOCK.Dock = DockStyle.Fill;
            CIFXCONFLOCK.Show();
        }

        private void watchdogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXWatchdog CIFXWATCHDOG = new cifXWatchdog(_hChannel);
            CIFXWATCHDOG.MdiParent = this;
            CIFXWATCHDOG.Dock = DockStyle.Fill;
            CIFXWATCHDOG.Show();
        }

        private void fileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXFileExplorer CIFXFILEEXP = new cifXFileExplorer(_hChannel, _hSysdevice);
            CIFXFILEEXP.MdiParent = this;
            CIFXFILEEXP.Dock = DockStyle.Fill;
            CIFXFILEEXP.Show();
        }

        private void iODataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXIOData CIFXIODATA = new cifXIOData(_hChannel);
            CIFXIODATA.MdiParent = this;
            CIFXIODATA.Dock = DockStyle.Fill;
            CIFXIODATA.Show();
        }

        private void pcketDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXPacketData CIFXPCTDATA = new cifXPacketData(_hChannel, _hSysdevice);
            CIFXPCTDATA.MdiParent = this;
            CIFXPCTDATA.Dock = DockStyle.Fill;
            CIFXPCTDATA.Show();
        }

        private void mailboxStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cifXMBXState CIFXMBXSTATE = new cifXMBXState(_hSysdevice);
            CIFXMBXSTATE.MdiParent = this;
            CIFXMBXSTATE.Dock = DockStyle.Fill;
            CIFXMBXSTATE.Show();
        }

        private void AppStart()
        {
            //Menu Device
            this.closeToolStripMenuItem.Enabled = false;
            this.resetToolStripMenuItem.Enabled = false;
            this.applicationReadyToolStripMenuItem.Enabled = false;
            this.busStateToolStripMenuItem.Enabled = false;
            this.configLockToolStripMenuItem.Enabled = false;
            this.watchdogToolStripMenuItem.Enabled = false;
            this.downloadToolStripMenuItem.Enabled = false;
            this.fileExplorerToolStripMenuItem.Enabled = false;

            //Menu Information
            this.channelInformationToolStripMenuItem.Enabled = false;
            this.mailboxStateToolStripMenuItem.Enabled = false;

            //Menu Datatransfer
            this.pcketDataToolStripMenuItem.Enabled = false;
            this.iODataToolStripMenuItem.Enabled = false;

        }

        public void SysDeviceOpened()
        {
            //Menu Device
            this.closeToolStripMenuItem.Enabled = true;
            this.resetToolStripMenuItem.Enabled = true;
            this.applicationReadyToolStripMenuItem.Enabled = false;
            this.busStateToolStripMenuItem.Enabled = false;
            this.configLockToolStripMenuItem.Enabled = false;
            this.watchdogToolStripMenuItem.Enabled = false;
            this.downloadToolStripMenuItem.Enabled = true;
            this.fileExplorerToolStripMenuItem.Enabled = true;

            //Menu Information
            this.channelInformationToolStripMenuItem.Enabled = true;
            this.mailboxStateToolStripMenuItem.Enabled = true;

            //Menu Datatransfer
            this.pcketDataToolStripMenuItem.Enabled = true;
            this.iODataToolStripMenuItem.Enabled = false;

        }

        public void ChannelOpened()
        {
            //Menu Device
            this.closeToolStripMenuItem.Enabled = true;
            this.resetToolStripMenuItem.Enabled = true;
            this.applicationReadyToolStripMenuItem.Enabled = true;
            this.busStateToolStripMenuItem.Enabled = true;
            this.configLockToolStripMenuItem.Enabled = true;
            this.watchdogToolStripMenuItem.Enabled = true;
            this.downloadToolStripMenuItem.Enabled = true;
            this.fileExplorerToolStripMenuItem.Enabled = true;

            //Menu Information
            this.channelInformationToolStripMenuItem.Enabled = true;
            this.mailboxStateToolStripMenuItem.Enabled = true;

            //Menu Datatransfer
            this.pcketDataToolStripMenuItem.Enabled = true;
            this.iODataToolStripMenuItem.Enabled = true;
        }

        private void OpenDriver()
        {
            Int32 lret = 0;
            lret = cifXUser.xDriverOpen(ref _hDriver);
            if (lret == 0)
                this.statusStrip.Items[0].Text = "Driver was succesfully opened";
            else
                this.statusStrip.Items[0].Text = "Driver open failed with " + string.Format("0x{0:X8}", lret.ToString("x"));
        }
    }
}
