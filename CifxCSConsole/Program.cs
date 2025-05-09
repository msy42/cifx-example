using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hilscher.CifX;

using Hilscher;
using cifXTest;

namespace CifxCSConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int ret = 0;
            IntPtr pDriver = IntPtr.Zero;
            IntPtr pChannel = IntPtr.Zero;

            ret = cifXUser.xDriverOpen(ref pDriver);

            if((ulong)ret == cifXError.CIFX_NO_ERROR)
            {
                ret = cifXUser.xChannelOpen(pDriver, "cifx2", 0, ref pChannel);

                if((ulong)ret == cifXError.CIFX_NO_ERROR)
                {
                    cifXBase cifx = new cifXBase(pChannel);

                    
                }
            }

            ret = cifXUser.xChannelClose(pChannel);
            ret = cifXUser.xDriverClose(pDriver);


        }
    }
}
