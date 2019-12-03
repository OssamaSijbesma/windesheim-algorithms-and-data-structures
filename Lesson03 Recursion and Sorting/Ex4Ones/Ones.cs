using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson03_Recursion_and_Sorting.Ex4Ones
{
    public class Ones
    {
        public static void Run()
        {
            for (int i = 0; i < 20; i++)
            {
                System.Console.WriteLine("Enen({0,4}) = {1,2}", i, OnesRecursive(i));
            }
            System.Console.WriteLine("Enen(1024) = {0,2}", OnesRecursive(1024));
            System.Console.WriteLine();
        }

        // Calculate aantal enen in een binair nummer
        public static int OnesRecursive(int n)
        {
            if (n <= 0)
                return 0;

            return (n % 2 == 0) ? OnesRecursive(n / 2) : 1 + OnesRecursive(n / 2);
        }
    }
}
