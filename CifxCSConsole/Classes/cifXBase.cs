using System;
using System.Runtime.InteropServices;
using System.Text;
using Hilscher.CifX;

namespace cifXTest
{

    public class cifXBase
    {
        const int PACKET_WAIT_TIMEOUT = 4000;
        const int IO_WAIT_TIMEOUT = 40;

        //cifxUser constants
        private const uint HIL_REGISTER_APP_REQ = 0x00002F10;
        private const uint HIL_REGISTER_APP_CNF = 0x00002F11;

        private const uint HIL_UNREGISTER_APP_REQ = 0x00002F12;
        private const uint HIL_UNREGISTER_APP_CNF = 0x00002F13;

        //private const uint

        //HIL_ApplicationCmd constants
        private const uint HIL_LINK_STATUS_CHANGE_IND = 0x00002F8A;
        private const uint HIL_LINK_STATUS_CHANGE_RES = 0x00002F8B;


        private IntPtr _hChannel;

        public cifXBase(IntPtr hChannel)
        {
            _hChannel = hChannel;
        }

        public int App_RegisterApplication(uint uniqueID)
        {
            int lRet = 0;

            cifXUser.CIFX_PACKETtag packet = new cifXUser.CIFX_PACKETtag();

            packet.tHeader.ulDest = 0x20;
            packet.tHeader.ulCmd = HIL_REGISTER_APP_REQ;
            packet.tHeader.ulSrc = uniqueID;

            
            lRet = cifXUser.xChannelPutPacket(_hChannel, ref packet, IO_WAIT_TIMEOUT);

            return lRet;
        }

        public int App_HandlePackets(uint timeout)
        {
            int lRet = 0;
            cifXUser.CIFX_PACKETtag packet = new cifXUser.CIFX_PACKETtag();

            lRet = cifXUser.xChannelGetPacket(_hChannel, (uint)Marshal.SizeOf(packet), ref packet, timeout);
            if ((ulong)lRet != cifXError.CIFX_NO_ERROR)
            {
                return lRet;
            }

            switch (packet.tHeader.ulCmd)
            {
                case HIL_REGISTER_APP_CNF:
                    
                    return (int)packet.tHeader.ulState;

                case HIL_UNREGISTER_APP_CNF:
                    
                    return (int)packet.tHeader.ulState;

                
                default:
                    
                    break;
            }
            //CheckReturnValue(ret);
            return lRet;
        }


        public static string SetLastError(Int32 lError)
        {
            string sError = null;

            if (lError == 0)
            {
                sError = string.Format("0x{0:X8}", lError);
                return sError;
            }
            else
            {
                StringBuilder szBuffer = null;
                UInt32 ulSize = 1024;
                Int32 lret = 0;
                sError = string.Format("0x{0:X8}", lError);

                lret = cifXUser.xDriverGetErrorDescription(lError, szBuffer, ulSize);
                sError += "\r\n" + szBuffer.ToString();
                return sError;
            }
        }

        public static byte[] CreateOutputData(string sTemp, bool bAutoInc)
        {
            //delete all existing blanks
            sTemp = sTemp.Replace(" ", "");
            byte[] data = new byte[(sTemp.Length +1) / 2];
           
            int iLen = sTemp.Length;
            if (iLen > 0)
            {
                int offset = 0;
                if(sTemp.Length % 2 > 0)
                {
                    data[0] = Convert.ToByte(sTemp[0].ToString(), 16);
                    offset = 1;
                }

                for (int i = 0; i < (sTemp.Length >> 1); i++)
                {
                    string str = sTemp.Substring(i * 2 + offset, 2);
                    data[i + offset] = Convert.ToByte(str, 16);
                    if (bAutoInc)
                        data[i]++;
                }
                return data;
            }
            byte[] pvNullData = new byte[0];
            return pvNullData;
        }
    }
}
