using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static bool ProcessIsRunning(string process_name)
        { //If user passes process name with ".exe",
            if (process_name.Substring(process_name.Length - 4) == ".exe")
            {
                process_name = process_name.Substring(0, process_name.Length - 4); //Strip it out
            }
            Process[] pname = Process.GetProcessesByName(process_name);
            if (pname.Length != 0)
                return true;
            else
                return false;

            //This doesn't work. idk why i even changed it.
            /*
            Process[] processlist = Process.GetProcesses();
            foreach (Process i in processlist) {
                if (i.ProcessName.ToLower() == process_name.ToLower()) {
                    return true; //I found the process name in the current list of running processes.
                }
            }
            return false; //I didn't find the process name.
            */
        }
    }
}
