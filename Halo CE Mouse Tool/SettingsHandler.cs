using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

/*
    -SettingsHandler Class-
    This class handles all settings related stuff. It's also terrible.
*/
namespace Halo_CE_Mouse_Tool {
    public class SettingsHandler {
        private float _SensX { get; set; } = 1;
        private float _SensY { get; set; } = 1;
        private int _PatchAcceleration { get; set; } = 1;
        private int _CheckForUpdatesOnStart { get; set; } = 1;
        private int _HotkeyEnabled { get; set; } = 1;
        private string _Hotkey { get; set; } = "F1";
        


        public float SensX {
            get { return _SensX; }
            set { _SensX = value; }
        }

        public float SensY {
            get { return _SensY; }
            set { _SensY = value; }
        }

        public int PatchAcceleration {
            get { return _PatchAcceleration; }
            set { _PatchAcceleration = value; }
        }

        public int CheckForUpdatesOnStart {
            get { return _CheckForUpdatesOnStart; }
            set { _CheckForUpdatesOnStart = value; }
        }

        public int HotkeyEnabled {
            get { return _HotkeyEnabled; }
            set { _HotkeyEnabled = value; }
        }
        public string Hotkey {
            get { return _Hotkey; }
            set { _Hotkey = value; }
        }
    }
}
