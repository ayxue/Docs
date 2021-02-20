using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighPerfBenchmark
{
    public class SampleCase
    {
        [Benchmark]
        public void TestMD5()
        {
            
        }

        [Benchmark]
        public void TestSHA1()
        {

        }
    }
}
