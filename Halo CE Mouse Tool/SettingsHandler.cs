using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Halo_CE_Mouse_Tool
{
    /*
        -SettingsHandler.cs-
        This class contains the settings for the application.
        I didn't declare as static since I wanted to try to keep it centralized or something.
    */
    [DataContract]
    public class SettingsHandler
    { //I'll just keep the getters/setters so in the future I can perform validation of some sort
        [DataMember] public float SensX { get; private set; } = 1;
        [DataMember] public float SensY { get; private set; } = 1;
        [DataMember] public int PatchAcceleration { get; private set; } = 1;
        [DataMember] public int CheckForUpdatesOnStart { get; private set; } = 1;
        [DataMember] public int HotkeyEnabled { get; private set; } = 1; //TODO: I use Hotkey and Keybind interchangebly throughout the code. Why not just use Hotkey?
        [DataMember] public string Hotkey { get; set; } = "F1";
        [DataMember] public int SoundsEnabled { get; private set; }
        [DataMember] public int HideKeybindSuccessMsg { get; private set; } = 0;
        [DataMember] public int UpdateTimeout { get; private set; } = 3000;
        [DataMember] public int IncrementSens { get; private set; } = 1;
        [DataMember] public float IncrementAmount { get; private set; } = 0.5F;

        public void setSensX(float value)
        {
            if (value > 0)
            {
                SensX = value;
            }
            else
            {
                SensX = 1;
            }
        }

        public void setSensY(float value)
        {
            if (value > 0)
            {
                SensY = value;
            }
            else
            {
                SensY = 1;
            }
        }

        public void setPatchAcceleration(int value)
        {
            if (value == 0 || value == 1)
            {
                PatchAcceleration = value;
            }
            else
            {
                PatchAcceleration = 1;
            }
        }

        public void setCheckForUpdates(int value)
        {
            if (value == 0 || value == 1)
            {
                CheckForUpdatesOnStart = value;
            }
            else
            {
                CheckForUpdatesOnStart = 1;
            }
        }

        public void setHotKeyEnabled(int value)
        {
            if (value == 0 || value == 1)
            {
                HotkeyEnabled= value;
            }
            else
            {
                HotkeyEnabled = 1;
            }
        }

        public void setSoundsEnabled(int value)
        {
            if (value == 0 || value == 1)
            {
                SoundsEnabled = value;
            }
            else
            {
                SoundsEnabled = 1;
            }
        }

        public void setHideKeybindSuccessMsg(int value)
        {
            if (value == 0 || value == 1)
            {
                HideKeybindSuccessMsg = value;
            }
            else
            {
                HideKeybindSuccessMsg = 0;
            }
        }

        public void setUpdateTimeout(int value)
        {
            if (value == 0 || value == 1)
            {
                UpdateTimeout = value;
            }
            else
            {
                UpdateTimeout = 3000;
            }
        }

        public void setIncrementSens(int value)
        {
            if (value == 0 || value == 1)
            {
                IncrementSens = value;
            }
            else
            {
                IncrementSens = 1;
            }
        }

        public void setIncrementAmount(float value)
        {
            if (value < 0 || value > 5)
            {
                IncrementAmount = 0.5F;
            }
            else
            {
                IncrementAmount = value;
            }
        }
    }
}
