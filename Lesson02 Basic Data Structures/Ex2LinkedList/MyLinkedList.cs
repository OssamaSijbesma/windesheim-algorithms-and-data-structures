using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson02_Basic_Data_Structures.Ex2LinkedList
{
    public class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyNode<T> header;
        private int size;

        // O(1) : Constructor
        public MyLinkedList()
        {
            header = new MyNode<T>();
        }

        // O(1) : Add an item to the start of the list
        public void AddFirst(T value)
        {
            header = new MyNode<T>(value, header);
            size++;
        }

        // O(1) : Returns the first item of the list
        public T GetFirst()
        {
            if (size == 0)
                throw new MyLinkedListEmptyException();

            return header.Value;
        }

        // O(1) : Remove the first item of the list
        public void RemoveFirst()
        {
            if (size == 0)
                throw new MyLinkedListEmptyException();

            header = header.Next;
            size--;
        }

        // O(n) : Insert an item on a specific index (insert, not overwrite!)
        public void Insert(int index, T value)
        {
            if (index < 0 || index > size)
                throw new MyLinkedListIndexOutOfRangeException();
            if (index == 0)
                AddFirst(value);
            else
            {
                MyNode<T> curNode = header;

                for (int i = 1; i < index; i++)
                {
                    curNode = curNode.Next;
                }

                curNode.Next = new MyNode<T>(value, curNode.Next);
                size++;
            }
        }

        // O(1) : Obtain the size of the list
        public int Size() => size;

        // O(1) : Clear the list
        public void Clear()
        {
            header = default;
            size = 0;
        }

        // O(n)
        public override string ToString()
        {
            if (size == 0)
                return "NIL";

            MyNode<T> curNode = header;
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            for (int i = 0; i < size; i++)
            {
                if (i != 0)
                    sb.Append(",");

                sb.Append(curNode.Value);
                curNode = curNode.Next;
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}
