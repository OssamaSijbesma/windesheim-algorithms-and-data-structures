using System;
using System.Collections.Generic;
using System.Text;

namespace Book.BinarySearchTree
{
    class BinaryNode<T>
    {
        private T element;              // Data in the node
        private BinaryNode<T> left;     // Left child
        private BinaryNode<T> right;    // Right child

        // Constructor
        public BinaryNode(T element) 
        {
            left = null;
            right = null;
            this.element = element;
        }
        public T GetElement() => element;
        public BinaryNode<T> GetLeft() => left;
        public BinaryNode<T> GetRight() => right;
        public void SetElement(T element) => this.element = element;
        public void SetLeft(BinaryNode<T> left) => this.left = left;
        public void SetRight(BinaryNode<T> right) => this.right = right;
    }
}
