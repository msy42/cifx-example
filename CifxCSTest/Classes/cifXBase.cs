using System;
using System.Runtime.InteropServices;
using System.Text;
using Hilscher.CifX;

namespace cifXTest
{
    public class cifXBase
    {
        ///<exclude/>
        public static Int32 xSysdeviceInfo<T>(IntPtr hSysDevice, UInt32 ulCmd, UInt32 size, ref T pvData)
        {
            byte[] data = new byte[size];
            Int32 lret = cifXUser.xSysdeviceInfo(hSysDevice, ulCmd, size, data);
            IntPtr ptr = Marshal.AllocHGlobal((int)size);
            Marshal.Copy(data, 0, ptr, (int)size);

            pvData = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);
            return lret;
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
                StringBuilder szBuffer = new StringBuilder();
                UInt32 ulSize = 1024;
                Int32 lret = 0;
                sError = string.Format("0x{0:X8}", lError);

                lret = cifXUser.xDriverGetErrorDescription(lError, szBuffer, ulSize);
                sError += "\r\n" + szBuffer.ToString();
                return sError;
            }
        }

       

        public static string ByteArrayToString(byte[] arr)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetString(arr);
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
