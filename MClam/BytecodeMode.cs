using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MClam
{
    /// <summary>
    /// Bytecode mode.
    /// </summary>
    public enum BytecodeMode
    {
        /// <summary>
        /// JIT if possible, fallback to interpreter.
        /// </summary>
        Auto = 0,
        /// <summary>
        /// Force Just-In-Time (JIT).
        /// </summary>
        JustInTime,
        /// <summary>
        /// Force interpreter.
        /// </summary>
        Interpreter,
        /// <summary>
        /// Both JIT and interpreter, compare results, all failures are fatal.
        /// </summary>
        Test,
        /// <summary>
        /// For query only, not settable.
        /// </summary>
        Off,
    }
}
