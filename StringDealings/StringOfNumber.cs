using System;

namespace StringDealings
{
    public class StringOfNumber
    {
        public static string AddStringOfNumbers(string[] str)
        {
            try
            {
                string result = string.Empty;
                int lstr1 = str[0].Length;
                int lstr2 = str[1].Length;
                int maxLength = lstr1 > lstr2 ? lstr1 : lstr2;

                //Append 0 zeros at the begining of the smaller string and lengthier strind wont be affected
                str[0] = str[0].PadLeft(maxLength, '0');
                str[1] = str[1].PadLeft(maxLength, '0');

                int carry = 0;

                //Now length of both string are same, Youcan add easily
                for (int i = 0; i < maxLength; i++)
                {
                    result = AddChar(str[0][maxLength - 1 - i], str[1][maxLength - 1 - i], ref carry) + result;
                }

                if (carry > 0)
                    result = carry.ToString() + result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error parsing string:" + ex.Message);
                return null;
            }
        }

        private static string AddChar(char char1, char char2, ref int carry)
        {
            int num1 = int.Parse(char1.ToString());
            int num2 = int.Parse(char2.ToString());
            int sumUnitPlaceDigit = AddInt(num1, num2, ref carry);
            return sumUnitPlaceDigit.ToString();
        }

        private static int AddInt(int num1, int num2, ref int carry)
        {
            int sum = num1 + num2 + carry;
            int unitPlace = sum % 10;
            carry = sum / 10;
            return unitPlace;
        }
    }
}
