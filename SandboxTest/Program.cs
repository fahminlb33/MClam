// 
//     Program.cs  is part of SandboxTest.
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MClam;

namespace SandboxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Stopwatch();
            st.Start();

            Console.WriteLine("Capturing...");
            ClamMain.Initialize();

            var dataChecker = new DatabaseStateChecker(@"D:\bin\database\test");
            dataChecker.CaptureState();

            Console.WriteLine("Do changes.");
            Console.ReadKey();

            Console.WriteLine("Changes detected: " + dataChecker.HasChanges());

            Console.WriteLine("Release.");
            dataChecker.ReleaseCapture();

            st.Stop();
            Console.WriteLine("Elapsed: " + st.ElapsedMilliseconds);
            Console.ReadKey();
        }

    }
}
