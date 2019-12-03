using Lesson03_Recursion_and_Sorting.Ex7Sorting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson03_Recursion_and_Sorting
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public class DSBuilder
    {
        public static Sorter CreateInsertionSorter()
        {
            return new InsertionSort();
        }

        public static Sorter CreateMergeSorter()
        {
            return new MergeSort();
        }

        public static Sorter CreateShellSorter()
        {
            return new ShellSort();
        }

    }
}
