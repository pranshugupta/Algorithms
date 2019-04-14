namespace StringDealings
{
    public static class Substrings
    {
        public static string[] GetAllSubstrings(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            int length = input.Length;
            int maxSubStrings = (length * (length + 1)) / 2;
            int count = 0;
            string[] subStrings = new string[maxSubStrings];

            for (int i = 0; i < input.Length; i++)
            {
                string subinput = input.Substring(i);
                for (int j = 0; j < subinput.Length; j++)
                    subStrings[count++] = subinput.Substring(0, subinput.Length - j);
            }
            return subStrings;
        }
    }
}
