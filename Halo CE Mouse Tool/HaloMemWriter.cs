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


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);


        public static int getPID(string processname)
        {
            Process[] process = Process.GetProcessesByName(processname);
            int PID = process[0].Id;

            return PID;
        }

        public static IntPtr getBaseAddr(string processname)
        {
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

        public static string WriteHaloMemory(float sensX, float sensY)
        {
            Process process = Process.GetProcessesByName("haloce")[0];
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, getPID("haloce"));
            IntPtr baseAddr = getBaseAddr("haloce");
            if ((int)baseAddr == 0)
            {
                return "Access denied. Try running the tool as Admin?";
            }

            IntPtr xVal = IntPtr.Add(baseAddr, 0x2ABB50);
            IntPtr yVal = IntPtr.Add(baseAddr, 0x2ABB54);
            IntPtr MouseAccelFunc1 = IntPtr.Add(baseAddr, 0x8F836);
            IntPtr MouseAccelFunc2 = IntPtr.Add(baseAddr, 0x8F830);

            byte[] nop = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            byte[] mouseaccel = BitConverter.GetBytes((float)0);
            byte[] buffer1 = BitConverter.GetBytes(sensX);
            byte[] buffer2 = BitConverter.GetBytes(sensY);

            int bytesWritten = 0;

            if (
                !WriteProcessMemory(processHandle, xVal, buffer1, buffer1.Length, out bytesWritten) 
                || !WriteProcessMemory(processHandle, yVal, buffer2, buffer2.Length, out bytesWritten)
                || !WriteProcessMemory(processHandle, MouseAccelFunc1, nop, nop.Length, out bytesWritten) 
                || !WriteProcessMemory(processHandle, MouseAccelFunc2, nop, nop.Length, out bytesWritten) 
                )
            {
                return "Failed to patch Halo CE Sensitivity. Error code: " + Marshal.GetLastWin32Error();
            }

            return "Successfully patched Halo CE Sensitivity + Mouse Acceleration.";

        }
    }
}
