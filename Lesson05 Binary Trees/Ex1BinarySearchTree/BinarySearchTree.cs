using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson05_Binary_Trees.Ex1BinarySearchTree
{
    public class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T>
        where T : System.IComparable<T>
    {
        // Add binary node to this tree
        public void Insert(T x) => root = Insert(x, root);

        // Add a binary node to a tree
        private BinaryNode<T> Insert(T x, BinaryNode<T> node)
        {
            if (node == null)
                return new BinaryNode<T>(x, null, null);
            else if (node.data.CompareTo(x) > 0)
                node.left = Insert(x, node.left);
            else if (node.data.CompareTo(x) < 0)
                node.right = Insert(x, node.right);
            else
                throw new BinarySearchTreeDoubleKeyException();

            return node;
        }

        // Find the smallest item in this tree
        public T FindMin()
        {
            if (root == null)
                throw new BinarySearchTreeEmptyException();

            return FindMin(root);
        }

        // Find the smallest item in a tree
        private T FindMin(BinaryNode<T> node)
        {
            if (node != null)
                while (node.left != null)
                    node = node.left;

            return node.data;
        }

        // Remove the smallest item in this tree
        public void RemoveMin()
        {
            if (root == null)
                throw new BinarySearchTreeEmptyException();

            root = RemoveMin(root);
        }

        // Remove the smallest item in a tree
        private BinaryNode<T> RemoveMin(BinaryNode<T> node)
        {
            if (node == null)
                throw new BinarySearchTreeElementNotFoundException();
            else if (node.left != null)
            {
                node.left = RemoveMin(node.left);
                return node;
            }
            else
                return node.right;
        }
        
        // Remove an item from this tree
        public void Remove(T x) => Remove(x, root);

        // Remove a item from a tree
        private BinaryNode<T> Remove(T x, BinaryNode<T> node)
        {
            if (node == null)
                throw new BinarySearchTreeElementNotFoundException();
            if (node.data.CompareTo(x) > 0)
                node.left = Remove(x, node.left);
            else if (node.data.CompareTo(x) < 0)
                node.right = Remove(x, node.right);
            else if (node.left != null && node.right != null)
            {
                node.data = FindMin(node.right);
                node.right = RemoveMin(node.right);
            }
            else
                node = (node.left != null) ? node.left : node.right;

            return node;
        }

        // Tree traversal L-R-N
        public string InOrder() => root.ToInfixString();

        public override string ToString()
        {
            if (root == null)
                return "";

            return ToString(root);
        }

        private string ToString(BinaryNode<T> node) 
        {
            return
                ((node.left != null) ? $"{ToString(node.left)} " : "") +
                node.ToString() +
                ((node.right != null) ? $" {ToString(node.right)}" : "");
        }
    }
}
