using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson04_QuickSort_and_Trees.Ex1QuickSort
{
    public class QuickSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            QuickSorter(list, 0, list.Count - 1);
        }

        // Quick sort algorithm
        private void QuickSorter(List<int> list, int low, int high)
        {
            int cutOff = 2;

            // If the list is to small use the insertion sort
            if (low + cutOff > high)
                InsertionSorter(list);
            else
            {
                // Sort low middle high
                int middle = (low + high) / 2;

                if (list[middle].CompareTo(list[low]) < 0)
                    SwapReferences(list, low, middle);
                if (list[high].CompareTo(list[low]) < 0)
                    SwapReferences(list, low, high);
                if (list[high].CompareTo(list[middle]) < 0)
                    SwapReferences(list, middle, high);

                // Place the pivot at position high -1
                SwapReferences(list, middle, high - 1);
                int pivot = list[high - 1];

                // Begin partitioning
                int i, j;
                for (i = low, j = high; ;)
                {
                    while (list[++i].CompareTo(pivot) < 0) ;
                    while (pivot.CompareTo(list[--j]) < 0) ;
                    if (i >= j)
                        break;
                    SwapReferences(list, i, j);
                }

                // Restore the pivot
                SwapReferences(list, i, high - 1);

                // Sort the smaller elements
                QuickSorter(list, low, i - 1);
                // Sort the bigger elements
                QuickSorter(list, i + 1, high);
            }
        }

        // Insertion sort algorithm
        private void InsertionSorter(List<int> list)
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

        // Swap two items inside a list
        private List<int> SwapReferences(List<int> list, int a, int b)
        {
            int temp = list[a];
            list[a] = list[b];
            list[b] = temp;
            return list;
        }
    }
}
