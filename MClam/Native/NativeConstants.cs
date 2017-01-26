// 
//     NativeConstants.cs  is part of MClam.
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
namespace MClam.Native
{
    internal class NativeConstants
    {
        // ----- ClamAV constants ----------------------------------------
        public const int CL_COUNT_PRECISION = 4096;
        public const int CL_INIT_DEFAULT = 0;

        // ----- MSVCRT constants ----------------------------------------
        public const int _O_RDONLY = 0;
        public const int _S_IREAD = 256;
    }
}
