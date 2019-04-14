using System;

namespace IntDealings
{
    public static class IntSwap
    {
        public static void SwapArray(int[] array, int startIndex, int count)
        {
            int endIndex = startIndex + count - 1;
            for (int i = 0; i < count / 2; i++)
            {
                PassByRefWithThirdVariable(ref array[startIndex + i], ref array[endIndex - i]);
            }
        }

        public static void PassByRefWithThirdVariable(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void PassByRefWithoutThirdVariable(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }

        public static void PassByValue(int a, int b)
        {
            Console.WriteLine("Pass by value doesn't swap anything");
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
