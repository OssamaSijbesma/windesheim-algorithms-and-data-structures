using Lesson06_Graphs.PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson06_Graphs.Ex1Graph
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

            // Register the startpoint of the algorithm
            Vertex start;
            if (!vertexMap.TryGetValue(name, out start))
                throw new System.Exception();

            // Create a queue with all the nodes to register
            Queue<Vertex> vertices = new Queue<Vertex>();
            vertices.Enqueue(start);
            start.dist = 0;
            
            // While the queue is not empty
            while (vertices.Count > 0)
            {
                // Dequeue a vertex from the queue
                Vertex vertex = vertices.Dequeue();

                // Foreach all edges of the current vertex
                foreach (Edge edge in vertex.edges)
                {
                    Vertex destVertex = edge.dest;

                    // Check if the node is already visited
                    if (destVertex.dist == INFINITY)
                    {
                        // Set distance en previous vertex
                        destVertex.dist = vertex.dist + 1;
                        destVertex.prev = vertex;
                        // Enqueue the next vertex
                        vertices.Enqueue(destVertex);
                    }
                }
            }
        }

        // Dijkstra algorithm
        public void Dijkstra(string name)
        {
            ClearAll();

            // Register the startpoint of the algorithm
            Vertex start;
            if (!vertexMap.TryGetValue(name, out start))
                throw new System.Exception();

            // Create a priority queue
            PriorityQueue<Path> priorityQueue = new PriorityQueue<Path>();
            priorityQueue.Add(new Path(start, 0));
            start.dist = 0;

            // Amount of nodes seen
            int nodesSeen = 0;

            // Continue while the priority queue still has items and if not all vertexes are seen.
            while (priorityQueue.Size() > 0 && nodesSeen < vertexMap.Count)
            {
                // Get the vertex with the shortest path
                Path path = priorityQueue.Remove();
                Vertex vertex = path.dest;

                if (vertex.scratch != 0)
                    continue;

                // Scratch vertex
                vertex.scratch = 1;
                nodesSeen++;

                // Foreach all edges en set the distance of those nodes
                foreach (Edge edge in vertex.edges)
                {
                    Vertex destVertex = edge.dest;
                    double edgeCost = edge.cost;

                    if (edgeCost < 0)
                        throw new System.Exception();

                    // Check if the distance is shorter
                    if (destVertex.dist > vertex.dist + edgeCost)
                    {
                        // Set the distance and the vertex where it came from
                        destVertex.dist = vertex.dist + edgeCost;
                        destVertex.prev = vertex;
                        // Add vertex to the priority queue
                        priorityQueue.Add(new Path(destVertex, destVertex.dist));
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
