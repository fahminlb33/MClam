// 
//     ScanResult.cs  is part of MClam.
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
namespace MClam
{
    /// <summary>
    /// File scan result.
    /// </summary>
    public class ScanResult
    {
        /// <summary>
        /// Virus name (if the file is infected).
        /// </summary>
        public string MalwareName { get; internal set; }

        /// <summary>
        /// Fullpath to file has been scanned.
        /// </summary>
        public string FullPath { get; internal set; }

        /// <summary>
        /// Number of bytes that has been scanned.
        /// </summary>
        public int Scanned { get; internal set; }

        /// <summary>
        /// Returns a value indicating this file is infected or not.
        /// </summary>
        public bool IsVirus { get; internal set; }
    }
}
