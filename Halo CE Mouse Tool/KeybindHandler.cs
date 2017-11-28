using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    -Keybind Class-
    This class should register keybinds (pair a key with a function/method to be called?),
    Get a list of currently registered/paired keys,
    And handle keypresses.

*/
namespace Halo_CE_Mouse_Tool {
    class KeybindHandler {
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
