using Halo_Mouse_Tool.Classes.ConfigValidators;

namespace Halo_Mouse_Tool.Classes.ConfigContainer
{
    public class Config
    {
        public Validators configValidators = new Validators();
        public Registrar.RegSettings settings = new Registrar.RegSettings(Registrar.RegBaseKeys.HKEY_CURRENT_USER, "Software/HaloMouseTool");

        private void RegisterSettings()
        {
            Registrar.RegOption mouseSensX = new Registrar.RegOption("SensitivityX", configValidators.SensitivityValidatorInstance, 1.0f, typeof(float));
            Registrar.RegOption mouseSensY = new Registrar.RegOption("SensitivityY", configValidators.SensitivityValidatorInstance, 1.0f, typeof(float));
            Registrar.RegOption hotKeyEnabled = new Registrar.RegOption("HotkeyEnabled", configValidators.BoolValidatorInstance, false, typeof(bool));
            Registrar.RegOption hotKey = new Registrar.RegOption("Hotkey", configValidators.HotkeyValidatorInstance, "F1", typeof(string));
            Registrar.RegOption incrementKeysEnabled = new Registrar.RegOption("IncrementHotkeys", configValidators.BoolValidatorInstance, false, typeof(bool));
            Registrar.RegOption incrementAmount = new Registrar.RegOption("IncrementAmount", configValidators.IncrementAmountValidatorInstance, 1.0f, typeof(float));
            Registrar.RegOption currentGame = new Registrar.RegOption("CurrentGame", null, 0, typeof(int));

            settings.RegisterSetting("SensitivityX", mouseSensX);
            settings.RegisterSetting("SensitivityY", mouseSensY);
            settings.RegisterSetting("HotkeyEnabled", hotKeyEnabled);
            settings.RegisterSetting("Hotkey", hotKey);
            settings.RegisterSetting("IncrementKeysEnabled", incrementKeysEnabled);
            settings.RegisterSetting("IncrementAmount", incrementAmount);
            settings.RegisterSetting("CurrentGame", currentGame);
        }

        public Config()
        {
            RegisterSettings();
        }
    }
}
