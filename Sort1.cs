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
        public static void LogSort(long[]vector, long[]timeArray, int n)
        {
            long a = 0;
            //считываем время работы алгоритма
            Stopwatch stopwatch=new Stopwatch();
            stopwatch.Start();
            if (vector.Length != 0)                     //for (int i = 0; i < vector.Length; i++) 
            {                                           //{
                a = vector[0];                          //    vector[i] = 1;
            }                                           //возведение в степень 0
            stopwatch.Stop();                           //double argument1 = vector[i];
                                                        //double function = Math.Pow(argument1,0);
            timeArray[0] = 0;                           //}
            timeArray[j] = stopwatch.ElapsedTicks;
            //компенсация выполнения n экспериментов, обнуление индекса для n-1 массива тиков
            if (j == n-1) 
                j = -1;
            j+= 1;
        }
    }
}
