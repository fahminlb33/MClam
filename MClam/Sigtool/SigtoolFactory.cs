using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using MClam.Native;

namespace MClam.Sigtool
{
    /// <summary>
    /// 
    /// </summary>
    [PermissionSet(SecurityAction.Demand)]
    public static class SigtoolFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IDatabaseFile OpenDatabase(string path)
        {
            switch (GetDatabaseType(path))
            {
                  case DatabaseType.Clamav:
                    return OpenCVD(path);
                    
                default:
                    return null;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static uint CountSignature(string path, CountOption option)
        {
            uint sigs = 0;
            NativeMethods.cl_countsigs(path, (uint)option, ref sigs).ThrowIfError();
            return sigs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool VerifyCVD(string path)
        {
            return NativeMethods.cl_cvdverify(path) == (int)cl_error_t.CL_SUCCESS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DatabaseType GetDatabaseType(string path)
        {
            switch (Path.GetExtension(path))
            {
                case ".cvd":
                    return DatabaseType.Clamav;

                case ".hdb":
                    return DatabaseType.MD5Hash;

                case ".hsb":
                    return DatabaseType.SHAHash;

                case ".mdb":
                    return DatabaseType.PESectionHash;

                default:
                    return DatabaseType.NotDatabase;
            }
        }
        #region Private Methods
        private static MD5HashDatabaseFile OpenMd5HashDatabaseFile(string path)
        {
            throw new NotImplementedException();
        }

        private static ClamavDatabaseFile OpenCVD(string file)
        {
            var cvdPointer = NativeMethods.cl_cvdhead(file);
            if (cvdPointer == IntPtr.Zero) throw new Exception("Malformed CVD header.");
            var data = (cl_cvd)Marshal.PtrToStructure(cvdPointer, typeof(cl_cvd));
            NativeMethods.cl_cvdfree(cvdPointer);

            return new ClamavDatabaseFile(file, data);
        }
        #endregion
    }
}
