namespace IntDealings
{
    public static class Consecutive
    {
        public static void ConsicutiveReplaceWithMiddle(int[] array)
        {
            for (int i = 1; i < array.Length - 2;)
            {
                if ((array[i + 1] - array[i] == 1) && (array[i] - array[i - 1] == 1))
                {
                    array[i + 1] = array[i];
                    array[i - 1] = array[i];
                    i += 3;
                }
                else
                {
                    i++;
                }
            }
        }
        public static void ConsecutiveOmitWithMiddle(int[] array, out int length)
        {
            int consecutiveStartIndex = -1, consecutiveEndIndex = -1;
            length = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i + 1] - array[i] != 1)
                {
                    if (consecutiveStartIndex != -1)
                    {
                        consecutiveEndIndex = i;
                        if ((consecutiveEndIndex - consecutiveStartIndex) % 2 == 0)
                        {
                            array[length] = array[(consecutiveEndIndex + consecutiveStartIndex) / 2];
                            length++;
                        }
                        consecutiveStartIndex = consecutiveEndIndex = -1;
                    }
                    else
                    {
                        array[length] = array[i];
                        length++;
                    }

                }
                else if (consecutiveStartIndex == -1)
                {
                    consecutiveStartIndex = i;
                }
            }
        }

        public static void RemoveRepeatetiveB2F(int[] array, out int length)
        {
            length = 1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] != array[i + 1])
                {
                    array[length] = array[i + 1];
                    length++;
                }
            }
        }
    }
}

//55  99 99  100  101 45  36  55  56  57  58  59  10  12  14 
//55         100      45  36          57          10  12  14