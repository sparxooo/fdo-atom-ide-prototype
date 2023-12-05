using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing.Atoms
{
    internal class Uni : Atom
    {
        public Uni()
        {

            this.alt = new()
            {
{ 0, new atomDef{name="uni-void"                    , arg=atomArg.raw}},
{ 1, new atomDef{name="uni-start-stream"            , arg=atomArg.raw}},
{ 2, new atomDef{name="uni-end-stream"              , arg=atomArg.raw}},
{ 3, new atomDef{name="uni-abort-stream"            , arg=atomArg.dword}},
{ 4, new atomDef{name="uni-start-large-atom"        , arg=atomArg.ignore}},
{ 5, new atomDef{name="uni-large-atom-segment"      , arg=atomArg.ignore}},
{ 6, new atomDef{name="uni-end-large-atom"          , arg=atomArg.ignore}},
{ 7, new atomDef{name="uni-sync-skip"               , arg=atomArg.dword}},
{ 8, new atomDef{name="uni-start-loop"              , arg=atomArg.raw}},
{ 9, new atomDef{name="uni-end-loop"                , arg=atomArg.raw}},
{10, new atomDef{name="uni-use-last-atom-string"    , arg=atomArg.multi}},
{11, new atomDef{name="uni-use-last-atom-value"     , arg=atomArg.multi}},
{12, new atomDef{name="uni-save-result"             , arg=atomArg.raw}},
{14, new atomDef{name="uni-data"                    , arg=atomArg.raw}},
{15, new atomDef{name="uni-wait-on"                 , arg=atomArg.raw}},
{16, new atomDef{name="uni-wait-off"                , arg=atomArg.raw}},
{17, new atomDef{name="uni-start-stream-wait-on"    , arg=atomArg.raw}},
{18, new atomDef{name="uni-wait-off-end-stream"     , arg=atomArg.raw}},
{19, new atomDef{name="uni-invoke-no-context"       , arg=atomArg.gid}},
{20, new atomDef{name="uni-invoke-local"            , arg=atomArg.gid}},
{21, new atomDef{name="uni-get-result"              , arg=atomArg.raw}},
{22, new atomDef{name="uni-next-atom-typed"         , arg=atomArg.word}},
{23, new atomDef{name="uni-start-typed-data"        , arg=atomArg.word}},
{24, new atomDef{name="uni-end-typed-data"          , arg=atomArg.raw}},
{32, new atomDef{name="uni-force-processing"        , arg=atomArg.raw}},
{33, new atomDef{name="uni-set-command-set"         , arg=atomArg.dword}},
{34, new atomDef{name="uni-wait-clear"              , arg=atomArg.raw}},
{35, new atomDef{name="uni-change-stream-id"        , arg=atomArg.dword}},
{36, new atomDef{name="uni-diagnostic-msg"          , arg=atomArg.multi}},
{37, new atomDef{name="uni-hold"                    , arg=atomArg.raw}},
{40, new atomDef{name="uni-invoke-local-preserve"   , arg=atomArg.gid}},
{41, new atomDef{name="uni-invoke-local-later"      , arg=atomArg.gid}},
{42, new atomDef{name="uni-convert-last-atom-string", arg=atomArg.raw}},
{43, new atomDef{name="uni-break"                   , arg=atomArg.raw}},
{44, new atomDef{name="uni-single-step"             , arg=atomArg.raw}},
{45, new atomDef{name="uni-convert-last-atom-data"  , arg=atomArg.raw}},
{46, new atomDef{name="uni-get-first-stream"        , arg=atomArg.raw}},
{47, new atomDef{name="uni-get-next-stream"         , arg=atomArg.raw}},
{48, new atomDef{name="uni-get-stream-window"       , arg=atomArg.dword}},
{49, new atomDef{name="uni-cancel-action"           , arg=atomArg.dword}},
{50, new atomDef{name="uni-get-current-sream-id"    , arg=atomArg.raw}},
{51, new atomDef{name="uni-set-data-length"         , arg=atomArg.dword}},
{52, new atomDef{name="uni-use-last-atom-data"      , arg=atomArg.atom}},
{53, new atomDef{name="uni-set-watchdog-interval"   , arg=atomArg.dword}},
{54, new atomDef{name="uni-udo-complete"            , arg=atomArg.raw}},
{55, new atomDef{name="uni-test-update"             , arg=atomArg.raw}},
{56, new atomDef{name="uni-insert-stream"           , arg=atomArg.str}},
{57, new atomDef{name="uni-next-atom-mixed-data"    , arg=atomArg.raw}},
{58, new atomDef{name="uni-start-mixed-data-mode"   , arg=atomArg.raw}},
{59, new atomDef{name="uni-end-mixed-data-mode"     , arg=atomArg.raw}},
{60, new atomDef{name="uni-transaction-id"          , arg=atomArg.dword}},
{61, new atomDef{name="uni-result-code"             , arg=atomArg.dword}},
{62, new atomDef{name="uni-command"                 , arg=atomArg.raw}},
{63, new atomDef{name="uni-get-from-stream-reg"     , arg=atomArg.raw}},
{64, new atomDef{name="uni-save-to-stream-reg"      , arg=atomArg.raw}},
{65, new atomDef{name="uni-reset-stream-regs"       , arg=atomArg.raw}},
{66, new atomDef{name="uni-string-to-gid"           , arg=atomArg.str}},
            };
        }
    }
}
