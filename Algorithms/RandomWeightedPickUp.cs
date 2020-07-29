using System;
/*
 Given an array w of positive integers,
where w[i] describes the weight of index i(0-indexed),
write a function pickIndex which randomly picks an index in proportion to its weight.

For example, given an input list of values w = [2, 8],
when we pick up a number out of it,
the chance is that 8 times out of 10 we should pick the number 1
as the answer since it's the second element of the array (w[1] = 8).


public class Solution {
    
    int[] wW;
    Random r;
    int l;
    public Solution(int[] w) 
    {
        l= w.length;
        wW = new int[l]; 
        r = new Random();
        
        wW[0] = w[0];
        
        for (int i=1;i<l;i++)
        {
          wW[i]=w[i]+wW[i-1]; 
        }
        
    }
    
    public int PickIndex() {
        int max = wW[l];
        int val = r.NextInt(max);
        int v= FindIdx(val);
    }
    
    private int FindIdx(int val, int begin, int end)
    {
            int mid = (end_idx - begin_idx) / 2;
            mid = begin_idx + mid;

            if (wW[mid] == val)
                return mid;

            if ((mid - 1 >= 0) && (wW[mid] > val)
                && (wW[mid - 1]) < val)
                return mid;

            if ((mid + 1 < l) && (wW[mid] < val)
                && (wW[mid + 1] > val))
                return mid+1;

            if (wW[mid] < val)
                return FindIdx(val, begin_idx+ mid, end_idx);
            else
              return FindIdx(val, begin_idx, end_idx- mid);
    }
}


 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 


 */
namespace Algorithms
{
    public class RandomWeightedPickUp
    {
        int[] wW;
        Random r;
        int l;


        private int[] _weihgt;
        
        public void Run()
        {
          MakeAJar();
          int max = wW[l - 1];
          int val = this.r.Next(max);
            Console.WriteLine("max {0}, for random {1}", max,val);
          int v_idx=   FindIdx(val, 0, l);

          Console.WriteLine("random value is {0}",_weihgt[v_idx]);
            Console.WriteLine("random value index in array  is {0}",v_idx);
        }

        public RandomWeightedPickUp()
        {
            _weihgt = new int[] { 1, 2, 3, 4, 5};
            l = _weihgt.Length;
            r = new Random();
            wW = new int[l];

        }

        private void MakeAJar()
        {
            //{0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4}
            //{1, 3, 6, 10, 15}
            wW[0] = _weihgt[0];
            for (int i = 1;i < l;i++)
            {
                wW[i] = _weihgt[i] + wW[i - 1];
            }
        }

        //binary search
        private int FindIdx(int val, int begin_idx, int end_idx)
        {
            try
            {
                int diff = (end_idx - begin_idx) / 2;
                int midIdx = begin_idx + diff;

                if (wW[midIdx] == val)
                    return midIdx;

                if ((midIdx - 1 >= 0) && (wW[midIdx] > val)
                    && (wW[midIdx - 1]) < val)
                    return midIdx;

                if ((midIdx + 1 < l) && (wW[midIdx] < val)
                    && (wW[midIdx + 1] > val))
                    return midIdx + 1;

                if (wW[midIdx] < val)
                    return FindIdx(val, begin_idx + diff, end_idx);
                else
                    return FindIdx(val, begin_idx, end_idx - diff);
            }
            catch (Exception e)
            {
                Console.WriteLine("error value is {0}",val);
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
