using System;

/*
 Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.

Given linked list -- head = [4,5,1,9], which looks like following:

Note:

The linked list will have at least two elements.
All of the nodes' values will be unique.
The given node will not be the tail and it will always be a valid node of the linked list.
Do not return anything from your function.
 */
namespace Algorithms
{
    public class ListNode_lc
    {
        public int val;
        public ListNode_lc next;
        public ListNode_lc(int x)
        {
            val = x;
        }

        public void  Print()
        {
            Console.WriteLine("-----");
            PrintNode(this);
            
        }

        private void PrintNode(ListNode_lc node)
        {
            Console.WriteLine("{0}, ", node.val);
            if (node.next != null)
            {
                PrintNode(node.next);
            }
        }
    }

    public class LinkedList_leetCode
    {
        ListNode_lc _lc;

        public void Run()
        {
            SetList();
            DeleteNode(_lc, 5);
            Console.WriteLine("updated list: ");
            _lc.Print();
        }


        private void SetList()
        {
            int[] _arr = new int[] { 1,2,5,3,9,4};

            _lc = CreateNode(_lc, _arr, 0);
            _lc.Print();
        }

        private ListNode_lc CreateNode(ListNode_lc node, int[] arrVal, int k)
        {
            node = new ListNode_lc(arrVal[k]);

            if (k +1 < arrVal.Length)
            {
                node.next = CreateNode(node.next, arrVal, k + 1);
            }

            return node;
        }

        private ListNode_lc DeleteNode(ListNode_lc list,int val)
        {

            ListNode_lc pointer = list;
            ListNode_lc prev = list;
            bool notDeleted = true;
            while (pointer != null && notDeleted)
            {
                if (pointer.val == val)
                {
                    prev.next = pointer.next;
                    notDeleted = false;
                }
                else
                {
                    prev = pointer;
                    pointer = pointer.next;

                }
            }


          return list;

        }

       

       

    }
}
