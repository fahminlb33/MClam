using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MClam.Native
{
    internal class NativeConstants
    {
        // ----- ClamAV constants ----------------------------------------
        public const int CL_COUNT_PRECISION = 4096;
        public const int CL_INIT_DEFAULT = 0;

        // ----- MSVCRT constants ----------------------------------------
        public const int _O_RDONLY = 0;
        public const int _S_IREAD = 256;
    }
}
