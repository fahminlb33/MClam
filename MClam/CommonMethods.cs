using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MClam.Native;

namespace MClam
{
    internal static class CommonMethods
    {
        internal static string GetClamErrorText(int errorCode)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cl_strerror(errorCode));
        }

        internal static void ThrowIfError(this int errorCode)
        {
            if (errorCode != (int)cl_error_t.CL_SUCCESS) throw new ClamException(errorCode);
        }
    }
}
