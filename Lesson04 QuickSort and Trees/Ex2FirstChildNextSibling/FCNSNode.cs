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

        public FCNSNode(T data) => this.data = data;

        public FCNSNode(T data, FCNSNode<T> firstChild, FCNSNode<T> nextSibling) 
        {
            this.data = data;
            this.firstChild = firstChild;
            this.nextSibling = nextSibling;
        }

        public T GetData() => data;

        public FCNSNode<T> GetFirstChild() => firstChild;

        public FCNSNode<T> GetNextSibling() => nextSibling;

        public void PrintPreOrder() 
        {
            Console.WriteLine(data);
            if (firstChild != null)
                firstChild.PrintPreOrder();
            if (nextSibling != null)
                nextSibling.PrintPreOrder();
        }

        public void PrintInOrder() 
        {
            if (firstChild != null)
                firstChild.PrintInOrder();
            Console.WriteLine(data);
            if (nextSibling != null)
                nextSibling.PrintInOrder();
        }

        public void PrintPostOrder() 
        {
            if (firstChild != null)
                firstChild.PrintPostOrder();
            if (nextSibling != null)
                nextSibling.PrintPostOrder();
            Console.WriteLine(data);
        }

        public override string ToString()
        {
            return $"{data}{((firstChild != null) ? $",FC({firstChild.ToString()})" : "")}{((nextSibling != null) ? $",NS({nextSibling.ToString()})" : "")}";
        }
    }
}
