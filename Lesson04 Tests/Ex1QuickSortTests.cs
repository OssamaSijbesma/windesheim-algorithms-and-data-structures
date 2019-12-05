using Lesson04_QuickSort_and_Trees;
using Lesson04_QuickSort_and_Trees.Ex1QuickSort;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson04_Tests
{
    [TestFixture]
    public class Ex1QuickSortTests
    {
        [Test, Combinatorial]
        public void Sort(
                    [Values("QuickSort")] string sorterName,
                    [Values(0, 10, 300)] int n)
        {
            List<int> list = new List<int>();
            List<int> listCopy;
            Sorter sorter;
            System.Random random = new System.Random();

            // Arrange
            if (sorterName == "QuickSort")
                sorter = DSBuilder.CreateQuickSorter();
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
