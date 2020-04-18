using NUnit.Framework;
using Practicum1920_VT2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT2_Tests
{
    public class BigIntTests
    {
        [Test, Sequential]
        public void BigInt_1_Constructor_1_WrongInput(
        [Values(
                "-3", "34.5", "54e2", "abc"
            )]
            string input)
        {
            // Arrange
            BigInt b;

            // Act

            // Assert
            Assert.Throws(typeof(BigIntWrongInputException), () => b = new BigInt(input));
        }
        [Test, Sequential]
        public void BigInt_1_Constructor_2_OneDigitInput_1_FirstAndNextOk(
            [Values(
                null,
                "0",
                "1",
                "7"
            )]
            string input)
        {
            // Arrange
            BigInt b;

            // Act
            b = new BigInt(input);

            // Assert
            Assert.IsNotNull(b.first);
            Assert.IsNull(b.first.next);
        }
        [Test, Sequential]
        public void BigInt_1_Constructor_2_OneDigitInput_2_FirstHasCorrectData(
                [Values(
                    null,
                    "0",
                    "1",
                    "7"
                )]
            string input,
                [Values(
                    0,
                    0,
                    1,
                    7
                )]
            int expected)
        {
            // Arrange
            BigInt b;

            // Act
            b = new BigInt(input);
            int actual = b.first.digit;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test, Sequential]
        public void BigInt_1_Constructor_3_BiggerNumbers(
                [Values(
                    "123",
                    "12345678",
                    "120",
                    "987600",
                    "397513948752134619234601348570923475093247562304865"
                )]
            string input)
        {
            // Arrange
            BigInt b;

            // Act
            b = new BigInt(input);

            // Assert
            BigIntNode n = b.first;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                Assert.IsNotNull(n);
                Assert.AreEqual(input[i] - '0', n.digit);
                n = n.next;
            }
        }
        [Test, Sequential]
        public void BigInt_2_ToString(
                [Values(
                    "123",
                    "12345678",
                    "120",
                    "987600",
                    "397513948752134619234601348570923475093247562304865"
                )]
            string input)
        {
            // Arrange
            BigInt b = new BigInt(input);
            string expected = input;

            // Act
            string actual = b.ToString();

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [Test, Sequential]
        public void BigInt_3_Sum(
                [Values(
                    "123",
                    "111",
                    null
                )]
            string input,
                [Values(
                    6,
                    3,
                    0
                )]
            int expected)
        {
            // Arrange
            BigInt b = new BigInt(input);

            // Act
            int actual = b.Sum();

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [Test, Sequential]
        public void BigInt_4_Increment(
                [Values(
                    "123",
                    "12345678",
                    "120",
                    "99999999999999999999999999999999",
                    "99999999999999999799999999999999"
                )]
            string input,
                [Values(
                    "124",
                    "12345679",
                    "121",
                    "100000000000000000000000000000000",
                    "99999999999999999800000000000000"
                )]
            string expected)
        {
            // Arrange
            BigInt b = new BigInt(input);

            // Act
            b.Increment();
            string actual = b.ToString();

            // Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
