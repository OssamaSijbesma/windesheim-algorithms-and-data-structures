using System;
using System.Diagnostics;

namespace Extra04_Calculate_Complexity
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a1 = CreateRandomDoubleArray(50000, 10, 80);
            double[] a2 = CreateRandomDoubleArray(100000, 10, 80);
            double[] b1 = CreateRandomDoubleArray(50000, 3, 11);
            double[] b2 = CreateRandomDoubleArray(100000, 3, 11);

            RunWithTimer(a1);
            RunWithTimer(a2);
            RunWithTimer(b1);
            RunWithTimer(b2);
        }

        static void RunWithTimer(double[] array) 
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            GetMax(array);
            stopWatch.Stop();

            System.Console.WriteLine($"{stopWatch.ElapsedTicks} ticks");
        }

        static double GetMax(double[] array)
        {
            double max = 0;

            for (int i = 0; i < array.Length; i++)
                max = (max < array[i]) ? array[i] : max;

            return max;
        }

        static double[] CreateRandomDoubleArray(int length, int min, int max)
        {
            Random random = new Random();
            double[] array = new double[length];

            for (int i = 0; i < length; i++)
                array[i] = random.Next(min, max) + random.NextDouble();

            return array;
        }
    }
}
