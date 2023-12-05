using P3FDOAtomParsing.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing.Atoms
{
    public enum atomArg
    {
        na, raw, @byte, word, dword, str, @bool, gid, token, atom, stream, crit,
        objst, var, vdword, vstring, alert, bytelist, orient, multi,
        ignore
    }
    public struct atomDef
    {
        public string name;
        public atomArg arg;
    }

    public class Atom
    {
        public Dictionary<int, atomDef> AtomLookupTable { get { return alt; } }

        public Dictionary<int, atomDef> alt = new Dictionary<int, atomDef>() { };

        public string getAtomName(int atomNumber)
        {
            if (!alt.ContainsKey(atomNumber))
            {
                return "INVALID_ATOM";
            }
            else
                return alt[atomNumber].name;
        }

        public atomArg getAtomArgType(int atomNumber)
        {
            if (!alt.ContainsKey(atomNumber))
            {
                return atomArg.na;
            }
            else
                return alt[atomNumber].arg;
        }
    }
}
