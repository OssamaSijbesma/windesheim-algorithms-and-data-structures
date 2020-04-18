using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT2
{
    public partial class Edge : IComparable<Edge>
    {
        public Vertex dest;
        public double cost;

        public Edge(Vertex d, double c)
        {
            dest = d;
            cost = c;
        }

        public int CompareTo(Edge other)
        {
            double otherCost = other.cost;
            return cost < otherCost ? -1 : cost > otherCost ? 1 : 0;
        }
    }
}
