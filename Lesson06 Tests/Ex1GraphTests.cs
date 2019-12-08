using Lesson06_Graphs;
using Lesson06_Graphs.Ex1Graph;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson06_Tests
{
    [TestFixture]
    public class Ex1GraphTests
    {
        private string StringWithoutSpaces(string s)
        {
            return Regex.Replace(s, @"\s+", "").Trim();
        }

        [Test]
        public void Graph_ToString_OnEmptyGraph()
        {
            // Arrange
            IGraph graph = DSBuilder.CreateGraphEmpty();
            string expected = "";

            // Act
            string actual = StringWithoutSpaces(graph.ToString());

            // Assert
            Assert.AreEqual(expected, actual);

            Assert.Pass();
        }

        [Test]
        public void Graph_ToString_OnGraph14_1()
        {
            // Arrange
            IGraph graph = DSBuilder.CreateGraph14_1();
            string expectedWithSpaces = StringWithoutSpaces("V0 [ V1(2) V3(1) ] V1 [ V3(3) V4(10) ] V2 [ V0(4) V5(5) ] V3 [ V2(2) V5(8) V6(4) V4(2) ] V4 [ V6(6) ] V5 V6 [ V5(1) ]");
            string expected = StringWithoutSpaces(expectedWithSpaces);

            // Act
            string actual = StringWithoutSpaces(graph.ToString());

            // Assert
            Assert.AreEqual(expected, actual);

            Assert.Pass();
        }
    }
}
