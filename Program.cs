using AlgoritmLab1;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void Main()
    {
        int n = 2000;
        long[] argArray = new long[n];
        long[,] multiArr = new long[5, n];
        
        for (int count=0; count<5; count++)
        { 
            for (n = 0; n < 2000; n++)
            {
                long[] arrVector = new long[n];
                Random rand = new Random();
                for (int i = 0; i < arrVector.Length; i++)
                    arrVector[i] = rand.Next();
                long x = 0;
                x = rand.Next(-1000,1000);
                long[,] matrixA = new long[n, n];
                long[,] matrixB = new long[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrixA[i, j] = rand.Next();
                        matrixB[i, j] = rand.Next();
                    }     
                }
                //I пункт
                //1 алгоритм
                //Sort1.LogSort(arrVector, argArray);
                //2 алгоритм
                //Sort2.LogSort2(arrVector, argArray);
                //3 алгоритм
                //Sort3.LogSort3(arrVector, argArray);
                //4 алгоритм
                //Sort4.LogSort4(arrVector, argArray);
                //5 алгоритм
                //BubbleSort.LogSort5(arrVector, argArray);
                //6 алгоритм
                //QuickSortAlg.QuickSort(arrVector,0, n-1, argArray);
                //7 алгоритм
                //TimSortAlg.TimSort(arrVector, n, argArray);
                //8 алгоритм
                //PowAlg.QuickPowSort(x,n,argArray);
                //II пункт
                //матрицы
                MatrixMultiplication.MatrixMul(matrixA,matrixB,argArray);

            }
            //заполняется мульти массив для результатов тиков за все (5 экспериментов)*2000
            for (int i=0; i<argArray.Length; i++ )
            {
                multiArr[count, i] = argArray[i];
            }         
        }
        //Здесь я привожу полученные 10000 результатов тиков за 5*2000 экспериментов
        //к секундам и кладу в файл
        double del = 100;//5 итераций*20 тиков=1 секунда средняя
        double[] mediumArr = new double[2000];
        for (int tick= 0; tick<2000;tick++)
        {
            long sum = 0;
            for (int i =0; i <5; i++)
            {
                sum += multiArr[i, tick];
            }
            mediumArr[tick] = sum/del;
        }
        
        StreamWriter sw = new StreamWriter("D:\\aboba.txt");
        foreach (double i in mediumArr)
        {
            sw.WriteLine(i);     
        }
        sw.Close();
    }
}
