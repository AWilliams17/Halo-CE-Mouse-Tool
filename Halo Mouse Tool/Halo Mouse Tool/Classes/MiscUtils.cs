using System;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace Halo_Mouse_Tool
{
    public static class MiscUtils
    {
        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void ShowHelp(Form parent)
        {
            string chmPath = Path.Combine(Path.GetTempPath(), "Halo Mouse Tool.chm");
            if (!File.Exists(chmPath))
            {
                byte[] chmBytes;
                chmBytes = Properties.Resources.Halo_Mouse_Tool;
                using (FileStream chmFile = new FileStream(chmPath, FileMode.Create))
                {
                    chmFile.Write(chmBytes, 0, chmBytes.Length);
                }
            }
            Help.ShowHelp(parent, chmPath);
        }

        public static void WriteHaloMemory(Settings settings) //ToDo: Refactor this garbage lol
        {
            byte[] mouseaccelnop = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }; //For noping the acceleration
            int currAddr = 0;
            byte[] currVal = { };
            string game;
            if (settings.Current_Game == Settings.Game.CombatEvolved)
            {
                game = "halo";
                for (int i = 0; i != 3; i++)
                {
                    if (i == 0)
                    {
                        currVal = BitConverter.GetBytes((settings.SensX * 0.25F));
                        currAddr = 0x310B50;
                    }
                    if (i == 1)
                    {
                        currVal = BitConverter.GetBytes((settings.SensY * 0.25F));
                        currAddr = 0x310B54;
                    }
                    if (i == 2 && settings.PatchAcceleration)
                    {
                        currVal = mouseaccelnop;
                        currAddr = 0x963C0;
                    }
                    MemoryHandlingUtils.WriteToProcessMemory(game, currVal, currAddr);
                }
            }
            else
            {
                game = "haloce";
                for (int i = 0; i != 4; i++)
                {
                    if (i == 0)
                    {
                        currVal = BitConverter.GetBytes((settings.SensX * 0.25F));
                        currAddr = 0x2ABB50;
                    }
                    if (i == 1)
                    {
                        currVal = BitConverter.GetBytes((settings.SensY * 0.25F));
                        currAddr = 0x2ABB54;
                    }
                    if (i == 2 && settings.PatchAcceleration)
                    {
                        currVal = mouseaccelnop;
                        currAddr = 0x8F836;
                    }
                    if (i == 3 && settings.PatchAcceleration)
                    {
                        currVal = mouseaccelnop;
                        currAddr = 0x8F830;
                    }
                    MemoryHandlingUtils.WriteToProcessMemory(game, currVal, currAddr);
                }
            }
        }

        public enum TextboxResult { contains_negatives, contains_spaces, is_empty, not_float, valid };
        public static TextboxResult TextboxValid(TextBox textbox)
        {
            float res;
            if (textbox.Text == "")
            {
                return TextboxResult.is_empty;
            }
            if (textbox.Text.Contains(" "))
            {
                return TextboxResult.contains_spaces;
            }
            if (textbox.Text.Contains("-"))
            {
                return TextboxResult.contains_negatives;
            }
            if (!float.TryParse(textbox.Text, out res))
            {
                return TextboxResult.not_float;
            }
            else
            {
                return TextboxResult.valid;
            }
        }
    }
}
