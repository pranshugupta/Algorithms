using System;

namespace StringDealings
{
    public static class StringChoiceMaker
    {
        public static void MakeChoice()
        {
            bool isDone = false;
            do
            {
                Console.Clear();
                Console.WriteLine("0 for Exit..");
                Console.WriteLine("1 to sort datetime in form of string array.");
                Console.WriteLine("2 to add large number in form of array.");
                Console.WriteLine("3 to print all substring.");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        isDone = true;
                        break;

                    case "1":
                        Console.Clear();
                        StringCommonFunctions.Execute("Enter Date<dd-MM-yyyy> separated by<comma>:", StringSort.SortDateTime, StringCommonFunctions.PrintArray);
                        break;
                    case "2":
                        Console.Clear();
                        StringCommonFunctions.Execute(2, "Enter string of numbers:", StringOfNumber.AddStringOfNumbers, StringCommonFunctions.Print);
                        break;
                    case "3":
                        Console.Clear();
                        StringCommonFunctions.Execute("Enter string:", Substrings.GetAllSubstrings, StringCommonFunctions.PrintArray);
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            } while (!isDone);
        }
    }
}
