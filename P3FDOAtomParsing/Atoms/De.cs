using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing.Atoms
{
    public class De : Atom
    {
        public De()
        {
            this.alt = new Dictionary<int, atomDef>(){
               {      0   , new atomDef{name="de-set-extraction-type", arg=atomArg.@byte}},
  {      1   , new atomDef{name="de-data"               , arg=atomArg.str}},
  {      2   , new atomDef{name="de-start-extraction"   , arg=atomArg.dword}},
  {      3   , new atomDef{name="de-set-data-type"      , arg=atomArg.@byte}},
  {      4   , new atomDef{name="de-set-variable-id"    , arg=atomArg.dword}},
  {      5   , new atomDef{name="de-set-text-column"    , arg=atomArg.dword}},
  {      6   , new atomDef{name="de-get-data"           , arg=atomArg.@byte}},
  {      7   , new atomDef{name="de-end-extraction"     , arg=atomArg.raw}},
  {      8   , new atomDef{name="de-get-data-value"     , arg=atomArg.@byte}},
  {      9   , new atomDef{name="de-get-data-pointer"   , arg=atomArg.@byte}},
  {     10   , new atomDef{name="de-ez-send-form"       , arg=atomArg.token}},
  {     11   , new atomDef{name="de-custom-data"        , arg=atomArg.raw}},
  {     12   , new atomDef{name="de-ez-send-list-text"  , arg=atomArg.token}},
  {     14   , new atomDef{name="de-ez-send-list-index" , arg=atomArg.token}},
  {     15   , new atomDef{name="de-ez-send-field"      , arg=atomArg.token}},
  {     16   , new atomDef{name="de-validate"           , arg=atomArg.@byte}},
  {     17   , new atomDef{name="de-typed-data"         , arg=atomArg.@byte}},
};
        }
    }
}
