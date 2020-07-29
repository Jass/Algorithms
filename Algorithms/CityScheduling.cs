using System;
using
            System.Collections.Generic;
namespace Algorithms

/*
 There are 2N people a company is planning to interview.

The cost of flying the i-th person to city A is costs[i][0],
and the cost of flying the i-th person to city B is costs[i][1].

Return the minimum cost to fly every person to a city such that exactly N people arrive in each city.


 */
{
    public class CityScheduling
    {
        private int _n;
        private int _personN;
        private int[][] _cost;

        public class TravelHelper
        {
            public int toA;
            public int toB;
            public int _difference;
            public bool _a_bigger;

            public TravelHelper(int A, int B)
            {
                toA = A;
                toB = B;
                _difference = Math.Abs(A - B);
                _a_bigger = A > B;
            }
        }
        public CityScheduling(int n)
        {
            _n = n;
            _personN = 2 * _n;
            _cost = new int[_personN][];

            for (int i = 0; i < _personN; i++)
                _cost[i] = new int[2];

        }

        private void SetPricesFor2NPersons()
        {
            for (int i = 0; i < _personN; i++)
            {
                PriceForPerson(i);
            }
        }


        private int CountCost()
        {
           /*
            считаем разницу в цене в каждой паре
           создаем список в котором цена в А цена в В разница между ними
           и бит учтено/не_учтено
           сортируем по разнице в цене
           больше разница в начало списка

            выборка
           идем по списку выбирая боле дешевый



            */

            List<TravelHelper> th = FormList();
            

           
            th.Sort(SortTravelHelperByCostDesc);
            
            int res = 0;
            int nToA = 0;
            int nToB = 0;

            for (int i = 0; i < th.Count; i++)
            {
                if (th[i]._a_bigger && nToB < _n)
                {
                    nToB++;
                    res += th[i].toB;
                }
                else
                if(nToA < _n)
                {
                    res += th[i].toA;
                    nToA++;
                }
            }
            return res;
        }
        #region delegate

        public static int SortTravelHelperByCostDesc(TravelHelper a, TravelHelper b)
        {
            if (a._difference == b._difference)
                return 0;
            if (a._difference < b._difference)
                return 1;

            return -1;
        }
        #endregion

        #region calculations

        private void PriceForPerson(int p_idx)
        {
            Console.WriteLine("input price for ({0}) person to travel to A",p_idx);
            string a = Console.ReadLine();
            int aa=0, bb=0;
            if (a != string.Empty)
            {
               
                try
                {
                    aa = int.Parse(a);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("input price for ({0}) person to travel to B",p_idx);
            a = Console.ReadLine();
            
            if (a != string.Empty)
            {
               
                try
                {
                    bb = int.Parse(a);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            if (aa > 0 && bb > 0)
            { 
                _cost[p_idx][0] = aa;
                _cost[p_idx][1] = bb;
           }
        }

      

        private
            List<TravelHelper> FormList()
        {
            List<TravelHelper> ltv = new List<TravelHelper>();
            
                for (int i = 0; i < _personN; i++)
                {
                
                    ltv.Add(new TravelHelper(_cost[i][0], _cost[i][1]));
                }
                
            return ltv;
        }


        #endregion



        public void Run()
        {

            SetPricesFor2NPersons();

            int totalcost = CountCost();
            Console.WriteLine("total cost is ({0})", totalcost);

        }
    }
}
