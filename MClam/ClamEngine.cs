using System;
using System.IO;
using System.Diagnostics.Contracts;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using MClam.Native;

namespace MClam
{
    /// <summary>
    /// ClamAV engine wrapper.
    /// </summary>
    [PermissionSet(SecurityAction.Demand)]
    public class ClamEngine : IDisposable
    {
        private HandleRef _handle;
        private bool _compiled;
        private uint _signatureCount;

        private const string ErrorDatabaseNotLoaded = "Database is not loaded.";
        private const string ErrorEngineComplied = "Engine is already compiled.";
        private const string ErrorEngineNotCompiled = "Engine is not compiled.";

        #region Constructor
        /// <summary>
        /// Initialize new instance of <see cref="ClamEngine"/>.
        /// </summary>
        public ClamEngine()
        {
            _handle = new HandleRef(this, NativeMethods.cl_engine_new());
        }
        #endregion

        #region Properties
        /// <summary>
        /// File scan options.
        /// </summary>
        public ScanFlags Flags { get; set; } = ScanFlags.Standard;

        /// <summary>
        /// Gets loaded signature count.
        /// </summary>
        public uint LoadedSignatures => _signatureCount;

        /// <summary>
        /// Gets a value indicating current engine instance is loaded by database.
        /// </summary>
        public bool IsLoaded => _signatureCount > 0;

        /// <summary>
        ///  Gets a value indicating current engine instance is ready for scanning.
        /// </summary>
        public bool IsCompiled => _compiled;
        #endregion

        #region Methods
        /// <summary>
        /// Load a single database file or a directory with database inside to current instance of <see cref="ClamEngine"/>.
        /// </summary>
        /// <param name="path">Fullpath to a file or directory containing the database file(s).</param>
        /// <param name="flags">Database loading options (default <see cref="DatabaseFlags.Standard"/>.</param>
        public void Load(string path, DatabaseFlags flags = DatabaseFlags.Standard)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(path), nameof(path));
            Contract.Requires<InvalidOperationException>(!IsCompiled, ErrorEngineComplied);

            NativeMethods.cl_load(path, _handle.Handle, ref _signatureCount, (uint)flags).ThrowIfError();
        }

        /// <summary>
        /// Compiles current engine instance for scanning purposes.
        /// </summary>
        public void Compile()
        {
            Contract.Requires<InvalidOperationException>(IsLoaded, ErrorDatabaseNotLoaded);
            Contract.Requires<InvalidOperationException>(!IsCompiled, ErrorEngineComplied);

            NativeMethods.cl_engine_compile(_handle.Handle).ThrowIfError();
            _compiled = true;
        }

        /// <summary>
        /// Scans a file for viruses.
        /// </summary>
        /// <param name="path">Full path to file to be scanned.</param>
        /// <returns><see cref="ScanResult"/> object containing scan information.</returns>
        public ScanResult ScanFile(string path)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(path), nameof(path));
            Contract.Requires<FileNotFoundException>(File.Exists(path));

            return ScanFile(FileEntry.Open(path));
        }

        /// <summary>
        /// Scans a file for viruses.
        /// </summary>
        /// <param name="file">File to be scanned.</param>
        /// <returns><see cref="ScanResult"/> object containing scan information.</returns>
        public ScanResult ScanFile(FileEntry file)
        {
            Contract.Requires<ArgumentNullException>(file != null, nameof(file));
            Contract.Requires<InvalidOperationException>(IsCompiled, ErrorEngineNotCompiled);

            var fscaned = 0;
            var vname = IntPtr.Zero;
            int retv;
            ScanResult result;
            
            retv = NativeMethods.cl_scandesc(file.FileDescriptor, ref vname, ref fscaned, _handle.Handle, (uint)Flags);
            result = new ScanResult
            {
                FullPath = file.FilePath,
                Scanned = fscaned,
            };

            switch (retv)
            {
                case (int) cl_error_t.CL_VIRUS:
                    result.IsVirus = true;
                    result.MalwareName = Marshal.PtrToStringAnsi(vname);
                    break;

                case (int) cl_error_t.CL_CLEAN:
                    result.IsVirus = false;
                    break;

                default:
                    throw new ClamException(retv);
            }

            return result;
        }
        #endregion

        #region IDisposable Support
        private bool _disposedValue;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Dispose managed objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            NativeMethods.cl_engine_free(_handle.Handle);

            _disposedValue = true;
        }

        /// <summary>
        /// Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
        /// </summary>
        ~ClamEngine()
        {
            Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
