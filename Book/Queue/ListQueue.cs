using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Queue
{
    class ListQueue<T>
    {
        private List<T> elements;

        public ListQueue() 
        {
            elements = new List<T>();
        }

        public bool IsEmpty() => elements.Count == 0;
        public void MakeEmpty() => elements.Clear();

        public void Enqueue(T element) => elements.Add(element);

        public T GetFront()
        {
            if (IsEmpty())
                throw new Exception();

            return elements[0];
        }

        public T Dequeue()
        {
            T element = GetFront();
            elements.RemoveAt(0);
            return element;
        }
    }
}
