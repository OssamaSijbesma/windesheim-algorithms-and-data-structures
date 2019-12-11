using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT1.Ex3RegioGraaf
{
    public class Edge
    {
        public Vertex dest;
        public double cost;

        public Edge(Vertex d, double c)
        {
            dest = d;
            cost = c;
        }
    }
}
