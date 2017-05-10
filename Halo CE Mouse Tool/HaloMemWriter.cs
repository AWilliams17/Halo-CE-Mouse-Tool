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
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);


        public static int GetPID(string processname)
        {
            Process[] processes = Process.GetProcessesByName(processname);

            if (processes.Length == 0)
                return 0;


            return processes[0].Id;
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
            IntPtr base_adr = h.MainModule.BaseAddress;
            return base_adr;
        }

        public static bool ReadMemory(string processname)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[0];

            IntPtr processHandle = GetProcessHandle(processname);
            IntPtr address = GetBaseAddr(processname);

            return ReadProcessMemory((int)processHandle, (int)address, buffer, buffer.Length, ref bytesRead);
        }
    }
}
