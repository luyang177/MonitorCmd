using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * config.txt:
 * - 1st line: process name
 * - 2nd line: window title name
 * - 3rd line: restart path
 */

namespace MonitorCmd
{
    class Program
    {
        private static int IntervalInSecond = 10;

        static void Main(string[] args)
        {
            var confLines = File.ReadAllLines("config.txt");

            var confName = confLines[0];
            var confTitle = confLines[1];
            var confRunPath = confLines[2];

            while(true)
            {
                var processList = Process.GetProcesses().ToList();
                var findProc = processList.FirstOrDefault(p => p.ProcessName == confName && p.MainWindowTitle.StartsWith(confTitle));
                if (findProc == null)
                {
                    Console.WriteLine("Start" + DateTime.Now + confRunPath);
                    Process.Start(confRunPath);
                }

                Thread.Sleep(IntervalInSecond * 1000);
            }
        }
    }
}
