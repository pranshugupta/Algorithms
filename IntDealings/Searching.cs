namespace IntDealings
{
    public class Searching
    {
        public static int SequentialSearch(int[] array, int start, int end, int item)
        {
            for (int i = start; i <= end; i++)
            {
                if (array[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int BinarySearch(int[] array, int start, int end, int item)
        {
            if (item < array[start] || array[end] < item)
            {
                return -1;
            }
            if (item == array[start])
            {
                return start;
            }
            else if (item == array[end])
            {
                return end;
            }
            else if (end - start > 2)
            {
                int mid = (start + end) / 2;
                if (item == array[mid])
                {
                    return mid;

                }
                else if (item < array[mid])
                {
                    return BinarySearch(array, start, mid, item);
                }
                else
                {
                    return BinarySearch(array, mid, end, item);
                }
            }
            else return -1;
        }
    }
}
