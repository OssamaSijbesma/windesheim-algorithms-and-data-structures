using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson06_Graphs.Ex1Graph
{
    public class Edge
    {
        public Vertex dest;     // Second vertex in an edge
        public double cost;     // Edge cost

        // constructor
        public Edge(Vertex d, double c)
        {
            dest = d;
            cost = c;
        }
    }
}
