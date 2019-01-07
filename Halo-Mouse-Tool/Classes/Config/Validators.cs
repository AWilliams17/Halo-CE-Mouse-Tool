using Registrar;
using System;
using System.Windows.Forms;

namespace Halo_Mouse_Tool.Classes.ConfigValidators
{
    public class Validators
    {
        class SensitivityValidator : IValidator
        {
            public string Description()
            {
                return "Value must be between 0.01 and 20.0";
            }

            public bool Validate(object value)
            {
                float convertedValue = ValidatorConverters.ValidatorFloatConverter(value);
                return (convertedValue >= 0.01f && convertedValue <= 20.0f);
            }
        }

        class BoolValidator : IValidator
        {
            public string Description()
            {
                return "Value must be a boolean (1 or 0 in registry)";
            }

            public bool Validate(object value)
            {
                int convertedValue = ValidatorConverters.ValidatorIntConverter(value);
                return (convertedValue == 1 || convertedValue == 0);
            }
        }

        class IncrementAmountValidator : IValidator
        {
            public string Description()
            {
                return "Value must be between 0.01 and 5.0";
            }

            public bool Validate(object value)
            {
                float convertedValue = ValidatorConverters.ValidatorFloatConverter(value);
                return (convertedValue >= 0.01f && convertedValue <= 5.0f);
            }
        }

        class HotkeyValidator : IValidator
        {
            public string Description()
            {
                return "Must be a valid key";
            }

            public bool Validate(object value)
            {
                string convertedValue = ValidatorConverters.ValidatorStringConverter(value);

                try
                {
                    Keys convertedKey = (Keys)Enum.Parse(typeof(Keys), convertedValue, true);
                }
                catch (ArgumentException)
                {
                    return false;
                }

                return true;
            }
        }


        class CurrentGameValidator : IValidator
        {
            public string Description()
            {
                return "Must be 0(PC) or 1(CE).";
            }

            public bool Validate(object value)
            {
                int convertedValue = ValidatorConverters.ValidatorIntConverter(value);
                return (convertedValue == 0 || convertedValue == 1);
            }
        }


        public IValidator SensitivityValidatorInstance = new SensitivityValidator();
        public IValidator BoolValidatorInstance = new BoolValidator();
        public IValidator IncrementAmountValidatorInstance = new IncrementAmountValidator();
        public IValidator HotkeyValidatorInstance = new HotkeyValidator();
        public IValidator CurrentGameValidatorInstance = new CurrentGameValidator();
    }
}
