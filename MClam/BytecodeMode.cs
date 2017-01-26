// 
//     BytecodeMode.cs  is part of MClam.
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
