using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;

namespace Halo_CE_Mouse_Tool
{
    /*
        -SoundHandler-
        Plays sounds!
        Relies on Mainform.settings though, can I abstract that out?
        TODO: Do it.
    */
    public static class SoundHandler
    {
        private static Stream success_file = Properties.Resources.SND_Success;
        private static Stream notice_file = Properties.Resources.SND_Notice;
        private static Stream error_file = Properties.Resources.SND_Error;
        private static SoundPlayer success = new System.Media.SoundPlayer(success_file);
        private static SoundPlayer notice = new System.Media.SoundPlayer(notice_file);
        private static SoundPlayer error = new System.Media.SoundPlayer(error_file);

        public static void sound_success(SettingsHandler settings)
        {
            if (settings.SoundsEnabled == 1)
            {
                success.Play();
            }
        }

        public static void sound_error(SettingsHandler settings)
        {
            if (settings.SoundsEnabled == 1)
            {
                error.Play();
            }
        }

        public static void sound_notice(SettingsHandler settings)
        {
            if (settings.SoundsEnabled == 1)
            {
                notice.Play();
            }
        }
    }
}
