using System;

namespace MClam
{
    /// <summary>
    /// Bytecode security trust.
    /// </summary>
    public enum BytecodeSecurity
    {
        /// <summary>
        /// Trust all bytecode.
        /// </summary>
        [Obsolete]
        TrustAll = 0,
        /// <summary>
        /// Trust only signaed bytecode. Default.
        /// </summary>
        TrustSigned,
        /// <summary>
        /// Never trust bytecode.
        /// </summary>
        TrustNothing,
    }
}
