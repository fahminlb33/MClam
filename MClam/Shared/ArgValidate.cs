using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MClam.Shared
{
    internal static class ArgValidate
    {
        public static void NotNull(object obj, string paramName)
        {
            if (obj == null) throw new ArgumentNullException(paramName);
        }

        public static void NotEmptyString(string s, string paramName)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new ArgumentNullException(paramName);
        }

        public static void FileExist(string path, string paramName)
        {
            if (!File.Exists(path)) throw new ArgumentException("File not found!", paramName);
        }

        public static void DirectoryExist(string path, string paramName)
        {
            if (!Directory.Exists(path)) throw new ArgumentException("Directory not found!", paramName);
        }
    }
}
