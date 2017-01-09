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
