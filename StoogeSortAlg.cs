using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlgoritmLab1
{
    internal class StoogeSortAlg
    {
        static int j =0;
        // меняет элементы местами
        static void Swap(ref long a, ref long b)
        {
            var t = a;
            a = b;
            b = t;
        }

        // сортирует по частям
        public static long[] StoogeSort(long[] array, int startIndex, int endIndex, long[] timeArray, int n)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            if (array[startIndex] > array[endIndex])
            {
                Swap(ref array[startIndex], ref array[endIndex]);
            }

            if (endIndex - startIndex > 1)
            {
                var len = (endIndex - startIndex + 1) / 3;
                StoogeSort(array, startIndex, endIndex - len, timeArray, n);
                StoogeSort(array, startIndex + len, endIndex, timeArray, n);
                StoogeSort(array, startIndex, endIndex - len, timeArray, n);
            }
            //stopwatch.Stop();
            //timeArray[j] = stopwatch.ElapsedTicks;
            //if (j == n-1)
            //    j = -1;
            //j += 1;
            return array;
            
            
        }
    }
}
