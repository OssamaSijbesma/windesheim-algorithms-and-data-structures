using System;
using System.Collections.Generic;
using System.Text;

namespace Book.BinaryTree
{
    class BinaryNode<T>
    {
        private T element;
        private BinaryNode<T> left;
        private BinaryNode<T> right;

        public BinaryNode() { }
        public BinaryNode(T element) 
        {
            this.element = element;
            this.left = null;
            this.right = null;
        }

        public BinaryNode(T element, BinaryNode<T> left, BinaryNode<T> right)
        {
            this.element = element;
            this.left = left;
            this.right = right;
        }

        public T GetElement() => element;
        public BinaryNode<T> GetLeft() => left;
        public BinaryNode<T> GetRight() => right;
        public void SetElement(T element) => this.element = element;
        public void SetLeft(BinaryNode<T> left) => this.left = left;
        public void SetRight(BinaryNode<T> right) => this.right = right;

        public int Size() => Size(this);
        private static int Size(BinaryNode<T> node) 
        {
            if (node == null)
                return 0;
            else
                return 1 + Size(node.left) + Size(node.right);
        }

        public int Height() => Height(this);
        public static int Height(BinaryNode<T> node) 
        {
            if (node == null)
                return -1;
            else
                return 1 + Math.Max(Height(node.left), Height(node.right));
        }

        public BinaryNode<T> Duplicate() 
        {
            BinaryNode<T> root = new BinaryNode<T>(element);

            if (left != null)
                root.left = left.Duplicate();
            if (right != null)
                root.right = right.Duplicate();
            return root;
        }

        public void PrintPreOrder() 
        {
            Console.WriteLine(element);
            if (left != null)
                left.PrintPreOrder();
            if (right != null)
                right.PrintPreOrder();
        }

        public void PrintPostOrder() 
        {
            if (left != null)
                left.PrintPostOrder();
            if (right != null)
                right.PrintPostOrder();
            Console.WriteLine(element);
        }

        public void PrintInOrder() 
        {
            if (left != null)
                left.PrintInOrder();
            Console.WriteLine(element);
            if (right != null)
                right.PrintInOrder();
        }
    }
}
