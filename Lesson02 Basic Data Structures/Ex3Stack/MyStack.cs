using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson02_Basic_Data_Structures.Ex3Stack
{
    public class MyStack<T> : IMyStack<T>
    {
        public MyNode<T> header;
        private int size;

        // O(1) : Constructor
        public MyStack()
        {
            header = new MyNode<T>();
        }

        // O(1) : Returns the first item from the stack
        public T Top()
        {
            if (size == 0)
                throw new MyStackEmptyException();

            return header.Value;
        }

        // O(1) : Returns and removes the first item from the stack
        public T Pop()
        {
            if (size == 0)
                throw new MyStackEmptyException();

            T value = header.Value;
            header = header.Next;
            size--;

            return value;
        }

        // O(1) : Add an item on the stack
        public void Push(T value)
        {
            header = new MyNode<T>() { Value = value, Next = header };
            size++;
        }

        // O(1) : Checks if the stack is empty
        public bool IsEmpty() => size == 0;
    }
}
