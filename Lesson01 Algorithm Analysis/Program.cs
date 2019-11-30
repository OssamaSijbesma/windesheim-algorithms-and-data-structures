using System;
using System.Collections.Generic;

namespace Lesson01_Algorithm_Analysis
{
    class Program
    {
        /*
           * ZEEF VAN ERATOSTHENE
           * O(N)
           */
        static void Main(string[] args)
        {
            int N = 1000;
            List<int> primenumbers = new List<int>();

            for (int i = 2; i < N; i++)
            {
                bool isPrime = true;

                foreach (int prime in primenumbers)
                {
                    if (i % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) primenumbers.Add(i);
            }

            foreach (int prime in primenumbers)
            {
                Console.WriteLine(prime);
            }
        }
    }
}
