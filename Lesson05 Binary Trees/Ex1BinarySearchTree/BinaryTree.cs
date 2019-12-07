using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson05_Binary_Trees.Ex1BinarySearchTree
{
    public class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Cunstructors
        //----------------------------------------------------------------------

        public BinaryTree() => this.root = null;

        public BinaryTree(T data) => this.root = new BinaryNode<T>(data, null, null);


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot() => root;

        public int Size() => Size(root);

        private static int Size(BinaryNode<T> node)
        {
            if (node == null)
                return 0;

            return 1 + Size(node.left) + Size(node.right);
        }

        public int Height() => Height(root);

        public static int Height(BinaryNode<T> node)
        {
            if (node == null)
                return -1;

            return 1 + Math.Max(Height(node.left), Height(node.right));
        }

        public void MakeEmpty() => root = null;

        public bool IsEmpty() => root == null;

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            if (t1.root == t2.root && t1.root != null)
                throw new ArgumentException();

            // Allocate new node
            root = new BinaryNode<T>(rootItem, t1.root, t2.root);

            // Ensure that every node is in one tree
            if (this != t1)
                t1.root = null;
            if (this != t2)
                t2.root = null;
        }

        public string ToPrefixString() => (root != null) ? root.ToPrefixString() : "NIL";

        public string ToInfixString() => (root != null) ? root.ToInfixString() : "NIL";

        public string ToPostfixString() => (root != null) ? root.ToPostfixString() : "NIL";


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves() => (root != null) ? root.NumberOfLeaves() : 0;

        public int NumberOfNodesWithOneChild() => (root != null) ? root.NumberOfNodesWithOneChild() : 0;

        public int NumberOfNodesWithTwoChildren() => (root != null) ? root.NumberOfNodesWithTwoChildren() : 0;
    }
}
