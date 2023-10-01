using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1
{
    internal class Sort4
    {
        static int j = 0;
        public static void LogSort4(long[] vector, long[] argArray)
        {
            double x = 1.5;
            double polinomial = 0;
            //считываем время работы алгоритма
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = vector.Length-1; i > 0; i--)
            {
                polinomial = polinomial * x;
                polinomial= vector[i-1] + polinomial;
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
