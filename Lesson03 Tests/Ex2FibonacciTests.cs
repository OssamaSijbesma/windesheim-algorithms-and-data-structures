using Lesson03_Recursion_and_Sorting.Ex2Fibonacci;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson03_Tests
{
    [TestFixture]
    public class Ex2FibonacciTests
    {
        [TestCase("iterative", 1, 1)]
        [TestCase("iterative", 9, 34)]
        [TestCase("iterative", 13, 233)]
        [TestCase("iterative", 21, 10946)]
        [TestCase("recursive", 1, 1)]
        [TestCase("recursive", 9, 34)]
        [TestCase("recursive", 13, 233)]
        [TestCase("recursive", 21, 10946)]

        public void FibonacciTest(string fun, int n, long expected)
        {
            long actual;
            System.Func<int, long> f = null;

            // Arrange
            if (fun == "iterative")
                f = (x) => Fibonacci.FibonacciIterative(x);
            else if (fun == "recursive")
                f = (x) => Fibonacci.FibonacciRecursive(x);
            Assume.That(f != null);

            // Act
            actual = f(n);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
