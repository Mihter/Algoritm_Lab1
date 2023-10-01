using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1
{
    internal class PowAlg
    {
        static long c = 0;
        static long k = 0;
        static long f = 0;
        static int j = 0;

        public static void QuickPowSort(long x, int n, long[] argArray) 
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            c = x;
            k = n;
            if (k % 2 == 1) 
            {
                f = c;
            }
            else
            {
                f = 1;
            }
            MicroRec();
            stopwatch.Stop();
            argArray[j] = stopwatch.ElapsedTicks;
            //компенсация выполнения 5 экспериментов, обнуление индекса для 2-5 массива тиков
            if (j == 1999)
                j = -1;
            j += 1;
        }
        public static void MicroRec()
        {
            k /= 2;
            c *= c;
            if (k % 2 == 1)
            {
                f *= c;
            }
            if (k != 0)
            {
                MicroRec();
            }
            else
            {
                return;
            }
        }
    }
}
