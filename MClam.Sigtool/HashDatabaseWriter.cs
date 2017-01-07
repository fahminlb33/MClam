using System;
using System.IO;
using System.Diagnostics.Contracts;

namespace MClam.Sigtool
{
    /// <summary>
    /// Provides hash-based database writer.
    /// </summary>
    public sealed class HashDatabaseWriter : IDisposable
    {
        private DatabaseType _type;
        private readonly StreamWriter _writer;

        /// <summary>
        /// Database hash type.
        /// </summary>
        public DatabaseType Type => _type;

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
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(outputPath), nameof(outputPath));
            Contract.Requires<DirectoryNotFoundException>(!Directory.Exists(outputPath));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(fileName), nameof(fileName));
            Contract.Requires<ArgumentOutOfRangeException>(SigtoolHelper.IsHashDatabase(type), nameof(fileName));
            
            var fname = string.Copy(fileName);
            switch (type)
            {
                case DatabaseType.ShaHash:
                    fname += ".hsb";
                    break;
                case DatabaseType.Md5Hash:
                    fname += ".hdb";
                    break;
                case DatabaseType.PeSectionHash:
                    fname += ".msb";
                    break;
            }

            _writer = new StreamWriter(Path.Combine(outputPath, fname), append);
            _writer.NewLine = "\n";
            _type = type;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Write specified entry to database.
        /// </summary>
        /// <param name="entry">Entry to be added.</param>
        public void Write(HashDatabaseEntry entry)
        {
            Contract.Requires<ArgumentNullException>(entry != null, nameof(entry));

            if (_type == DatabaseType.Md5Hash || _type == DatabaseType.ShaHash)
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
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(hash), nameof(hash));
            Contract.Requires<ArgumentOutOfRangeException>(size == -1 || size > 0, nameof(size));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(name), nameof(name));

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
