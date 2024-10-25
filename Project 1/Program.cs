using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array2D = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9} };

            Print2DArray(array2D);
        }
        public static void Print2DArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            Console.WriteLine("Printing 2D Array:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
    }
}
