using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MClam
{
    [Flags]
    public enum ScanFlags
    {
        Raw = 0,
        Archive = 1,
        Mail = 2,
        Ole2 = 4,
        Blockencrypted = 8,
        Html = 16,
        PE = 32,
        Blockbroken = 64,
        Algorithmic = 512,
        PhishingBlockssl = 2048,
        PhishingBlockcloak = 4096,
        Elf = 8192,
        Pdf = 16384,
        Structured = 32768,
        StructuredSsnNormal = 65536,
        StructuredSsnStripped = 131072,
        PartialMessage = 262144,
        HeuristicPrecedence = 524288,
        BlockMacros = 1048576,
        Swf = 4194304,
        Standard = Archive | Mail | Ole2 | Pdf | Html | PE | Algorithmic | Elf | Swf
    }
}
