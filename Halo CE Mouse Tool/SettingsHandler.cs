using System.Runtime.Serialization;
using System;
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
        [DataMember] private float SensXP = 1;
        [DataMember] private float SensYP = 1;
        [DataMember] private int PatchAccelerationP = 1;
        [DataMember] private int CheckForUpdatesP = 1;
        [DataMember] private int HotkeyEnabledP = 1;
        [DataMember] private string HotkeyP = "F1";
        [DataMember] private int SoundsEnabledP = 1;
        [DataMember] private int HideKeyBindSuccessMsgP = 1;
        [DataMember] private int UpdateTimeoutP = 3000;
        [DataMember] private int IncrementSensP = 1;
        [DataMember] private float IncrementAmountP = 0.5F;


        public float SensX
        {
            get
            {
                return SensXP;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    SensXP = value;
                }
            }
        }
        public float SensY
        {
            get
            {
                return SensYP;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    SensYP = value;
                }
            }
        }
        public int PatchAcceleration
        {
            get
            {
                return PatchAccelerationP;
            }
            set
            {
                if (value == 1 || value == 0)
                {
                    PatchAccelerationP = value;

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
                return CheckForUpdatesP;
            }
            set
            {
                if (value == 1 || value == 0)
                {
                    CheckForUpdatesP = value;
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
                return HotkeyEnabledP;
            }
            set
            {
                if (value == 1 || value == 0)
                {
                    HotkeyEnabledP = value;
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
                return HotkeyP;
            }
            set
            {
                HotkeyP = value; //I guess I'll just validate if its got a Keys equiv.
            }
        }
        public int SoundsEnabled
        {
            get
            {
                return SoundsEnabledP;
            }
            set
            {
                if (value == 1 || value == 0)
                {
                    SoundsEnabledP = value;
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
                return HideKeyBindSuccessMsgP;
            }
            set
            {
                if (value == 1 || value == 0)
                {
                    HideKeyBindSuccessMsgP = value;
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
                return UpdateTimeoutP;
            }
            set
            {
                UpdateTimeoutP = value; //IDK if I should really care what the user sets the timeout to...
            }
        }
        public int IncrementSens
        {
            get
            {
                return IncrementSensP;
            }
            set
            {
                if (value == 0 || value == 1)
                {
                    IncrementSensP = value;
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
                return IncrementAmountP;
            }
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentException();
                }
                else
                {
                    IncrementAmountP = value;
                }
            }
        }
    }
}
