using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

/*
    -MemoryHandler-
    This class should allow access to a processes memory, and allow reading from
    and writing to it.
*/
namespace Halo_CE_Mouse_Tool {
    public static class MemoryHandler {
        const int PROCESS_WM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);


        private static int GetPID(string processname) {
            Process[] process = Process.GetProcessesByName(processname);
            int PID = process[0].Id;

            return PID;
        }

        private static IntPtr getBaseAddr(string processname) {
            IntPtr baseaddr;
            try {
                Process[] processes = Process.GetProcessesByName(processname);
                baseaddr = processes[0].MainModule.BaseAddress;
            } catch (System.ComponentModel.Win32Exception) {
                return (IntPtr)0;
            }

            return baseaddr;
        }

        /*
            -WriteToProcessMemory-
            Return value 1: Access Denied.
            Return value 0: Success
            Otherwise, error code is returned.
        */
        public static int WriteToProcessMemory(string processname, float value, int address) {
            Process process = Process.GetProcessesByName(processname)[0];
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, GetPID(processname));
            IntPtr baseAddr = getBaseAddr(processname);
            if ((int)baseAddr == 0) {
                return 1;
            }

            IntPtr addr = IntPtr.Add(baseAddr, address);
            byte[] buffer = BitConverter.GetBytes(value);
            int bytesWritten = 0;

            if (!WriteProcessMemory(processHandle, addr, buffer, buffer.Length, out bytesWritten)) {
                return Marshal.GetLastWin32Error();
            }
            return 0;
        }

        public static int WriteToProcessMemory(string processname, byte[] value, int address) {
            Process process = Process.GetProcessesByName(processname)[0];
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, GetPID(processname));
            IntPtr baseAddr = getBaseAddr(processname);
            if ((int)baseAddr == 0) {
                return 1;
            }

            IntPtr addr = IntPtr.Add(baseAddr, address);
            int bytesWritten = 0;

            if (!WriteProcessMemory(processHandle, addr, value, value.Length, out bytesWritten)) {
                return Marshal.GetLastWin32Error();
            }
            return 0;
        }
    }
}
