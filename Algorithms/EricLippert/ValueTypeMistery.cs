using System;
namespace Algorithms.EricLippert
{
    public class ValueTypeMistery
    {


        public struct S
        {
            int x;
            int y;

            public int X { get { return x; } }
            public int Y { get { return y; } }


            public void callBackPrint()
            {
                Console.WriteLine("x:{0}, y:{1}", this.x, this.y);
            }

           public  S(int x, int y)
            {
                this.x = x;
                this.y = y;
                callBackPrint();
            }
        }


        public class NotS
        {
            int z;
            int n;

            public int Z { get { return z; } }
            public int N { get { return n; } }

            public void classCallBackPrint()
            {
                Console.WriteLine("local z:{0}, n:{1}", z, n);
            }

            public NotS()
            {
                z = n = 0;
            }
            public NotS(int x, int y)
            {
                classCallBackPrint();
                z = x;
                classCallBackPrint();
                n = y;
                classCallBackPrint();
            }
        }

        public static void RunValueTypeMistery()
        {
            S _s = new S();
            NotS _nots = new NotS();
            _s = new S(12, 13);
            _nots = new NotS(31, 32);

            Console.WriteLine("------------");

            Action _callBack = () => { Console.WriteLine(" other x:{0}, y:{1}", _s.X, _s.Y); };
           // Action _callBack1 = () => { Console.WriteLine(" other x:{0}, y:{1}", _nots.Z,_nots.N); };

            _s = new S(43, 44);
            _nots = new NotS(55, 56);
        }

    }
}
