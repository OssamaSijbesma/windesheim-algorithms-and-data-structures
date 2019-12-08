using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson04_QuickSort_and_Trees.Ex2FirstChildNextSibling
{
    public class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FCNSNode<T> root;

        // Return the size of the FCNS tree
        public int Size() => Size(root);

        // Return the size of the given node.
        private int Size(FCNSNode<T> node)
        {
            if (node == null)
                return 0;

            return 1
                + ((node.GetFirstChild() != null) ? Size(node.GetFirstChild()) : 0)
                + ((node.GetNextSibling() != null) ? Size(node.GetNextSibling()) : 0);
        }

        // Print the FCNS tree pre-order N-L-R
        public void PrintPreOrder()
        {
            if (root != null)
                root.PrintPreOrder();
            else 
                Console.WriteLine("NIL");
        }

        // Print the FCNS tree post-order L-R-N
        public void PrintPostOrder()
        {
            if (root != null)
                root.PrintPostOrder();
            else
                Console.WriteLine("NIL");
        }

        // Print the FCNS tree in-order L-N-R
        public void PrintInOrder()
        {
            if (root != null)
                root.PrintInOrder();
            else
                Console.WriteLine("NIL");
        }

        // ToString FCNS tree
        public override string ToString() => (root != null) ? root.ToString() : "NIL";
    }
}
