namespace StringDealings
{
    public static class StringReverse
    {
        public static string ReverseString_Rec(string str)
        {
            if (str.Length <= 1) { return str; }
            else
            {
                return ReverseString_Rec(str.Substring(1)) + str[0];
            }
        }

        public static string ReverseString_CharArray(string str)
        {
            char[] chars = new char[str.Length];
            for (int i = 0, j = str.Length - 1; i <= j; i++, j--)
            {
                chars[i] = str[j];
                chars[j] = str[i];
            }
            return new string(chars);
        }

        public static string ReverseString_XOR(string str)
        {
            char[] inputstream = str.ToCharArray();
            int length = str.Length - 1;
            for (int i = 0; i < length; i++, length--)
            {
                inputstream[i] ^= inputstream[length];
                inputstream[length] ^= inputstream[i];
                inputstream[i] ^= inputstream[length];
            }
            return new string(inputstream);
        }
    }
}
