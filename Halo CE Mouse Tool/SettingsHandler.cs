using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Halo_CE_Mouse_Tool {
    /*
        -SettingsHandler.cs-
        This class contains the settings for the application.
        I didn't declare as static since I wanted to try to keep it centralized or something.
    */
    public class SettingsHandler {
        private float _SensX { get; set; } = 1;
        private float _SensY { get; set; } = 1;
        private int _PatchAcceleration { get; set; } = 1;
        private int _CheckForUpdatesOnStart { get; set; } = 1;
        private int _HotkeyEnabled { get; set; } = 1; //TODO: I use Hotkey and Keybind interchangebly throughout the code. Why not just use Hotkey?
        private string _Hotkey { get; set; } = "F1";
        private int _SoundEnabled { get; set; } = 1;
        
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
        public int SoundsEnabled {
            get { return _SoundEnabled; }
            set { _SoundEnabled = value; }
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
