using System;

namespace StringDealings
{
    public class StringCommonFunctions
    {
        public static void Execute(string msg, Func<string[], string[]> algo, Action<string[]> print)
        {
            Console.WriteLine(msg);
            string input = TakeUserArrayInput();
            string[] array = input.Split(',');
            string[] resultant = algo(array);
            PrintArray(resultant);
        }
        public static void Execute(int noOfArray, string msg, Func<string[], string> algo, Action<string> print)
        {
            string[] input = new string[noOfArray];
            for (int i = 0; i < noOfArray; i++)
            {
                Console.WriteLine(msg + (i + 1) + ":");
                input[i] = TakeUserArrayInput();
            }
            string resultant = algo(input);
            print(resultant);
        }

        public static void Execute(string msg, Func<string, string[]> algo, Action<string[]> print)
        {
            Console.WriteLine(msg);
            string input = TakeUserArrayInput();
            string[] result = algo(input);
            print(result);
        }
        public static string TakeUserArrayInput()
        {
            return Console.ReadLine();
        }

        public static void PrintArray(string[] array)
        {
            Console.WriteLine("Result Strings:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("  " + array[i]);
            }
            Console.ReadKey();
        }

        public static void Print(string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Result could not be calculated");
                return;
            }
            Console.WriteLine("Resultant String:");
            Console.Write(result);
            Console.ReadKey();
        }
    }
}
