using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

/*
    -Keybind Class-
    This class should register keybinds (pair a key with a function/method to be called?),
    Get a list of currently registered/paired keys,
    And handle keypresses.

*/
namespace Halo_CE_Mouse_Tool {
    public class KeybindHandler {

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);


        public static bool IsKeyPushedDown(System.Windows.Forms.Keys vKey) {
            return 0 != (GetAsyncKeyState(vKey) & 0x8000);
        }

        private bool KeybindsEnabled;

        public bool GetKeybindStatus() {
            return KeybindsEnabled;
        }

        public void SuspendKeybinds() {
            KeybindsEnabled = false;
        }

        public void EnableKeybinds() {
            KeybindsEnabled = true;
        }
    }
}
