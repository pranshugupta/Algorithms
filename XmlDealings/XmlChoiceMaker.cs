using System;

namespace XmlDealings
{
    public static class XmlChoiceMaker
    {
        public static void MakeChoice()
        {
            bool isDone = false;
            do
            {
                Console.Clear();
                Console.WriteLine("0 for Exit..");
                Console.WriteLine("1 to create xml");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        isDone = true;
                        break;

                    case "1":
                        Console.Clear();
                        XmlFormatter.FormatXml();
                        break;
                    case "2":
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            } while (!isDone);
        }
    }
}
