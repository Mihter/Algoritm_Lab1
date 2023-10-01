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
        public static long[] QuickSort(long[] array, int minIndex, int maxIndex, long[] argArray)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1, argArray);
            QuickSort(array, pivotIndex + 1, maxIndex, argArray);

            stopwatch.Stop();
            argArray[j] = stopwatch.ElapsedTicks;
            //компенсация выполнения 5 экспериментов, обнуление индекса для 2-5 массива тиков
            if (j == 1999)
                j = -1;
            j += 1;
            return array;

        }
    }
    
}
