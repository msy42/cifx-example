using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Hilscher.CifX;

namespace cifXTest
{
    public partial class cifXDownload : Form
    {
        private const int   CONFIG      = 0;
        private const int   FILE        = 1;
        private const int   FW          = 2;
        private const int   LIC         = 3;

        private string sFilePath        = "";
        private string sFileName        = "";
        private byte[] abFileData;

        private IntPtr _hChannel;
        private IntPtr _hSysdevice;

        public cifXDownload(IntPtr hChannel, IntPtr hSysdevice)
        {
            InitializeComponent();

            _hChannel = hChannel;
            _hSysdevice = hSysdevice;
        }

        private void cifXDownload_Load(object sender, EventArgs e)
        {
            this.cmbMode.BeginUpdate();
            this.cmbMode.Items.Clear();

            /*  constants for file download as they are defined in cifXUser.cs
                DOWNLOAD_MODE_FIRMWARE    = 1;
                DOWNLOAD_MODE_CONFIG      = 2;
                DOWNLOAD_MODE_FILE        = 3;
                DOWNLOAD_MODE_BOOTLOADER  = 4; 
                DOWNLOAD_MODE_LICENSECODE = 5; 
            */

            this.cmbMode.Items.Add("Configuration Download");
            this.cmbMode.Items.Add("File Download");
            this.cmbMode.Items.Add("Firmware Download");
            this.cmbMode.Items.Add("License Download");

            if (_hChannel != IntPtr.Zero)
            {
                this.cmbMode.SelectedIndex  = CONFIG;
                this.txtChannel.Text        = cifXMain.ActiveChannel.ToString();
                this.txtChannel.Enabled     = false;
            }
            else
            {
                this.cmbMode.SelectedIndex  = FW;
                this.txtChannel.Text        = "0";
                this.txtChannel.Enabled     = true;
            }

            this.cmbMode.EndUpdate();
        }

        private void btnSelFile_Click(object sender, EventArgs e)
        {
            FileDialog  dlgFileOpen = new OpenFileDialog();
            int         iSelIndex   = this.cmbMode.SelectedIndex;
            
            switch (iSelIndex)
            {
                case CONFIG:
                    dlgFileOpen.Filter = "netX Configuration File (*.nxd, *.dbm)|*.nxd, *.dbm";
                    break;
                case FILE:
                    dlgFileOpen.Filter = "All Files (*.*)|*.*";
                    break;
                case FW:
                    dlgFileOpen.Filter = "netX Firmware Files (*.nxf, *.nxm, *.mod)|*.nxf; *.nxm; *.mod";
                    break;
                case LIC:
                    dlgFileOpen.Filter = "netX License Files (*.nxl)|*.nxl";
                    break;
            }
            
            if (dlgFileOpen.ShowDialog() != DialogResult.Cancel)
            {
                this.txtFilename.Text = dlgFileOpen.FileName;
                sFilePath = dlgFileOpen.FileName;
                sFileName = sFilePath.Substring(sFilePath.LastIndexOf("\\") + 1);
            }
        }

        private void btnStartDownload_Click(object sender, EventArgs e)
        {
            Int32 lret         = 0;
            abFileData          = ReadFile(sFilePath);
            UInt32 ulChannel    = 0;    //Up to now we support only channel 0
            UInt32 ulMode       = 0;

            switch(this.cmbMode.SelectedIndex)
            {
                case CONFIG:
                    ulMode = cifXUser.DOWNLOAD_MODE_CONFIG;
                    break;

                case FILE:
                    ulMode = cifXUser.DOWNLOAD_MODE_FILE;
                    break;

                case FW:
                    ulMode = cifXUser.DOWNLOAD_MODE_FIRMWARE;
                    break;

                case LIC:
                    ulMode = cifXUser.DOWNLOAD_MODE_LICENSECODE;
                    break;
            }

            if (_hChannel != IntPtr.Zero)
                //because of the greater Channel Mailbox, you should prefer the download via the xChannelDownload
                lret = cifXUser.xChannelDownload(_hChannel, ulMode, sFileName, abFileData, (uint)abFileData.Length, ProgressCallback, RecvPktCallback, UIntPtr.Zero);
            else
                lret = cifXUser.xSysdeviceDownload(_hSysdevice, ulChannel, ulMode, sFileName, abFileData, (uint)abFileData.Length, null, null, UIntPtr.Zero);

            this.txtError.Text = cifXBase.SetLastError(lret);
        }

        private void ProgressCallback(UInt32 ulStep, UInt32 ulMaxStep, UIntPtr pvUser, char bFinished, Int32 lError)
        {
            Console.Out.WriteLine("ProgressCallback:");
        }

        private void RecvPktCallback(ref cifXUser.CIFX_PACKETtag ptRecvPkt, UIntPtr pvUser)
        {
            Console.Out.WriteLine("RecvPktCallback:");
        }

        private byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

    }
}