using P3FDOAtomParsing.Atoms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing.Types
{

    public class protoDef
    { 
        public string name;
        public Atoms.Atom atom;
    }
 
    public class AtomLookup
    {
        public static Dictionary<int, protoDef> ProtocolLookupTable { get { return plt; } }

        private static Dictionary<int, protoDef> plt = new Dictionary<int, protoDef>()
        {
            { 0, new protoDef{name="UNI_PID",    atom=new Uni()}},
            { 1, new protoDef{name="MAN_PID",    atom=new Man()}},
            { 2, new protoDef{name="ACT_PID",    atom=new Atoms.Atom()}},
            { 3, new protoDef{name="DE_PID",     atom=new De()}},
            { 4, new protoDef{name="BUF_PID",    atom=new Atoms.Atom()}},
            { 5, new protoDef{name="IDB_PID",    atom=new Atoms.Atom()}},
            { 7, new protoDef{name="XFER_PID",   atom=new Atoms.Atom()}},
            { 8, new protoDef{name="FM_PID",     atom=new Atoms.Atom()}},
            { 9, new protoDef{name="LM_PID",     atom=new Atoms.Atom()}},
            {10, new protoDef{name="CM_PID",     atom=new Atoms.Atom()}},
            {12, new protoDef{name="VAR_PID",    atom=new Atoms.Atom()}},
            {13, new protoDef{name="ASYNC_PID",  atom=new Async()}},
            {14, new protoDef{name="SM_PID",     atom=new Atoms.Atom()}},
            {15, new protoDef{name="IF_PID",     atom=new Atoms.Atom()}},
            {16, new protoDef{name="MAT_PID",    atom=new Atoms.Atom()}},
            {17, new protoDef{name="MIP_PID",    atom=new Atoms.Atom()}},
            {20, new protoDef{name="MMI_PID",    atom=new Atoms.Atom()}},
            {21, new protoDef{name="IMGXFER_PID",atom=new Atoms.Atom()}},
            {22, new protoDef{name="IMAGE_PID",  atom=new Atoms.Atom()}},
            {23, new protoDef{name="CHART_PID",  atom=new Atoms.Atom()}},
            {24, new protoDef{name="MORG_PID",   atom=new Atoms.Atom()}},
            {25, new protoDef{name="RICH_PID",   atom=new Atoms.Atom()}},
            {26, new protoDef{name="EXAPI_PID",  atom=new Atoms.Atom()}},
            {27, new protoDef{name="DOD_PID",    atom=new Atoms.Atom()}},
            {28, new protoDef{name="RADIO_PID",  atom=new Atoms.Atom()}},
            {29, new protoDef{name="PICTALK_PID",atom=new Atoms.Atom()}},
            {30, new protoDef{name="IRC_PID",    atom=new Atoms.Atom()}},
            {31, new protoDef{name="DOC_PID",    atom=new Atoms.Atom()}},
            {34, new protoDef{name="CCL_PID",    atom=new Atoms.Atom()}},
            {35, new protoDef{name="P3_PID",     atom=new Atoms.Atom()}},
            {39, new protoDef{name="AD_PID",     atom=new Atoms.Atom()}},
            {41, new protoDef{name="APP_PID",    atom=new Atoms.Atom()}},
            {42, new protoDef{name="MT_PID",     atom=new Atoms.Atom()}},
            {43, new protoDef{name="MERC_PID",   atom=new Atoms.Atom()}},
            {47, new protoDef{name="VRM_PID",    atom=new Atoms.Atom()}},
            {48, new protoDef{name="WWW_PID",    atom=new Atoms.Atom()}},
            {49, new protoDef{name="JAVA_PID",   atom=new Atoms.Atom()}},
            {51, new protoDef{name="HFS_PID",    atom=new Atoms.Atom()}},
            {52, new protoDef{name="BLANK_PID",  atom=new Atoms.Atom()}},
            {53, new protoDef{name="VID_PID",    atom=new Atoms.Atom()}},
            {54, new protoDef{name="ACTIVEX_PID",atom=new Atoms.Atom()}},
            {55, new protoDef{name="SEC_IP_PID", atom=new Atoms.Atom()}},
            {56, new protoDef{name="GALLERY_PID",atom=new Atoms.Atom()}},
            {57, new protoDef{name="DICE_PID",   atom=new Atoms.Atom()}},
            {60, new protoDef{name="PHONE_PID",  atom=new Atoms.Atom()}},
            {61, new protoDef{name="SPELL_PID",  atom=new Atoms.Atom()}},
            {62, new protoDef{name="ARTEXP_PID", atom=new Atoms.Atom()}},
            {63, new protoDef{name="MF_PID",     atom=new Atoms.Atom()}},
            {64, new protoDef{name="PLUGIN_PID", atom=new Atoms.Atom()}},
            {65, new protoDef{name="SLIDER_PID", atom=new Atoms.Atom()}},
            {66, new protoDef{name="ADP_PID",    atom=new Atoms.Atom()}},
            {69, new protoDef{name="MAP_PID",    atom=new Atoms.Atom()}},
            {70, new protoDef{name="SAGE_PID",   atom=new Atoms.Atom()}},
            {73, new protoDef{name="BUDDY_PID",  atom=new Atoms.Atom()}},
            {74, new protoDef{name="COMIT_PID",  atom=new Atoms.Atom()}},
            {75, new protoDef{name="HTMLVIEW_PID", atom=new Atoms.Atom()}},
            {76, new protoDef{name="DPC_PID",    atom=new Atoms.Atom()}},
            {77, new protoDef{name="SAP_PID",    atom=new Atoms.Atom()}},
        };

        public static string getProtocolName(int protocolNumber)
        {
            if (!plt.ContainsKey(protocolNumber))
                return "INVALID_PID";
            else
                return plt[protocolNumber].name;
        }

        public static string getAtomName(int protocolNumber, int atomNumber)
        {
            if (!plt.ContainsKey(protocolNumber) || !plt[protocolNumber].atom.AtomLookupTable.ContainsKey(atomNumber))
            {
                return "INVALID_PID_OR_NO_ATOM_NAME";
            }

            return plt[protocolNumber].atom.getAtomName(atomNumber);
        }

        public static atomArg getAtomArgType(int protocolNumber, int atomNumber)
        {
            if (!plt.ContainsKey(protocolNumber) || !plt[protocolNumber].atom.AtomLookupTable.ContainsKey(atomNumber))
            {
                return atomArg.na;
            }

            return plt[protocolNumber].atom.getAtomArgType(atomNumber) ;
        }

    }
}
