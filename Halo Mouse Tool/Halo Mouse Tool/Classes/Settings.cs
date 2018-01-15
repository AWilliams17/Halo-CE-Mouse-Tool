using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Halo_Mouse_Tool
{
    public class Settings
    {
        //CombatEvolved == 1, CustomEdition == 0 in registry
        public enum Game { CombatEvolved, CustomEdition };

        private Game _current_game = Game.CustomEdition;
        private float _sensX = 1.0F;
        private float _sensY = 1.0F;
        private int _hotKeyApplication = 0x70; //F1
        private int _hotKeyDll = 0x71; //F2
        private bool _hotKeyEnabled = true;
        private bool _patchAccel = true;

        private bool _checkForUpdates = true;
        private int _updateTimeout = 5000; //TODO: This needs restrictions
        private bool _soundsEnabled = true;
        private bool _soundsEnabledDll = true;
        private bool _successMessages = true;

        private float _incrementAmount = 0.1F; //TODO: Don't let it go below 0 and above 10
        private bool _incrementKeysEnabled = true;
        
        public Game Current_Game
        {
            get
            {
                return _current_game;
            }
            set
            {
                _current_game = value;
            }
        }

        public float SensX
        {
            get
            {
                return _sensX;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("This cannot be below 0.");
                }
                _sensX = value;
            }
        }

        public float SensY
        {
            get
            {
                return _sensY;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("This cannot be below 0.");
                }
                _sensY = value;
            }
        }

        public bool PatchAcceleration
        {
            get
            {
                return _patchAccel;
            }
            set
            {
                _patchAccel = value;
            }
        }

        public int HotKeyApplication
        {
            get
            {
                return _hotKeyApplication;
            }
            set
            {
                _hotKeyApplication = value;
            }
        }

        public bool HotKeyEnabled
        {
            get
            {
                return _hotKeyEnabled;
            }
            set
            {
                _hotKeyEnabled = value;
            }
        }

        public int HotKeyDll
        {
            get
            {
                return _hotKeyDll;
            }
            set
            {
                _hotKeyDll = value;
            }
        }

        public bool CheckForUpdates
        {
            get
            {
                return _checkForUpdates;
            }
            set
            {
                _checkForUpdates = value;
            }
        }

        public int UpdateTimeout
        {
            get
            {
                return _updateTimeout;
            }
            set
            {
                if (value < 1000)
                {
                    throw new ArgumentOutOfRangeException("This can not be less than 1 second.");
                }
                if (value > 15000)
                {
                    throw new ArgumentOutOfRangeException("This can not be greater than 15 seconds.");
                }
                _updateTimeout = value;
            }
        }

        public bool SoundsEnabled
        {
            get
            {
                return _soundsEnabled;
            }
            set
            {
                _soundsEnabled = value;
            }
        }

        public bool SoundsEnabledDll
        {
            get
            {
                return _soundsEnabledDll;
            }
            set
            {
                _soundsEnabledDll = value;
            }
        }

        public bool SuccessMessages
        {
            get
            {
                return _successMessages;
            }
            set
            {
                _successMessages = value;
            }
        }

        public float IncrementAmount
        {
            get
            {
                return _incrementAmount;
            }
            set
            {
                if (value < 0.0F)
                {
                    throw new ArgumentOutOfRangeException("Increment amount can not be below 0.");
                }
                if (value > 25.0F)
                {
                    throw new ArgumentOutOfRangeException("Increment amount can not be above 25.");
                }
                _incrementAmount = value;
            }
        }

        public bool IncrementKeysEnabled
        {
            get
            {
                return _incrementKeysEnabled;
            }
            set
            {
                _incrementKeysEnabled = value;
            }
        }

        public void LoadSettings() //ToDo: Refactor this garbage
        {
            RegistryKey HaloMouseToolRegistry = Registry.CurrentUser.OpenSubKey("Software\\HaloMouseTool", false);
            if (HaloMouseToolRegistry == null)
            {
                saveSettings();
            }
            else
            {
                object sensX = HaloMouseToolRegistry.GetValue("SensX");
                object sensY = HaloMouseToolRegistry.GetValue("SensY");
                object mouseAcceleration = HaloMouseToolRegistry.GetValue("PatchMouseAcceleration");
                object hotKeyApplication = HaloMouseToolRegistry.GetValue("HotkeyApplication");
                object hotKeyDll = HaloMouseToolRegistry.GetValue("HotkeyDll");

                object incrementAmount = HaloMouseToolRegistry.GetValue("IncrementAmount");
                object incrementEnabled = HaloMouseToolRegistry.GetValue("IncrementKeysEnabled");
                object currentGame = HaloMouseToolRegistry.GetValue("CurrentGame");

                object checkForUpdates = HaloMouseToolRegistry.GetValue("CheckForUpdates");
                object updateTimeout = HaloMouseToolRegistry.GetValue("UpdateTimeout");
                object soundsEnabled = HaloMouseToolRegistry.GetValue("SoundsEnabled");
                object soundsEnabledDll = HaloMouseToolRegistry.GetValue("SoundsEnabledDll");
                object successMessages = HaloMouseToolRegistry.GetValue("SuccessMessages");

                SensX = float.Parse(sensX.ToString());
                SensY = float.Parse(sensY.ToString());
                if (mouseAcceleration.ToString() == "0")
                {
                    PatchAcceleration = false;
                }
                HotKeyApplication = int.Parse(hotKeyApplication.ToString());
                HotKeyDll = int.Parse(hotKeyDll.ToString());
                if (checkForUpdates.ToString() == "0")
                {
                    CheckForUpdates = false;
                }
                UpdateTimeout = int.Parse(updateTimeout.ToString());
                if (soundsEnabled.ToString() == "0")
                {
                    SoundsEnabled = false;
                }
                if (soundsEnabledDll.ToString() == "0")
                {
                    SoundsEnabledDll = false;
                }
                if (successMessages.ToString() == "0")
                {
                    SuccessMessages = false;
                }
                if (incrementEnabled.ToString() == "0")
                {
                    IncrementKeysEnabled = false;
                }
                if ((int)currentGame == 1)
                {
                    Current_Game = Settings.Game.CombatEvolved;
                }
                IncrementAmount = float.Parse(incrementAmount.ToString());
            }
        }

        public void saveSettings() //ToDo: Refactor this garbage.
        {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SensX", SensX, RegistryValueKind.String);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SensY", SensY, RegistryValueKind.String);
            if (PatchAcceleration)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "PatchMouseAcceleration", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "PatchMouseAcceleration", 0, RegistryValueKind.DWord);
            }

            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "HotkeyApplication", HotKeyApplication, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "HotkeyDll", HotKeyDll, RegistryValueKind.DWord);
            if (CheckForUpdates)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "CheckForUpdates", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "CheckForUpdates", 0, RegistryValueKind.DWord);
            }

            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "UpdateTimeout", UpdateTimeout, RegistryValueKind.DWord);

            if (HotKeyEnabled)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "HotKeyEnabled", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "HotKeyEnabled", 0, RegistryValueKind.DWord);
            }

            if (SoundsEnabled)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SoundsEnabled", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SoundsEnabled", 0, RegistryValueKind.DWord);
            }

            if (SoundsEnabledDll)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SoundsEnabledDll", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SoundsEnabledDll", 0, RegistryValueKind.DWord);
            }

            if (SuccessMessages)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SuccessMessages", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SuccessMessages", 0, RegistryValueKind.DWord);
            }

            if (Current_Game == Settings.Game.CombatEvolved)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "CurrentGame", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "CurrentGame", 0, RegistryValueKind.DWord);
            }

            if (IncrementKeysEnabled)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "IncrementKeysEnabled", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "IncrementKeysEnabled", 0, RegistryValueKind.DWord);
            }

            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "IncrementAmount", IncrementAmount, RegistryValueKind.String);
        }
    }
}
