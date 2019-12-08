using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson06_Graphs.Ex1Graph
{
    public class Vertex : IVertex
    {
        public string name;             // Vertex name
        public LinkedList<Edge> adj;    // Adjacent vertices
        public double dist;             // Cost
        public Vertex prev;             // Previous vertex on shortest path
        public int scratch;             // Extra variable used in algorithm

        public Vertex(string name)
        {
            this.name = name;
            this.adj = new LinkedList<Edge>();
            Reset();
        }

        public void Reset()
        {
            dist = Graph.INFINITY;
            prev = null;
            scratch = 0;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(name);

            if (dist != Graph.INFINITY)
                stringBuilder.Append($"({dist})");

            if (adj.Count != 0) 
            {
                stringBuilder.Append(" [ ");

                foreach (Edge edge in adj)
                    stringBuilder.Append($"{edge.dest.name}({edge.cost}) ");

                stringBuilder.Append("] ");
            }

            return stringBuilder.ToString();
        }
    }
}
