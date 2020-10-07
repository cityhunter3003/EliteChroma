﻿using System;
using System.Collections.Generic;
using Colore.Effects.Keyboard;
using EliteChroma.Elite.Internal;
using EliteFiles.Bindings.Devices;

namespace EliteChroma.Core.Internal
{
    // References:
    // - <EliteRoot>\Products\elite-dangerous-64\ControlSchemes\Help.txt
    // - <EliteRoot>\Products\elite-dangerous-64\EliteDangerous64.exe (binary scraping)
    // - https://developer.razer.com/works-with-chroma/razer-chroma-led-profiles/
    internal static class KeyMappings
    {
        private static readonly Dictionary<string, Key> _keys = new Dictionary<string, Key>(StringComparer.Ordinal)
        {
            { Keyboard.Escape, Key.Escape },
            { GetKeyName('1'), Key.D1 },
            { GetKeyName('2'), Key.D2 },
            { GetKeyName('3'), Key.D3 },
            { GetKeyName('4'), Key.D4 },
            { GetKeyName('5'), Key.D5 },
            { GetKeyName('6'), Key.D6 },
            { GetKeyName('7'), Key.D7 },
            { GetKeyName('8'), Key.D8 },
            { GetKeyName('9'), Key.D9 },
            { GetKeyName('0'), Key.D0 },
            { Keyboard.Minus, Key.OemMinus },
            { Keyboard.EqualsKey, Key.OemEquals },
            { Keyboard.Backspace, Key.Backspace },
            { Keyboard.Tab, Key.Tab },
            { GetKeyName('Q'), Key.Q },
            { GetKeyName('W'), Key.W },
            { GetKeyName('E'), Key.E },
            { GetKeyName('R'), Key.R },
            { GetKeyName('T'), Key.T },
            { GetKeyName('Y'), Key.Y },
            { GetKeyName('U'), Key.U },
            { GetKeyName('I'), Key.I },
            { GetKeyName('O'), Key.O },
            { GetKeyName('P'), Key.P },
            { Keyboard.LeftBracket, Key.OemLeftBracket },
            { Keyboard.RightBracket, Key.OemRightBracket },
            { Keyboard.Enter, Key.Enter },
            { Keyboard.LeftControl, Key.LeftControl },
            { GetKeyName('A'), Key.A },
            { GetKeyName('S'), Key.S },
            { GetKeyName('D'), Key.D },
            { GetKeyName('F'), Key.F },
            { GetKeyName('G'), Key.G },
            { GetKeyName('H'), Key.H },
            { GetKeyName('J'), Key.J },
            { GetKeyName('K'), Key.K },
            { GetKeyName('L'), Key.L },
            { Keyboard.SemiColon, Key.OemSemicolon },
            { Keyboard.Apostrophe, Key.OemApostrophe },
            { Keyboard.Grave, Key.OemTilde },
            { Keyboard.LeftShift, Key.LeftShift },
            { Keyboard.BackSlash, Key.EurBackslash },
            { GetKeyName('Z'), Key.Z },
            { GetKeyName('X'), Key.X },
            { GetKeyName('C'), Key.C },
            { GetKeyName('V'), Key.V },
            { GetKeyName('B'), Key.B },
            { GetKeyName('N'), Key.N },
            { GetKeyName('M'), Key.M },
            { Keyboard.Comma, Key.OemComma },
            { Keyboard.Period, Key.OemPeriod },
            { Keyboard.Slash, Key.OemSlash },
            { Keyboard.RightShift, Key.RightShift },
            { Keyboard.NumpadMultiply, Key.NumMultiply },
            { Keyboard.LeftAlt, Key.LeftAlt },
            { Keyboard.Space, Key.Space },
            { Keyboard.CapsLock, Key.CapsLock },
            { Keyboard.F1, Key.F1 },
            { Keyboard.F2, Key.F2 },
            { Keyboard.F3, Key.F3 },
            { Keyboard.F4, Key.F4 },
            { Keyboard.F5, Key.F5 },
            { Keyboard.F6, Key.F6 },
            { Keyboard.F7, Key.F7 },
            { Keyboard.F8, Key.F8 },
            { Keyboard.F9, Key.F9 },
            { Keyboard.F10, Key.F10 },
            { Keyboard.NumLock, Key.NumLock },
            { Keyboard.ScrollLock, Key.Scroll },
            { Keyboard.Numpad7, Key.Num7 },
            { Keyboard.Numpad8, Key.Num8 },
            { Keyboard.Numpad9, Key.Num9 },
            { Keyboard.NumpadSubtract, Key.NumSubtract },
            { Keyboard.Numpad4, Key.Num4 },
            { Keyboard.Numpad5, Key.Num5 },
            { Keyboard.Numpad6, Key.Num6 },
            { Keyboard.NumpadAdd, Key.NumAdd },
            { Keyboard.Numpad1, Key.Num1 },
            { Keyboard.Numpad2, Key.Num2 },
            { Keyboard.Numpad3, Key.Num3 },
            { Keyboard.Numpad0, Key.Num0 },
            { Keyboard.NumpadDecimal, Key.NumDecimal },
            { Keyboard.F11, Key.F11 },
            { Keyboard.F12, Key.F12 },
            { Keyboard.F13, 0 },
            { Keyboard.F14, 0 },
            { Keyboard.F15, 0 },
            { Keyboard.Kana, 0 },
            { Keyboard.AbntC1, 0 },
            { Keyboard.Convert, Key.Jpn3 },
            { Keyboard.NoConvert, Key.Jpn4 },
            { Keyboard.Yen, Key.JpnYen },
            { Keyboard.AbntC2, 0 },
            { Keyboard.NumpadEquals, 0 },
            { Keyboard.PrevTrack, 0 },
            { Keyboard.AT, 0 },
            { Keyboard.Colon, 0 },
            { Keyboard.Underline, 0 },
            { Keyboard.Kanji, 0 },
            { Keyboard.Stop, 0 },
            { Keyboard.AX, 0 },
            { Keyboard.Unlabeled, 0 },
            { Keyboard.NextTrack, 0 },
            { Keyboard.NumpadEnter, Key.NumEnter },
            { Keyboard.RightControl, Key.RightControl },
            { Keyboard.Mute, 0 },
            { Keyboard.Calculator, 0 },
            { Keyboard.PlayPause, 0 },
            { Keyboard.MediaStop, 0 },
            { Keyboard.VolumeDown, 0 },
            { Keyboard.VolumeUp, 0 },
            { Keyboard.WebHome, 0 },
            { Keyboard.NumpadComma, 0 },
            { Keyboard.NumpadDivide, Key.NumDivide },
            { Keyboard.SysRQ, Key.PrintScreen },
            { Keyboard.RightAlt, Key.RightAlt },
            { Keyboard.Pause, Key.Pause },
            { Keyboard.Home, Key.Home },
            { Keyboard.UpArrow, Key.Up },
            { Keyboard.PageUp, Key.PageUp },
            { Keyboard.LeftArrow, Key.Left },
            { Keyboard.RightArrow, Key.Right },
            { Keyboard.End, Key.End },
            { Keyboard.DownArrow, Key.Down },
            { Keyboard.PageDown, Key.PageDown },
            { Keyboard.Insert, Key.Insert },
            { Keyboard.Delete, Key.Delete },
            { Keyboard.LeftWin, Key.LeftWindows },
            { Keyboard.RightWin, 0 },
            { Keyboard.Apps, Key.RightMenu },
            { Keyboard.Power, 0 },
            { Keyboard.Sleep, 0 },
            { Keyboard.Wake, 0 },
            { Keyboard.WebSearch, 0 },
            { Keyboard.WebFavourites, 0 },
            { Keyboard.WebRefresh, 0 },
            { Keyboard.WebStop, 0 },
            { Keyboard.WebForward, 0 },
            { Keyboard.WebBack, 0 },
            { Keyboard.MyComputer, 0 },
            { Keyboard.Mail, 0 },
            { Keyboard.MediaSelect, 0 },
            { Keyboard.GreenModifier, 0 },
            { Keyboard.OrangeModifier, 0 },
            { Keyboard.F16, 0 },
            { Keyboard.F17, 0 },
            { Keyboard.F18, 0 },
            { Keyboard.F19, 0 },
            { Keyboard.F20, 0 },
            { Keyboard.Section, 0 },
            { Keyboard.Menu, 0 },
            { Keyboard.Help, 0 },
            { Keyboard.Function, Key.Function },
            { Keyboard.Clear, 0 },
            { Keyboard.LeftCommand, 0 },
            { Keyboard.RightCommand, 0 },
            { Keyboard.Plus, 0 },
            { Keyboard.Hash, Key.EurPound },
            { Keyboard.LessThan, Key.EurBackslash },
            { Keyboard.GreaterThan, 0 },
            { Keyboard.Acute, 0 },
            { Keyboard.Circumflex, 0 },
            { Keyboard.Tilde, 0 },
            { Keyboard.Ring, 0 },
            { Keyboard.Umlaut, 0 },
            { Keyboard.Half, 0 },
            { Keyboard.Dollar, 0 },
            { Keyboard.SuperscriptTwo, 0 },
            { Keyboard.Ampersand, 0 },
            { Keyboard.DoubleQuote, 0 },
            { Keyboard.LeftParenthesis, 0 },
            { Keyboard.RightParenthesis, 0 },
            { Keyboard.Asterisk, 0 },
            { Keyboard.ExclamationPoint, 0 },
            { Keyboard.Macron, 0 },
            { Keyboard.Overline, 0 },
            { Keyboard.Breve, 0 },
            { Keyboard.Overdot, 0 },
            { Keyboard.HookAbove, 0 },
            { Keyboard.RingAbove, 0 },
            { Keyboard.DoubleAcute, 0 },
            { Keyboard.Caron, 0 },
            { Keyboard.VerticalLineAbove, 0 },
            { Keyboard.DoubleVerticalLineAbove, 0 },
            { Keyboard.DoubleGrave, 0 },
            { Keyboard.Candrabindu, 0 },
            { Keyboard.InvertedBreve, 0 },
            { Keyboard.TurnedCommaAbove, 0 },
            { Keyboard.CommaAbove, 0 },
            { Keyboard.ReversedCommaAbove, 0 },
            { Keyboard.CommaAboveRight, 0 },
            { Keyboard.GraveBelow, 0 },
            { Keyboard.AcuteBelow, 0 },
            { Keyboard.LeftTackBelow, 0 },
            { Keyboard.RightTackBelow, 0 },
            { Keyboard.LeftAngleAbove, 0 },
            { Keyboard.Horn, 0 },
            { Keyboard.LeftHalfRingBelow, 0 },
            { Keyboard.UpTackBelow, 0 },
            { Keyboard.DownTackBelow, 0 },
            { Keyboard.PlusSignBelow, 0 },
            { Keyboard.Cedilla, 0 },
        };

