using System.Diagnostics;

namespace Halo_Mouse_Tool
{
    public static class ProcessHandlingUtils
    {
        public static bool ProcessIsRunning(string processName)
        { //If user passes process name with ".exe",
            if (processName.Contains(".exe"))
            {
                processName = processName.Substring(0, processName.Length - 4); //Strip it out
            }
            Process[] pname = Process.GetProcessesByName(processName);
            if (pname.Length != 0)
            {
                return true;
            }
            return false;
        }
    }
}
