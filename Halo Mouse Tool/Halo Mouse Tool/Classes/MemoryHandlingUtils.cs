using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace Halo_Mouse_Tool
{
    public class BaseAddressInvalid : Exception
    {
        public BaseAddressInvalid() : base() { }
    }

    public class WriteProcessException : Exception
    {
        public WriteProcessException(string exceptionText) : base(exceptionText) { }
    }

    public static class MemoryHandlingUtils
    {
        const int PROCESS_WM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);


        private static int GetPid(string processname)
        { //Return the PID of the requested process. Needs exception handling.
            Process[] process = Process.GetProcessesByName(processname);
            int pid = process[0].Id;

            return pid;
        }

        private static IntPtr GetBaseAddr(string processname)
        { //Return the base address of the requested process.
            IntPtr baseaddr;
            try
            {
                Process[] processes = Process.GetProcessesByName(processname);
                baseaddr = processes[0].MainModule.BaseAddress;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                return (IntPtr)0;
            }

            return baseaddr;
        }
        
        public static void WriteToProcessMemory(string processname, byte[] value, int address)
        {
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, GetPid(processname));
            IntPtr baseAddr = GetBaseAddr(processname);
            if ((int)baseAddr == 0)
            {
                throw new BaseAddressInvalid();
            }

            IntPtr addr = IntPtr.Add(baseAddr, address);
            int bytesWritten = 0;

            if (!WriteProcessMemory(processHandle, addr, value, value.Length, out bytesWritten))
            {
                throw new WriteProcessException("WriteProcessMemory operation failed with Win32ErrorCode: " + Marshal.GetLastWin32Error().ToString());
            }
        }
    }
}
