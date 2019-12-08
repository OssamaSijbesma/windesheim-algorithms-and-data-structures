using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson04_QuickSort_and_Trees.Ex2FirstChildNextSibling
{
    public class FCNSNode<T> : IFCNSNode<T>
    {
        private T data;
        private FCNSNode<T> firstChild;
        private FCNSNode<T> nextSibling;

        // Constructor
        public FCNSNode(T data) => this.data = data;

        // Constructor
        public FCNSNode(T data, FCNSNode<T> firstChild, FCNSNode<T> nextSibling) 
        {
            this.data = data;
            this.firstChild = firstChild;
            this.nextSibling = nextSibling;
        }

        // Return the data of the node
        public T GetData() => data;

        // Return the first child of the node
        public FCNSNode<T> GetFirstChild() => firstChild;

        // Return the next sibling of the node
        public FCNSNode<T> GetNextSibling() => nextSibling;

        // Print the nodes pre-order N-L-R
        public void PrintPreOrder() 
        {
            Console.WriteLine(data);
            if (firstChild != null)
                firstChild.PrintPreOrder();
            if (nextSibling != null)
                nextSibling.PrintPreOrder();
        }

        // Print the nodes in-order L-N-R
        public void PrintInOrder() 
        {
            if (firstChild != null)
                firstChild.PrintInOrder();
            Console.WriteLine(data);
            if (nextSibling != null)
                nextSibling.PrintInOrder();
        }

        // Print the nodes post-order L-R-N
        public void PrintPostOrder() 
        {
            if (firstChild != null)
                firstChild.PrintPostOrder();
            if (nextSibling != null)
                nextSibling.PrintPostOrder();
            Console.WriteLine(data);
        }

        // ToString: <data>,FC(<contents first child>),NS(<contents next sibling>)
        // Example: a,FC(b,FC(d),NS(c))
        public override string ToString()
        {
            return $"{data}{((firstChild != null) ? $",FC({firstChild.ToString()})" : "")}{((nextSibling != null) ? $",NS({nextSibling.ToString()})" : "")}";
        }
    }
}
