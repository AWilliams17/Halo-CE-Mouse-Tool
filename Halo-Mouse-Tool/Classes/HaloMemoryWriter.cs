using System;
using System.Diagnostics;
using System.Linq;
using SharpUtils.MiscUtils;

namespace Halo_Mouse_Tool.Classes.HaloMemoryWriter
{
    public static class HaloMemoryWriter
    {
        private static readonly byte[] _mouseAccelerationNOP = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
        private enum _haloAddresses
        {
            AccelerationCE_1 = 0x8F830,
            AccelerationCE_2 = 0x8F836,
            AccelerationPC = 0x963C0,
            SensXCE = 0x2ABB50,
            SensYCE = 0x2ABB54,
            SensXPC = 0x310B50,
            SensYPC = 0x310B54,
        }

        public static bool IsProcessRunning(string ProcessName)
        {
            Process[] processSearchResults = Process.GetProcessesByName(ProcessName);
            return (processSearchResults.Length != 0);
        }

        public static bool WriteToCustomEdition(float SensitivityX, float SensitivityY)
        {
            byte[] sensitivityX = BitConverter.GetBytes(SensitivityX);
            byte[] sensitivityY = BitConverter.GetBytes(SensitivityY);
            bool[] operationResults = {
                WriteMemoryHelper.WriteToProcessMemory("haloce", sensitivityX, (int)_haloAddresses.SensXCE),
                WriteMemoryHelper.WriteToProcessMemory("haloce", sensitivityX, (int)_haloAddresses.SensYCE),
                WriteMemoryHelper.WriteToProcessMemory("haloce", _mouseAccelerationNOP, (int)_haloAddresses.AccelerationCE_1),
                WriteMemoryHelper.WriteToProcessMemory("haloce", _mouseAccelerationNOP, (int)_haloAddresses.AccelerationCE_2),
            };
            
            return operationResults.All(x => x);
        }

        public static bool WriteToCombatEvolved(float SensitivityX, float SensitivityY)
        {
            byte[] sensitivityX = BitConverter.GetBytes(SensitivityX);
            byte[] sensitivityY = BitConverter.GetBytes(SensitivityY);
            bool[] operationResults = {
                WriteMemoryHelper.WriteToProcessMemory("halo", sensitivityX, (int)_haloAddresses.SensXPC),
                WriteMemoryHelper.WriteToProcessMemory("halo", sensitivityX, (int)_haloAddresses.SensYPC),
                WriteMemoryHelper.WriteToProcessMemory("halo", _mouseAccelerationNOP, (int)_haloAddresses.AccelerationPC),
            };

            return operationResults.All(x => x);
        }
    }
}
