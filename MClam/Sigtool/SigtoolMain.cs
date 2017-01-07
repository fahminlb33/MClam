using System;
using System.IO;
using System.Security.Permissions;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using MClam.Native;

namespace MClam.Sigtool
{
    /// <summary>
    /// Clamav Signature Tool (sigtool) implementations.
    /// </summary>
    [PermissionSet(SecurityAction.Demand)]
    public static class SigtoolMain
    {
        private const string ErrorMalformed = "Malformed CVD header.";


        /// <summary>
        /// Count signature on database file.
        /// </summary>
        /// <param name="filePath">Full path to database file.</param>
        /// <param name="option">Database count option.</param>
        /// <returns>Number of signature contained on specified database.</returns>
        public static uint CountSignature(string filePath, CountOption option)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(filePath), nameof(filePath));
            Contract.Requires<FileNotFoundException>(File.Exists(filePath), nameof(filePath));

            uint sigs = 0;
            NativeMethods.cl_countsigs(filePath, (uint)option, ref sigs).ThrowIfError();
            return sigs;
        }

        /// <summary>
        /// Verifies Clamav Database File (CVD).
        /// </summary>
        /// <param name="filePath">Full path to CVD file.</param>
        /// <returns><see cref="bool"/> value indicating verified status of specified database file.</returns>
        public static bool VerifyCvd(string filePath)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(filePath), nameof(filePath));
            Contract.Requires<FileNotFoundException>(File.Exists(filePath), nameof(filePath));

            return NativeMethods.cl_cvdverify(filePath) == (int)cl_error_t.CL_SUCCESS;
        }

        /// <summary>
        /// Gets Clamav Database File metadata informations.
        /// </summary>
        /// <param name="filePath">Full path to CVD file.</param>
        /// <returns><see cref="ClamavDatabaseFile"/> object which contains specified database informations.</returns>
        public static ClamavDatabaseFile GetCvdMetadata(string filePath)
        {
            Contract.Requires<Exception>(VerifyCvd(filePath), ErrorMalformed);

            var cvdPointer = NativeMethods.cl_cvdhead(filePath);
            if (cvdPointer == IntPtr.Zero) throw new Exception(ErrorMalformed);

            var data = (cl_cvd)Marshal.PtrToStructure(cvdPointer, typeof(cl_cvd));
            NativeMethods.cl_cvdfree(cvdPointer);

            return new ClamavDatabaseFile(filePath, data);
        }

        /// <summary>
        /// Gets database type based on file extension.
        /// </summary>
        /// <param name="filePath">Full path to database file.</param>
        /// <returns><see cref="DatabaseType"/> represents specified database file type.</returns>
        public static DatabaseType GetDatabaseType(string filePath)
        {
            switch (Path.GetExtension(filePath))
            {
                case ".cvd":
                    return DatabaseType.Clamav;

                case ".hdb":
                    return DatabaseType.Md5Hash;

                case ".hsb":
                    return DatabaseType.ShaHash;

                case ".msb":
                    return DatabaseType.PeSectionHash;

                default:
                    return DatabaseType.Unknown;
            }
        }

    }
}
