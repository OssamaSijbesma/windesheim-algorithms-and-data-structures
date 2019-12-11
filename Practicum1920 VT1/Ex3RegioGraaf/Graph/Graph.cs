using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practicum1920_VT1.Ex3RegioGraaf
{
    public class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        protected Dictionary<string, Vertex> vertexMap;


        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!
        //!! Vul deze klasse met je eigen Graph en vul aan
        //!!
        //!! LET OP!
        //!! De namespace is "AD".
        //!! Waarschijnlijk zijn je uitwerkingen van het huiswerk nog "Huiswerk6"
        //!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

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
            vertex.edges.AddLast(new Edge(vertex1, cost));
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

        public bool IsConnected()
        {
            foreach (var vName in vertexMap.Keys)
            {
                Unweighted(vName);

                foreach (var vertex in vertexMap.Values)
                {
                    if (vertex.dist == INFINITY)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented during exam
        //----------------------------------------------------------------------

        public string AllPaths()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Vertex vertex in vertexMap.Values)
            {
                stringBuilder.Append(vertex.name);
                Vertex curVertex = vertex;

                while (curVertex.prev != null)
                {
                    curVertex = curVertex.prev;
                    stringBuilder.Append($"<-{curVertex.name}");
                }

                stringBuilder.Append(";");
            }

            return stringBuilder.ToString();


        }

        public void AddUndirectedEdge(string source, string dest, double cost)
        {
            AddEdge(source, dest, cost);
            AddEdge(dest, source, cost);
        }

        public void AddVertex(string name, string regio)
        {
            vertexMap.Add(name, new Vertex(name, regio));
        }
    }
}
