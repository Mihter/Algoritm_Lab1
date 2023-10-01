using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1
{
    class MatrixMultiplication
    {
        static int j = 0;
        public static void MatrixMul(long[,] matrixOne, long[,] matrixTwo, long[] argArray)
        {
            long[,] outMatrix = new long[matrixTwo.GetLength(0), matrixOne.Rank];
            //считываем время работы алгоритма
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int outMatrixRank = 0; outMatrixRank < matrixOne.Rank; outMatrixRank++)
            {
                for (int outMatrixLength = 0; outMatrixLength < matrixTwo.GetLength(0); outMatrixLength++)
                {
                    for (int fillerOne = 0; fillerOne < matrixOne.GetLength(0); fillerOne++)
                    {
                        outMatrix[outMatrixLength, outMatrixRank] += matrixOne[fillerOne, outMatrixRank] + matrixTwo[outMatrixLength, fillerOne];
                    }
                }
            }

            stopwatch.Stop();

            argArray[j] = stopwatch.ElapsedTicks;
            //компенсация выполнения 5 экспериментов, обнуление индекса для 2-5 массива тиков
            if (j == 1999)
                j = -1;
            j += 1;
        }
    }
}
