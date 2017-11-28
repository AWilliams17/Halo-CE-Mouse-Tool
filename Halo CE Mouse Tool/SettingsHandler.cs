using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*
    -SettingsHandler Class-
    This class should call inihandler and set the settings in the application
*/
namespace Halo_CE_Mouse_Tool {
    class SettingsHandler {
        private float SensX;
        private float SensY;

        public bool IniExists() {
            string pathtoexec = Application.StartupPath;
            if (File.Exists(pathtoexec + "/CEMT.ini")){
                return true;
            } else {
                return false;
            }
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

        public float GetSensX() {
            return SensX;
        }

        public float GetSensY() {
            return SensY;
        }

        public void SetSensX(float val) {
            SensX = val;
        }

        public void SetSensY(float val) {
            SensY = val;
        }

        public void WriteSettingsToIni() {

        }

        public void LoadSettingsFromIni() {
            if (IniExists()) {
                //Load and set values
            }
        }



    }
}
