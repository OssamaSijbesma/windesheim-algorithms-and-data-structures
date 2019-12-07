using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson05_Binary_Trees.Ex1BinarySearchTree
{
    public class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T>
        where T : System.IComparable<T>
    {
        public void Insert(T x) => root = Insert(x, root);

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

        public T FindMin()
        {
            if (root == null)
                throw new BinarySearchTreeEmptyException();

            return FindMin(root);
        }

        private T FindMin(BinaryNode<T> node)
        {
            if (node != null)
                while (node.left != null)
                    node = node.left;

            return node.data;
        }

        public void RemoveMin()
        {
            if (root == null)
                throw new BinarySearchTreeEmptyException();

            root = RemoveMin(root);
        }

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

        public void Remove(T x) => Remove(x, root);
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
