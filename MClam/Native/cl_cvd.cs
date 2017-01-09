using System.Runtime.InteropServices;

namespace MClam.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct cl_cvd
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string time;

        public uint version;

        public uint sigs;

        public uint fl;

        [MarshalAs(UnmanagedType.LPStr)]
        public string md5;

        [MarshalAs(UnmanagedType.LPStr)]
        public string dsig;

        [MarshalAs(UnmanagedType.LPStr)]
        public string builder;

        public uint stime;
    }
}
