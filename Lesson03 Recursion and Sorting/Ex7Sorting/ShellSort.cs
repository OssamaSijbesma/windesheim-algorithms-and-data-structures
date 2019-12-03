using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson03_Recursion_and_Sorting.Ex7Sorting
{
    class ShellSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            int j;

            // Marcin Ciura's gap sequence.
            //int[] gaps = new int[] { 701, 301, 132, 57, 23, 10, 4, 1 };

            // Gap sequence school.
            int[] gaps = new int[] { 5, 3, 1 };

            // Start with the largest gap and work down to a gap of 1.
            for (int gap = 0; gap < gaps.Length; gap++)
            {

                // Do a gapped insertion sort for this gap size.
                for (int i = gap; i < list.Count; i++)
                {
                    // Save list[i] in temp and make a hole at position i.
                    int temp = list[i];

                    // Shift earlier gap-sorted elements up until the correct location for list[i] is found.
                    for (j = i; j >= gap && list[j - gap] > temp; j -= gap)
                    {
                        list[j] = list[j - gap];
                    }

                    // Put temp (the original list[i]) in its correct location.
                    list[j] = temp;
                }
            }
        }
    }
}
