// 
//     Program.cs  is part of FileScanExample.
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using MClam;

namespace FileScanExample
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintWelcomeMessage();

            // get file path
            Console.WriteLine("1. Enter file path to scan.");
            var scanPath = GetFilePath();
            Console.WriteLine();

            // get database path
            Console.WriteLine("1. Enter database file path.");
            var databasePath = GetFilePath();
            Console.WriteLine();

            // check paths
            if (!File.Exists(scanPath) || !File.Exists(databasePath))
            {
                Console.WriteLine("Scan path or database path is not exist! Exiting...");
                PrintExitMessage();
            }

            // do scan
            try
            {
                // initialize libclamav
                PrintLog("Initializing libclamav...");
                ClamMain.Initialize();
                PrintLog("libclamav initialized.");

                // create new engine
                PrintLog("Creating new engine instance...");
                using (var engine = ClamMain.CreateEngine())
                {
                    PrintLog("Engine instance is created.");

                    // load database
                    PrintLog("Loading database...");
                    engine.Load(databasePath);
                    PrintLog("Database loaded.");

                    // compile engine
                    PrintLog("Compiling engine...");
                    engine.Compile();
                    PrintLog("Engine compiled.");

                    // scan the file
                    PrintLog("Scanning file...");
                    var result = engine.ScanFile(scanPath);
                    PrintLog("SCAN FINISHED.");
                    Console.WriteLine("Scanned:      " + result.Scanned);
                    Console.WriteLine("IsVirus:      " + result.IsVirus);
                    Console.WriteLine("MalwareName:  " + result.IsVirus);
                    
                    PrintLog("Releasing engine...");
                }
                PrintLog("Engine released.");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                CenterText("-----EXCEPTION CAUGHT-----");
                Console.WriteLine(ex.ToString());
            }

            // exit
            Console.WriteLine();
            Console.WriteLine();
            PrintExitMessage();
        }

        static void PrintWelcomeMessage()
        {
            CenterText(@" __  __  _____ _                 ");
            CenterText(@"|  \/  |/ ____| |                ");
            CenterText(@"| \  / | |    | | __ _ _ __ ___  ");
            CenterText(@"| |\/| | |    | |/ _` | '_ ` _ \ ");
            CenterText(@"| |  | | |____| | (_| | | | | | |");
            CenterText(@"|_|  |_|\_____|_|\__,_|_| |_| |_|");
            Console.WriteLine();
            CenterText(@"          FileScanExample         ");
            Console.WriteLine();
            CenterText(@"This example demonstrate how to do");
            CenterText(@"file scanning using MClam library.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void PrintExitMessage()
        {
            Console.Write("Press anykey to exit...");
            Console.Read();
            Environment.Exit(0);
        }

        static void PrintLog(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToShortTimeString()}   {message}");
        }

        static string GetFilePath()
        {
            Console.WriteLine();
            Console.Write("   File path: ");
            var path = Console.ReadLine();
            Console.WriteLine();
            return path;
        }

        static void CenterText(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

    }
}
