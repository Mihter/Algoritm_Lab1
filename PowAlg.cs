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
        

        public static int QuickPowSort(long x, int n, long[] argArray, int l) 
        {
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int count = 0;
            c = x;
            k = n;
            count = count + 2;
            if (k % 2 == 1) 
            {
                f = c;
                count= count +1;
            }
            else
            {
                f = 1;
                count = count + 1;
            }
            count = MicroRec(count);
            stopwatch.Stop();
            argArray[j] = stopwatch.ElapsedTicks;
            //компенсация выполнения l экспериментов, обнуление индекса для l-1 массива тиков
            if (j == l-1)
                j = -1;
            j += 1;
            return count;
        }
        public static int MicroRec(int count)
        {
            k /= 2;
            c *= c;
            count = count + 2;

            if (k % 2 == 1)
            {
                f *= c;
                count = count + 1;
            }
            if (k != 0)
            {
                
                count = MicroRec(count);
                return count;


            }
            else
            {
                return count;
            }
        }
    }
}
