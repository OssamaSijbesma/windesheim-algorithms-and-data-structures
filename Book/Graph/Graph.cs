using System;
using System.Collections.Generic;
using System.Text;

using Book.PriorityQueue;

namespace Book.Graph
{
    class Graph
    {
        public static readonly double INFINITY = Double.MaxValue;
        private Dictionary<string, Vertex> vertexDictonary= new Dictionary<string, Vertex>();

        // Add a new edge to the graph
        public void AddEdge(string name, string dest, double cost)
        {
            Vertex oVertex = GetVertex(name);
            Vertex dVertex = GetVertex(name);
            oVertex.edges.AddLast(new Edge(dVertex, cost));
        }

        // Print total cost and handle unreachables
        public void PrintPath(string dest)
        {
            Vertex vertex;
            if (!vertexDictonary.TryGetValue(dest, out vertex))
                throw new Exception();
            else if (vertex.dist == INFINITY)
                Console.WriteLine($"{dest} is unreachable");
            else 
            {
                Console.WriteLine($"(Cost is {vertex.dist})");
                PrintPath(vertex);
            }
        }

        // Single-source unweighted shortest-path algorithm
        public void Unweighted(string startName)
        {
            ClearAll();

            Vertex start;
            if (!vertexDictonary.TryGetValue(startName, out start))
                throw new Exception();

            Queue<Vertex> vQueue = new Queue<Vertex>();
            vQueue.Enqueue(start);
            start.dist = 0;

            while (vQueue.Count > 0)
            {
                Vertex vertex = vQueue.Dequeue();

                foreach (Edge edge in vertex.edges)
                {
                    Vertex destination = edge.dest;
                    if (destination.dist == INFINITY)
                    {
                        destination.dist = vertex.dist + 1;
                        destination.prev = vertex;
                        vQueue.Enqueue(destination);
                    }
                }
            }
        }

        // Dijkstra
        public void Dijkstra(string startName)
        {
            ClearAll();

            Vertex start;
            if (!vertexDictonary.TryGetValue(startName, out start))
                throw new Exception();

            PriorityQueue<Edge> priorityQueue = new PriorityQueue<Edge>();
            priorityQueue.Add(new Edge(start, 0));
            start.dist = 0;

            int nodesSeen = 0;
            while (!priorityQueue.IsEmpty() && nodesSeen < vertexDictonary.Count)
            {
                Edge curEdge = priorityQueue.Remove();
                Vertex vertex = curEdge.dest;

                if (vertex.scratch != 0)
                    continue;

                vertex.scratch = 1;
                nodesSeen++;

                foreach (Edge edge in vertex.edges)
                {
                    Vertex destination = edge.dest;
                    double destCost = edge.cost;

                    if (destCost < 0)
                        throw new Exception();

                    if (destination.dist > vertex.dist + destCost) 
                    {
                        destination.dist = vertex.dist + destCost;
                        destination.prev = vertex;
                        priorityQueue.Add(new Edge(destination, destination.dist));
                    }
                }
            }
        }

        public void Negative(string start)
        { }

        public void Acyclic(string start)
        { }


       
        // Return vertex with that name, when not present, add it to vertexMap
        private Vertex GetVertex(string name)
        {
            Vertex vertex;

            if (!vertexDictonary.TryGetValue(name, out vertex))
            {
                vertex = new Vertex(name);
                vertexDictonary.Add(name, vertex);
            }

            return vertex;
        }

        // Print shortest path to dest
        private void PrintPath(Vertex dest)
        {
            if (dest.prev != null)
            {
                PrintPath(dest.prev);
                Console.WriteLine(" to ");
            }

            Console.WriteLine(dest.name);
        }

        // Clear all vertexes prior to running an algorithm
        private void ClearAll()
        {
            foreach (Vertex vertex in vertexDictonary.Values)
                vertex.Reset();
        }
    }
}
