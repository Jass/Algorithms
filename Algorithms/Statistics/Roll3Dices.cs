using System;
namespace Algorithms.Statistics
{
    public class Dice
    {
       public int[] Sides = { 1,2,3,4,5,6};
    }
    public class Roll3Dices
    {
        
        public Roll3Dices()
        {
            Probability8();
        }

        public int NumberOfPossibleEvents()
        {
            return 6 * 6 * 6;
        }

        public void Probability8()
        {
            int count7more = 0;
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    for (int k = 1; k < 7; k++)
                    {
                        
                        if (i + j + k > 7)
                        {
                            count7more++;
                            Console.Write("[{0} {1} {2}]", i, j, k);
                        }
                        else Console.Write(" {0} {1} {2} ", i, j, k);
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("7 + is  {0}", count7more);
        }
    }
}
