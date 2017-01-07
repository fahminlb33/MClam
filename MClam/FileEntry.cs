using System;
using System.IO;
using MClam.Native;

namespace MClam
{
    /// <summary>
    /// Represent a file to scan.
    /// </summary>
    public sealed class FileEntry : IDisposable
    {
        private readonly int _fileDesc;
        private readonly string _filePath;

        #region Constructor
        private FileEntry(string path)
        {
            _fileDesc = NativeMethods.wopen(path, NativeConstants._O_RDONLY, NativeConstants._S_IREAD);
            _filePath = path;
        }
        #endregion

        #region Helper Methods
        /// <summary>
        ///  Initialize new instance of <see cref="FileEntry"/>.
        /// </summary>
        /// <param name="filePath">Fullpath to file.</param>
        /// <returns><see cref="FileEntry"/> object from specified file.</returns>
        public static FileEntry Open(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException();

            return new FileEntry(filePath);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns if this file entry is valid for use.
        /// </summary>
        public bool IsValid => _fileDesc != -1;

        /// <summary>
        /// Fullpath to this file entry.
        /// </summary>
        public string FilePath => _filePath;

        /// <summary>
        /// Opened file descriptor.
        /// </summary>
        public int FileDescriptor => _fileDesc;
        #endregion

        #region IDisposable Support
        private bool _disposedValue;
        
        void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
               
            }

            // release file
            if (IsValid) NativeMethods.close(_fileDesc);

            _disposedValue = true;
        }

        /// <summary>
        /// Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
        /// </summary>
        ~FileEntry()
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
