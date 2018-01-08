using System;
using System.Windows.Forms;

namespace Halo_Mouse_Tool
{
    public class Settings
    {
        public enum Game { CombatEvolved, CustomEdition };

        private Game _current_game = Game.CustomEdition;
        private float _sensX = 1.0F;
        private float _sensY = 1.0F;
        private string _hotKeyApplication = "F1";
        private string _hotKeyDll = "F2";
        private bool _patchAccel = true;

        private bool _checkForUpdates = true;
        private bool _soundsEnabled = true;
        private bool _successMessages = true;

        public Game Current_Game
        {
            get
            {
                return _current_game;
            }
            set
            {
                if (value != Game.CombatEvolved || value != Game.CustomEdition)
                {
                    throw new ArgumentException();
                }
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

        public string HotKeyApplication
        {
            get
            {
                return _hotKeyApplication;
            }
            set
            {
                Keys key;
                if(Enum.TryParse(value, out key))
                {
                    _hotKeyApplication = value;
                }
                else
                {
                    throw new ArgumentException("String must have a Keys equivelant.");
                }
            }
        }

        public string HotKeyDll
        {
            get
            {
                return _hotKeyDll;
            }
            set
            {
                Keys key;
                if (Enum.TryParse(value, out key))
                {
                    _hotKeyDll = value;
                }
                else
                {
                    throw new ArgumentException("String must have a Keys equivelant.");
                }
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
    }
}
