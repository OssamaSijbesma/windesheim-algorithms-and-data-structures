﻿using Lesson02_Basic_Data_Structures.Ex1ArrayList;
using Lesson02_Basic_Data_Structures.Ex2LinkedList;
using Lesson02_Basic_Data_Structures.Ex3Stack;
using Lesson02_Basic_Data_Structures.Ex4BracketChecker;
using Lesson02_Basic_Data_Structures.Ex5Queue;
using System;

namespace Lesson02_Basic_Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            Opgave1();
            Opgave2();
            Opgave3();
            Opgave4();
            Opgave5();
        }

        static void Opgave1()
        {
            System.Console.WriteLine("\n=====   Opgave 1 : MyArrayList   =====\n");

            MyArrayList al = new MyArrayList(10);
            System.Console.WriteLine(al);
            al.Add(2);
            al.Add(3);
            al.Add(5);
            System.Console.WriteLine(al);
            Console.WriteLine(al.Get(0));
            try
            {
                Console.WriteLine(al.Get(3));
            }
            catch (MyArrayListIndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            al.Set(2, 4);
            System.Console.WriteLine(al);

            al.Clear();
            for (int i = 0; i < 10; i++)
            {
                al.Add(i);
            }
            al.Set(9, 2);
            al.Set(7, 2);
            System.Console.WriteLine(al);
            Console.WriteLine(al.CountOccurences(2));
        }

        static void Opgave2()
        {
            System.Console.WriteLine("\n=====   Opgave 2 : MyLinkedList   =====\n");

            MyLinkedList<string> ll = new MyLinkedList<string>();
            System.Console.WriteLine(ll);
            ll.AddFirst("a");
            ll.AddFirst("b");
            ll.AddFirst("c");
            ll.Insert(2, "x");
            System.Console.WriteLine(ll);
            try
            {
                ll.Insert(4, "kan niet");
            }
            catch (MyLinkedListIndexOutOfRangeException e)
            {
                System.Console.WriteLine(e.Message);
            }

            ll.Clear();
            ll.AddFirst("a");
            ll.AddFirst("b");
            System.Console.WriteLine(ll.GetFirst());
            ll.RemoveFirst();
            System.Console.WriteLine(ll);
            ll.RemoveFirst();
            System.Console.WriteLine(ll);
        }

        static void Opgave3()
        {
            System.Console.WriteLine("\n=====   Opgave 3 : MyStack   =====\n");

            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            System.Console.WriteLine(stack.Top());
            stack.Pop();
            stack.Pop();
            stack.Pop();
            try
            {
                stack.Pop();
            }
            catch (MyStackEmptyException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        static void Opgave4()
        {
            System.Console.WriteLine("\n=====   Opgave 4 : BracketChecker   =====\n");

            System.Console.WriteLine(BracketChecker.CheckBrackets(""));
            System.Console.WriteLine(BracketChecker.CheckBrackets("()"));
            System.Console.WriteLine(BracketChecker.CheckBrackets("())"));

            System.Console.WriteLine("\n=====   Opgave 4 : BracketChecker2   =====\n");

            System.Console.WriteLine(BracketChecker.CheckBrackets2("(())([][][][[]]{})"));
            System.Console.WriteLine(BracketChecker.CheckBrackets2("(){}[]["));
            System.Console.WriteLine(BracketChecker.CheckBrackets2("([)]"));
            System.Console.WriteLine(BracketChecker.CheckBrackets2("([][]"));
        }

        static void Opgave5()
        {
            System.Console.WriteLine("\n=====   Opgave 5 : MyQueue   =====\n");

            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            System.Console.WriteLine(queue.Dequeue());
            System.Console.WriteLine(queue.GetFront());
            System.Console.WriteLine(queue.Dequeue());
            System.Console.WriteLine(queue.GetFront());
            queue.Dequeue();
            try
            {
                System.Console.WriteLine(queue.GetFront());
            }
            catch (MyQueueEmptyException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
