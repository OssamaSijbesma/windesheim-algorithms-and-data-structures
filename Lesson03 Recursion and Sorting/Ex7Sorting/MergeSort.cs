using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson03_Recursion_and_Sorting.Ex7Sorting
{
    class MergeSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            List<int> sorted = MergeSorter(list);
            list.Clear();
            list.AddRange(sorted);
        }

        // Merge sort algorithm 
        private List<int> MergeSorter(List<int> list)
        {
            if (list.Count <= 1)
                return list;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            // Split the list into two lists
            for (int i = 0; i < list.Count; i++)
            {
                if (i < (list.Count / 2))
                    left.Add(list[i]);
                else
                    right.Add(list[i]);
            }

            // Split the left and right side again till the size is 1
            left = MergeSorter(left);
            right = MergeSorter(right);

            // Merge the left and right side
            return Merge(left, right);
        }

        // Merge two lists together into one list
        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            // Compare the items left and right and add the smallest one to the result
            while (left.Count != 0 && right.Count != 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            // Add the items remaining items to the result
            while (left.Count != 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }

            // Add the items remaining items to the result
            while (right.Count != 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }

            return result;
        }
    }
}
