using System;


namespace Algorithms.Oreily_lectures
{
    public class ShellsortTestForLoop : ISort
    {
        
        private string strToSort = "SORTEXAMPLE";

        public ShellsortTestForLoop()
        {


        }

        int sort(char[] toSort)
        {
            int n = toSort.Length;

            // Start with a big gap,  
            // then reduce the gap 
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                Console.WriteLine("gap is {0}", gap);
                // Do a gapped insertion sort for this gap size. 
                // The first gap elements a[0..gap-1] are already 
                // in gapped order keep adding one more element 
                // until the entire array is gap sorted 
                for (int i = gap; i < n; i += 1)
                {
                    // add a[i] to the elements that have 
                    // been gap sorted save a[i] in temp and 
                    // make a hole at position i 
                    char temp = toSort[i];
                    Console.WriteLine("for i={0} temp={1}", i, temp);
                    // shift earlier gap-sorted elements up until 
                    // the correct location for a[i] is found 
                    int j;
                    
                    for (j = i; j >= gap ; j -= gap)
                    {
                        if ( toSort[j - gap] > temp)
                        {

                            toSort[j] = toSort[j - gap];
                            Console.WriteLine("--shift" + String.Concat(toSort));
                        } 
                    }
                    toSort[j] = temp;
                    // put temp (the original a[i])  
                    // in its correct location 
                   
                }

                Console.WriteLine("----end gap {0}-----{1}", gap, String.Concat(toSort));
            }
            return 0;
        }


        public void DoSort()
        {
            Console.WriteLine("unsorted: {0}", strToSort);
            char[] toSort = strToSort.ToCharArray();
            sort(toSort);


        }
    }
}
