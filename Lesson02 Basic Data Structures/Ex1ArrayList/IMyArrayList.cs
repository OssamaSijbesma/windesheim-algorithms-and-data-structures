using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson02_Basic_Data_Structures.Ex1ArrayList
{
    public interface IMyArrayList
    {
        // Add an element to the end of the list (as long
        // as there is still capacity)
        void Add(int x);

        // Get the value from an index
        int Get(int index);

        // Set the value at a certain index
        void Set(int index, int x);

        // Returns the capacity of the list
        int Capacity();

        // Returns the size of the list
        int Size();

        // Clears the list
        void Clear();

        // Count the number of occurences in the list of a number
        int CountOccurences(int x);
    }

    public class MyArrayListIndexOutOfRangeException : Exception
    {
    }

    public class MyArrayListFullException : Exception
    {
    }
}
