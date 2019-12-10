using OefenTentamen.PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OefenTentamen.Ex4Graph
{
    public class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;
        private Dictionary<string, Vertex> vertexMap;

        // Constructor
        public Graph()
        {
            vertexMap = new Dictionary<string, Vertex>();
        }

        public void FillDistance(string name)
        {
            Vertex target;
            if (!vertexMap.TryGetValue(name, out target))
                throw new System.Exception();

            Queue<double> results = new Queue<double>();

            foreach (Vertex vertex in vertexMap.Values)
            {
                Unweighted(vertex.name);
                
                results.Enqueue( (target.dist == INFINITY) ? -1 : target.dist);
            };

            ClearAll();

            foreach (Vertex vertex in vertexMap.Values)
                vertex.dist = results.Dequeue();
        }

        public void ShowDistance()
        {
            foreach (Vertex vertex in vertexMap.Values)
                Console.WriteLine($"{vertex.name} ({vertex.dist})");
        }

        public void ShowCyles() 
        {
            foreach (Vertex vertex in vertexMap.Values)
                Console.WriteLine($"{vertex.name} ({HasCycle(vertex.name)})");
        }

        public bool HasCycle(string name) 
        {
            ClearAll();

            Vertex target;
            if (!vertexMap.TryGetValue(name, out target))
                throw new System.Exception();

            Stack<Vertex> vertices = new Stack<Vertex>();
            vertices.Push(target);

            while (vertices.Count != 0)
            {
                Vertex curVertex = vertices.Pop();

                if (curVertex.scratch == 0)
                {
                    curVertex.scratch = 1;
                    foreach (Edge edge in curVertex.edges)
                    {
                        if (edge.dest == target)
                            return true;

                        vertices.Push(edge.dest); 
                    }
                }
            }

            return false;    
        }

        // Return a vertex if it's not in the dictonary add one
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

        // Add a new edge to the graph
        public void AddEdge(string source, string dest, double cost)
        {
            Vertex vertex = GetVertex(source);
            Vertex vertex1 = GetVertex(dest);
            vertex.edges.AddLast(new Edge(vertex1, cost));
        }

        // Clear all vertexes
        public void ClearAll()
        {
            foreach (Vertex vertex in vertexMap.Values)
                vertex.Reset();
        }

        // To string of this graph
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Vertex vertex in vertexMap.Values)
                stringBuilder.AppendLine(vertex.ToString());

            return stringBuilder.ToString();
        }

        // Unweighted algorithm
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

                foreach (Edge edge in vertex.edges)
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

        // Dijkstra algorithm
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

                foreach (Edge edge in v.edges)
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

        // Check if all nodes are connected
        public bool IsConnected()
        {
            bool CanReachNode(Vertex nodeOne, Vertex nodeTwo, IEnumerable<Vertex> visitedNodes)
            {
                if (nodeOne.edges.Any(edge => edge.dest == nodeTwo)) return true;

                if (nodeOne.edges.Count == 0) return false;

                ICollection<Vertex> newVisitedNodes = new LinkedList<Vertex>(visitedNodes);
                newVisitedNodes.Add(nodeOne);

                return nodeOne.edges.Where(edge => !newVisitedNodes.Contains(edge.dest))
                                .Select(edge => CanReachNode(edge.dest, nodeTwo, newVisitedNodes))
                                .FirstOrDefault();
            }

            bool CanReachAllNodes(Vertex vertex) => this.vertexMap.Values.All(otherVertex => CanReachNode(vertex, otherVertex, new List<Vertex>()));

            return this.vertexMap.Values.All(CanReachAllNodes);
        }
    }
}
