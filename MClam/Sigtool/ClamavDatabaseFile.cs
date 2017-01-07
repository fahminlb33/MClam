using MClam.Native;

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
            FullPath = file;
            _data = data;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets full path to this database file.
        /// </summary>
        public string FullPath { get; }

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
