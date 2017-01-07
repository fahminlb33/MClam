using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MClam.Sigtool
{
    internal static class SigtoolHelper
    {
        public static bool IsHashDatabase(DatabaseType type)
        {
            return type == DatabaseType.Md5Hash ||
                   type == DatabaseType.ShaHash ||
                   type == DatabaseType.PeSectionHash;
        }
    }
}
