using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Book.Graph
{
    // Represents an edge in the graph
    class Edge : IComparable<Edge>
    {
        public Vertex dest;     // Second vertex in Edge
        public double cost;     // Edge cost

        // Constructor
        public Edge(Vertex dest, double cost) 
        {
            this.dest = dest;
            this.cost = cost;
        }

        public int CompareTo(Edge edge)
        {
            double otherCost = edge.cost;

            return cost < otherCost ? -1 : cost > otherCost ? 1 : 0;
        }
    }
}
