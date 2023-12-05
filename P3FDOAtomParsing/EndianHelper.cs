using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing
{
    public class EndianHelper
    {
        /// <summary>
        /// Reads a UInt16 from a byte[] array.
        /// If the system is in LittleEndian mode, then it will convert this back to Network (Big Endian)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="startIndex"></param>
        /// <returns>UInt16 in Big Endian</returns>
        public static UInt16 ToUInt16(byte[] data, int startIndex)
        {
            UInt16 value = BitConverter.ToUInt16(data, startIndex);

            return BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(value) : value;
        }

        public static byte[] ToBytes(UInt16 value)
        {
            byte[] val = new byte[2];
            BinaryPrimitives.WriteUInt16BigEndian(val, value);
            return val;
        }
    }
}
