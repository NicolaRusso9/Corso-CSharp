using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MonitoringLib
    {
        private static Stopwatch timer = new();

        private static long bytesPhysicalBefore = 0;
        private static long bytesVirtualBefore = 0;

        public static void Start()
        {
            // release unecessary memory data
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // store the current physical and virtual memory use
            bytesPhysicalBefore = Process.GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = Process.GetCurrentProcess().VirtualMemorySize64;

            timer.Restart();

        }

        public static void Stop()
        {
            timer.Stop();
            long bytesPhysicalAfter = Process.GetCurrentProcess().WorkingSet64; 
            long bytesVirtualAfter = Process.GetCurrentProcess().VirtualMemorySize64;

            Console.WriteLine("{0:N0} physical bytes used.",
                bytesPhysicalAfter - bytesPhysicalBefore);

            Console.WriteLine("{0:N0} virtual bytes used.",
                bytesVirtualAfter - bytesVirtualBefore);

            Console.WriteLine("{0} time span ellapsed.", timer.Elapsed);

            Console.WriteLine("{0:N0} total milliseconds ellapsed.",
                timer.ElapsedMilliseconds);

        }
    }
}
