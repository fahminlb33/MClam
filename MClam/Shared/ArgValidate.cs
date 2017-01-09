using System;
using System.IO;

namespace MClam.Shared
{
    internal static class ArgValidate
    {
        internal static void NotNull(object obj, string paramName)
        {
            if (obj == null) throw new ArgumentNullException(paramName);
        }

        internal static void NotEmptyString(string s, string paramName)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new ArgumentNullException(paramName);
        }

        internal static void FileExist(string path, string paramName)
        {
            if (!File.Exists(path)) throw new ArgumentException("File not found!", paramName);
        }

        internal static void DirectoryExist(string path, string paramName)
        {
            if (!Directory.Exists(path)) throw new ArgumentException("Directory not found!", paramName);
        }

        internal static void IsInRange(int value, int min, int max, string paramName)
        {
            if (min >= value || value <= max)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

    }
}
