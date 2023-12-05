using P3FDOAtomParsing.Atoms;
using P3FDOAtomParsing.Types;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing
{
    public class Atom
    {
        public AtomStyle Style { get; private set; }
        public string ProtocolName { get { return AtomLookup.getProtocolName(this.ProtocolNum); } }
        public int ProtocolNum { get; set; } = -1;
        public string AtomName { get { return AtomLookup.getAtomName(this.ProtocolNum, this.AtomNum); } }

        public atomArg AtomArgType { get { return AtomLookup.getAtomArgType(this.ProtocolNum, this.AtomNum); } }
        public string GetAtomArgData { get
            {
                // Find out type
                switch (AtomArgType)
                {
                    case atomArg.str:
                        return System.Text.Encoding.ASCII.GetString(this.Args);
                    break;
                }

                return "0xDEADBEEF";
            } 
        }
        public int AtomNum { get; set; } = -1;
        public UInt16 ArgsLen { get; set; } = 0;
        public bool BigArgsLen { get; set; }
        public byte[] Args { get; set; } = Array.Empty<byte>();
        public int ProtocolOffset { get; set; } = -1;
        public int AtomOffset { get; set; } = -1;
        public bool KeepPrefix { get; set; }
        public bool HadPrefixApplied { get; set; }

        public Atom(AtomStyle style)
        {
            Style = style;
        }

        public void parseProtocolNumber(ref byte[] data, int index, Atom? lastAtom, Atom? prefixAtom)
        {
            // Only if we are an Atom that has a protocol number
            if ((int)this.Style > (int)AtomStyle.Data)
            {
                // We don't have a protocol number, use the last one...
                if(this.Style != AtomStyle.Prefix)
                {
                    // Use last protocol number
                    if (lastAtom != null)
                    {
                        ProtocolNum = lastAtom.ProtocolNum;
                        // Set if this has been modified by Prefix atoms
                        HadPrefixApplied = lastAtom.HadPrefixApplied;
                    }

                }
                    return;
            }

            // Get first byte, bitwise AND to get only first 5 bits
            int protocolNum = data[index + 0] & 0b00011111;

            // Check if we have an active prefix atom
            if(prefixAtom!= null && prefixAtom.Style == AtomStyle.Prefix)
            {
                protocolNum = protocolNum | prefixAtom.ProtocolOffset;
                this.HadPrefixApplied = true;
            }

            this.ProtocolNum = protocolNum;
        }

        public void parseAtomNumber(ref byte[] data, int index, Atom? lastAtom, Atom? prefixAtom)
        {
            // If we are an atom that doesn't have atom numbers (like, prefix only), parse the offsets
            if (this.Style == AtomStyle.Prefix)
            {
                int protoOffset = (data[index] & 0b00011000) >> 3;
                int atomOffset = (data[index] & 0b00000110) >> 1;
                int keepPrefix = data[index] & 0b0000001;
                this.KeepPrefix = keepPrefix == 1;
                this.ProtocolOffset = protoOffset;
                this.AtomOffset = atomOffset;

                return;
            }

            // Set the index of where the atom number is supposed to be
            // For Full, Length and Data styles it's in the second byte.
            // For all others except prefix, it's in the first byte.
            int atomNumIndex = (int)this.Style < 3 ? 1 : 0;
            byte atomNumBitwise = (byte)(this.Style == AtomStyle.Full ? 0b11111111 : 0b00011111);

            int atomNum = data[index + atomNumIndex] & atomNumBitwise;

            if (prefixAtom != null && prefixAtom.Style == AtomStyle.Prefix)
            {
                this.HadPrefixApplied = true;
                this.AtomNum = atomNum | prefixAtom.AtomOffset;
            }
            this.AtomNum = atomNum;
        }

        /// <summary>
        /// Parse the args from the data stream, is responsible for returning the index of the next atom
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int parseArgs(ref byte[] data, int index)
        {
            int valToFirstArg = 0;

            // Check for those atoms which don't have args, in which case, just return the next index
            if (this.Style == AtomStyle.Atom || this.Style == AtomStyle.Prefix)
            {
                return index+1; // Just add one
            }
            else if (this.Style == AtomStyle.One || this.Style == AtomStyle.Zero)
            {
                // Set the arguments
                this.Args = new byte[1] { (byte)(this.Style == AtomStyle.One ? 1 : 0) };
                return index+1; // Just add one, as args implicit
            }
            else if (this.Style == AtomStyle.Data)
            {
                // Argument for Data style is in it's second byte, last 3 bits
                this.Args = new byte[1] { (byte)((data[index + 1] & 0b11100000) >> 5) };
                return index + 2;
            }
            else
            {
                // Work at getting the args len value
                int argsLen = 0;

                switch (this.Style)
                {
                    case AtomStyle.Full:
                        // Get if args_len is big
                        this.BigArgsLen = (data[index + 2] & 0b10000000) >> 7 == 1;

                        argsLen = this.BigArgsLen ? EndianHelper.ToUInt16(data, index + 2) : (UInt16)data[index + 2];

                        this.ArgsLen = Convert.ToUInt16(this.BigArgsLen ? argsLen & 0b0111111111111111 : argsLen & 0b01111111);
                        valToFirstArg = this.BigArgsLen ? 4 : 3;
                        break;
                    case AtomStyle.Length:
                        this.ArgsLen = Convert.ToUInt16((data[index + 1] & 0b11100000) >> 5);
                        valToFirstArg = 2;
                        break;
                    case AtomStyle.Current:
                        this.ArgsLen = Convert.ToUInt16(data[index + 1]);
                        valToFirstArg = 2;
                        break;
                }

                // We now know args len. Check if we have enough bytes...
                if (data.Length < index + valToFirstArg + this.ArgsLen) throw new Exception("Data array not long enough to parse args... whoops");

                this.Args = new byte[this.ArgsLen];

                for (int i = 0; i < this.ArgsLen; i++)
                {
                    this.Args[i] = data[index + valToFirstArg + i];
                }

                // Done!
                // Return the index to the next atom
                return index + valToFirstArg + this.ArgsLen;

            }

            throw new Exception("Shouldnt have got here?");
        }

        // Construct the atom back into bytes!
        public byte[] Build()
        {
            MemoryStream ms = new MemoryStream();
            switch (this.Style)
            {
                case AtomStyle.Full:
                    
                    byte[] stream = this.BigArgsLen ? new byte[4 + this.ArgsLen] : new byte[3 + this.ArgsLen];

                stream[0] = (byte)(this.ProtocolNum & 0b00011111); // Write the style and protocol number
                stream[1] = (byte)(this.AtomNum); // Write the Atom number
                if (this.BigArgsLen)
                {
                    UInt16 size = (UInt16)(this.ArgsLen | 0b1000000000000000); // Set the sizeof arg_len bit
                    byte[] bsize = EndianHelper.ToBytes(size);
                    stream[2] = bsize[0];
                    stream[3] = bsize[1];
                }
                else
                {
                    stream[2] = (byte)(Convert.ToByte(this.ArgsLen) | 0x01111111);
                }

                return stream;
                break;
            }
                
                return Array.Empty<byte>();
        }
        
            
    }
}
