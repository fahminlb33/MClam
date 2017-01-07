using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MClam
{
    /// <summary>
    /// Engine settings fields.
    /// </summary>
    public enum EngineField
    {
        /// <summary>
        /// <c>UInt64</c> length. Numerical type.
        /// </summary>
        MaxScansize,
        /// <summary>
        /// <c>UInt64</c> length. Numerical type.
        /// </summary>
        MaxFilesize,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        MaxRecursion,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        MaxFiles,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        MinCcCount,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        MinSsnCount,
        /// <summary>
        /// String type.
        /// </summary>
        PuaCategories,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        DbOptions,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        DbVersion,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        DbTime,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        AcOnly,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        AcMindepth,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        AcMaxdepth,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        Tmpdir,
        /// <summary>
        /// String type.
        /// </summary>
        Keeptmp,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type. Use <see cref="MClam.BytecodeSecurity"/> enumeration
        /// to fill the value.
        /// </summary>
        BytecodeSecurity,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        BytecodeTimeout,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type. Use <see cref="MClam.BytecodeMode"/> enumeration
        /// to fill the value.
        /// </summary>
        BytecodeMode,
        /// <summary>
        /// <c>UInt64</c> length. Numerical type.
        /// </summary>
        MaxEmbeddedpe,
        /// <summary>
        /// <c>UInt64</c> length. Numerical type.
        /// </summary>
        MaxHtmlnormalize,
        /// <summary>
        /// <c>UInt64</c> length. Numerical type.
        /// </summary>
        MaxHtmlnotags,
        /// <summary>
        /// <c>UInt64</c> length. Numerical type.
        /// </summary>
        MaxScriptNormalize,
        /// <summary>
        /// <c>UInt64</c> length. Numerical type.
        /// </summary>
        MaxZiptypercg,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        Forcetodisk,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        DisableCache,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        DisablePeStats,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        StatsTimeout,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        MaxPartitions,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        MaxIconspe,
        /// <summary>
        /// <c>UInt32</c> length. Numerical type.
        /// </summary>
        TimeLimit,
        /// <summary>
        /// <c>UInt64</c> length. Numerical type.
        /// </summary>
        PcreMatchLimit,
        /// <summary>
        /// <c>UInt64</c> length. Numerical type.
        /// </summary>
        PcreRecmatchLimit,
        /// <summary>
        /// <c>UInt64</c> length. Numerical type.
        /// </summary>
        PcreMaxFilesize,
    }
}
