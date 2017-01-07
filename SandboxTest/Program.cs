using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SandboxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Stopwatch();
            st.Start();

            var crypt = SHA1.Create();
            using (var file = new FileStream("D:\\bin\\clamav\\libclamav.dll", FileMode.Open))
            {
                var hash = crypt.ComputeHash(file);
                Console.WriteLine(ArrayToHex(hash));
                Console.WriteLine(hash.Length);
                Console.WriteLine(file.Length);
            }

            st.Stop();
            Console.WriteLine("Elapsed: " + st.ElapsedMilliseconds);
            Console.ReadKey();
        }

        private static string ArrayToHex(byte[] input)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
