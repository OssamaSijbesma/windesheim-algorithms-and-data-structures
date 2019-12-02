using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson02_Basic_Data_Structures.Ex5Queue
{
    public class MyQueue<T> : IMyQueue<T>
    {
        private List<T> queue;

        // O(1)
        public MyQueue()
        {
            queue = new List<T>();
        }

        // O(1)
        public bool IsEmpty() => (queue.Count == 0);

        // O(1)
        public void Enqueue(T data) => queue.Add(data);

        // O(1)
        public T GetFront()
        {
            if (IsEmpty())
                throw new MyQueueEmptyException();

            return queue[0];
        }

        // O(1)
        public T Dequeue()
        {
            T item = GetFront();
            queue.RemoveAt(0);
            return item;
        }

        // O(1)
        public void Clear() => queue.Clear();
    }
}
