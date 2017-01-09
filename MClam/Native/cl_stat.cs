using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
