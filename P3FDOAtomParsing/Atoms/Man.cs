﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FDOAtomParsing.Atoms
{
    public class Man : Atom
    {
        public Man()
        {
            this.alt = new Dictionary<int, atomDef>(){
                {  0, new atomDef{name="man-start-object"               , arg=atomArg.objst}},
                {  1, new atomDef{name="man-start-sibling"              , arg=atomArg.objst}},
                {  2, new atomDef{name="man-end-object"                 , arg=atomArg.raw}},
                {  3, new atomDef{name="man-close"                      , arg=atomArg.gid}},
                {  4, new atomDef{name="man-close-children"             , arg=atomArg.gid}},
                {  5, new atomDef{name="man-do-magic-token-arg"         , arg=atomArg.token}},
                {  6, new atomDef{name="man-do-magic-response-id"       , arg=atomArg.dword}},
                {  7, new atomDef{name="man-set-response-id"            , arg=atomArg.dword}},
                {  8, new atomDef{name="man-set-context-response-id"    , arg=atomArg.dword}},
                {  9, new atomDef{name="man-set-context-globalid"       , arg=atomArg.gid}},
                { 10, new atomDef{name="man-set-context-relative"       , arg=atomArg.dword}},
                { 11, new atomDef{name="man-set-context-index"          , arg=atomArg.dword}},
                { 12, new atomDef{name="man-change-context-relative"    , arg=atomArg.dword}},
                { 14, new atomDef{name="man-clear-relative"             , arg=atomArg.dword}},
                { 15, new atomDef{name="man-clear-object"               , arg=atomArg.gid}},
                { 16, new atomDef{name="man-use-default-title"          , arg=atomArg.raw}},
                { 17, new atomDef{name="man-update-display"             , arg=atomArg.gid}},
                { 18, new atomDef{name="man-update-woff-end-stream"     , arg=atomArg.gid}},
                { 19, new atomDef{name="man-update-end-object"          , arg=atomArg.raw}},
                { 20, new atomDef{name="man-append-data"                , arg=atomArg.str}},
                { 21, new atomDef{name="man-replace-data"               , arg=atomArg.str}},
                { 22, new atomDef{name="man-preset-gid"                 , arg=atomArg.gid}},
                { 23, new atomDef{name="man-preset-title"               , arg=atomArg.str}},
                { 24, new atomDef{name="man-place-cursor"               , arg=atomArg.dword}},
                { 25, new atomDef{name="man-set-domain-type"            , arg=atomArg.raw}},
                { 26, new atomDef{name="man-set-domain-info"            , arg=atomArg.raw}},
                { 27, new atomDef{name="man-response-pop"               , arg=atomArg.dword}},
                { 28, new atomDef{name="man-close-update"               , arg=atomArg.gid}},
                { 29, new atomDef{name="man-end-context"                , arg=atomArg.raw}},
                { 32, new atomDef{name="man-item-get"                   , arg=atomArg.dword}},
                { 33, new atomDef{name="man-item-set"                   , arg=atomArg.raw}},
                { 34, new atomDef{name="man-start-first"                , arg=atomArg.objst}},
                { 35, new atomDef{name="man-do-edit-menu"               , arg=atomArg.dword}},
                { 36, new atomDef{name="man-logging-command"            , arg=atomArg.dword}},
                { 37, new atomDef{name="man-get-index-by-title"         , arg=atomArg.str}},
                { 40, new atomDef{name="man-start-alpha"                , arg=atomArg.objst}},
                { 41, new atomDef{name="man-start-last"                 , arg=atomArg.objst}},
                { 44, new atomDef{name="man-insert-object-after"        , arg=atomArg.dword}},
                { 45, new atomDef{name="man-cut-object"                 , arg=atomArg.raw}},
                { 46, new atomDef{name="man-copy-object"                , arg=atomArg.raw}},
                { 47, new atomDef{name="man-paste-object"               , arg=atomArg.raw}},
                { 48, new atomDef{name="man-is-rendered"                , arg=atomArg.raw}},
                { 51, new atomDef{name="man-preset-relative"            , arg=atomArg.dword}},
                { 52, new atomDef{name="man-insert-object-before"       , arg=atomArg.dword}},
                { 53, new atomDef{name="man-make-focus"                 , arg=atomArg.gid}},
                { 54, new atomDef{name="man-get-top-window"             , arg=atomArg.raw}},
                { 55, new atomDef{name="man-get-first-response-id"      , arg=atomArg.raw}},
                { 56, new atomDef{name="man-get-next-response-id"       , arg=atomArg.raw}},
                { 57, new atomDef{name="man-get-response-window"        , arg=atomArg.dword}},
                { 58, new atomDef{name="man-get-request-window"         , arg=atomArg.dword}},
                { 59, new atomDef{name="man-ignore-response"            , arg=atomArg.dword}},
                { 60, new atomDef{name="man-get-first-window"           , arg=atomArg.raw}},
                { 61, new atomDef{name="man-get-next-window"            , arg=atomArg.raw}},
                { 62, new atomDef{name="man-is-response-pending"        , arg=atomArg.dword}},
                { 63, new atomDef{name="man-is-response-ignored"        , arg=atomArg.dword}},
                { 64, new atomDef{name="man-get-attribute"              , arg=atomArg.atom}},
                { 65, new atomDef{name="man-set-item-type"              , arg=atomArg.dword}},
                { 66, new atomDef { name = "man-set-default-title", arg = atomArg.str }},
                { 67, new atomDef { name = "man-get-child-count", arg = atomArg.raw }},
                { 68, new atomDef { name = "man-check-and-set-context-rid", arg = atomArg.dword }},
                { 69, new atomDef { name = "man-clear-file-name", arg = atomArg.raw }},
                { 71, new atomDef { name = "man-is-window-iconic", arg = atomArg.gid }},
                { 72, new atomDef { name = "man-post-update-gid", arg = atomArg.gid }},
                { 73, new atomDef { name = "man-end-data", arg = atomArg.raw }},
                { 74, new atomDef { name = "man-update-fonts", arg = atomArg.raw }},
                { 75, new atomDef { name = "man-enable-one-shot-timer", arg = atomArg.raw }},
                { 76, new atomDef { name = "man-enable-continuous-timer", arg = atomArg.raw }},
                { 77, new atomDef { name = "man-kill-timer", arg = atomArg.raw }},
                { 78, new atomDef { name = "man-force-update", arg = atomArg.raw }},
                { 81, new atomDef { name = "man-set-edit-position", arg = atomArg.dword }},
                { 82, new atomDef { name = "man-set-edit-position-to-end", arg = atomArg.dword }},
                { 83, new atomDef { name = "man-preset-authoring-form", arg = atomArg.raw }},
                { 84, new atomDef { name = "man-add-date-time", arg = atomArg.dword }},
                { 85, new atomDef { name = "man-start-title", arg = atomArg.str }},
                { 86, new atomDef { name = "man-add-title-text", arg = atomArg.str }},
                { 87, new atomDef { name = "man-add-title-tab", arg = atomArg.raw }},
                { 88, new atomDef { name = "man-add-title-date-time", arg = atomArg.raw }},
                { 89, new atomDef { name = "man-end-title", arg = atomArg.str }},
                { 90, new atomDef { name = "man-preset-url", arg = atomArg.str }},
                { 91, new atomDef { name = "man-get-dropped-url", arg = atomArg.raw }},
                { 92, new atomDef { name = "man-force-old-style-dod", arg = atomArg.@bool }},
                { 93, new atomDef { name = "man-preset-tag", arg = atomArg.raw }},
                { 94, new atomDef { name = "man-build-font-list", arg = atomArg.raw }},
                { 96, new atomDef { name = "man-spell-check", arg = atomArg.raw }},
                { 97, new atomDef { name = "man-obj-stack-push", arg = atomArg.gid }},
                { 98, new atomDef { name = "man-obj-stack-pop", arg = atomArg.dword }},
                { 99, new atomDef { name = "man-display-popup-menu", arg = atomArg.dword }},
                { 100, new atomDef { name = "man-wm-close", arg = atomArg.raw }},
                { 101, new atomDef { name = "man-set-append-secure-data", arg = atomArg.str }},
                { 102, new atomDef { name = "man-sappend-secure-data", arg = atomArg.raw }},
                { 103, new atomDef { name = "man-start-ip-session", arg = atomArg.token }},
                { 104, new atomDef { name = "man-end-ip-session", arg = atomArg.raw }},
                { 105, new atomDef { name = "man-build-savemail-menu", arg = atomArg.raw }},
                { 106, new atomDef { name = "man-buid-favorites-menu", arg = atomArg.raw }},
                { 107, new atomDef { name = "man-get-display-characteristics", arg = atomArg.multi }},
                { 108, new atomDef { name = "man-build-signatures-menu", arg = atomArg.raw }},
                { 109, new atomDef { name = "man-sort-items", arg = atomArg.dword }},
                { 110, new atomDef { name = "man-treectrl-action-command", arg = atomArg.dword }},
                { 111, new atomDef { name = "man-set-context-first-selection", arg = atomArg.gid }},
                { 112, new atomDef { name = "man-set-context-next-selection", arg = atomArg.gid }},
                { 113, new atomDef { name = "man-accessibility-setting", arg = atomArg.raw }},
            };
        }
    }
}
