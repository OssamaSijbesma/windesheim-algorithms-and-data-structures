using System;
using System.Collections.Generic;
using System.Text;

namespace OefenTentamen.Ex1Recursion
{
    public static class Recursion
    {
        public static string PrintLetters(int i) 
        {
            if (i == 0)
                return default;

            return $"A{PrintLetters(--i)}Z";
        }

        public static string PrintLetters2(int i, int j)
        {
            if (i == 0 && j == 0)
                return default;
            else if (i == 0)
                return $"{PrintLetters2(i, --j)}Z";
            else if (j == 0)
                return $"A{PrintLetters2(--i, j)}";

            return $"A{PrintLetters2(--i, --j)}Z";
        }
    }
}
