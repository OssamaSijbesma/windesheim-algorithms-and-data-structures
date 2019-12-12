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

            return node.GetElement();
        }

        private BinaryNode<T> Find(T element, BinaryNode<T> node) 
        {
            while (node != null)
            {
                if (element.CompareTo(node.GetElement()) < 0)
                    node = node.GetLeft();
                else if (element.CompareTo(node.GetElement()) > 0)
                    node = node.GetRight();
                else
                    return node;
            }

            return null;
        }

        BinaryNode<T> FindMin(BinaryNode<T> node)
        {
            if (node != null)
                while (node.GetLeft() != null)
                    node = node.GetLeft();

            return node;
        }

        BinaryNode<T> FindMax(BinaryNode<T> node)
        {
            if (node != null)
                while (node.GetRight() != null)
                    node = node.GetRight();

            return node;
        }

        BinaryNode<T> Insert(T element, BinaryNode<T> node)
        {
            if (node == null)
                node = new BinaryNode<T>(element);
            else if (element.CompareTo(node.GetElement()) < 0)
                node.SetLeft(Insert(element, node.GetLeft()));
            else if (element.CompareTo(node.GetElement()) > 0)
                node.SetRight(Insert(element, node.GetRight()));
            else
                throw new Exception();
            return node;
        }

        BinaryNode<T> RemoveMin(BinaryNode<T> node)
        {
            if (node == null)
                throw new Exception();
            else if (node.GetLeft() != null)
            {
                node.SetLeft(RemoveMin(node.GetLeft()));
                return node;
            }
            else
                return node.GetRight();
        }

        BinaryNode<T> Remove(T element, BinaryNode<T> node)
        {
            if (node == null)
                throw new Exception();
            if (element.CompareTo(node.GetElement()) < 0)
                node.SetLeft(Remove(element, node.GetLeft()));
            else if (element.CompareTo(node.GetElement()) > 0)
                node.SetRight(Remove(element, node.GetRight()));
            else if (node.GetLeft() != null && node.GetRight() != null)
            {
                node.SetElement(ElementAt(FindMin(node.GetRight())));
                node.SetRight(RemoveMin(node.GetRight()));
            }
            else
                node = (node.GetLeft() != null) ? node.GetLeft() : node.GetRight();
            return node;

        }
    }
}
