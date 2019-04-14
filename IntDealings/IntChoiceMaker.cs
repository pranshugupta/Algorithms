using System;

namespace IntDealings
{
    public static class IntChoiceMaker
    {
        public static void MakeChoice()
        {
            bool isDone = false;
            do
            {
                Console.Clear();
                Console.WriteLine("0 for Exit..");
                Console.WriteLine("1 for Merge Two Ascending Sorted Array To New Array");
                Console.WriteLine("2 for swapping two numbers");
                Console.WriteLine("3 for swapping integer array(Reverse)");
                Console.WriteLine("4 for Searching");
                Console.WriteLine("5 for getting common items in each row");
                Console.WriteLine("6 Sort 1 2 3");
                Console.WriteLine("7 Necklace problem");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        isDone = true;
                        break;
                    case "1":
                        Console.Clear();
                        IntCommonFunctions.Execute(2, "Enter integer values separated by comma for array:", IntMergeArray.MergeTwoAscendingSortedArrayToNewArray, IntCommonFunctions.Print);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("1 for pass by ref with temp variable");
                        Console.WriteLine("2 for pass by ref without temp variable");
                        Console.WriteLine("3 pass by value");
                        Console.WriteLine("Any other key for Exit..");
                        string swapInput = Console.ReadLine();
                        switch (swapInput)
                        {
                            case "1":
                                Console.Clear();
                                IntCommonFunctions.ExecuteByRef(2, "Enter integer value:", IntSwap.PassByRefWithThirdVariable, IntCommonFunctions.Print);
                                break;
                            case "2":
                                Console.Clear();
                                IntCommonFunctions.ExecuteByRef(2, "Enter integer value:", IntSwap.PassByRefWithoutThirdVariable, IntCommonFunctions.Print);
                                break;
                            case "3":
                                Console.Clear();
                                IntCommonFunctions.ExecuteByVal(2, "Enter integer value:", IntSwap.PassByValue, IntCommonFunctions.Print);
                                break;
                            default: break;
                        }
                        break;
                    case "3":
                        Console.Clear();
                        IntCommonFunctions.Execute(new string[] { "Enter integer values separated by comma for array:", "Enter starting index:", "Enter count:" },
                            IntSwap.SwapArray,
                            IntCommonFunctions.Print);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("1 for Sequential Search");
                        Console.WriteLine("2 for Binary Serach");
                        Console.WriteLine("Any other key for Exit..");
                        string searchInput = Console.ReadLine();
                        switch (searchInput)
                        {
                            case "1":
                                Console.Clear();
                                IntCommonFunctions.Execute(new string[] { "Enter integer values separated by comma for array:", "Enter item to search:" }, Searching.SequentialSearch, IntCommonFunctions.PrintItem);
                                break;
                            case "2":
                                IntCommonFunctions.Execute(new string[] { "Enter integer values separated by comma for array:", "Enter item to search:" }, Searching.BinarySearch, IntCommonFunctions.PrintItem);
                                Console.Clear();
                                break;
                            default: break;
                        }
                        break;
                    case "5":
                        Console.Clear();
                        IntCommonFunctions.Execute(new string[] { "Size Of Array:", "Enter no of rows", "Enter no of columns", "Inter comma separated items for row {0}" },
                            Matrix.FindCommonElements, IntCommonFunctions.Print);

                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        IntCommonFunctions.Execute("Enter integer values separated by comma for array:", Sorting.Sort123, IntCommonFunctions.Print);

                        Console.Clear();
                        break;
                    case "7":
                        Console.Clear();
                        IntCommonFunctions.Execute("Enter integer values separated by comma for array, Be vary that array does form nacklace:", Necklace.FindSmallestNecklace, IntCommonFunctions.Print);

                        Console.Clear();
                        break;
                    default:
                        break;
                }
            } while (!isDone);
        }
    }
}
