using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson04_QuickSort_and_Trees.Ex3BinaryTree
{
    public class BinaryNode<T>
    {
        public T data;
        public BinaryNode<T> left;
        public BinaryNode<T> right;

        public BinaryNode() : this(default, default, default) { }

        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        public T GetData() => data;
        public BinaryNode<T> GetLeft() => left;
        public BinaryNode<T> GetRight() => right;
        public void SetData(T data) => this.data = data;
        public void SetLeft(BinaryNode<T> left) => this.left = left;
        public void SetRight(BinaryNode<T> right) => this.right = right;

        public void PrintPreOrder()
        {
            Console.WriteLine(data);
            if (left != null)
                left.PrintPreOrder();
            if (right != null)
                right.PrintPreOrder();
        }

        public void PrintInOrder()
        {
            if (left != null)
                left.PrintInOrder();
            Console.WriteLine(data);
            if (right != null)
                right.PrintInOrder();
        }

        public void PrintPostOrder()
        {
            if (left != null)
                left.PrintPostOrder();
            if (right != null)
                right.PrintPostOrder();
            Console.WriteLine(data);
        }

        public string ToPrefixString()
        {
            return $"[ {data} {((left != null) ? left.ToPrefixString() : "NIL")} {((right != null) ? right.ToPrefixString() : "NIL")} ]";
        }

        public string ToInfixString()
        {
            return $"[ {((left != null) ? left.ToInfixString() : "NIL")} {data} {((right != null) ? right.ToInfixString() : "NIL")} ]";
        }

        public string ToPostfixString()
        {
            return $"[ {((left != null) ? left.ToPostfixString() : "NIL")} {((right != null) ? right.ToPostfixString() : "NIL")} {data} ]";

        }

        public int NumberOfLeaves() 
        {
            if (left == null && right == null)
                return 1;

            return 
                ((left != null) ? left.NumberOfLeaves() : 0) +
                ((right != null) ? right.NumberOfLeaves() : 0);
        }

        public int NumberOfNodesWithOneChild() 
        {
            if (left == null && right == null)
                return 0;

            if (left != null && right != null)
                return left.NumberOfNodesWithOneChild() + right.NumberOfNodesWithOneChild();

            return 1 + 
                ((left != null) ? left.NumberOfNodesWithOneChild() : 0) + 
                ((right != null) ? right.NumberOfNodesWithOneChild() : 0);
        }

        public int NumberOfNodesWithTwoChildren() 
        {
            if (left != null && right != null)
                return 1 + left.NumberOfNodesWithTwoChildren() + right.NumberOfNodesWithTwoChildren();

            return
                ((left != null) ? left.NumberOfNodesWithTwoChildren() : 0) +
                ((right != null) ? right.NumberOfNodesWithTwoChildren() : 0);
        }
    }
}
