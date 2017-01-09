using System;
using System.Runtime.InteropServices;

namespace MClam.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct cl_stat
    {

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string dir;

        /// stat*
        public IntPtr stattab;

        /// char**
        public IntPtr statdname;

        /// unsigned int
        public uint entries;
    }
}
