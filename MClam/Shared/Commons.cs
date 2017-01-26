// 
//     Commons.cs  is part of MClam.
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
