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
    public partial class cifXFileExplorer : Form
    {
        private const UInt32 SYSDEVICEFILE = 0;
        private const UInt32 CHANNELFILE   = 1;

        private IntPtr _hChannel = IntPtr.Zero;
        private IntPtr _hSysdevice = IntPtr.Zero;

        public cifXFileExplorer(IntPtr hChannel, IntPtr hSysdevice)
        {
            InitializeComponent();
            if (hChannel == IntPtr.Zero)
            {
                this.cmbChannel.SelectedIndex = 6;
                this.cmbChannel.Enabled       = true;
            }
            else
            {
                this.cmbChannel.SelectedIndex = cifXMain.ActiveChannel;
                this.cmbChannel.Enabled       = false;
            }
        }

        private void GetChannelfiles()
        {
            Int32 lret   = 0;
            UIntPtr pvUser = UIntPtr.Zero;
            string sFile  = null;
            UInt32 ulMode = 0;

            UInt32 ulChannel = (UInt32)this.cmbChannel.SelectedIndex;
            if (ulChannel == 6)
                ulChannel = 0;

            if (_hChannel != IntPtr.Zero)
                ulMode = CHANNELFILE;
            else
                ulMode = SYSDEVICEFILE;

            this.lstFileList.BeginUpdate();
            this.lstFileList.Items.Clear();

            cifXUser.CIFX_DIRECTORYENTRYtag dirEntry = new cifXUser.CIFX_DIRECTORYENTRYtag();
            if (ulMode == SYSDEVICEFILE)
            {
                lret = cifXUser.xSysdeviceFindFirstFile(_hSysdevice, ulChannel, ref dirEntry, null, (UIntPtr)null);
                sFile = dirEntry.szFilename;
                if( sFile.StartsWith(".")==false && lret == 0)
                    this.lstFileList.Items.Add(new ListViewItem(new string[] { sFile, dirEntry.ulFilesize.ToString() }));
                this.txtError.Text = cifXBase.SetLastError(lret);
                do
                {
                    lret = cifXUser.xSysdeviceFindNextFile(_hSysdevice, ulChannel, ref dirEntry, null, (UIntPtr)null);
                    sFile = dirEntry.szFilename;
                    if(sFile.StartsWith(".")==false && lret == 0)
                        this.lstFileList.Items.Add(new ListViewItem(new string[] { sFile, dirEntry.ulFilesize.ToString() }));
                    this.txtError.Text = cifXBase.SetLastError(lret);
                } while (lret == 0);
            }
            else
            {
                lret = cifXUser.xChannelFindFirstFile(_hChannel, ref dirEntry, null, pvUser);
                sFile = dirEntry.szFilename;
                if(sFile.StartsWith(".")==false && lret == 0)
                    this.lstFileList.Items.Add(new ListViewItem(new string[] { sFile, dirEntry.ulFilesize.ToString() }));
                this.txtError.Text = cifXBase.SetLastError(lret);
                do
                {
                    lret = cifXUser.xChannelFindNextFile(_hChannel, ref dirEntry, null, pvUser);
                    sFile = dirEntry.szFilename;
                    if (sFile.StartsWith(".")==false && lret == 0)
                        this.lstFileList.Items.Add(new ListViewItem(new string[] { sFile, dirEntry.ulFilesize.ToString() }));

                    this.txtError.Text = cifXBase.SetLastError(lret);
                } while (lret == 0);
            }
            this.lstFileList.EndUpdate();
        }

        private void cmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetChannelfiles();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetChannelfiles();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            //not implemented yet
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //not implemented yet
        }
    }
}