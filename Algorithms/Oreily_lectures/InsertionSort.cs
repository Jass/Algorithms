using System;
namespace Algorithms.Oreily_lectures
{
    public class InsetionSortChar:ISort
    {
        private char[] _toSort;

        public InsetionSortChar(char[] toSort)
        {
            _toSort = toSort;
        }

        public char[] GetSorted()
        {
            DoSort();
            return _toSort;
        }

        public void DoSort()
        {
            int l = _toSort.Length;
            int j;
            for (int i = 1; i < l; i++)
            {
                char key = _toSort[i];
                j = i - 1;

                while (j>=0 && (_toSort[j] > key))
                {
                    _toSort[j + 1] = _toSort[j];
                    j--;
                }
                _toSort[j+1] = key;
            }
        }

       
    }
}
