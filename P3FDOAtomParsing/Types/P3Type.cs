using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing
{
    public enum P3Type  : byte
    {
        DATA = 0x20,
        SS = 0x21,
        SSR = 0x22,
        INIT = 0x23,
        ACK = 0x24,
        NAK = 0x25,
        HEARTBEAT=0x26,
    }
}
