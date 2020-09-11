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

           public  S(int x, int y, Action _callback)
            {
                _callback();
                this.x = x;
                _callback();
                this.y = y;
                _callback();
            }
        }


        public static void RunValueTypeMistery()
        {
            S _s = new S();
            _s = new S(12, 13, _s.callBackPrint);

            Console.WriteLine("------------");

            Action _callBack = () => { Console.WriteLine(" other x:{0}, y:{1}", _s.X, _s.Y); };
            _s = new S(43, 44, _callBack);
        }

    }
}
