using System;

namespace MClam
{
    /// <summary>
    /// Database load flags.
    /// </summary>
    [Flags]
    public enum DatabaseFlags
    {
        /// <summary>
        /// Load phishing signatures.
        /// </summary>
        Phishing = 2,

        /// <summary>
        /// Initialize the phishing detection module and load .wdb and .pdb files.
        /// </summary>
        PhishingUrls = 8,

        /// <summary>
        /// Load signatures for Potentially Unwanted Applications.
        /// </summary>
        Pua = 16,

        /// <summary>
        /// Only load official signatures from digitally signed databases.
        /// </summary>
        Official = 64,

        /// <summary>
        /// Load bytecode.
        /// </summary>
        Bytecode = 8192,

        /// <summary>
        /// This is a recommended set of database load flags.
        /// </summary>
        Standard = Phishing | PhishingUrls | Bytecode,
    }
}
