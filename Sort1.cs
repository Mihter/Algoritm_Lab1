using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1
{
     class Sort1
    {
        static int j = 0;
        public static void LogSort(int[]vector, long[]argArray)
        {
            //считываем время работы алгоритма
            Stopwatch stopwatch=new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < vector.Length; i++) 
            {
                vector[i] = 1;
                //возведение в степень 0
                //double argument1 = vector[i];
                //double function = Math.Pow(argument1,0);
            }

            stopwatch.Stop();
            argArray[j] = stopwatch.ElapsedTicks;
            //компенсация выполнения 5 экспериментов, обнуление индекса для 2-5 массива тиков
            if (j == 1999) 
                j = -1;
            j+= 1;
        }
    }
}
