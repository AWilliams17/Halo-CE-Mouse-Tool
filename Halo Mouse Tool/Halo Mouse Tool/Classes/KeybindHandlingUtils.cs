﻿using System.Runtime.InteropServices;

namespace Halo_Mouse_Tool
{
    class KeybindHandlingUtils
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        
        public static bool IsKeyPushedDown(System.Windows.Forms.Keys vKey)
        {
            return 0 != (GetAsyncKeyState(vKey) & 0x8000);
        }

        public static bool KeybindsEnabled { get; set; }
    }
}
