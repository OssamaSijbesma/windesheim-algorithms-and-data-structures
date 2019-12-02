using Lesson02_Basic_Data_Structures.Ex1ArrayList;
using Lesson02_Basic_Data_Structures.Ex2LinkedList;
using Lesson02_Basic_Data_Structures.Ex3Stack;
using Lesson02_Basic_Data_Structures.Ex5Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson02_Basic_Data_Structures
{
    public class DSBuilder
    {
        public static IMyArrayList CreateMyArrayList()
        {
            return new MyArrayList(5);
        }

        public static IMyLinkedList<string> CreateMyLinkedList()
        {
            return new MyLinkedList<string>();
        }

        public static IMyStack<string> CreateMyStack()
        {
            return new MyStack<string>();
        }

        public static IMyQueue<string> CreateMyQueue()
        {
            return new MyQueue<string>();
        }
    }
}
