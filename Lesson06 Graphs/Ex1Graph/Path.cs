using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson06_Graphs.Ex1Graph
{
    class Path : IComparable<Path>
    {
        public Vertex dest;
        public double cost;

        public Path(Vertex d, double c)
        {
            dest = d;
            cost = c;
        }

        public int CompareTo(Path other)
        {
            double otherCost = other.cost;
            return cost < otherCost ? -1 : cost > otherCost ? 1 : 0;
        }
    }
}
