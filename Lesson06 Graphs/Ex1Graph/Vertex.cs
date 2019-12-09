using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson06_Graphs.Ex1Graph
{
    public class Vertex : IVertex
    {
        public string name;             // Vertex name
        public LinkedList<Edge> edges;  // Adjacent vertices
        public double dist;             // Cost to get to this vertex with the last used algorithm
        public Vertex prev;             // Previous vertex on shortest path algorithm
        public int scratch;             // Extra variable used in algorithms

        // Constructor
        public Vertex(string name)
        {
            this.name = name;
            this.edges = new LinkedList<Edge>();
            Reset();
        }

        // Reset the vertex
        public void Reset()
        {
            dist = Graph.INFINITY;
            prev = null;
            scratch = 0;
        }

        // Return a string of this vertex and all its adjacent vertices
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(name);

            if (dist != Graph.INFINITY)
                stringBuilder.Append($"({dist})");

            if (edges.Count != 0) 
            {
                stringBuilder.Append(" [ ");

                foreach (Edge edge in edges)
                    stringBuilder.Append($"{edge.dest.name}({edge.cost}) ");

                stringBuilder.Append("] ");
            }

            return stringBuilder.ToString();
        }
    }
}
