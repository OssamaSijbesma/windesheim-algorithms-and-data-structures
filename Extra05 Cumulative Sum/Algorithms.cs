using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Extra05_Cumulative_Sum
{
    class Algorithms
    {
        private int[] arrayCumalativeSum;

        // Complexity O(n)
        static int CumalativeSum(int[] array, int index) 
        {
            int total = 0;

            for (int i = 0; i <= index; i++)
                total += array[i];

            return total;
        }

        static void InitCumalativeSum2(int[] array) 
        {
            
        }

        static int CumalativeSum2(int[] array, int index)
        {
            if (index < 0 || index > array.Length)
                new IndexOutOfRangeException();


        }

        static void RunWithTimer(int[] array, int index)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            CumalativeSum(array, index);
            stopWatch.Stop();

            System.Console.WriteLine($"{stopWatch.ElapsedTicks} ticks");
        }
    }
}
