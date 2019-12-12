using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Stack
{
    class ListStack<T>
    {
        private List<T> elements;
        private int size;

        public ListStack()
        {
            elements = new List<T>();
        }

        public bool IsEmpty() => elements.Count == 0;
        public void MakeEmpty() => elements.Clear();

        public T Top()
        {
            if (IsEmpty())
                throw new Exception();

            return elements[size - 1];
        }

        public T Pop() 
        {
            if (IsEmpty())
                throw new Exception();

            T element = elements[--size];
            elements.RemoveAt(size);
            return element;
        }

        public void Push(T element) 
        {
            elements.Add(element);
            size++;
        }
    }
}
