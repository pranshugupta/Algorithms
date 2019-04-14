using System;
using System.Linq;

namespace IntDealings
{
    public delegate void RefDelegate(ref int arg1, ref int arg2);

    public static class IntCommonFunctions
    {
        public static void Execute(int noOfArray, string msg, Func<int[], int[], int[]> algo, Action<int[]> print)
        {
            int[][] arrays = new int[noOfArray][];
            for (int i = 0; i < noOfArray; i++)
            {
                Console.WriteLine(msg + (i + 1) + ":");
                arrays[i] = TakeUserArrayInput();
            }

            int[] resultant = algo(arrays[0], arrays[1]);
            print(resultant);
        }

        public static void Execute(string[] msg, Action<int[], int, int> algo, Action<int[]> print)
        {
            Console.WriteLine(msg[0]);
            int[] arrays = TakeUserArrayInput();
            Console.WriteLine(msg[1]);
            int startIndex = TakeUserArrayInput()[0];
            Console.WriteLine(msg[2]);
            int count = TakeUserArrayInput()[0];

            algo(arrays, startIndex, count);
            print(arrays);

        }

        public static void ExecuteByRef(int noOfValues, string msg, RefDelegate algo, Action<int[]> print)
        {
            int[] array = new int[noOfValues];
            for (int i = 0; i < noOfValues; i++)
            {
                Console.WriteLine(msg + (i + 1) + ":");
                array[i] = TakeUserArrayInput()[0];
            }

            algo(ref array[0], ref array[1]);
            print(array);
        }

        public static void ExecuteByVal(int noOfValues, string msg, Action<int, int> algo, Action<int[]> print)
        {
            int[] array = new int[noOfValues];
            for (int i = 0; i < noOfValues; i++)
            {
                Console.WriteLine(msg + (i + 1) + ":");
                array[i] = TakeUserArrayInput()[0];
            }

            algo(array[0], array[1]);
            print(array);
        }

        public static void Execute(string[] msg, Func<int[], int, int, int, int> algo, Action<int[], int> print)
        {
            Console.WriteLine(msg[0]);
            int[] array = TakeUserArrayInput();
            Console.WriteLine(msg[1]);
            int item = TakeUserArrayInput()[0];

            print(array, algo(array, 0, array.Length - 1, item));
        }

        public static void Execute(string[] msg, Func<int[][], int, int, int[]> algo, Action<int[]> print)
        {
            Console.WriteLine(msg[0]);
            Console.WriteLine(msg[1]);
            int rows = TakeUserArrayInput()[0];

            Console.WriteLine(msg[2]);
            int cols = TakeUserArrayInput()[0];

            int[][] array = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(msg[3], i);
                array[i] = TakeUserArrayInput(cols);
            }

            Print2DArray(array, rows, cols);

            print(algo(array, rows, cols));

        }
        public static void Execute(string msg, Func<int[], int[]> algo, Action<int[]> print)
        {
            Console.WriteLine(msg);
            int[] array = TakeUserArrayInput();
            array = algo(array);
            print(array);
        }

        private static void Print2DArray(int[][] array, int rows, int cols)
        {
            Console.WriteLine("\n2D Array-----");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0}\t", array[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static int[] TakeUserArrayInput(int length = 0)
        {
            System.Collections.Generic.IEnumerable<int> items = Console.ReadLine().Split(',').Select(item => int.Parse(item));
            if (length > 0)
            {
                items.Take(length).ToArray();
            }
            return items.ToArray();
        }

        public static void Print(int[] array)
        {
            Console.WriteLine("Resultant Array:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("  " + array[i]);
            }
            Console.ReadKey();
        }

        public static void PrintItem(int[] array, int index)
        {
            if (-1 < index && index < array.Length)
            {
                Console.WriteLine(string.Format("Searched item<{0}> is found at position<{1}>", array[index], index));
            }
            else
            {
                Console.WriteLine(string.Format("Searched item<{0}> is not found at", array[index]));
            }
            Console.ReadKey();
        }
    }
}