        private static readonly Dictionary<uint, Key> _scanCodes = new Dictionary<uint, Key>()
        {
            { 0x7D, Key.JpnYen },
            { 0x29, Key.OemTilde },
            { 0x0C, Key.OemMinus },
            { 0x0D, Key.OemEquals },
            { 0x1A, Key.OemLeftBracket },
            { 0x1B, Key.OemRightBracket },
            { 0x2B, Key.OemBackslash },
            { 0x27, Key.OemSemicolon },
            { 0x28, Key.OemApostrophe },
            { 0x56, Key.EurBackslash },
            { 0x33, Key.OemComma },
            { 0x34, Key.OemPeriod },
            { 0x35, Key.OemSlash },
            { 0x73, Key.JpnSlash },
            { 0xE01C, Key.NumEnter },
            { 0x7B, Key.Jpn3 },
            { 0x79, Key.Jpn4 },
            { 0x70, Key.Jpn5 },
        };

        public static bool TryGetKey(string keyName, string keyboardLayout, out Key key, INativeMethods nativeMethods)
        {
            if (_keys.TryGetValue(keyName, out key))
            {
                return true;
            }

            _ = Elite.Internal.KeyMappings.TryGetKey(keyName, keyboardLayout, out var vk, nativeMethods);

            IntPtr hkl = KeyboardLayoutMap.GetKeyboardLayout(keyboardLayout, nativeMethods);

            var scanCode = nativeMethods.MapVirtualKeyEx((uint)vk, NativeMethods.MAPVK.VK_TO_VSC_EX, hkl);

            return _scanCodes.TryGetValue(scanCode, out key);
        }

        private static string GetKeyName(char c)
        {
            _ = Keyboard.TryGetKeyName(c, out var keyName);
            return keyName;
        }
    }
}
