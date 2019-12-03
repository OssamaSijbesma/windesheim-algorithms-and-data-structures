using Lesson03_Recursion_and_Sorting;
using Lesson03_Recursion_and_Sorting.Ex7Sorting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson03_Tests
{
    [TestFixture]
    public class Ex7SortingTests
    {
        [TestCase("InsertionSort", 0)]
        [TestCase("InsertionSort", 10)]
        [TestCase("InsertionSort", 300)]
        [TestCase("MergeSort", 0)]
        [TestCase("MergeSort", 10)]
        [TestCase("MergeSort", 300)]
        [TestCase("ShellSort", 0)]
        [TestCase("ShellSort", 10)]
        [TestCase("ShellSort", 300)]
        public void Sort(string sorterName, int n)
        {
            List<int> list = new List<int>();
            List<int> listCopy;
            Sorter sorter;
            System.Random random = new System.Random();

            // Arrange
            if (sorterName == "InsertionSort")
                sorter = DSBuilder.CreateInsertionSorter();
            else if (sorterName == "MergeSort")
                sorter = DSBuilder.CreateMergeSorter();
            else if (sorterName == "ShellSort")
                sorter = DSBuilder.CreateShellSorter();
            else
                sorter = null;
            Assert.IsNotNull(sorter != null);

            // Arrange
            for (int i = 0; i < n; i++)
                list.Add(random.Next(0, 100000));
            listCopy = new List<int>(list);
            listCopy.Sort();

            // Act
            sorter.Sort(list);

            // Assert
            bool equal = list.SequenceEqual(listCopy);
            Assert.IsTrue(equal);
        }
    }
}
