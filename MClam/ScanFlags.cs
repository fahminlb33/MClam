// 
//     ScanFlags.cs  is part of MClam.
//     Copyright (C) 2017  Fahmi Noor Fiqri
// 
//     This program is free software; you can redistribute it and/or
//     modify it under the terms of the GNU General Public License
//     as published by the Free Software Foundation; either version 2
//     of the License, or (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program; if not, write to the Free Software
//     Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
using System;

namespace MClam
{
    /// <summary>
    /// File scan flags.
    /// </summary>
    [Flags]
    public enum ScanFlags
    {
        /// <summary>
        /// Use it alone if you want to disable support for special files.
        /// </summary>
        Raw = 0,

        /// <summary>
        /// Enables transparent scanning of various archive formats.
        /// </summary>
        Archive = 1,

        /// <summary>
        /// Enable support for mail files.
        /// </summary>
        Mail = 2,

        /// <summary>
        /// Enables support for OLE2 containers (used by MS Office and .msi files).
        /// </summary>
        Ole2 = 4,

        /// <summary>
        /// The library will mark encrypted archives as viruses (Encrypted.Zip, Encrypted.RAR).
        /// </summary>
        Blockencrypted = 8,

        /// <summary>
        /// This flag enables HTML normalisation (including ScrEnc decryption).
        /// </summary>
        Html = 16,

        /// <summary>
        /// Enables deep scanning of Portable Executable files and allows engine to unpack executables compressed with run-time unpackers.
        /// </summary>
        Pe = 32,

        /// <summary>
        /// Engine will try to detect broken executables and mark them as Broken.Executable.
        /// </summary>
        Blockbroken = 64,

        /// <summary>
        /// Enable algorithmic detection of viruses.
        /// </summary>
        Algorithmic = 512,

        /// <summary>
        /// Phishing module: always block SSL mismatches in URLs.
        /// </summary>
        PhishingBlockssl = 2048,

        /// <summary>
        /// Phishing module: always block cloaked URLs.
        /// </summary>
        PhishingBlockcloak = 4096,

        /// <summary>
        /// Enable support for ELF files.
        /// </summary>
        Elf = 8192,

        /// <summary>
        /// Enables scanning within PDF files.
        /// </summary>
        Pdf = 16384,

        /// <summary>
        /// Enable the DLP module which scans for credit card and SSN numbers.
        /// </summary>
        Structured = 32768,

        /// <summary>
        /// Search for SSNs formatted as xx-yy-zzzz.
        /// </summary>
        StructuredSsnNormal = 65536,

        /// <summary>
        /// Search for SSNs formatted as xxyyzzzz.
        /// </summary>
        StructuredSsnStripped = 131072,

        /// <summary>
        /// Scan RFC1341 messages split over many emails.
        /// </summary>
        /// <remarks>You will need to periodically clean up %temp%\clamav-partial directory.</remarks>
        PartialMessage = 262144,

        /// <summary>
        /// Allow heuristic match to take precedence.
        /// </summary>
        /// <remarks>When enabled, if a heuristic scan (such as phishingScan) detects 
        /// a possible virus/phish it will stop scan immediately. Recommended, saves
        /// CPU scan-time. When disabled, virus/phish detected by heuristic scans will 
        /// be reported only at the end of a scan. If an archive contains both a
        /// heuristically detected  virus/phishing, and a real malware, the real malware
        /// will be reported.</remarks>
        HeuristicPrecedence = 524288,

        /// <summary>
        /// OLE2 containers, which contain VBA macros will be marked infected 
        /// (Heuristics.OLE2.ContainsMacros).
        /// </summary>
        BlockMacros = 1048576,

        /// <summary>
        /// Enables scanning within SWF files, notably compressed SWF.
        /// </summary>
        Swf = 4194304,

        /// <summary>
        /// This is a recommended set of scan flags.
        /// </summary>
        Standard = Archive | Mail | Ole2 | Pdf | Html | Pe | Algorithmic | Elf | Swf
    }
}
