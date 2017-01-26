// 
//     ClamException.cs  is part of MClam.
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
using MClam.Shared;

namespace MClam
{
    /// <summary>
    /// Exception class for errors from libclamav native.
    /// </summary>
    /// <remarks><para>This class gets the error messages from libclamav using error codes by invoking P/Invoke to libclamav.
    /// This class should not be thrown outside by <c>MClam</c> internals.</para>
    /// <para>See <c>The ClamException and other Exceptions.</c> topic on the <c>Cheatsheet.</c></para>
    /// </remarks>
    public sealed class ClamException : Exception
    {
        internal ClamException(int errorCode) : base(Commons.GetClamErrorText(errorCode))
        { }
    }
}
