// 
//     HashDatabaseWriter.cs  is part of MClam.Sigtool.
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
using System.Diagnostics.Contracts;
using MClam.Shared;

namespace MClam.Sigtool
{
    /// <summary>
    /// Provides hash-based database writer.
    /// </summary>
    public sealed class HashDatabaseWriter : IDisposable
    {
        private DatabaseType _type;
        private readonly StreamWriter _writer;

        #region Constructor
        /// <summary>
        /// Initialize new instance of <see cref="HashDatabaseWriter"/> with specified hash type.
        /// </summary>
        /// <param name="outputPath">Fullpath output directory.</param>
        /// <param name="fileName">Database file name (without extension, the extension will selected automatically).</param>
        /// <param name="type">Hash type.</param>
        /// <param name="append">Specifies that this writer is appending not overwriting.</param>
        public HashDatabaseWriter(string outputPath, string fileName, DatabaseType type, bool append)
        {
            ArgValidate.NotEmptyString(outputPath, nameof(outputPath));
            ArgValidate.DirectoryExist(outputPath, nameof(outputPath));
            ArgValidate.NotEmptyString(fileName, nameof(fileName));
            ArgValidate.FileExist(fileName, nameof(fileName));
            
            var fname = string.Copy(fileName);
            switch (type)
            {
                case DatabaseType.Sha1Hash:
                    fname += ".hsb";
                    break;
                case DatabaseType.Sha256Hash:
                    fname += ".hsb";
                    break;
                case DatabaseType.Md5Hash:
                    fname += ".hdb";
                    break;
                case DatabaseType.PeSectionHash:
                    fname += ".msb";
                    break;
            }

            _type = type;
            _writer = new StreamWriter(Path.Combine(outputPath, fname), append)
            {
                NewLine = "\n"
            };
        }
        #endregion

        #region Properties
        /// <summary>
        /// Database hash type.
        /// </summary>
        public DatabaseType Type => _type;
        #endregion

        #region Public Methods
        /// <summary>
        /// Write specified entry to database.
        /// </summary>
        /// <param name="entry">Entry to be added.</param>
        public void Write(HashDatabaseEntry entry)
        {
            ArgValidate.NotNull(entry, nameof(entry));

            if (_type == DatabaseType.Md5Hash || _type == DatabaseType.Sha1Hash || _type == DatabaseType.Sha256Hash)
                WriteFileHashEntry(entry);
            else
                WritePeHashEntry(entry);
        }

        /// <summary>
        /// Write specified entry to database.
        /// </summary>
        /// <param name="hash">File hash (same as database hash type).</param>
        /// <param name="size">Hash size (-1 to use variable size).</param>
        /// <param name="name">Malware name.</param>
        public void Write(string hash, int size, string name)
        {
            ArgValidate.NotEmptyString(hash, nameof(hash));
            ArgValidate.NotEmptyString(name, nameof(name));
            if (!(size == -1 || size > 0))
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            Write(new HashDatabaseEntry
            {
                Hash = hash,
                MalwareName = name,
                Size = size
            });
        }
        #endregion

        #region Private Methods
        private void WriteFileHashEntry(HashDatabaseEntry entry)
        {
            string data;
            if (entry.Size == -1) data = $"{entry.Hash}:*:{entry.MalwareName}:73";
            else data = $"{entry.Hash}:{entry.Size}:{entry.MalwareName}";

            _writer.WriteLine(data);
        }

        private void WritePeHashEntry(HashDatabaseEntry entry)
        {
            string data;
            if (entry.Size == -1) data = $"*:{entry.Hash}:{entry.MalwareName}:73";
            else data = $"{entry.Size}:{entry.Hash}:{entry.MalwareName}";

            _writer.WriteLine(data);
        }
        #endregion

        #region IDisposable Support
        private bool _disposedValue; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                _writer?.Dispose();
            }

            _disposedValue = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
