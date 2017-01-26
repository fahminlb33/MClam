// 
//     DatabaseFlags.cs  is part of MClam.
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

namespace MClam
{
    /// <summary>
    /// Database load flags.
    /// </summary>
    [Flags]
    public enum DatabaseFlags
    {
        /// <summary>
        /// Load phishing signatures.
        /// </summary>
        Phishing = 2,

        /// <summary>
        /// Initialize the phishing detection module and load .wdb and .pdb files.
        /// </summary>
        PhishingUrls = 8,

        /// <summary>
        /// Load signatures for Potentially Unwanted Applications.
        /// </summary>
        Pua = 16,

        /// <summary>
        /// Only load official signatures from digitally signed databases.
        /// </summary>
        Official = 64,

        /// <summary>
        /// Load bytecode.
        /// </summary>
        Bytecode = 8192,

        /// <summary>
        /// This is a recommended set of database load flags.
        /// </summary>
        Standard = Phishing | PhishingUrls | Bytecode,
    }
}
