using System.Runtime.InteropServices;
using MClam.Native;
using MClam.Sigtool;

namespace MClam.Shared
{
    /// <summary>
    /// Provides commons tasks
    /// </summary>
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

        internal static bool IsHashDatabase(DatabaseType type)
        {
            return type == DatabaseType.Md5Hash ||
                   type == DatabaseType.Sha1Hash ||
                   type == DatabaseType.Sha256Hash ||
                   type == DatabaseType.PeSectionHash;
        }
    }
}
