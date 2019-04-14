namespace IntDealings
{
    public static class IntMergeArray
    {
        public static int[] MergeTwoAscendingSortedArrayToNewArray(int[] array1, int[] array2)
        {
            int i = 0, j = 0, k = 0;
            int array1Length = array1.Length;
            int array2Length = array2.Length;
            int array3Length = array1Length + array2Length;
            int[] array3 = new int[array3Length];

            while (i < array1Length && j < array2Length)
            {
                array3[k++] = array1[i] < array2[j] ? array1[i++] : array2[j++];
            }
            while (i < array1Length)
            {
                array3[k++] = array1[i++];
            }
            while (j < array2Length)
            {
                array3[k++] = array2[j++];
            }
            return array3;
        }
    }
}
