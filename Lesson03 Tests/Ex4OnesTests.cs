using Lesson03_Recursion_and_Sorting.Ex4Ones;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson03_Tests
{
    [TestFixture]
    class Ex4OnesTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(7, 3)]
        [TestCase(9, 2)]
        [TestCase(15, 4)]
        [TestCase(16, 1)]
        [TestCase(1024, 1)]

        public void OnesTest(int n, int expected)
        {
            int actual;

            // Arrange

            // Act
            actual = Ones.OnesRecursive(n);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
