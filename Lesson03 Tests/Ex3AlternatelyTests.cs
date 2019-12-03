using Lesson03_Recursion_and_Sorting.Ex3Alternately;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson03_Tests
{
    [TestFixture]
    class Ex3AlternatelyTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(10, 30)]
        [TestCase(17, 81)]
        [TestCase(19, 100)]
        public void AlternatelyTest(int n, long expected)
        {
            int actual;

            // Arrange

            // Act
            actual = Alternately.AlternatelyRecursive(n);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(-1)]
        [TestCase(-10)]
        public void Alternately_ThrowingExceptionOnNegativeInput(int n)
        {
            // Arrange

            // Act & Assert
            Assert.Throws(typeof(OmEnOmNegativeValueException), () => Alternately.AlternatelyRecursive(n));
        }
    }
}
