namespace StringDealings
{
    public static class CharSwap
    {
        public static void PassByRefWithoutThirdVariable(ref char first, ref char second)
        {
            first ^= second;
            second ^= first;
            first ^= second;
        }
    }
}
