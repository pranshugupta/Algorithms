using System.Collections.Generic;
using System.Linq;

namespace IntDealings
{
    public class Matrix
    {
        public static int[] FindCommonElements(int[][] array, int rows, int columns)
        {
            Dictionary<int, int> commonElements = new Dictionary<int, int>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0)
                    {
                        if (!commonElements.ContainsKey(array[i][j]))
                        {
                            commonElements.Add(array[i][j], i + 1);
                        }
                    }
                    else
                    {
                        if (!commonElements.ContainsKey(array[i][j]))
                        {
                            continue;
                        }
                        else
                        {
                            commonElements[array[i][j]] = i + 1;
                        }
                    }
                }
            }
            return commonElements.Keys.Where(key => commonElements[key] == rows).ToArray();
        }
    }
}