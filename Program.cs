using AlgoritmLab1;

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
                //1 алгоритм
                //Sort1.LogSort(arrVector, argArray);
                //2 алгоритм
                //Sort2.LogSort2(arrVector, argArray);
                //3 алгоритм
                Sort3.LogSort3(arrVector, argArray);
            }
            //заполняется мульти массив для результатов тиков за все (5 экспериментов)*2000
            for (int i=0; i<argArray.Length; i++ )
            {
                multiArr[count, i] = argArray[i];
            }         
        }
        //Здесь я привожу полученные 10000 результатов тиков за 5*2000 экспериментов
        //к секундам и кладу в файл
        double del = 100;
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
