using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Halo_CE_Mouse_Tool
{
    class HaloMemWriter
    {
        const int PROCESS_WM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, uint lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, uint lpBaseAddress, byte[] lpBuffer, int nSize, IntPtr lpNumberOfBytesWritten);


        private static int GetPID(string processname)
        {
            int PID = Process.GetProcessesByName(processname)[0].Id;
            return PID;
        }

        public static IntPtr GetProcessHandle(string processname)
        {
            IntPtr processHandle;
            processHandle = OpenProcess(PROCESS_WM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, GetPID(processname));
            return processHandle;
        }

        public static IntPtr GetBaseAddr(string windowname)
        {
            Process h = Process.GetProcessesByName(windowname).FirstOrDefault();
            IntPtr base_adr = h.MainModule.EntryPointAddress;
            return base_adr;
        }



    }
}
