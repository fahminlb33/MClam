// 
//     SigtoolHasher.cs  is part of MClam.Sigtool.
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
using System.Text;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace MClam.Sigtool
{
    /// <summary>
    /// Provides hash computator.
    /// </summary>
    public sealed class SigtoolHasher : IDisposable
    {
        private readonly HashAlgorithm _hasher;

        #region Constructor
        /// <summary>
        /// Initialize new instance of <see cref="SigtoolHasher"/>.
        /// </summary>
        /// <param name="method">Hash algorithm.</param>
        public SigtoolHasher(HasherAlgorithm method)
        {
            switch (method)
            {
                case HasherAlgorithm.Md5:
                    _hasher = MD5.Create();
                    break;
                case HasherAlgorithm.Sha1:
                    _hasher = SHA1.Create();
                    break;
                case HasherAlgorithm.Sha256:
                    _hasher = SHA256.Create();
                    break;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// Compute hash from specified file.
        /// </summary>
        /// <param name="filePath">Full path to file to be hashed.</param>
        /// <returns><see cref="Tuple{T1,T2}"/> object containing hash string and file length.</returns>
        public Tuple<string, long> HashFile(string filePath)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(filePath), nameof(filePath));
            Contract.Requires<FileNotFoundException>(File.Exists(filePath));

            using (var file = new FileStream(filePath, FileMode.Open))
            {
                var hash = _hasher.ComputeHash(file);
                return new Tuple<string, long>(ArrayToHex(hash), file.Length);
            }
        }
        #endregion

        #region Private Methods
        private static string ArrayToHex(byte[] input)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i].ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion    

        #region IDisposable Support
        private bool _disposedValue; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                _hasher?.Dispose();
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
