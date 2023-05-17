using LinkedList.Model;
using System;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 3, h = 3, m = 3;
            Matrix a = new Matrix(n, h);
            Matrix b=new Matrix(h,m);
            Matrix result = new Matrix(n, m);

            Console.WriteLine("Матрица A:");
            a.PrintMatrix();
            Console.WriteLine("Матрица B:");
            b.PrintMatrix();

            if (a.CanMultMatrix(b))
            {
                result.matrix = Matrix.MatrixMult(a, b);
                Console.WriteLine("Матрица C = A * B с помощью массивов:");
                result.PrintMatrix();

                result.matrixList = Matrix.MatrixMult(a.matrixList, b.matrixList, n, h, m);
                Console.WriteLine("Матрица C = A * B с помощью LinkedList:");
                result.PrintMatrixInLinkedList();
            }
            else
            {
                Console.WriteLine("Умножение невозможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }
            Console.ReadKey();
        }
    }
}
