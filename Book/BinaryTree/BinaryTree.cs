using System;
using System.Collections.Generic;
using System.Text;

namespace Book.BinaryTree
{
    class BinaryTree<T>
    {
        private BinaryNode<T> root;

        public BinaryTree() => root = null;
        public BinaryTree(T rootElement) => root = new BinaryNode<T>(rootElement);

        public BinaryNode<T> GetRoot() => root;
        public int Size() => root.Size();
        public int Height() => root.Height();

        public void PrintPreOrder()
        {
            if (root != null) 
                root.PrintPreOrder();
        }

        public void PrintInOrder()
        {
            if (root != null)
                root.PrintInOrder();
        }

        public void PrintPostOrder() 
        {
            if (root != null)
                root.PrintPostOrder();
        }

        public void MakeEmpty() => root = null;
        public bool IsEmpty() => root == null;

        public void Merge(T rootElement, BinaryTree<T> tree1, BinaryTree<T> tree2) 
        {
            if (tree1.root == tree2.root && tree1 != null)
                throw new ArgumentException();

            // Allocate new node
            root = new BinaryNode<T>(rootElement, tree1.root, tree2.root);

            // Ensure that every node is in one tree
            if (this != tree1)
                tree1.root = null;
            if (this != tree2)
                tree2.root = null;
        }
    }
}
