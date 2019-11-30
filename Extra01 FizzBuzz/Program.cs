using System;
using System.Text;

namespace Extra01_FizzBuzz
{
    class Program
    {
        // Complexity O(n)
        static void Main(string[] args)
        {
            int n = 100;
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                if (i % 15 == 0)
                    stringBuilder.Append("FizzBuzz");
                else if (i % 3 == 0)
                    stringBuilder.Append("Fizz");
                else if (i % 5 == 0)
                    stringBuilder.Append("Buzz");
                else
                    stringBuilder.Append($"{i}");

                if (i != n)
                    stringBuilder.Append(", ");
            }

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
