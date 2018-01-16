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
        
        public void SaveSettings()
        {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SensX", SensX, RegistryValueKind.String);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SensY", SensY, RegistryValueKind.String);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "PatchMouseAcceleration", Convert.ToInt32(PatchAcceleration), RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "HotkeyApplication", HotKeyApplication, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "HotkeyDll", HotKeyDll, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "CheckForUpdates", CheckForUpdates, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "UpdateTimeout", UpdateTimeout, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "HotKeyEnabled", Convert.ToInt32(HotKeyEnabled), RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SoundsEnabled", Convert.ToInt32(SoundsEnabled), RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SoundsEnabledDll", Convert.ToInt32(SoundsEnabledDll), RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SuccessMessages", Convert.ToInt32(SuccessMessages), RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "CurrentGame", (int)Current_Game, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "IncrementKeysEnabled", Convert.ToInt32(IncrementKeysEnabled), RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "IncrementAmount", IncrementAmount, RegistryValueKind.String);
        }
        
        public void LoadSettings() //This is bad, but it works.
        {
            RegistryKey HaloMouseToolRegistry = Registry.CurrentUser.OpenSubKey("Software\\HaloMouseTool", false);
            if (HaloMouseToolRegistry == null)
            {
                SaveSettings();
            }
            else
            {
                SensX = float.Parse(HaloMouseToolRegistry.GetValue("SensX").ToString());
                SensY = float.Parse(HaloMouseToolRegistry.GetValue("SensY").ToString());
                PatchAcceleration = Convert.ToInt32(HaloMouseToolRegistry.GetValue("PatchMouseAcceleration")) == 1;
                SoundsEnabled = Convert.ToInt32(HaloMouseToolRegistry.GetValue("SoundsEnabled")) == 1;
                SoundsEnabledDll = Convert.ToInt32(HaloMouseToolRegistry.GetValue("SoundsEnabledDll")) == 1;
                SuccessMessages = Convert.ToInt32(HaloMouseToolRegistry.GetValue("SuccessMessages")) == 1;
                IncrementKeysEnabled = Convert.ToInt32(HaloMouseToolRegistry.GetValue("IncrementKeysEnabled")) == 1;
                CheckForUpdates = Convert.ToInt32(HaloMouseToolRegistry.GetValue("CheckForUpdates")) == 1;
                HotKeyEnabled = Convert.ToInt32(HaloMouseToolRegistry.GetValue("HotKeyEnabled")) == 1;
                HotKeyApplication = int.Parse(HaloMouseToolRegistry.GetValue("HotkeyApplication").ToString());
                HotKeyDll = int.Parse(HaloMouseToolRegistry.GetValue("HotkeyDll").ToString());
                UpdateTimeout = int.Parse(HaloMouseToolRegistry.GetValue("UpdateTimeout").ToString());
                IncrementAmount = float.Parse(HaloMouseToolRegistry.GetValue("IncrementAmount").ToString());
                if (int.Parse(currentGame = HaloMouseToolRegistry.GetValue("CurrentGame").ToString()) == 0)
                {
                    Current_Game = Game.CombatEvolved;
                }
            }
        }
    }
}
