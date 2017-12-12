namespace Halo_CE_Mouse_Tool
{
    /*
        -SettingsHandler.cs-
        This class contains the settings for the application.
        I didn't declare as static since I wanted to try to keep it centralized or something.
    */
    public class SettingsHandler
    { //I'll just keep the getters/setters so in the future I can perform validation of some sort
        public float SensX { get; private set; } = 1;
        public float SensY { get; private set; } = 1;
        public int PatchAcceleration { get; private set; } = 1;
        public int CheckForUpdatesOnStart { get; private set; } = 1;
        public int HotkeyEnabled { get; private set; } = 1; //TODO: I use Hotkey and Keybind interchangebly throughout the code. Why not just use Hotkey?
        public string Hotkey { get; set; } = "F1";
        public int SoundsEnabled { get; private set; } = 1;
        public int HideKeybindSuccessMsg { get; private set; } = 0;
        public int UpdateTimeout { get; private set; } = 3000;
        public int IncrementSens { get; private set; } = 1;
        public float IncrementAmount { get; private set; } = 0.5F;

        public void setSensX(float value)
        {
            if (value <= 0)
            {
                SensX = 0.1F;
            }
            else
            {
                SensX = value;
            }
        }

        public void setSensY(float value)
        {
            if (value <= 0)
            {
                SensX = 0.1F;
            }
            else
            {
                SensY = value;
            }
        }

        public void setPatchAcceleration(int value)
        {
            if (value != 0 || value != 1)
            {
                PatchAcceleration = 1;
            }
            else
            {
                PatchAcceleration = value;
            }
        }

        public void setCheckForUpdates(int value)
        {
            if (value != 0 || value != 1)
            {
                CheckForUpdatesOnStart = 1;
            }
            else
            {
                CheckForUpdatesOnStart = value;
            }
        }

        public void setHotKeyEnabled(int value)
        {
            if (value != 0 || value != 1)
            {
                HotkeyEnabled= 1;
            }
            else
            {
                HotkeyEnabled = value;
            }
        }

        public void setSoundsEnabled(int value)
        {
            if (value != 0 || value != 1)
            {
                SoundsEnabled = 1;
            }
            else
            {
                SoundsEnabled = value;
            }
        }

        public void setHideKeybindSuccessMsg(int value)
        {
            if (value != 0 || value != 1)
            {
                HideKeybindSuccessMsg = 0;
            }
            else
            {
                HideKeybindSuccessMsg = value;
            }
        }

        public void setUpdateTimeout(int value)
        {
            if (value != 0 || value != 1)
            {
                UpdateTimeout = 3000;
            }
            else
            {
                UpdateTimeout = value;
            }
        }

        public void setIncrementSens(int value)
        {
            if (value != 0 || value != 1)
            {
                IncrementSens = 1;
            }
            else
            {
                IncrementSens = value;
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
