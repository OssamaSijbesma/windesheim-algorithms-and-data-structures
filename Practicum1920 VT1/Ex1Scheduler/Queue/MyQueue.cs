using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT1.Ex1Scheduler
{
    public class MyQueue<T> : IMyQueue<T>
    {
        public List<T> queue;

        // O(1) Constructor
        public MyQueue()
        {
            queue = new List<T>();
        }

        // O(1) Check if the queue is empty.
        public bool IsEmpty() => (queue.Count == 0);

        // O(1) Add an item to the queue.
        public void Enqueue(T data) => queue.Add(data);

        // O(1) Return the first item inside of the queue.
        public T GetFront()
        {
            if (IsEmpty())
                throw new MyQueueEmptyException();

            return queue[0];
        }

        // O(1) Remove and return the first item in the queue.
        public T Dequeue()
        {
            T item = GetFront();
            queue.RemoveAt(0);
            return item;
        }

        // O(1) Clear the queue.
        public void Clear() => queue.Clear();
    }
}
