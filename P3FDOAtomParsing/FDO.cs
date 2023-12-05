using P3FDOAtomParsing.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing
{
    /// <summary>
    /// FDO Class contains the token", "and also the Atom Stream/Atoms or just Atoms.
    /// These will get parsed out
    /// </summary>
    public class FDO
    {
        public string Token { get; set; }

        public byte[]? RawData { get { return this.rawData; } set {this.rawData = value; } }
        public byte[]? rawData = null;

        public bool HasAtomStream = false;

        public byte[]? StreamID { get; set; }
        public int StreamIDLength = 0;

        public List<Atom> Atoms { get; set; } = new List<Atom>();

        /// <summary>
        /// Returns an empty FDO object
        /// </summary>
        public FDO(string token) { this.Token = token; }


        public FDO(byte[] data)
        {
            // Check data length
            if (data.Length < 2) throw new ArgumentException("Data not long enough to contain a token");

            string tok = System.Text.Encoding.ASCII.GetString(data, 0, 2);

            this.Token = tok;
            this.RawData = new byte[data.Length - 2];
            Array.Copy(data, 2, this.RawData, 0, data.Length - 2);


            // Process any streamID we may have (take this into account when reading atoms later on)
            this.processStreamId();

            this.parseAtoms();
        }

        // TODO: Parse the Prefix style properly
        public void parseAtoms()
        {
            // No Raw Data to Parse
            if(this.rawData == null) return;

            // Lets begin to parse the Atoms from the data stream
            // We need to skip ahead by AtomStreamID if we have an AtomStream
            // If not, just start at zero
            int startIndex = this.HasAtomStream ? this.StreamIDLength : 0;
            int currentIndex = startIndex;
            Atom? lastAtom = null;
            Atom? prefixAtom = null;
            
            // While we're less than the RawData stream
            while(currentIndex < rawData.Length)
            {
                AtomStyle atomStyle = (AtomStyle)((rawData[currentIndex] & 0b11100000) >> 5);

                // Just a stupidity check, if we don't have enough in the buffer, then exit.
                if (atomStyle == AtomStyle.Full && rawData.Length - currentIndex < 3 ||
                    (atomStyle == AtomStyle.Length || atomStyle == AtomStyle.Data || atomStyle == AtomStyle.Current) && rawData.Length - currentIndex < 2)
                    break;

                Atom newAtom = new Atom(atomStyle);
                newAtom.parseProtocolNumber(ref rawData, currentIndex, lastAtom, prefixAtom);
                newAtom.parseAtomNumber(ref rawData, currentIndex, lastAtom, prefixAtom);
                int nextAtom = newAtom.parseArgs(ref rawData, currentIndex);
                currentIndex = nextAtom;
                Atoms.Add(newAtom);

                // Check if we were a prefix atom
                if (newAtom.Style == AtomStyle.Prefix)
                {
                    prefixAtom = newAtom;
                }
                else
                {
                    // If we weren't a prefix atom, AND, the prefixAtom is not null, and has the keep bit set, then remove it.
                    if (prefixAtom != null && !prefixAtom.KeepPrefix)
                    {
                        prefixAtom = null;
                        lastAtom = newAtom;
                    }
                    else
                    {
                        lastAtom = newAtom;
                    }
                }
                    

            }

        }

        private void processStreamId()
        {
            // Check if we have an atomStream or not
            char[] tokensWhichDontHaveAtomStreamsPrefixes = new char[] { 'F', 'T', 'x' };
            string[] tokensWhichDontHaveAtomStreams = new string[] { "AA", "AB", "AC", "AD", "CA", "CB", "D3", "D6", "DD", "dp", "Dp", "eI", "eJ", "eX", "fD", "OT", "XS" };

            if (this.Token.Length > 1 && !tokensWhichDontHaveAtomStreams.Contains(this.Token) && !tokensWhichDontHaveAtomStreamsPrefixes.Contains(this.Token[0]))
                this.HasAtomStream = true; // We have an Atom Stream

            int streamIDLength = 2;
            
            if (this.Token == "at") // Length of streamID is 4 bytes
                streamIDLength = 4;
            else if (this.Token == "At") // Length of streamID is 3 bytes
                streamIDLength = 3;


            if (this.RawData != null && (this.RawData.Length >= streamIDLength))
            {
                this.StreamID = new byte[streamIDLength];
                Array.Copy(this.RawData, this.StreamID, streamIDLength);
                this.StreamIDLength = streamIDLength;
            }
            else
            {
                throw new Exception("FDO Parsing:- IsAtomStream but not enough data to parse");
            }
        }
    }
}
