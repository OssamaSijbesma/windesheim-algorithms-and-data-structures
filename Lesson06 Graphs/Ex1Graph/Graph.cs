using Lesson06_Graphs.PriorityQueue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson06_Graphs.Ex1Graph
{
    public class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;
        private Dictionary<string, Vertex> vertexMap;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph()
        {
            vertexMap = new Dictionary<string, Vertex>();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public Vertex GetVertex(string name)
        {
            Vertex vertex;
            if (vertexMap.TryGetValue(name, out vertex))
                return vertex;
            else
            {
                vertex = new Vertex(name);
                vertexMap.Add(name, vertex);
                return vertex;
            }
        }

        public void AddEdge(string source, string dest, double cost)
        {
            Vertex vertex = GetVertex(source);
            Vertex vertex1 = GetVertex(dest);
            vertex.adj.AddLast(new Edge(vertex1, cost));
        }

        public void ClearAll()
        {
            foreach (Vertex vertex in vertexMap.Values)
                vertex.Reset();
        }


        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Vertex vertex in vertexMap.Values)
                stringBuilder.AppendLine(vertex.ToString());

            return stringBuilder.ToString();
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void Unweighted(string name)
        {
            ClearAll();

            Vertex start;
            if (!vertexMap.TryGetValue(name, out start))
                throw new System.Exception();

            Queue<Vertex> vertices = new Queue<Vertex>();
            vertices.Enqueue(start);
            start.dist = 0;

            while (vertices.Count > 0)
            {
                Vertex vertex = vertices.Dequeue();

                foreach (Edge edge in vertex.adj)
                {
                    Vertex vertex1 = edge.dest;

                    if (vertex1.dist == INFINITY)
                    {
                        vertex1.dist = vertex.dist + 1;
                        vertex1.prev = vertex;
                        vertices.Enqueue(vertex1);
                    }
                }
            }
        }

        public void Dijkstra(string name)
        {
            PriorityQueue<Path> priorityQueue = new PriorityQueue<Path>();

            Vertex start;
            if (!vertexMap.TryGetValue(name, out start))
                throw new System.Exception();

            ClearAll();
            priorityQueue.Add(new Path(start, 0));
            start.dist = 0;

            int nodesSeen = 0;
            while (priorityQueue.Size() > 0 && nodesSeen < vertexMap.Count)
            {
                Path vrec = priorityQueue.Remove();
                Vertex v = vrec.dest;

                if (v.scratch != 0)
                    continue;

                v.scratch = 1;
                nodesSeen++;

                foreach (Edge edge in v.adj)
                {
                    Vertex vertex = edge.dest;
                    double cvw = edge.cost;

                    if (cvw < 0)
                        throw new System.Exception();

                    if (vertex.dist > v.dist + cvw)
                    {
                        vertex.dist = v.dist + cvw;
                        vertex.prev = v;
                        priorityQueue.Add(new Path(vertex, vertex.dist));
                    }
                }
            }
        }

        public bool IsConnected()
        {
            throw new System.NotImplementedException();
        }
    }
}
