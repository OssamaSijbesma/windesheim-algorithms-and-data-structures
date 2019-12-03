using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson03_Recursion_and_Sorting.Ex6ForwardBackwardString
{
    public class ForwardBackwardString
    {
        public static void Run()
        {
            List<int> list = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });

            System.Console.WriteLine(ForwardString(list, 3));
            System.Console.WriteLine(ForwardString(list, 7));
            System.Console.WriteLine(BackwardString(list, 3));
            System.Console.WriteLine(BackwardString(list, 7));
        }

        // Returns the old string from a certain point recursive
        public static string ForwardString(List<int> list, int from)
        {
            if (list.Count <= from || list.Count == 0)
                return "";

            if (list.Count - 1 == from)
                return $"{list[from]}";

            return $"{list[from]} {ForwardString(list, ++from)}";
        }

        // Returns the old string to a certain point recursive
        public static string BackwardString(List<int> list, int to)
        {
            if (list.Count <= to || list.Count == 0)
                return "";

            if (list.Count - 1 == to)
                return $"{list[to]}";

            return $"{BackwardString(list, to+1)} {list[to]}";
        }
    }
}
