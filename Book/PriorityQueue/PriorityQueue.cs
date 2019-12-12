using System;
using System.Collections.Generic;
using System.Text;

namespace Book.PriorityQueue
{
    class PriorityQueue<T>
        where T : System.IComparable<T>
    {
        private static readonly int DEFAULT_CAPACITY = 100;
        private int currentSize;   // Number of elements in heap
        private T[] array;  // The heap array

        // Constructor
        public PriorityQueue()
        {
            currentSize = 0;
            array = new T[DEFAULT_CAPACITY];
        }

        public int Size() => currentSize;
        public void Clear() => currentSize = 0;
        public bool IsEmpty() => currentSize == 0;

        // Return the smallest item this priority queue
        public T Element() 
        {
            if (IsEmpty())
                throw new Exception();

            return array[1];
        }

        // Add item to this priority queue
        public bool Add(T element) 
        {
            if (currentSize + 1 == array.Length)
                DoubleArray();

            // Percolate up
            int hole = ++currentSize;
            array[0] = element;

            while (element.CompareTo(array[hole/2]) < 0)
            {
                array[hole] = array[hole / 2];
                hole /= 2;
            }

            array[hole] = element;

            return true;
        }

        // Remove the smallest item in this priority queue
        public T Remove() 
        {
            T element = Element();
            array[1] = array[currentSize--];
            PercolateDown(1);
            return element;
        }

        // Percolate down in the heap
        private void PercolateDown(int hole) 
        {
            int child;
            T temp = array[hole];

            for (; hole * 2 <= currentSize; hole = child)
            {
                child = hole * 2;
                if (child != currentSize && array[child + 1].CompareTo(array[child]) < 0)
                    child++;
                if (array[child].CompareTo(temp) < 0)
                    array[hole] = array[child];
                else
                    break;
            }

            array[hole] = temp;
        }

        // Establish heap order
        private void BuildHeap() 
        {
            for (int i = currentSize / 2; i > 0; i--)
                PercolateDown(i);
        }

        // Double the array
        private void DoubleArray()
        {
            T[] tmpArray = new T[array.Length * 2];

            for (int i = 0; i < array.Length; i++)
                tmpArray[i] = array[i];

            array = tmpArray;
        }
    }
}
