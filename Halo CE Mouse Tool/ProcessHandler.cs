using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/*
    -ProcessHandler Class-
    This class should check if a process is running or not. :/ Might be removed
    later because thats kinda silly.
*/
namespace Halo_CE_Mouse_Tool {
    public class ProcessHandler  {
        public bool ProcessIsRunning(string process_name) { //If user passes process name with ".exe",
            if (process_name.Substring(process_name.Length - 4) == ".exe") {
                process_name = process_name.Substring(0, process_name.Length - 4); //Strip it out
            }

            Process[] processlist = Process.GetProcesses();
            foreach (Process i in processlist) {
                if (i.ProcessName == process_name) {
                    return true;
                }
            }
            return false;
        }
    }
}
