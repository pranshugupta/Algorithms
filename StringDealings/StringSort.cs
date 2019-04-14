using System;
using System.Globalization;

namespace StringDealings
{
    public class StringSort
    {
        public static string[] SortDateTime(string[] arrDate)
        {
            try
            {
                for (int i = 0; i < arrDate.Length; i++)
                {
                    for (int j = 0; j < arrDate.Length - i - 1; j++)
                    {
                        string tmp;
                        if (DateTime.ParseExact(arrDate[j + 1], "dd-MM-yyyy", CultureInfo.InvariantCulture) <
                            DateTime.ParseExact(arrDate[j], "dd-MM-yyyy", CultureInfo.InvariantCulture))
                        {
                            tmp = arrDate[j + 1];
                            arrDate[j + 1] = arrDate[j];
                            arrDate[j] = tmp;
                        }
                    }
                }
                return arrDate;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error parsing string:" + ex.Message);
                return null;
            }
        }
    }
}
