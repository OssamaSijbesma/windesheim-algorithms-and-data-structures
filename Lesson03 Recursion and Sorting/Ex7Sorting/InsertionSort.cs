using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson03_Recursion_and_Sorting.Ex7Sorting
{
    class InsertionSort : Sorter
    {
        // Insertion sort algorithm
        public override void Sort(List<int> list)
        {
            int tmp;

            // Loop through all items
            for (int i = 1; i < list.Count; i++)
            {
                // Set the item on a temporary location
                tmp = list[i];

                // Check if the current item is smaller than the previous one
                while ((i - 1 >= 0) && (tmp < list[i - 1]))
                {
                    // Move the position of the previous item forward
                    list[i] = list[i - 1];
                    i--;
                }

                // Set the item on the right position
                list[i] = tmp;
            }
        }
    }
}
