// 
//     NativeMethods.cs  is part of MClam.
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
using System.Runtime.InteropServices;

namespace MClam.Native
{
    internal class NativeMethods
    {
        private const string LibclamavName = "libclamav.dll";
        private const string MsvcrtName = "msvcr100.dll";

        #region MSVCRT
        [DllImport(MsvcrtName, EntryPoint = "_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern int close(int _FileHandle);

        [DllImport(MsvcrtName, EntryPoint = "_wopen", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern int wopen([In, MarshalAs(UnmanagedType.LPWStr)] string _Filename, int _OpenFlag, int _PermissionMode);
        #endregion
        
        #region libclamav
        // ----- Scan methods ----------------------------------------------
        [DllImport(LibclamavName, EntryPoint = "cl_scandesc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int cl_scandesc(int desc, ref IntPtr virname, ref int scanned, IntPtr engine, uint scanoptions);


        // ----- Engine methods --------------------------------------------
        [DllImport(LibclamavName, EntryPoint = "cl_engine_new", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cl_engine_new();

        [DllImport(LibclamavName, EntryPoint = "cl_engine_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern int cl_engine_free(IntPtr engine);

        [DllImport(LibclamavName, EntryPoint = "cl_engine_compile", CallingConvention = CallingConvention.Cdecl)]
        public static extern int cl_engine_compile(IntPtr engine);


        // ----- Engine field methods ---------------------------------------
        [DllImport(LibclamavName, EntryPoint = "cl_engine_set_num", CallingConvention = CallingConvention.Cdecl)]
        public static extern int cl_engine_set_num(IntPtr engine, EngineField field, long num);

        [DllImport(LibclamavName, EntryPoint = "cl_engine_get_num", CallingConvention = CallingConvention.Cdecl)]
        public static extern long cl_engine_get_num(IntPtr engine, EngineField field, ref int err);

        [DllImport(LibclamavName, EntryPoint = "cl_engine_set_str", CallingConvention = CallingConvention.Cdecl)]
        public static extern int cl_engine_set_str(IntPtr engine, EngineField field, IntPtr str);

        [DllImport(LibclamavName, EntryPoint = "cl_engine_get_str", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cl_engine_get_str(IntPtr engine, EngineField field, ref int err);


        // ----- CVD methods ------------------------------------------------
        [DllImport(LibclamavName, EntryPoint = "cl_cvdhead", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cl_cvdhead([In, MarshalAs(UnmanagedType.LPStr)] string file);

        [DllImport(LibclamavName, EntryPoint = "cl_cvdparse", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cl_cvdparse([In, MarshalAs(UnmanagedType.LPStr)] string head);

        [DllImport(LibclamavName, EntryPoint = "cl_cvdverify", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cl_cvdverify([In, MarshalAs(UnmanagedType.LPStr)] string file);

        [DllImport(LibclamavName, EntryPoint = "cl_cvdfree", CallingConvention = CallingConvention.Cdecl)]
        public static extern void cl_cvdfree(IntPtr cvd);


        // ----- Database methods -------------------------------------------
        [DllImport(LibclamavName, EntryPoint = "cl_load", CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
        public static extern int cl_load([In, MarshalAs(UnmanagedType.LPStr)] string path, IntPtr engine, ref uint signo, uint dboptions);

        [DllImport(LibclamavName, EntryPoint = "cl_countsigs", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cl_countsigs([In, MarshalAs(UnmanagedType.LPStr)] string path, uint countoptions, ref uint sigs);

        [DllImport(LibclamavName, EntryPoint = "cl_retdbdir", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cl_retdbdir();


        // ----- Database Stats ---------------------------------------------
        [DllImport(LibclamavName, EntryPoint = "cl_statinidir", CallingConvention = CallingConvention.Cdecl)]
        public static extern int cl_statinidir([In, MarshalAs(UnmanagedType.LPStr)] string dirname, IntPtr dbstat);
        
        [DllImport(LibclamavName, EntryPoint = "cl_statchkdir", CallingConvention = CallingConvention.Cdecl)]
        public static extern int cl_statchkdir(IntPtr dbstat);
        
        [DllImport(LibclamavName, EntryPoint = "cl_statfree", CallingConvention = CallingConvention.Cdecl)]
        public static extern int cl_statfree(IntPtr dbstat);


        // ----- Other methods ----------------------------------------------
        [DllImport(LibclamavName, EntryPoint = "cl_init", CallingConvention = CallingConvention.Cdecl)]
        public static extern int cl_init(uint initoptions);
        
        [DllImport(LibclamavName, EntryPoint = "cl_strerror", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cl_strerror(int clerror);

        [DllImport(LibclamavName, EntryPoint = "cl_retver")]
        public static extern IntPtr cl_retver();
        #endregion
    }
}
