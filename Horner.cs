using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1
{
    internal class Horner
    {
        static int j = 0;
        public static void HornerSort(long[] vector, long[] timeArray, int n)
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
            timeArray[j] = stopwatch.ElapsedTicks;
            //компенсация выполнения n экспериментов, обнуление индекса для n-1 массива тиков
            if (j == n-1)
                j = -1;
            j += 1;
        }
    }
}
