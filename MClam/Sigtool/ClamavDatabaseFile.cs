// 
//     ClamavDatabaseFile.cs  is part of MClam.
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
using MClam.Native;
using MClam.Shared;

namespace MClam.Sigtool
{
    /// <summary>
    /// CVD file metadata.
    /// </summary>
    public sealed class ClamavDatabaseFile
    {
        private cl_cvd _data;

        #region Constructor
        internal ClamavDatabaseFile(string file, cl_cvd data)
        {
            ArgValidate.NotNull(data, nameof(data));
            ArgValidate.NotNull(file, nameof(file));
            ArgValidate.FileExist(file, nameof(file));

            FullPath = file;
            _data = data;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets full path to this database file.
        /// </summary>
        public string FullPath { get; private set; }

        /// <summary>
        /// Gets date when this CVD is built.
        /// </summary>
        public string BuildTime => _data.time;

        /// <summary>
        /// Gets current CVD version.
        /// </summary>
        public uint Version => _data.version;

        /// <summary>
        /// Gets number of signatures included in this CVD.
        /// </summary>
        public uint Signatures => _data.sigs;

        /// <summary>
        /// Gets CVD functionality level.
        /// </summary>
        public uint FunctionalityLevel => _data.fl;

        /// <summary>
        /// Gets who built this CVD.
        /// </summary>
        public string Builder => _data.builder;

        /// <summary>
        /// Gets MD5 checksum of this CVD.
        /// </summary>
        public string Checksum => _data.md5;

        /// <summary>
        /// Gets digital signature of this CVD.
        /// </summary>
        public string DigitalSignature => _data.dsig;
        #endregion
    }
}
