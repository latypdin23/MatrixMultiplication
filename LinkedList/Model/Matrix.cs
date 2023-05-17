using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList.Model
{
    internal class Matrix
    {
        internal int[,] matrix;
        internal LinkedList<LinkedList<int>> matrixList;
        /// <summary>
        /// Инициализиурет матрицу заданного размера случайными числами. Матрица представлена в двух видах: в виде двумерного массива и в виде LinkedList
        /// </summary>
        /// <param name="rowsCount"></param>
        /// <param name="columnsCount"></param>
        public Matrix(int rowsCount, int columnsCount)
        {
            Random random=new Random();
            matrix = new int[rowsCount, columnsCount];
            matrixList= new LinkedList<LinkedList<int>>();

            for (int i = 0; i < rowsCount; i++)
            {
                LinkedList<int> temp = new LinkedList<int>();
                for (int j = 0; j < columnsCount; j++)
                {
                    int tmp = random.Next(10);
                    temp.AddLast(tmp);
                    matrix[i, j] = tmp;
                }
                matrixList.AddLast(temp);
            }
        }
        /// <summary>
        /// Получает количество строк матрицы
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int RowsCount()
        {
            return matrix.GetUpperBound(0) + 1;
        }
        /// <summary>
        /// Получает количество столбцов матрицы
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int ColumnsCount()
        {
            return matrix.GetUpperBound(1) + 1;
        }
        /// <summary>
        /// Проверка на возможность перемножения текущей матрицы с заданной. Матрицы Можно перемножить, если количество столбцов левой матрицы совпадает с количесвтом строк правой матрицы.
        /// </summary>
        /// <param name="matrixB"></param>
        /// <returns></returns>
        internal bool CanMultMatrix(Matrix matrixB)
        {
            if (ColumnsCount() != matrixB.RowsCount())
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// Умножение двух матриц
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns></returns>
        internal static int[,] MatrixMult(Matrix matrixA, Matrix matrixB)
        {
            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.ColumnsCount(); k++)
                    {
                        matrixC[i, j] += matrixA.matrix[i, k] * matrixB.matrix[k, j];
                    }
                }
            }

            return matrixC;
        }
        /// <summary>
        /// Умножение двух матриц с использованием LinkedList
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="N"></param>
        /// <param name="H"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        internal static LinkedList<LinkedList<int>> MatrixMult(LinkedList<LinkedList<int>> A, LinkedList<LinkedList<int>> B, int N, int H, int M)
        {
            LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();

            for (int i = 0; i < N; i++)
            {
                LinkedList<int> resRow = new LinkedList<int>();
                LinkedList<int> fromA = A.First();
                for (int j = 0; j < M; j++)
                {
                    int tmp = 0;
                    for (int k = 0; k < H; k++)
                    {
                        LinkedList<int> fromB = B.First();

                        int a = fromA.First(); int b = fromB.First();
                        tmp += a * b;

                        fromA.RemoveFirst(); fromA.AddLast(a);
                        fromB.RemoveFirst(); fromB.AddLast(b);
                        B.RemoveFirst(); B.AddLast(fromB);
                    }
                    resRow.AddLast(tmp);
                }
                result.AddLast(resRow);
                A.RemoveFirst(); A.AddLast(fromA);
            }

            return result;
        }
        /// <summary>
        /// Вывести матрицу на консоль
        /// </summary>
        /// <param name="matrix"></param>
        internal void PrintMatrix()
        {
            for (var i = 0; i < RowsCount(); i++)
            {
                for (var j = 0; j < ColumnsCount(); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }
        /// <summary>
        /// Вывести матрицу на консоль
        /// </summary>
        /// <param name="matrix"></param>
        internal void PrintMatrixInLinkedList()
        {
            foreach (LinkedList<int> i in matrixList)
            {
                foreach (int j in i)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }
        }
    }
}
