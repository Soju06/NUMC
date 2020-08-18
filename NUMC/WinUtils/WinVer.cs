using System;
using System.Runtime.InteropServices;

namespace WinUtils
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SYSTEM_INFO
    {
        public PROCESSOR_ARCHITECTURE wProcessorArchitecture;
        private readonly short wReserved;

        public int dwPageSize;
        public IntPtr lpMinimumApplicationAddress;
        public IntPtr lpMaximumApplicationAddress;
        public IntPtr dwActiveProcessorMask;
        public int dwNumberOfProcessors;
        public int dwProcessorType;
        public int dwAllocationGranularity;
        public short wProcessorLevel;
        public short wProcessorRevision;
    };

    public enum PROCESSOR_ARCHITECTURE : short
    {
        PROCESSOR_ARCHITECTURE_INTEL = 0,
        PROCESSOR_ARCHITECTURE_MIPS = 1,
        PROCESSOR_ARCHITECTURE_ALPHA = 2,
        PROCESSOR_ARCHITECTURE_PPC = 3,
        PROCESSOR_ARCHITECTURE_SHX = 4,
        PROCESSOR_ARCHITECTURE_ARM = 5,
        PROCESSOR_ARCHITECTURE_IA64 = 6,
        PROCESSOR_ARCHITECTURE_ALPHA64 = 7,
        PROCESSOR_ARCHITECTURE_MSIL = 8,
        PROCESSOR_ARCHITECTURE_AMD64 = 9,
        PROCESSOR_ARCHITECTURE_IA32_ON_WIN64 = 10,
        PROCESSOR_ARCHITECTURE_NEUTRAL = 11
    }

    public static class WinVer
    {
        public static Version SystemVersion = WinVer.GetSystemVersion();

        private delegate IntPtr RtlGetNtVersionNumbers(ref int dwMajor, ref int dwMinor, ref int dwBuildNumber);

        private static Version GetSystemVersion()
        {
            IntPtr hinst = WinAPI.GetModuleHandle("ntdll.dll");
            RtlGetNtVersionNumbers func = (RtlGetNtVersionNumbers)WinAPI.GetFunctionAddress(hinst, "RtlGetNtVersionNumbers", typeof(RtlGetNtVersionNumbers));

            if (func == null)
                return Environment.OSVersion.Version;

            int dwMajor = 0, dwMinor = 0, dwBuildNumber = 0;
            func.Invoke(ref dwMajor, ref dwMinor, ref dwBuildNumber);
            dwBuildNumber &= 0xffff;
            return new Version(dwMajor, dwMinor, dwBuildNumber);
        }
    }
}