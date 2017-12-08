using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Halo_CE_Mouse_Tool
{
    /*
        -SettingsHandler.cs-
        This class contains the settings for the application.
        I didn't declare as static since I wanted to try to keep it centralized or something.
    */
    public class SettingsHandler
    { //I'll just keep the getters/setters so in the future I can perform validation of some sort
        public float SensX { get; set; } = 1;
        public float SensY { get; set; } = 1;
        public int PatchAcceleration { get; set; } = 1;
        public int CheckForUpdatesOnStart { get; set; } = 1;
        public int HotkeyEnabled { get; set; } = 1; //TODO: I use Hotkey and Keybind interchangebly throughout the code. Why not just use Hotkey?
        public string Hotkey { get; set; } = "F1";
        public int SoundsEnabled { get; set; } = 1;
    }
}
