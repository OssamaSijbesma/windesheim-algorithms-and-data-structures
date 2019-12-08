using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson02_Basic_Data_Structures.Ex3Stack
{
    public class MyNode<T>
    {
        public T Value;
        public MyNode<T> Next;

        public MyNode() { }

        public MyNode(T value, MyNode<T> next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
