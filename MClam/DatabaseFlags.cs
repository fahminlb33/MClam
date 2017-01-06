using System;

namespace MClam
{
    [Flags]
    public enum DatabaseFlags
    {
        Phishing = 2,
        PhishingUrls = 8,
        Pua = 16,
        Cvdnotmp = 32,
        Official = 64,
        PuaMode = 128,
        PuaInclude = 256,
        PuaExclude = 512,
        Compiled = 1024,
        Directory = 2048,
        OfficialOnly = 4096,
        Bytecode = 8192,
        Signed = 16384,
        BytecodeUnsigned = 32768,
        Unsigned = 65536,
        BytecodeStats = 131072,
        Enhanced = 262144,
        PcreStats = 524288,
        YaraExclude = 1048576,
        YaraOnly = 2097152,
        Standard = Phishing | PhishingUrls | Bytecode,
    }
}
