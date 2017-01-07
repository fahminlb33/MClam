using System.Runtime.InteropServices;
using MClam.Native;

namespace MClam
{
    internal static class Commons
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
