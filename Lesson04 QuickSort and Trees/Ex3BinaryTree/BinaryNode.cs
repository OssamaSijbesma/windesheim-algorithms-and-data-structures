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

        // Constructor
        public BinaryNode() : this(default, default, default) { }

        // Constructor
        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        // Return data
        public T GetData() => data;
        // Return left underlying node
        public BinaryNode<T> GetLeft() => left;
        // Return right underlying node
        public BinaryNode<T> GetRight() => right;
        // Set data
        public void SetData(T data) => this.data = data;
        // Set the left underlying node
        public void SetLeft(BinaryNode<T> left) => this.left = left;
        // Set the right underlying node
        public void SetRight(BinaryNode<T> right) => this.right = right;

        // Print the nodes pre-order N-L-R
        public void PrintPreOrder()
        {
            Console.WriteLine(data);
            if (left != null)
                left.PrintPreOrder();
            if (right != null)
                right.PrintPreOrder();
        }

        // Print the nodes in-order L-N-R
        public void PrintInOrder()
        {
            if (left != null)
                left.PrintInOrder();
            Console.WriteLine(data);
            if (right != null)
                right.PrintInOrder();
        }

        // Print the nodes post-order L-R-N
        public void PrintPostOrder()
        {
            if (left != null)
                left.PrintPostOrder();
            if (right != null)
                right.PrintPostOrder();
            Console.WriteLine(data);
        }

        // Return a string of the nodes pre-order N-L-R
        public string ToPrefixString()
        {
            return $"[ {data} {((left != null) ? left.ToPrefixString() : "NIL")} {((right != null) ? right.ToPrefixString() : "NIL")} ]";
        }

        // Return a string of the nodes in-order L-N-R
        public string ToInfixString()
        {
            return $"[ {((left != null) ? left.ToInfixString() : "NIL")} {data} {((right != null) ? right.ToInfixString() : "NIL")} ]";
        }

        // Return a string of the nodes post-order L-R-N
        public string ToPostfixString()
        {
            return $"[ {((left != null) ? left.ToPostfixString() : "NIL")} {((right != null) ? right.ToPostfixString() : "NIL")} {data} ]";

        }

        // Return the number of leaves
        public int NumberOfLeaves() 
        {
            if (left == null && right == null)
                return 1;

            return 
                ((left != null) ? left.NumberOfLeaves() : 0) +
                ((right != null) ? right.NumberOfLeaves() : 0);
        }

        // Return the number of underlying nodes with one child
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

        // Return the number of underlying nodes with two childs
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
