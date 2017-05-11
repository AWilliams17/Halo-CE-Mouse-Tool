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
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess ,bool bInheritHandle, int dwProcessId);


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

        public static string WriteHaloMemory(float sens) //make this function less gay later
        {
            Process process = Process.GetProcessesByName("haloce")[0];
            IntPtr processHandle = OpenProcess(0x1F0FFF, false, getPID("haloce"));
            IntPtr baseAddr = getBaseAddr("haloce");
            if ((int)baseAddr == 0)
            {
                return "Access denied. Try running the tool as Admin?";
            }
            IntPtr xVal = IntPtr.Add(baseAddr, 0x2ABB50);
            IntPtr yVal = IntPtr.Add(baseAddr, 0x2ABB54);
            IntPtr MouseAccelAddress = IntPtr.Add(baseAddr, 0x224AB4); //Default mouse accel is around 0.7
            IntPtr MouseAccelFunc = IntPtr.Add(baseAddr, 0x8F836);
            //byte[] nop = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            //|| !WriteProcessMemory(processHandle, MouseAccelFunc, nop, nop.Length, out bytesWritten) - not entirely sure if this even does anything but make it feel like garbage
            byte[] mouseaccel = BitConverter.GetBytes(2000.5);
            byte[] buffer = BitConverter.GetBytes(sens);
            int bytesWritten = 0;
            
            if (!WriteProcessMemory(processHandle, xVal, buffer, buffer.Length, out bytesWritten) || !WriteProcessMemory(processHandle, yVal, buffer, buffer.Length, out bytesWritten)
                || !WriteProcessMemory(processHandle, MouseAccelAddress, mouseaccel, mouseaccel.Length, out bytesWritten))
            {
                return "Failed to patch Halo CE Sensitivity. Error code: " + Marshal.GetLastWin32Error();
            }

            return "Successfully patched Halo CE Sensitivity + Mouse Acceleration.";

        }
    }
}
