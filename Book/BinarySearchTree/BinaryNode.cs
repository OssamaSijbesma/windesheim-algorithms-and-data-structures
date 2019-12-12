using System;
using System.Collections.Generic;
using System.Text;

namespace Book.BinarySearchTree
{
    class BinaryNode<T>
    {
        public T element;              // Data in the node
        public BinaryNode<T> left;     // Left child
        public BinaryNode<T> right;    // Right child

        // Constructor
        public BinaryNode(T element) 
        {
            left = null;
            right = null;
            this.element = element;
        }
    }
}
