using IntDealings;
using StringDealings;
using System;
using XmlDealings;

namespace DriverConsole
{
    public class Driver
    {
        public static void Main(string[] args)
        {
            MakeChoice();
            Console.ReadLine();
        }

        private static void MakeChoice()
        {
            bool isDone = false;
            do
            {
                Console.Clear();
                Console.WriteLine("0 for Exit..");
                Console.WriteLine("1 for integer operation:");
                Console.WriteLine("2 for string operations:");
                Console.WriteLine("3 for Xml operations:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        isDone = true;
                        break;
                    case "1":
                        Console.Clear();
                        IntChoiceMaker.MakeChoice();
                        break;
                    case "2":
                        Console.Clear();
                        StringChoiceMaker.MakeChoice();
                        break;
                    case "3":
                        Console.Clear();
                        XmlChoiceMaker.MakeChoice();
                        break;
                    default:
                        break;
                }
            } while (!isDone);
        }
    }
}
