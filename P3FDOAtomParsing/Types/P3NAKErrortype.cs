using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing
{
    public enum NAKErrorType : byte
    {
        INVALID_CRC = 0x01,
        INCORRECT_SEQ = 0x02,
        INCORRECT_LEN = 0x03,
    }
}
