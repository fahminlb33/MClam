// 
//     DatabaseType.cs  is part of MClam.
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
    /// Specified ClamAV database type (according to sigtool specs).
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// Clamav Database File (CVD).
        /// </summary>
        Clamav,

        /// <summary>
        /// MD5 hash database.
        /// </summary>
        Md5Hash,

        /// <summary>
        /// SHA1 hash database.
        /// </summary>
        Sha1Hash,

        /// <summary>
        /// SHA256 hash database.
        /// </summary>
        Sha256Hash,

        /// <summary>
        /// Pe section hash database.
        /// </summary>
        PeSectionHash,

        /// <summary>
        /// Unknown database type.
        /// </summary>
        Unknown
    }
}
