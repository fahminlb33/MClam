using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MClam.Native;

namespace MClam.Sigtool
{
    /// <summary>
    /// Represent a CVD file.
    /// </summary>
    public sealed class ClamavDatabaseFile : IDatabaseFile
    {
        private cl_cvd _data;
        private string _filePath;

        #region Constructor
        internal ClamavDatabaseFile(string file, cl_cvd data)
        {
            _filePath = file;
            _data = data;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets full path to this database file.
        /// </summary>
        public string FullPath => _filePath;

        /// <summary>
        /// Gets date when this CVD is built (if current instance is CVD).
        /// </summary>
        public string BuildTime => _data.time;

        /// <summary>
        /// Gets current CVD version (if current instance is CVD).
        /// </summary>
        public uint Version => _data.version;

        /// <summary>
        /// Gets number of signatures included in this CVD (if current instance is CVD).
        /// </summary>
        public uint Signatures => _data.sigs;

        /// <summary>
        /// Gets CVD functionality level (if current instance is CVD).
        /// </summary>
        public uint FunctionalityLevel => _data.fl;

        /// <summary>
        /// Gets who built this CVD (if current instance is CVD).
        /// </summary>
        public string Builder => _data.builder;

        /// <summary>
        /// Gets MD5 checksum of this CVD (if current instance is CVD).
        /// </summary>
        public string MD5Checksum => _data.md5;

        /// <summary>
        /// Gets digital signature of this CVD (if current instance is CVD).
        /// </summary>
        public string DigitalSignature => _data.dsig;
        #endregion


    }
}
