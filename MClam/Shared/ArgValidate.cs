// 
//     ArgValidate.cs  is part of MClam.
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
using System;
using System.IO;

namespace MClam.Shared
{
    internal static class ArgValidate
    {
        internal static void NotNull(object obj, string paramName)
        {
            if (obj == null) throw new ArgumentNullException(paramName);
        }

        internal static void NotEmptyString(string s, string paramName)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new ArgumentNullException(paramName);
        }

        internal static void FileExist(string path, string paramName)
        {
            if (!File.Exists(path)) throw new ArgumentException("File not found!", paramName);
        }

        internal static void DirectoryExist(string path, string paramName)
        {
            if (!Directory.Exists(path)) throw new ArgumentException("Directory not found!", paramName);
        }

        internal static void IsInRange(int value, int min, int max, string paramName)
        {
            if (min >= value || value <= max)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

    }
}
