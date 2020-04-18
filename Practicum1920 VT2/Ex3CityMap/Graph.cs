using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT2
{
    public partial class Graph : IGraph
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

            // Register the startpoint of the algorithm
            Vertex start;
            if (!vertexMap.TryGetValue(name, out start))
                throw new System.Exception();

            // Create a queue with all the nodes to register
            Queue<Vertex> vertices = new Queue<Vertex>();
            vertices.Enqueue(start);
            start.distance = 0;

            // While the queue is not empty
            while (vertices.Count > 0)
            {
                // Dequeue a vertex from the queue
                Vertex vertex = vertices.Dequeue();

                // Foreach all edges of the current vertex
                foreach (Edge edge in vertex.adj)
                {
                    Vertex destVertex = edge.dest;

                    // Check if the node is already visited
                    if (destVertex.distance == INFINITY)
                    {
                        // Set distance en previous vertex
                        destVertex.distance = vertex.distance + 1;
                        destVertex.prev = vertex;
                        // Enqueue the next vertex
                        vertices.Enqueue(destVertex);
                    }
                }
            }
        }

        public void Dijkstra(string name)
        {
            ClearAll();

            // Register the startpoint of the algorithm
            Vertex start;
            if (!vertexMap.TryGetValue(name, out start))
                throw new System.Exception();

            start.InShortestPath = true;

            // Create a priority queue
            PriorityQueue<Edge> priorityQueue = new PriorityQueue<Edge>();
            priorityQueue.Add(new Edge(start, 0));
            start.distance = 0;

            // Amount of nodes seen
            int nodesSeen = 0;

            // Continue while the priority queue still has items and if not all vertexes are seen.
            while (priorityQueue.Size() > 0 && nodesSeen < vertexMap.Count)
            {
                // Get the vertex with the shortest path
                Edge edge = priorityQueue.Remove();
                Vertex vertex = edge.dest;

                if (vertex.known)
                    continue;

                // Scratch vertex
                vertex.known = true;
                nodesSeen++;

                // Foreach all edges en set the distance of those nodes
                foreach (Edge ad in vertex.adj)
                {
                    Vertex destVertex = ad.dest;
                    double edgeCost = ad.cost;

                    if (edgeCost < 0)
                        throw new System.Exception();

                    // Check if the distance is shorter
                    if (destVertex.distance > vertex.distance + edgeCost)
                    {
                        // Set the distance and the vertex where it came from
                        destVertex.distance = vertex.distance + edgeCost;
                        destVertex.prev = vertex;
                        // Add vertex to the priority queue
                        priorityQueue.Add(new Edge(destVertex, destVertex.distance));
                    }
                }
            }
        }

        public bool IsConnected()
        {
            throw new System.NotImplementedException();
        }


        //----------------------------------------------------------------------
        // Methods to be implemented during exam
        //----------------------------------------------------------------------

        public static Graph MakeCityMap()
        {
            Graph graph = new Graph();

            graph.AddEdge("Utrecht", "Arnhem", 6);
            graph.AddEdge("Utrecht", "Den Bosch", 2);

            graph.AddEdge("Arnhem", "Utrecht", 5);
            graph.AddEdge("Arnhem", "Maastricht", 5);

            graph.AddEdge("Den Bosch", "Utrecht", 2);
            graph.AddEdge("Den Bosch", "Maastricht", 7);
            graph.AddEdge("Den Bosch", "Tilburg", 3);

            graph.AddEdge("Maastricht", "Arnhem", 4);
            graph.AddEdge("Maastricht", "Den Bosch", 6);

            graph.AddEdge("Tilburg", "Den Bosch", 4);

            return graph;
        }

        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented during exam
        //----------------------------------------------------------------------

        public List<string> VerticesNotOnShortestPath(string origin,
                                       string destination)
        {
            Dijkstra(origin);

            Vertex target;
            if (!vertexMap.TryGetValue(destination, out target))
                throw new System.Exception();

            while (target.prev != null)
            {
                target.InShortestPath = true;
                target = target.prev;
            }

            List<string> names = new List<string>();

            foreach (Vertex vertex in vertexMap.Values)
                if (!vertex.InShortestPath)
                    names.Add(vertex.name);

            return names;
        }
    }
}
