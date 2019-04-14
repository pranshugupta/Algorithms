namespace IntDealings
{
    public static class Sorting
    {
        public static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[0] > array[1])
                {

                }
            }
            return array;
        }

        public static int[] Sort123(int[] array)
        {
            int startIndex1 = -1;
            int startIndex2 = -1;
            int startIndex3 = -1;
            for (int i = 0; i < array.Length;)
            {
                System.Console.WriteLine("\n\nIteration for index: {0}", i);

                if (array[i] == 3)
                {
                    if (startIndex3 == -1)
                    {
                        startIndex3 = i;
                    }

                    i = i + 1;
                }
                else if (array[i] == 2)
                {
                    if (startIndex3 != -1)
                    {
                        IntSwap.PassByRefWithoutThirdVariable(ref array[startIndex3], ref array[i]);
                        System.Console.WriteLine("Swapped");
                        if (startIndex2 == -1)
                        {
                            startIndex2 = startIndex3;
                        }

                        startIndex3 = startIndex3 + 1;
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
                else if (array[i] == 1)
                {
                    if (startIndex2 != -1)
                    {
                        IntSwap.PassByRefWithoutThirdVariable(ref array[startIndex2], ref array[i]);
                        System.Console.WriteLine("Swapped");
                        if (startIndex1 == -1)
                        {
                            startIndex1 = startIndex2;
                        }

                        startIndex2 = startIndex2 + 1;
                    }
                    else if (startIndex3 != -1)
                    {
                        IntSwap.PassByRefWithoutThirdVariable(ref array[startIndex3], ref array[i]);
                        System.Console.WriteLine("Swapped");
                        if (startIndex1 == -1)
                        {
                            startIndex1 = startIndex3;
                        }

                        startIndex3 = startIndex3 + 1;
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
            }
            System.Console.WriteLine("StartIndex1:{0} \t StartInded2:{1} \t StartInded3: {2}", startIndex1, startIndex2, startIndex3);
            return array;
        }
    }
}
