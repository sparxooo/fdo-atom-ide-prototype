using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;

namespace P3FDOAtomParsing
{
    public class P3Packet
    {
        /// <summary>
        /// The magic byte of the packet (0x5A)
        /// </summary>
        public byte MagicByte { get; } = 0x5A;

        /// <summary>
        /// The CRC of the packet (generate yourself)
        /// </summary>
        public UInt16 CRC { get; set; } = 0x0;

        /// <summary>
        /// The length of the packet from 5 bytes to the stop bit (not incl)
        /// </summary>
        public UInt16 Size { get; set; } = 0x0;

        public int DataSize { get { return this.Size - 3; } }

        public byte TxSeq { get; set; } = 0x7f;

        public byte RxSeq { get; set; } = 0x7f;

        public P3Type Type { get; set; }

        public bool IsFromClient { get; set; }

        public byte[] Data { get; set; } = new byte[] { };

        public NAKErrorType? NAKError {  get
            {
                if (this.Type != P3Type.NAK || this.DataSize < 1) return null;// Not NAK or no payload to get error from
                return ((NAKErrorType)this.Data[0]);
            } 
        }

        public byte StopBit { get; } = 0x0D;

        private const int P3MinPacketLength = 9;
        private const int P3CRCStartIndex = 1;
        private const int P3SizeStartIndex = 3;
        private const int P3TxSeqIndex = 5;
        private const int P3RxSeqIndex = 6;
        private const int P3TypeIndex = 7;
        private const int P3DataStartIndex = 8;

        public FDO? FDO { get; set; }



        public P3Packet(byte[] data)
        {
            // Lets parse a P3Packet...
            // If there is no data, if the data is less than 1, or data doesnt begin with Z (0x5A), return.
            if (data == null || data.Length < P3MinPacketLength || data[0] != 0x5A || data[data.Length - 1] != 0x0D)
            {
                throw new Exception("Badly formed P3 packet byte stream");
            }

            this.CRC = EndianHelper.ToUInt16(data, P3CRCStartIndex);
            this.Size = EndianHelper.ToUInt16(data, P3SizeStartIndex);


            this.TxSeq = data[P3TxSeqIndex];
            this.RxSeq = data[P3RxSeqIndex];

            P3Type type = (P3Type)(data[P3TypeIndex] & 0b01111111);

            this.Type = type;
            this.IsFromClient = (data[P3TypeIndex] & 0b10000000) == 0x80;

            this.Data = new byte[this.DataSize];
            Array.Copy(data, P3DataStartIndex, this.Data, 0, this.DataSize);

            if (this.Type == P3Type.DATA)
                this.FDO = new FDO(this.Data);
        }

        /// <summary>
        /// Construct the P3 packet
        /// </summary>
        /// <param name="tx_seq"></param>
        /// <param name="rx_seq"></param>
        /// <returns></returns>
        public byte[] Build(int tx_seq, int rx_seq)
        {
            return new byte[1];
        }

    }
}
