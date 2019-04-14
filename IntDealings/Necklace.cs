using System;
using System.Collections.Generic;
using System.Linq;

namespace IntDealings
{
    public static class Necklace
    {
        public static int[] FindSmallestNecklace(int[] array)
        {
            List<List<int>> allNecklaces = new List<List<int>>();

            foreach (int bead in array)
            {
                if (allNecklaces.Any(necklace => necklace.IndexOf(bead) > -1))
                {
                    // bead is already processed no need to to it again.
                }
                else
                {
                    List<int> newNecklace = new List<int>();
                    int currentBead = bead;
                    do
                    {
                        newNecklace.Add(currentBead);
                        currentBead = array[currentBead];

                    } while (currentBead != newNecklace[0]);

                    allNecklaces.Add(newNecklace);
                }
            }


            // print all necklaces
            Console.WriteLine("All necklace");
            foreach (List<int> necklace in allNecklaces)
            {
                foreach (int bead in necklace)
                {
                    Console.Write(string.Format("{0}\t", bead));
                }
                Console.WriteLine();
            }


            // find smalles necklace
            List<int> smallestNecklace = allNecklaces[0];
            foreach (List<int> necklace in allNecklaces)
            {
                if (necklace.Count < smallestNecklace.Count)
                {
                    smallestNecklace = necklace;
                }
            }
            return smallestNecklace.ToArray();
        }
    }
}
