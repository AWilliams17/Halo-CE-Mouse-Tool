using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    -SettingsHandler Class-
    This class should call inihandler and set the settings in the application
*/
namespace Halo_CE_Mouse_Tool {
    class SettingsHandler {
        private bool IniExists() {
            return false;
        }

        public bool CheckForUpdatesOnStart() {
            return false;
        }

        public bool HotkeyEnabled() {
            return false;
        }

        public bool PatchAcceleration() {
            return true;
        }

        public float SensX() {
            return 0;
        }

        public float SensY() {
            return 0;
        }

        public void WriteSettingsToIni() {

        }

        public void LoadSettingsFromIni() {
            if (IniExists()) {
                //Load and set
            }
        }

    }
}
