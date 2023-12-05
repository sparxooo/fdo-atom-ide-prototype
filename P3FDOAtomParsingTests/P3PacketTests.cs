using Microsoft.VisualStudio.TestTools.UnitTesting;
using P3FDOAtomParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing.Tests
{
    [TestClass()]
    public class P3PacketTests
    {
        [TestMethod()]
        public void P3PacketTest()
        {
            try
            {
                
                string packet = "5aa16a00347f15a30382380010000000050f00001c980b3a0a2810c003200000000005010000018007d103ffff0000000000000000000000020d";
                string packetData = "0382380010000000050f00001c980b3a0a2810c003200000000005010000018007d103ffff000000000000000000000002";
                byte[] correctPacketData = Convert.FromHexString(packetData);

                P3Packet p = new P3Packet(Convert.FromHexString(packet));

                Assert.IsTrue(p.CRC == 41322, "CRC should be 41322, but is not");
                Assert.IsTrue(p.Size == 52, "Size should be 52, but is not");
                Assert.IsTrue(p.IsFromClient, "This is a Client INIT packet, but it says it is not");
                Assert.IsTrue(p.Type == P3Type.INIT, "This should be an INIT packet");
                Assert.IsTrue(p.TxSeq == 0x7f, "TxSeq is incorrect");
                Assert.IsTrue(p.RxSeq == 0x15, "RxSeq is incorrect");
                Assert.IsTrue(p.Data.Length == 49, "Data Length Is Incorrect");
                CollectionAssert.AreEqual(p.Data, correctPacketData);

            }catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod()]
        public void P3NAKPacketTest()
        {
            string packet = "5aa16a00347f15a30382380010000000050f00001c980b3a0a2810c003200000000005010000018007d103ffff0000000000000000000000020d";
            string nakPak = "5a540E00041010a5020D";

            P3Packet p = new P3Packet(Convert.FromHexString(nakPak));
            P3Packet p2 = new P3Packet(Convert.FromHexString(packet));

            // Check if it is a NAK packet
            Assert.IsTrue(p.Type == P3Type.NAK, "Packet isn't a NAK packet");
            Assert.IsTrue(p.NAKError == NAKErrorType.INCORRECT_SEQ, "Correctly parsed NAK error");
            Assert.IsTrue(p2.NAKError == null, "Non-NAK packet shouldn't have a NAK Error");
        }
    }
}