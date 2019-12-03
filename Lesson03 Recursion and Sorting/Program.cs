using Lesson03_Recursion_and_Sorting.Ex1Factorial;
using Lesson03_Recursion_and_Sorting.Ex2Fibonacci;
using Lesson03_Recursion_and_Sorting.Ex3Alternately;
using Lesson03_Recursion_and_Sorting.Ex4Ones;
using Lesson03_Recursion_and_Sorting.Ex6ForwardBackwardString;
using Lesson03_Recursion_and_Sorting.Ex7Sorting;
using System;

namespace Lesson03_Recursion_and_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("\n=====   Opgave 1 : Faculteit   =====\n");
            Factorial.Run();

            System.Console.WriteLine("\n=====   Opgave 2 : Fibonacci   =====\n");
            Fibonacci.Run();

            System.Console.WriteLine("\n=====   Opgave 3 : Alternately   =====\n");
            Alternately.Run();

            System.Console.WriteLine("\n=====   Opgave 4 : Enen   =====\n");
            Ones.Run();

            System.Console.WriteLine("\n=====   Opgave 6 : ForwardString   =====\n");
            ForwardBackwardString.Run();

            System.Console.WriteLine("\n=====   Opgave 7 : Sorting   =====\n");
            Sorter isort = new InsertionSort();
            Sorter msort = new MergeSort();
            Sorter ssort = new ShellSort();
            isort.Run();
            msort.Run();
            ssort.Run();
            int[] numbers = { 100, 1000, 10000 };
            foreach (int num in numbers)
            {
                isort.RunWithTimer(num);
                msort.RunWithTimer(num);
                ssort.RunWithTimer(num);
            }
        }
    }
}
