using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson03_Recursion_and_Sorting.Ex3Alternately
{
    public class Alternately
    {
        public static void Run()
        {
            int MAX = 20;

            for (int n = 0; n < MAX; n++)
            {
                System.Console.WriteLine("          OmEnOm({0,2}) = {1,3}", n, AlternatelyRecursive(n));
            }
        }

        // Som van om en om recursief 
        public static int AlternatelyRecursive(int n)
        {
            if (n < 0)
                throw new OmEnOmNegativeValueException();

            if (n == 1) return 1;
            if (n == 0) return 0;
            return n + AlternatelyRecursive(n - 2);
        }
    }
    public class OmEnOmNegativeValueException : Exception
    {
    }
}
