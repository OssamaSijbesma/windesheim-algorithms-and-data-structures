using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson02_Basic_Data_Structures.Ex2LinkedList
{
    public class MyNode<T>
    {
        public T Value { get; set; }
        public MyNode<T> Next { get; set; }
    }
}
