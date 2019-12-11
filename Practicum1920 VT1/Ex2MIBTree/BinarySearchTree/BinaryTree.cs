using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT1.Ex2MIBTree
{
    public class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        // Constructor
        public BinaryTree() => this.root = null;

        // Constructor
        public BinaryTree(T data) => this.root = new BinaryNode<T>(data, null, null);

        // Return the root node
        public BinaryNode<T> GetRoot() => root;

        // Return the size of the tree
        public int Size() => Size(root);

        // Calculate the size of a node recursive
        private static int Size(BinaryNode<T> node)
        {
            if (node == null)
                return 0;

            return 1 + Size(node.left) + Size(node.right);
        }

        // Return the height of this tree
        public int Height() => Height(root);

        // Calculate the height of a node recursive
        private static int Height(BinaryNode<T> node)
        {
            if (node == null)
                return -1;

            return 1 + Math.Max(Height(node.left), Height(node.right));
        }

        // Empty this tree
        public void MakeEmpty() => root = null;

        // Returns if the tree is empty
        public bool IsEmpty() => root == null;

        // Merge two binary trees
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

        // Tree traversal N-L-R
        public string ToPrefixString() => (root != null) ? root.ToPrefixString() : "NIL";

        // Tree traversal L-R-N
        public string ToInfixString() => (root != null) ? root.ToInfixString() : "NIL";

        // Tree traversal L-N-R
        public string ToPostfixString() => (root != null) ? root.ToPostfixString() : "NIL";

        // Return the number of leaves of this tree
        public int NumberOfLeaves() => (root != null) ? root.NumberOfLeaves() : 0;

        // Return the number of nodes with one child of this tree
        public int NumberOfNodesWithOneChild() => (root != null) ? root.NumberOfNodesWithOneChild() : 0;

        // Return the number of nodes with two children of this tree
        public int NumberOfNodesWithTwoChildren() => (root != null) ? root.NumberOfNodesWithTwoChildren() : 0;
    }
}
