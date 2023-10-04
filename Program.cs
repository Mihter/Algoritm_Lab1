using AlgoritmLab1;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

class Program
{
    
    public static void Main()
    {
        /*
        n=n
        argArray теперь timeArray
        multiArr теперь multiTimeArr
        количество тестов для массива - howManyTests (по госту 5)
        iterHowManyTests - от 0 до (по госту 5-1=4)
        nCycle это цикл по одному (из 5 по госту) тесту для массивов(1-2000)
        mediumArr теперь approxArr
        */
        
        int j = 0;  
        int n = 0;
        n = Convert.ToInt32(Console.ReadLine());//размер массива для тестов
        int[] countOper = new int[n];//колво операций для степенной(возведение в степень)
        long[] timeArray = new long[n];//массив для замеров времени тестов для массивов длины до n (1-n)
        int howManyTests = 5;//количество тестов для массива
        long[,] multiTimeArr = new long[howManyTests, n];// массив хранит время всех операций
        Random rand = new Random();
        for (int iterHowManyTests = 0; iterHowManyTests < howManyTests; iterHowManyTests++)//цикл по колличеству тестов
        {
            for (int nCycle = 1; nCycle < n+1; nCycle++)//цикл по одному тесту для массивов(1-n)
            {
                long[] testVector = new long[nCycle]; //массив подопытный
                for (int i = 0; i < testVector.Length; i++)//заполнение подопытного
                    testVector[i] = rand.Next(0, 50000);

                long x = 0;
                x = rand.Next(-1000, 1000);

                ////создание матриц для II
                //long[,] matrixA = new long[nCycle, nCycle];
                //long[,] matrixB = new long[nCycle, nCycle];
                //for (int i = 0; i < nCycle; i++)
                //{
                //    for (j = 0; j < nCycle; j++)
                //    {
                //        matrixA[i, j] = rand.Next();
                //        matrixB[i, j] = rand.Next();
                //    }
                //}

                //I пункт
                //1 алгоритм
                //Sort1.LogSort(testVector, timeArray, n);
                //2 алгоритм
                //Sort2.LogSort2(testVector, timeArray,n);
                //3 алгоритм
                //Sort3.LogSort3(testVector, timeArray,n);
                //4 алгоритм
                //Horner.HornerSort(testVector, timeArray, n);
                //5 алгоритм
                //BubbleSort.LogSort5(testVector, timeArray,n);
                //6 алгоритм
                //QuickSortAlg.QuickSort(testVector,0, nCycle-1, timeArray,n);
                //7 алгоритм
                //TimSortAlg.TimSort(testVector, nCycle, timeArray, n);
                //8 алгоритм
                countOper[nCycle-1] = PowAlg.QuickPowSort(x, nCycle, timeArray,n);
                //II пункт
                //матрицы
                //MatrixMultiplication.MatrixMul(matrixA, matrixB, timeArray,n);
                //III пункт
                //Казьмин М. Аллгоритм
                //Stopwatch stopwatch = new Stopwatch(); //убрать если что
                //stopwatch.Start();
                //StoogeSortAlg.StoogeSort(testVector, 0, nCycle - 1, timeArray, n);
                //stopwatch.Stop();
                //timeArray[j] = stopwatch.ElapsedTicks;
                //if (j == n - 1)
                //    j = -1;
                //j += 1;
            }
            //заполняется мультимассив для результатов тиков за все эксперименты
            for (int i = 0; i < timeArray.Length; i++)
            {
                multiTimeArr[iterHowManyTests, i] = timeArray[i];
            }
        }
        
        //Здесь я привожу полученные результаты в виде тиков к секундам и кладу в файл
        double del = 10000000 * howManyTests;//итераций*10млн тиков=1 секунда средняя
        double[] approxArr = new double[n];
        for (int tick = 0; tick < n; tick++)
        {
            long sum = 0;
            for (int iterHowManyTests = 0; iterHowManyTests < howManyTests; iterHowManyTests++)
            {
                sum += multiTimeArr[iterHowManyTests, tick];
            }
            approxArr[tick] = sum / del;
        }
        //вывод
        StreamWriter sw = new StreamWriter("D:\\test.txt");
        foreach (double i in approxArr)
        {
            sw.WriteLine(i);
        }
        sw.Close();
        StreamWriter spw = new StreamWriter("D:\\test2.txt");
        foreach (int i in countOper)
        {
            spw.WriteLine(i);
        }
        spw.Close();
        //System.Diagnostics.Process.Start("D:\\dev\\Algoritms_2course\\AlgoritmLab1\\bin\\Debug\\net6.0\\aboba.txt"); //ПРОВЕРИТЬ ЭТУ ШТУКУ ЭТО ОТКРЫТИЕ ФАЙЛА В БЛОКНОТЕ
    }
}
