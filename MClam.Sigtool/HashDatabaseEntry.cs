// 
//     HashDatabaseEntry.cs  is part of MClam.Sigtool.
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
namespace MClam.Sigtool
{
    /// <summary>
    /// Hash entry.
    /// </summary>
    /// <remarks>When using <see cref="DatabaseType.PeSectionHash"/>, you need to calculate
    /// Pe section hash, which can be done by using tools like <c>exeinfope</c>. Open up
    /// the file and use Sections Viewer to select and save it. Use <see cref="HasherAlgorithm.MD5"/> 
    /// algorithm to calculate section hash.</remarks>
    public class HashDatabaseEntry
    {
        /// <summary>
        /// File hash.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Hash size.
        /// </summary>
        public int Size { get; set; } = -1;

        /// <summary>
        /// Malware name
        /// </summary>
        public string MalwareName { get; set; }
    }
}
