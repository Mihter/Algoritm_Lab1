using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1
{
    internal class Sort3
    {
        static int j = 0;
        public static void LogSort3(long[] vector, long[] timeArray, int n)
        {
            long composition= 0;
            //считываем время работы алгоритма
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < vector.Length; i++)
            {
                composition *= vector[i];
            }

            stopwatch.Stop();
            timeArray[j] = stopwatch.ElapsedTicks;
            //компенсация выполнения n экспериментов, обнуление индекса для n-1 массива тиков
            if (j == n-1)
                j = -1;
            j += 1;
        }
    }
}
