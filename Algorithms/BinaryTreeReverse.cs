using System;
/*
 Invert a binary tree.

      (1)                                  (1)
  (2)      (3)        =>          (3)              (2)
(4) (5)  (6) (7)              (7)    (6)        (5)   (4)
 */


namespace Algorithms
{
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
         }

        public void Print(bool doLine)
        {
            Console.Write("--------({0})----------", val);
            if (doLine) Console.WriteLine();
            if (left != null)
            {
                bool pl =  right == null;
                left.Print(pl);
            }
            if (right != null)
            {
                
                bool pl = ((right.left != null) || (right.right != null));
                right.Print(pl);
            }
        }
  }
    public class BinaryTreeReverse
    {
        public TreeNode BinaryTreeReverseIt(TreeNode root)
        {
            if(root is null)
            return root;

            NodeReverse(root);
          if(root.left != null)  BinaryTreeReverseIt(root.left);
         if(root.right  !=null)   BinaryTreeReverseIt(root.right);


            return root;
        }

        private TreeNode NodeReverse(TreeNode node)
        {
            Console.WriteLine("--- node reverse ---");
            TreeNode _temp = node.left;
            node.left = node.right;
            node.right = _temp;

            Console.WriteLine("-------({0})-----------",node.val);
            Console.WriteLine("--({0})-----------({1})-----", node.left !=null ? node.left.val.ToString() : string.Empty,
                node.right == null ? string.Empty : node.right.val.ToString());
            Console.WriteLine("------------------------------");
            return node;
        }


        private TreeNode NodeLevel(int[] _array, int i, TreeNode root  )
        {
            if (i < _array.Length)
            {
                TreeNode _temp = new TreeNode();
                _temp.val = _array[i];

                root = _temp;

                root.left = NodeLevel(_array, 2*i + 1, root.left);
                root.right = NodeLevel(_array, 2 * i + 2, root.right);
            }
            return root;
        }

        

        public void RunBinaryTreeReverse()
        {
            int[] _array = new int[] {1, 2, 3,4,5,6,7 };
            TreeNode tree = new TreeNode();
            tree = NodeLevel(_array, 0, tree);
            tree.Print(true);
            tree = BinaryTreeReverseIt(tree);
            Console.WriteLine("----end-----");
            tree.Print(true);
        }
    }
}
