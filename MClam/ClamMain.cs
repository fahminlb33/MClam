using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MClam.Native;

namespace MClam
{
    /// <summary>
    /// Main libclamav wrapper.
    /// </summary>
    public static class ClamMain
    {
        /// <summary>
        /// Initialize libclamav library.
        /// </summary>
        /// <param name="initOption">Initizalization options. Leave this parameter untouched.</param>
        /// <remarks>Call this method once. Only at first start to initialize crypto engine.</remarks>
        public static void Initialize(uint initOption = NativeConstants.CL_INIT_DEFAULT)
        {
            NativeMethods.cl_init(initOption).ThrowIfError();
        }

        /// <summary>
        /// Returns current libclamav version.
        /// </summary>
        /// <returns>Libclamav version.</returns>
        public static string GetVersion()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cl_retver());
        }

        /// <summary>
        /// Returns current libclamav hardcoded database directory.
        /// </summary>
        /// <returns>Hardcoded database directory.</returns>
        public static string GetDatabaseDirectory()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cl_retdbdir());
        }

        /// <summary>
        /// Create new scan engine.
        /// </summary>
        /// <returns>New instance of <see cref="ClamEngine"/>.</returns>
        public static ClamEngine CreateEngine()
        {
            return new ClamEngine();
        }
    }
}
