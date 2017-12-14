using System.Diagnostics;

/*
    -ProcessHandler Class-
    This class should check if a process is running or not. :/ Might be removed
    later because thats kinda silly. But I guess it helps split things up. -shrug-
*/
namespace Halo_CE_Mouse_Tool
{
    public static class ProcessHandler
    {
        public static bool ProcessIsRunning(string processName)
        { //If user passes process name with ".exe",
            if (processName.Contains(".exe"))
            {
                processName = processName.Substring(0, processName.Length - 4); //Strip it out
            }
            Process[] pname = Process.GetProcessesByName(processName);
            if (pname.Length != 0)
                return true;
            else
                return false;
        }
    }
}

