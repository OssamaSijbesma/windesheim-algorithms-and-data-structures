using System;
using System.Text;

namespace Extra02_Random_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 20;
            int min = 7;
            int max = 69;

            int[] intArray = CreateRandomIntArray(length, min, max);
            double[] doubleArray = CreateRandomDoubleArray(length, min, max);
            StringBuilder stringBuilder1 = new StringBuilder(), stringBuilder2 = new StringBuilder();


            for (int i = 0; i < length; i++) 
            {
                stringBuilder1.AppendLine($"{intArray[i]}");
                stringBuilder2.AppendLine($"{doubleArray[i]}");
            }

            Console.WriteLine(stringBuilder1.ToString());
            Console.WriteLine(stringBuilder2.ToString());
        }

        // Complexity O(n)
        static int[] CreateRandomIntArray(int length, int min, int max) 
        {
            Random random = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
                array[i] = random.Next(min, max);

            return array;
        }

        // Complexity O(n)
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
