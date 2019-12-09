using System;
using System.Collections.Generic;
using System.Text;

namespace OefenTentamen.Ex4Graph
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
