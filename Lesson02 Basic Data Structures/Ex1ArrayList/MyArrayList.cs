using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson02_Basic_Data_Structures.Ex1ArrayList
{
    public class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;

        // O(1) : Constructor
        public MyArrayList(int capacity)
        {
            data = new int[capacity];
        }

        // O(1) : Add an element to the end of the list (as long
        // as there is still capacity) 
        public void Add(int x)
        {
            if (size == data.Length)
                throw new MyArrayListFullException();

            data[size++] = x;
        }

        // O(1) : Get the value from an index
        public int Get(int index)
        {
            if (index < 0 || index >= size)
                throw new MyArrayListIndexOutOfRangeException();

            return data[index];
        }

        // O(1) : Set the value at a certain index
        public void Set(int index, int x)
        {
            if (index < 0 || index >= size)
                throw new MyArrayListIndexOutOfRangeException();

            data[index] = x;
        }

        // O(1) : Returns the capacity of the list
        public int Capacity() => data.Length;

        // O(1) : Returns the size of the list
        public int Size() => size;

        // O(1) : Clears the list
        public void Clear() => size = 0;
        

        // O(n) : Count the number of occurences in the list of a number
        public int CountOccurences(int n)
        {
            int counter = 0;

            for (int i = 0; i < size; i++)
            {
                if (data[i] == n) counter++;
            }

            return counter;
        }

        // O(n)
        public override string ToString()
        {
            if (size == 0)
                return "NIL";

            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            for (int i = 0; i < size; i++)
            {
                if (i != 0)
                    sb.Append(",");

                sb.Append(data[i]);
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}
