using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing
{
    public class P3InitPacket : P3Packet
    {
        public P3InitPacket(byte[] data) : base(data)
        {
            // Is the base constructor done by now?
            if (this.CRC == 0)
                throw new Exception("Err");
        }
    }
}
