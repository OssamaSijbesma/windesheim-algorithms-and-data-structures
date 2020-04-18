using NUnit.Framework;
using Practicum1920_VT2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT2_Tests
{
    public class CityMapTests
    {

        [Test]
        public void Graph_1_MakeCityMap_Outgoing()
        {
            Graph graph = Graph.MakeCityMap();
            Assert.AreEqual(graph.GetVertex("Den Bosch").Outgoing(), 3);
            Assert.AreEqual(graph.GetVertex("Arnhem").Outgoing(), 2);
            Assert.AreEqual(graph.GetVertex("Maastricht").Outgoing(), 2);
            Assert.AreEqual(graph.GetVertex("Utrecht").Outgoing(), 2);
            Assert.AreEqual(graph.GetVertex("Tilburg").Outgoing(), 1);
        }

        [Test]
        public void Graph_2_VerticesNotOnShortesPath_1_Tilburg_Arnhem()
        {
            Graph graph = Graph.MakeCityMap();
            string[] exp_U_A = { "Maastricht" };
            List<string> res_U_A = graph.VerticesNotOnShortestPath("Tilburg", "Arnhem");
            res_U_A.Sort();
            CollectionAssert.AreEquivalent(exp_U_A, res_U_A.ToArray());
        }

        [Test]
        public void Graph_2_VerticesNotOnShortestPath_2_Utrecht_Arnhem()
        {
            Graph graph = Graph.MakeCityMap();
            string[] exp_U_A = { "Maastricht", "Den Bosch", "Tilburg" };
            List<string> res_U_A = graph.VerticesNotOnShortestPath("Utrecht", "Arnhem");
            res_U_A.Sort();
            CollectionAssert.AreEquivalent(exp_U_A, res_U_A.ToArray());
        }
    }
}
