using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JNSoundboard
{
    public class Keyboard
    {
        const int INPUT_MOUSE = 0;
        const int INPUT_KEYBOARD = 1;
        const int INPUT_HARDWARE = 2;
        const uint KEYEVENTF_KEYDOWN = 0x0000;
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        const uint KEYEVENTF_KEYUP = 0x0002;
        const uint KEYEVENTF_UNICODE = 0x0004;
        const uint KEYEVENTF_SCANCODE = 0x0008;

        struct INPUT
        {
            public int type;
            public InputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern short GetKeyState(ushort virtualKeyCode);

        internal static bool IsKeyDown(Keys keyCode)
        {
            short keyState = GetKeyState((ushort)keyCode);
            return keyState < 0;
        }
        
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);

        const uint MAPVK_VK_TO_VSC = 0x00;

        public static bool sendKey(Keys key, bool keyDown)
        {
            INPUT[] inputs =
            {
                new INPUT
                {
                    type = INPUT_KEYBOARD,
                    u = new InputUnion
                    {
                        ki = new KEYBDINPUT()
                        {
                            wVk = 0,
                            wScan = (ushort)MapVirtualKey((uint)key, MAPVK_VK_TO_VSC),
                            dwFlags = ((keyDown ? KEYEVENTF_KEYDOWN : KEYEVENTF_KEYUP) | KEYEVENTF_SCANCODE),
                            dwExtraInfo = GetMessageExtraInfo(),
                            time = (keyDown ? unchecked ((uint)-1) : 0)
                        }
                    }
                }
            };

            return SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT))) > 0;
        }

        public static Tuple<int, string> getKeys(int lastAmountPressed, string currentKeys)
        {
            int amountPressed = 0;
            string newKeys = (currentKeys == "") ? "" : currentKeys;

            if (!IsKeyDown(Keys.Escape))
            {
                var pressedKeys = new List<Keys>();

                foreach (Keys key in Enum.GetValues(typeof(Keys)))
                {
                    if (IsKeyDown(key))
                    {
                        amountPressed++;
                        pressedKeys.Add(key);
                    }
                }

                if (amountPressed > lastAmountPressed)
                {
                    newKeys = Helper.keysArrayToString(pressedKeys.ToArray());
                }

                lastAmountPressed = amountPressed;
            }
            else
            {
                newKeys = "";
            }

            return Tuple.Create(lastAmountPressed, newKeys);
        }
        public enum Keys
        {
            Modifiers = -65536,
            None = 0,
            LButton = 1,
            RButton = 2,
            Cancel = 3,
            MButton = 4,
            XButton1 = 5,
            XButton2 = 6,
            VK_07 = 7, //MenuMaskKey, cannot be bound
            Back = 8,
            Tab = 9,
            LineFeed = 10,
            VK_0B = 11, //Reserved
            Clear = 12,
            Return = 13,
            Enter = 13,
            VK_0E = 14, //Undefined
            VK_0F = 15, //Undefined
            ShiftKey = 16,
            ControlKey = 17,
            Menu = 18,
            Pause = 19,
            Capital = 20,
            CapsLock = 20,
            KanaMode = 21,
            HanguelMode = 21,
            HangulMode = 21,
            VK_16 = 22, //Undefined
            JunjaMode = 23,
            FinalMode = 24,
            HanjaMode = 25,
            KanjiMode = 25,
            VK_1A = 26, //Undefined
            Escape = 27,
            IMEConvert = 28,
            IMENonconvert = 29,
            IMEAccept = 30,
            IMEAceept = 30,
            IMEModeChange = 31,
            Space = 32,
            Prior = 33,
            PageUp = 33,
            Next = 34,
            PageDown = 34,
            End = 35,
            Home = 36,
            Left = 37,
            Up = 38,
            Right = 39,
            Down = 40,
            Select = 41,
            Print = 42,
            Execute = 43,
            Snapshot = 44,
            PrintScreen = 44,
            Insert = 45,
            Delete = 46,
            Help = 47,
            D0 = 48,
            D1 = 49,
            D2 = 50,
            D3 = 51,
            D4 = 52,
            D5 = 53,
            D6 = 54,
            D7 = 55,
            D8 = 56,
            D9 = 57,
            VK_3A = 58, //Undefined
            VK_3B = 59, //Undefined
            VK_3C = 60, //Undefined
            VK_3D = 61, //Undefined
            VK_3E = 62, //Undefined
            VK_3F = 63, //Undefined
            VK_40 = 64, //Undefined
            A = 65,
            B = 66,
            C = 67,
            D = 68,
            E = 69,
            F = 70,
            G = 71,
            H = 72,
            I = 73,
            J = 74,
            K = 75,
            L = 76,
            M = 77,
            N = 78,
            O = 79,
            P = 80,
            Q = 81,
            R = 82,
            S = 83,
            T = 84,
            U = 85,
            V = 86,
            W = 87,
            X = 88,
            Y = 89,
            Z = 90,
            LWin = 91,
            RWin = 92,
            Apps = 93,
            VK_5E = 94, //Reserved
            Sleep = 95,
            NumPad0 = 96,
            NumPad1 = 97,
            NumPad2 = 98,
            NumPad3 = 99,
            NumPad4 = 100,
            NumPad5 = 101,
            NumPad6 = 102,
            NumPad7 = 103,
            NumPad8 = 104,
            NumPad9 = 105,
            Multiply = 106,
            Add = 107,
            Separator = 108,
            Subtract = 109,
            Decimal = 110,
            Divide = 111,
            F1 = 112,
            F2 = 113,
            F3 = 114,
            F4 = 115,
            F5 = 116,
            F6 = 117,
            F7 = 118,
            F8 = 119,
            F9 = 120,
            F10 = 121,
            F11 = 122,
            F12 = 123,
            F13 = 124,
            F14 = 125,
            F15 = 126,
            F16 = 127,
            F17 = 128,
            F18 = 129,
            F19 = 130,
            F20 = 131,
            F21 = 132,
            F22 = 133,
            F23 = 134,
            F24 = 135,
            VK_88 = 136, //Unassigned
            VK_89 = 137, //Unassigned
            VK_8A = 138, //Unassigned
            VK_8B = 139, //Unassigned
            VK_8C = 140, //Unassigned
            VK_8D = 141, //Unassigned
            VK_8E = 142, //Unassigned
            VK_8F = 143, //NumLock
            NumLock = 144,
            Scroll = 145,
            VK_92 = 146, //OEM Specific
            VK_93 = 147, //OEM Specific
            VK_94 = 148, //OEM Specific
            VK_95 = 149, //OEM Specific
            VK_96 = 150, //OEM Specific
            VK_97 = 151, //Unassigned
            VK_98 = 152, //Unassigned
            VK_99 = 153, //Unassigned
            VK_9A = 154, //Unassigned
            VK_9B = 155, //Menu
            VK_9C = 156, //Unassigned
            VK_9D = 157, //Unassigned
            VK_9E = 158, //Unassigned
            VK_9F = 159, //Unassigned
            LShiftKey = 160,
            RShiftKey = 161,
            LControlKey = 162,
            RControlKey = 163,
            LMenu = 164,
            RMenu = 165,
            BrowserBack = 166,
            BrowserForward = 167,
            BrowserRefresh = 168,
            BrowserStop = 169,
            BrowserSearch = 170,
            BrowserFavorites = 171,
            BrowserHome = 172,
            VolumeMute = 173,
            VolumeDown = 174,
            VolumeUp = 175,
            MediaNextTrack = 176,
            MediaPreviousTrack = 177,
            MediaStop = 178,
            MediaPlayPause = 179,
            LaunchMail = 180,
            SelectMedia = 181,
            LaunchApplication1 = 182,
            LaunchApplication2 = 183,
            VK_B8 = 184, //Reserved
            VK_B9 = 185, //Reserved
            OemSemicolon = 186,
            Oem1 = 186,
            Oemplus = 187,
            Oemcomma = 188,
            OemMinus = 189,
            OemPeriod = 190,
            OemQuestion = 191,
            Oem2 = 191,
            Oemtilde = 192,
            Oem3 = 192,
            VK_C1 = 193, //Cut
            VK_C2 = 194, //Copy
            VK_C3 = 195, //Paste
            VK_C4 = 196, //Select All
            VK_C5 = 197, //Find
            VK_C6 = 198, //New
            VK_C7 = 199, //Print
            VK_C8 = 200, //Save
            VK_C9 = 201, //Reserved
            VK_CA = 202, //Reserved
            VK_CB = 203, //Reserved
            VK_CC = 204, //Reserved
            VK_CD = 205, //Reserved
            VK_CE = 206, //Reserved
            VK_CF = 207, //Reserved
            VK_D0 = 208, //Close Window
            VK_D1 = 209, //Lock PC
            VK_D2 = 210, //Open Explorer
            VK_D3 = 211, //Run
            VK_D4 = 212, //Show Desktop
            VK_D5 = 213, //LButton
            VK_D6 = 214, //RButton
            VK_D7 = 215, //MButton
            VK_D8 = 216, //Scroll Up
            VK_D9 = 217, //Scroll Down
            VK_DA = 218, //Unassigned
            OemOpenBrackets = 219,
            Oem4 = 219,
            OemPipe = 220,
            Oem5 = 220,
            OemCloseBrackets = 221,
            Oem6 = 221,
            OemQuotes = 222,
            Oem7 = 222,
            Oem8 = 223,
            VK_E0 = 224, //Reserved
            VK_E1 = 225, //OEM Specific
            OemBackslash = 226,
            Oem102 = 226,
            VK_E3 = 227, //OEM Specific
            VK_E4 = 228, //00
            ProcessKey = 229,
            VK_E6 = 230, //OEM Specific
            Packet = 231,
            VK_E8 = 232, //Unassigned
            VK_E9 = 233, //OEM Specific
            VK_EA = 234, //OEM Specific
            VK_EB = 235, //OEM Specific
            VK_EC = 236, //OEM Specific
            VK_ED = 237, //OEM Specific
            VK_EE = 238, //OEM Specific
            VK_EF = 239, //OEM Specific
            VK_F0 = 240, //OEM Specific
            VK_F1 = 241, //OEM Specific
            VK_F2 = 242, //OEM Specific
            VK_F3 = 243, //OEM Specific
            VK_F4 = 244, //OEM Specific
            VK_F5 = 245, //OEM Specific
            Attn = 246,
            Crsel = 247,
            Exsel = 248,
            EraseEof = 249,
            Play = 250,
            Zoom = 251,
            NoName = 252,
            Pa1 = 253,
            OemClear = 254,
            KeyCode = 65535,
            Shift = 65536,
            Control = 131072,
            Alt = 262144
        }
    }
}
