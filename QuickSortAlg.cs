using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1
{
    internal class QuickSortAlg
    {
       
        //метод для обмена элементов массива
        static void Swap(ref long x, ref long y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(long[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        static int j = 0;
        //быстрая сортировка
        public static long[] QuickSort(long[] array, int minIndex, int maxIndex, long[] argArray, int n)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1, argArray,n);
            QuickSort(array, pivotIndex + 1, maxIndex, argArray,n);

            stopwatch.Stop();
            argArray[j] = stopwatch.ElapsedTicks;
            //компенсация выполнения n экспериментов, обнуление индекса для n-1 массива тиков
            if (j == n-1)
                j = -1;
            j += 1;
            return array;

        }
    }
    
}
