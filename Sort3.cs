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
        public static void LogSort3(long[] vector, long[] argArray)
        {
            long sum = 0;
            //считываем время работы алгоритма
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < vector.Length; i++)
            {
                sum *= vector[i];
            }

            stopwatch.Stop();
            argArray[j] = stopwatch.ElapsedTicks;
            //компенсация выполнения 5 экспериментов, обнуление индекса для 2-5 массива тиков
            if (j == 1999)
                j = -1;
            j += 1;
        }
    }
}
