using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

        // функция тимсорт для сортировки массива от 0 до n-1
        // (аналогичная сортировке слиянием)
        static int j = 0;
        public static void TimSort(long[] arr, int n, long[] timeArray, int N)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Сортировка отдельных подмассивов по размеру RUN
            for (int i = 0; i < n; i += RUN)
                InsertionSort(arr, i,
                Math.Min((i + RUN - 1), (n - 1)));

            //Начинает слияние с размера RUN(или 32).
            // Он сольется
            // чтобы сформировать размер 64, затем
            // 128, 256 и так далее ....
            for (int size = RUN; size < n; size = 2 * size)
            {

                // Выберите начальную точку
                // левого подмассива. Мы
                // собираемся объединиться
                // arr[left..left+size-1]
                // и arr[left+size, left+2*size-1]
                // После каждого слияния мы увеличиваем
                // left на 2*size
                for (int left = 0; left < n; left += 2 * size)
                {

                    // Найти конечную точку левого подмассива
                    // mid+1 - начальная точка
                    // правого подмассива
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1),
                                         (n - 1));

                    // Объединить подмассив arr[left.....mid] &
                    // arr[mid+1....right]
                    if (mid < right)
                        Merge(arr, left, mid, right);
                }
            }
            stopwatch.Stop();
            timeArray[j] = stopwatch.ElapsedTicks;
            if (j == N - 1)
                j = -1;
            j += 1;
        }
    }
}

