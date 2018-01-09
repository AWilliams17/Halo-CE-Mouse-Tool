using System.IO;
using System.Media;

namespace Halo_Mouse_Tool
{
    public static class SoundHandlingUtils
    {
        private static readonly Stream SuccessFile = Properties.Resources.Success;
        private static readonly Stream AlertFile = Properties.Resources.Alert;
        private static readonly Stream ErrorFile = Properties.Resources.Error;
        private static readonly Stream IncrementErrFile = Properties.Resources.IncrementError;
        private static readonly SoundPlayer Success = new SoundPlayer(SuccessFile);
        private static readonly SoundPlayer Alert = new SoundPlayer(AlertFile);
        private static readonly SoundPlayer Error = new SoundPlayer(ErrorFile);
        private static readonly SoundPlayer IncrementError = new SoundPlayer(IncrementErrFile);

        public enum SoundType { Success, IncrementError, Error, Alert };

        public static void sound_success()
        {
            Success.Play();
        }

        public static void sound_incrementerror()
        {
            IncrementError.Play();
        }

        public static void sound_error()
        {
            Error.Play();
        }

        public static void sound_alert()
        {
            Alert.Play();
        }
    }
}
