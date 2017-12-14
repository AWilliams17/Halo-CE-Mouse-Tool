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
        private static readonly Stream SuccessFile = Properties.Resources.SND_Success;
        private static readonly Stream NoticeFile = Properties.Resources.SND_Notice;
        private static readonly Stream ErrorFile = Properties.Resources.SND_Error;
        private static readonly SoundPlayer Success = new SoundPlayer(SuccessFile);
        private static readonly SoundPlayer Notice = new SoundPlayer(NoticeFile);
        private static readonly SoundPlayer Error = new SoundPlayer(ErrorFile);

        public static void sound_success(SettingsHandler settings)
        {
            if (settings.SoundsEnabled == 1)
            {
                Success.Play();
            }
        }

        public static void sound_error(SettingsHandler settings)
        {
            if (settings.SoundsEnabled == 1)
            {
                Error.Play();
            }
        }

        public static void sound_notice(SettingsHandler settings)
        {
            if (settings.SoundsEnabled == 1)
            {
                Notice.Play();
            }
        }
    }
}
