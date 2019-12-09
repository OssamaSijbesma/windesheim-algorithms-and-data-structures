using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson06_Graphs.Ex1Graph
{
    // Represents an entry in the priority queue for Dijkstra's algorithm
    class Path : IComparable<Path>
    {
        public Vertex dest;     // Second vertex in an edge
        public double cost;     // Edge cost

        // Constructor
        public Path(Vertex d, double c)
        {
            dest = d;
            cost = c;
        }

        // Compare function
        public int CompareTo(Path other)
        {
            double otherCost = other.cost;
            return cost < otherCost ? -1 : cost > otherCost ? 1 : 0;
        }
    }
}
