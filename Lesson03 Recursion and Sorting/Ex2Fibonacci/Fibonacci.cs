using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson03_Recursion_and_Sorting.Ex2Fibonacci
{
    public class Fibonacci
    {
        static long calls = 0;

        public static void Run()
        {
            int MAX = 35;

            System.Console.WriteLine("Recursief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} calls)", n, FibonacciRecursive(n), calls);
            }

            System.Console.WriteLine("Iteratief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} loops)", n, FibonacciIterative(n), calls);
            }
        }

        // Calculate the fibonacci numbers recursive
        public static long FibonacciRecursive(int n)
        {
            calls++;

            if (n <= 2)
                return 1;

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        // Calculate the fibonacci numbers iterative
        public static long FibonacciIterative(int n)
        {
            calls = 0;
            long n1 = 1;
            long n2 = 0;

            for (int i = 1; i < n; i++)
            {
                long temp = n1;
                n1 += n2;
                n2 = temp;

                calls++;
            }
            return n1;
        }
    }
}
