using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var process = Process.Start(@"C:\Projects\Ray\GitHub\Docs\PerfView\ConsoleApp1\TargetConsole\bin\Debug\TargetConsole.exe");
            Thread.Sleep(1000);
            using (var target = DataTarget.AttachToProcess(process.Id, 10000))
            {
                var clr = target.ClrVersions[0].CreateRuntime();
                var heap = clr.Heap;
                var module = clr.Modules;
                foreach(var obj in heap.EnumerateObjects())
                {
                }
            }
        }
    }
}
