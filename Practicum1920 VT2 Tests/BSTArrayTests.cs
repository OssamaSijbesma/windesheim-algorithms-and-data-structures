using NUnit.Framework;
using Practicum1920_VT2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT2_Tests
{
    public class BSTArrayTests
    {
        public static BSTArray BuildBSTArrayOne()
        {
            BSTArray a = new BSTArray();
            a.tree[0] = new BSTNode(42);
            a.root = 0;

            return a;
        }

        public static BSTArray BuildBSTArraySmall()
        {
            // Same as:
            // Add 4, 2, 7
            // But then hardcoded
            BSTArray a = new BSTArray();
            a.tree[0] = new BSTNode(4);
            a.tree[1] = new BSTNode(2);
            a.tree[2] = new BSTNode(7);
            a.tree[0].left = 1;
            a.tree[0].right = 2;
            a.root = 0;

            return a;
        }

        public static BSTArray BuildBSTArrayBig()
        {
            // Same as:
            // Add 50, 80, 20, 10, 30, 70, 90, 60, 40
            // But then hardcoded
            BSTArray a = new BSTArray();
            a.tree[0] = new BSTNode(50);
            a.tree[1] = new BSTNode(80);
            a.tree[2] = new BSTNode(20);
            a.tree[3] = new BSTNode(10);
            a.tree[4] = new BSTNode(30);
            a.tree[5] = new BSTNode(70);
            a.tree[6] = new BSTNode(90);
            a.tree[7] = new BSTNode(60);
            a.tree[8] = new BSTNode(40);
            a.tree[0].left = 2;
            a.tree[0].right = 1;
            a.tree[1].left = 5;
            a.tree[1].right = 6;
            a.tree[2].left = 3;
            a.tree[2].right = 4;
            a.tree[4].right = 8;
            a.tree[5].left = 7;
            a.root = 0;

            return a;
        }

        [Test]
        public void BSTArray_1_Add_1_One()
        {
            // Arrange
            BSTArray a = new BSTArray();

            // Act
            a.Add(3);

            // Assert
            Assert.AreEqual(0, a.root);
            Assert.AreEqual(3, a.tree[0].data);
            Assert.AreEqual(BSTNode.UNDEFINED, a.tree[0].left);
            Assert.AreEqual(BSTNode.UNDEFINED, a.tree[0].right);
        }
        [Test]
        public void BSTArray_1_Add_2_Three()
        {
            // Arrange
            BSTArray a = new BSTArray();

            // Act
            a.Add(3);
            a.Add(5);
            a.Add(4);

            // Assert
            Assert.AreEqual(0, a.root);
            Assert.AreEqual(3, a.tree[0].data);
            Assert.AreEqual(5, a.tree[1].data);
            Assert.AreEqual(4, a.tree[2].data);
            Assert.AreEqual(BSTNode.UNDEFINED, a.tree[0].left);
            Assert.AreEqual(1, a.tree[0].right);
            Assert.AreEqual(2, a.tree[1].left);
            Assert.AreEqual(BSTNode.UNDEFINED, a.tree[1].right);
            Assert.AreEqual(BSTNode.UNDEFINED, a.tree[2].left);
            Assert.AreEqual(BSTNode.UNDEFINED, a.tree[2].right);
        }
        [Test, Sequential]
        public void BSTArray_2_Contains_1_OnBSTArrayEmpty()
        {
            // Arrange
            BSTArray a = new BSTArray();
            bool expected = false;

            // Act
            bool actual = a.Contains(42);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test, Sequential]
        public void BSTArray_2_Contains_2_OnBSTArrayBig(
            [Values(
                50,
                20,
                70,
                35,
                45,
                90,
                10,
                100
            )]
            int input,
            [Values(
                true,
                true,
                true,
                false,
                false,
                true,
                true,
                false)]
            bool expected)
        {
            // Arrange
            BSTArray a = BuildBSTArrayBig();

            // Act
            bool actual = a.Contains(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BSTArray_3_GetPreOrder_1_OnBSTArrayEmpty()
        {
            // Arrange
            BSTArray a = new BSTArray();
            string expected = "";

            // Act
            string actual = TestUtils.StringWithoutSpaces(a.GetPreOrder());

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BSTArray_3_GetPreOrder_1_OnBSTArraySmall()
        {
            // Arrange
            BSTArray a = BuildBSTArraySmall();
            string expected = "4,2,7";

            // Act
            string actual = TestUtils.StringWithoutSpaces(a.GetPreOrder());

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BSTArray_3_GetPreOrder_2_OnBSTArrayBig()
        {
            // Arrange
            BSTArray a = BuildBSTArrayBig();
            string expected = "50,20,10,30,40,80,70,60,90";

            // Act
            string actual = TestUtils.StringWithoutSpaces(a.GetPreOrder());

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BSTArray_4_Remove_1_OnBSTArrayOne()
        {
            // Arrange
            BSTArray a = BuildBSTArrayOne();
            string expected = "";

            // Act
            a.Remove(42);
            string actual = TestUtils.StringWithoutSpaces(a.GetPreOrder());

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test, Sequential]
        public void BSTArray_4_Remove_2_OnBSTArrayBig(
            [Values(
                10,
                30,
                70,
                50,
                80
            )]
            int input,
            [Values(
                "50,20,30,40,80,70,60,90",
                "50,20,10,40,80,70,60,90",
                "50,20,10,30,40,80,60,90",
                "60,20,10,30,40,80,70,90",
                "50,20,10,30,40,90,70,60")]
            string expected)
        {
            // Arrange
            BSTArray a = BuildBSTArrayBig();

            // Act
            Assert.IsTrue(a.Contains(input));
            a.Remove(input);
            string actual = TestUtils.StringWithoutSpaces(a.GetPreOrder());

            // Assert
            Assert.IsFalse(a.Contains(input));
            Assert.AreEqual(expected, actual);
        }
    }
}
