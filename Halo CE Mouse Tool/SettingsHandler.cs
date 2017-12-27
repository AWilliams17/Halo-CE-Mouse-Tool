using System.Runtime.Serialization;
using System;

namespace Halo_CE_Mouse_Tool
{
    /*
        -SettingsHandler.cs-
        This class contains the settings for the application.
    */
    [DataContract]
    public class SettingsHandler
    {
        [DataMember] private float _sensX = 0.25F;
        [DataMember] private float _sensY = 0.25F;
        [DataMember] private int _patchAcceleration = 1;
        [DataMember] private int _checkForUpdates = 1;
        [DataMember] private int _hotkeyEnabled = 1;
        [DataMember] private string _hotkey = "F1";
        [DataMember] private int _soundEnabled = 1;
        [DataMember] private int _hideKeybindSuccessMessage = 1;
        [DataMember] private int _updateTimeout = 3000;
        [DataMember] private int _incrementSens = 1;
        [DataMember] private float _incrementAmount = 0.5F;


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
                    throw new ArgumentOutOfRangeException();
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
                    throw new ArgumentOutOfRangeException();
                }
                _sensY = value;
            }
        }
        public int PatchAcceleration
        {
            get
            {
                return _patchAcceleration;
            }
            set
            {
                if (value == 1 || value == 0)
                {
                    _patchAcceleration = value;

                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public int CheckForUpdatesOnStart
        {
            get
            {
                return _checkForUpdates;
            }
            set
            {
                if (value == 1 || value == 0)
                {
                    _checkForUpdates = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public int HotkeyEnabled
        {
            get
            {
                return _hotkeyEnabled;
            }
            set
            {
                if (value == 1 || value == 0)
                {
                    _hotkeyEnabled = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string Hotkey
        {
            get
            {
                return _hotkey;
            }
            set
            {
                _hotkey = value; //I guess I'll just validate if its got a Keys equiv.
            }
        }
        public int SoundsEnabled
        {
            get
            {
                return _soundEnabled;
            }
            set
            {
                if (value == 1 || value == 0)
                {
                    _soundEnabled = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public int HideKeybindSuccessMsg
        {
            get
            {
                return _hideKeybindSuccessMessage;
            }
            set
            {
                if (value == 1 || value == 0)
                {
                    _hideKeybindSuccessMessage = value;
                }
                else
                {
                    throw new ArgumentException();
                }
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
                _updateTimeout = value; //IDK if I should really care what the user sets the timeout to...
            }
        }
        public int IncrementSens
        {
            get
            {
                return _incrementSens;
            }
            set
            {
                if (value == 0 || value == 1)
                {
                    _incrementSens = value;
                }
                else
                {
                    throw new ArgumentException();
                }
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
                if (value < 0 || value > 5)
                {
                    throw new ArgumentException();
                }
                _incrementAmount = value;
            }
        }
    }
}
