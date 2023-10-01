using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1
{
    internal class TimSortAlg
    {
        //константа от которой
        public const int RUN = 32;

        //  функция сортирует массив от левого индекса к
        // к правому индексу, который имеет размер при наибольшем RUN
        public static void InsertionSort(long[] arr, int left,
                                         int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                long temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

        // функция слияния объединяет отсортированные прогоны
        public static void Merge(long[] arr, int l, int m, int r)
        {
            // исходный массив разбит на две части
            // левый и правый массив
            int len1 = m - l + 1, len2 = r - m;
            long[] left = new long[len1];
            long[] right = new long[len2];
            for (int x = 0; x < len1; x++)
                left[x] = arr[l + x];
            for (int x = 0; x < len2; x++)
                right[x] = arr[m + 1 + x];

            int i = 0;
            int j = 0;
            int k = l;

            // После сравнения мы объединяем эти два массива
            // в большем подмассиве
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            //Скопируйте оставшиеся элементы
            // слева, если таковые имеются
            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }

            //Скопируйте оставшиеся элементы
            // справа, если таковые имеются
            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }

        // Iterative Timsort function to sort the
        // array[0...n-1] (similar to merge sort)
        static int j = 0;
        public static void TimSort(long[] arr, int n, long[] argArray)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Sort individual subarrays of size RUN
            for (int i = 0; i < n; i += RUN)
                InsertionSort(arr, i,
                              Math.Min((i + RUN - 1), (n - 1)));

            // Start merging from size RUN (or 32).
            // It will merge
            // to form size 64, then
            // 128, 256 and so on ....
            for (int size = RUN; size < n; size = 2 * size)
            {

                // Pick starting point of
                // left sub array. We
                // are going to merge
                // arr[left..left+size-1]
                // and arr[left+size, left+2*size-1]
                // After every merge, we increase
                // left by 2*size
                for (int left = 0; left < n; left += 2 * size)
                {

                    // Find ending point of left sub array
                    // mid+1 is starting point of
                    // right sub array
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1),
                                         (n - 1));

                    // Merge sub array arr[left.....mid] &
                    // arr[mid+1....right]
                    if (mid < right)
                        Merge(arr, left, mid, right);
                }
            }
            stopwatch.Stop();
            argArray[j] = stopwatch.ElapsedTicks;
            if (j == 1999)
                j = -1;
            j += 1;
        }

        // Utility function to print the Array
        //public static void PrintArray(long[] arr, int n)
        //{
        //    for (int i = 0; i < n; i++)
        //        Console.Write(arr[i] + " ");
        //    Console.Write("\n");
        //}

        // Driver program to test above function
        //public static void Main()
        //{
            //int[] arr = { -2, 7,  15,  -14, 0, 15,  0, 7,
            //          -7, -4, -13, 5,   8, -14, 12 };
            //int n = arr.Length;
            //TimSort(arr, n);

            //Console.Write("After Sorting Array is\n");
            //PrintArray(arr, n);
        //}
    }
}

