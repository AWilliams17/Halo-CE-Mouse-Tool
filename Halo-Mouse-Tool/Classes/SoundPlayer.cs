using Halo_Mouse_Tool.Classes.ConfigContainer;
using System;

namespace Halo_Mouse_Tool.Classes.SoundPlayer
{
    public class SoundPlayer
    {
        private readonly Config configInstance;

        public SoundPlayer(Config config)
        {
            configInstance = config;
        }

        public void PlaySuccess()
        {
            if (configInstance.settings.GetOption<int>("SuccessSounds") == 1)
            {
                Console.Beep(300, 250);
            }
        }

        public void PlayError()
        {
            Console.Beep(150, 250);
        }
    }
}
