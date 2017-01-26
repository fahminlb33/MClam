// 
//     ClamMain.cs  is part of MClam.
//     Copyright (C) 2017  Fahmi Noor Fiqri
// 
//     This program is free software; you can redistribute it and/or
//     modify it under the terms of the GNU General Public License
//     as published by the Free Software Foundation; either version 2
//     of the License, or (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program; if not, write to the Free Software
//     Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
using System.Runtime.InteropServices;
using MClam.Native;
using MClam.Shared;

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
