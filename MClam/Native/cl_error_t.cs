// 
//     cl_error_t.cs  is part of MClam.
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
    internal enum cl_error_t : int
    {
        CL_CLEAN = 0,
        CL_SUCCESS = 0,
        CL_VIRUS,
        CL_ENULLARG,
        CL_EARG,
        CL_EMALFDB,
        CL_ECVD,
        CL_EVERIFY,
        CL_EUNPACK,
        CL_EOPEN,
        CL_ECREAT,
        CL_EUNLINK,
        CL_ESTAT,
        CL_EREAD,
        CL_ESEEK,
        CL_EWRITE,
        CL_EDUP,
        CL_EACCES,
        CL_ETMPFILE,
        CL_ETMPDIR,
        CL_EMAP,
        CL_EMEM,
        CL_ETIMEOUT,
        CL_BREAK,
        CL_EMAXREC,
        CL_EMAXSIZE,
        CL_EMAXFILES,
        CL_EFORMAT,
        CL_EPARSE,
        CL_EBYTECODE,
        CL_EBYTECODE_TESTFAIL,
        CL_ELOCK,
        CL_EBUSY,
        CL_ESTATE,
        CL_ELAST_ERROR,
    }
}
