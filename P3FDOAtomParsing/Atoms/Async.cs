using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing.Atoms
{
    public class Async : Atom
    {
        public Async()
        {
            this.alt = new Dictionary<int, atomDef> (){
                { 0, new atomDef{name="async-exit"                     , arg=atomArg.raw}},
                { 1, new atomDef{name="async-password"                 , arg=atomArg.raw}},
                { 2, new atomDef{name="async-guest-password"           , arg=atomArg.raw}},
                { 3, new atomDef{name="async-exit-damnit"              , arg=atomArg.raw}},
                { 4, new atomDef{name="async-online"                   , arg=atomArg.raw}},
                { 5, new atomDef{name="async-offline"                  , arg=atomArg.raw}},
                { 6, new atomDef{name="async-error-box"                , arg=atomArg.str}},
                { 7, new atomDef{name="async-alert"                    , arg=atomArg.alert}},
                { 8, new atomDef{name="async-display-netnews"          , arg=atomArg.raw}},
                { 9, new atomDef{name="async-go-netnews"               , arg=atomArg.raw}},
                {10, new atomDef{name="async-moreinfo-netnews"         , arg=atomArg.raw}},
                {11, new atomDef{name="async-playsound"                , arg=atomArg.str}},
                {12, new atomDef{name="async-exit-aux"                 , arg=atomArg.raw}},
                {13, new atomDef{name="async-exec-help"                , arg=atomArg.raw}},
                {14, new atomDef{name="async-exec-context-help"        , arg=atomArg.raw}},
                {15, new atomDef{name="async-play-sound-dammit"        , arg=atomArg.str}},
                {16, new atomDef{name="async-exec-help-file"           , arg=atomArg.str}},
                {17, new atomDef{name="async-force-off"                , arg=atomArg.str}},
                {18, new atomDef{name="async-send-clientstatus"        , arg=atomArg.raw}},
                {19, new atomDef{name="async-get-stat-count"           , arg=atomArg.raw}},
                {20, new atomDef{name="async-extract-stats"            , arg=atomArg.raw}},
                {21, new atomDef{name="async-stat-collection-state"    , arg=atomArg.raw}},
                {22, new atomDef{name="async-clear-stats"              , arg=atomArg.raw}},
                {23, new atomDef{name="async-stat-record"              , arg=atomArg.raw}},
                {24, new atomDef{name="async-get-alert-result"         , arg=atomArg.raw}},
                {25, new atomDef{name="async-exec-app"                 , arg=atomArg.str}},
                {26, new atomDef{name="async-screen-name-changed"      , arg=atomArg.raw}},
                {27, new atomDef{name="async-is-known-subaccount"      , arg=atomArg.raw}},
                {28, new atomDef{name="async-dump-diag"                , arg=atomArg.str}},
                {29, new atomDef{name="async-get-screen-name"          , arg=atomArg.raw}},
                {30, new atomDef{name="async-sign-on"                  , arg=atomArg.raw}},
                {31, new atomDef{name="async-alert-start"              , arg=atomArg.str}},
                {32, new atomDef{name="async-alert-add-text"           , arg=atomArg.str}},
                {33, new atomDef{name="async-alert-add-date-time"      , arg=atomArg.dword}},
                {34, new atomDef{name="async-alert-end"                , arg=atomArg.str}},
                {35, new atomDef{name="async-invoke-timezone-pref"     , arg=atomArg.raw}},
                {36, new atomDef{name="async-invoke-language-pref"     , arg=atomArg.raw}},
                {37, new atomDef{name="async-set-screen-name"          , arg=atomArg.str}},
                {38, new atomDef{name="async-auto-launch"              , arg=atomArg.raw}},
                {39, new atomDef{name="async-launcher-name"            , arg=atomArg.raw}},
                {40, new atomDef{name="async-is-client-32bit"          , arg=atomArg.raw}},
                {41, new atomDef{name="async-display-errors"           , arg=atomArg.raw}},
                {42, new atomDef{name="async-is-guest"                 , arg=atomArg.raw}},
                {43, new atomDef{name="async-relogon-init"             , arg=atomArg.raw}},
                {44, new atomDef{name="async-relogon"                  , arg=atomArg.raw}},
                {45, new atomDef{name="async-storename"                , arg=atomArg.str}},
                {46, new atomDef{name="async-storepassword"            , arg=atomArg.str}},
                {47, new atomDef{name="async-signoff"                  , arg=atomArg.raw}},
                {48, new atomDef{name="async-is-current-screenname"    , arg=atomArg.str}},
                {49, new atomDef{name="async-logout"                   , arg=atomArg.raw}},
                {50, new atomDef{name="async-check-and-invoke-driveway", arg=atomArg.raw}},
                {51, new atomDef{name="async-record-error"             , arg=atomArg.str}},
                {52, new atomDef{name="async-system-usage"             , arg=atomArg.str}},
                {53, new atomDef{name="async-replace-pref"             , arg=atomArg.str}},
                {54, new atomDef{name="async-bool-diag-on"             , arg=atomArg.@bool}},
                {55, new atomDef{name="async-allow-switch-screen-names", arg=atomArg.raw}},
                {56, new atomDef{name="async-install-sound"            , arg=atomArg.dword}},
                {57, new atomDef{name="async-voice-recognition"        , arg=atomArg.dword}},
                {58, new atomDef{name="async-get-os"                   , arg=atomArg.dword}}};
        }
    }
}
