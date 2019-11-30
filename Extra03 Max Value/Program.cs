using System;

namespace Extra03_Max_Value
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] doubleArray = CreateRandomDoubleArray(10, 10, 50);

            Console.WriteLine($"{GetMax(doubleArray)}");
            Console.WriteLine($"{GetMaxIndex(doubleArray)}");
        }

        static double GetMax(double[] array)
        {
            double max = 0;

            for (int i = 0; i < array.Length; i++)
                max = (max < array[i]) ? array[i] : max;

            return max;
        }

        static int GetMaxIndex(double[] array)
        {
            int index = 0;
            double max = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i]) 
                {
                    index = i;
                    max = array[i];
                }
            }

            return index;
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
