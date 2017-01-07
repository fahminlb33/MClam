using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// ReSharper disable InconsistentNaming

namespace MClam.Sigtool
{
    /// <summary>
    /// Hash algorithm.
    /// </summary>
    public enum Algorithm
    {
        /// <summary>
        /// Message Diggest 5.
        /// </summary>
        MD5,

        /// <summary>
        /// Secure Hash Algorithm.
        /// </summary>
        SHA1,

        /// <summary>
        /// Secure Hash Algorithm 256-bits.
        /// </summary>
        SHA256,
    }
}
