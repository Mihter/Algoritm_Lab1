using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1
{
    class MatrixMultiplication
    {
        static int j = 0;
        public static void MatrixMul(long[,] matrixOne, long[,] matrixTwo, long[] argArray,int n)
        {
            /*вывод первых двух массивов
            for(int visota = 0; visota < matrixOne.GetLength(1); visota++)
            {
                for(int dlina = 0; dlina < matrixOne.GetLength(0); dlina++)
                {
                    Console.Write(matrixOne[dlina, visota]+" ");
                }
                Console.Write("   ");
                for (int dlina = 0; dlina < matrixOne.GetLength(0); dlina++)
                {
                    Console.Write(matrixTwo[dlina, visota] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine();*/

            long[,] outMatrix = new long[matrixTwo.GetLength(0), matrixOne.GetLength(1)];

            //считываем время работы алгоритма
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int outMatrixRank = 0; outMatrixRank < matrixOne.GetLength(1); outMatrixRank++)
            {
                for (int outMatrixLength = 0; outMatrixLength < matrixTwo.GetLength(0); outMatrixLength++)
                {
                    for (int fillerOne = 0; fillerOne < matrixOne.GetLength(0); fillerOne++)
                    {
                        outMatrix[outMatrixLength, outMatrixRank] = outMatrix[outMatrixLength, outMatrixRank] + matrixOne[fillerOne, outMatrixRank] * matrixTwo[outMatrixLength, fillerOne];
                    }
                }
            }

            stopwatch.Stop();
            /* вывод конечного массива
            for (int visota = 0; visota < matrixOne.GetLength(1); visota++)
            {
                for (int dlina = 0; dlina < matrixOne.GetLength(0); dlina++)
                {
                    Console.Write(outMatrix[dlina, visota] + " ");
                }
                Console.WriteLine("");
            }
            */

            argArray[j] = stopwatch.ElapsedTicks;
            //компенсация выполнения n экспериментов, обнуление индекса для n массива тиков
            if (j == n-1)//было 1999
                j = -1;
            j += 1;
        }
    }
}
