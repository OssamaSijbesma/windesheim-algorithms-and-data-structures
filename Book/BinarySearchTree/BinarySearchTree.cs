using System;
using System.Collections.Generic;
using System.Text;

namespace Book.BinarySearchTree
{
    class BinarySearchTree<T> where T : System.IComparable<T>
    {
        private BinaryNode<T> root;

        public BinarySearchTree() => root = null;

        public void Insert(T element) => root = Insert(element, root);
        public void Remove(T element) => root = Remove(element, root);
        public void RemoveMin() => root = RemoveMin(root);
        public T FindMin() => ElementAt(FindMin(root));
        public T FindMax() => ElementAt(FindMax(root));
        public T Find(T element) => ElementAt(Find(element, root));
        public void MakeEmpty() => root = null;
        public bool IsEmpty() => root == null;

        private T ElementAt(BinaryNode<T> node) 
        {
            if (node == null)
                return default;

            return node.element;
        }

        private BinaryNode<T> Find(T element, BinaryNode<T> node) 
        {
            while (node != null)
            {
                if (element.CompareTo(node.element) < 0)
                    node = node.left;
                else if (element.CompareTo(node.element) > 0)
                    node = node.right;
                else
                    return node;
            }

            return null;
        }

        BinaryNode<T> FindMin(BinaryNode<T> node)
        {
            if (node != null)
                while (node.left != null)
                    node = node.left;

            return node;
        }

        BinaryNode<T> FindMax(BinaryNode<T> node)
        {
            if (node != null)
                while (node.right != null)
                    node = node.right;

            return node;
        }

        BinaryNode<T> Insert(T element, BinaryNode<T> node)
        {
            if (node == null)
                node = new BinaryNode<T>(element);
            else if (element.CompareTo(node.element) < 0)
                node.left = Insert(element, node.left);
            else if (element.CompareTo(node.element) > 0)
                node.right = Insert(element, node.right);
            else
                throw new Exception();
            return node;
        }

        BinaryNode<T> RemoveMin(BinaryNode<T> node)
        {
            if (node == null)
                throw new Exception();
            else if (node.left != null)
            {
                node.left = RemoveMin(node.left);
                return node;
            }
            else
                return node.right;
        }

        BinaryNode<T> Remove(T element, BinaryNode<T> node)
        {
            if (node == null)
                throw new Exception();
            if (element.CompareTo(node.element) < 0)
                node.left = Remove(element, node.left);
            else if (element.CompareTo(node.element) > 0)
                node.right = Remove(element, node.right);
            else if (node.left != null && node.right != null)
            {
                node.element = ElementAt(FindMin(node.right));
                node.right = RemoveMin(node.right);
            }
            else
                node = (node.left != null) ? node.left : node.right;
            return node;
        }
    }
}
