using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT2
{
    public partial class Vertex : IVertex
    {
        public string name;
        public LinkedList<Edge> adj;
        public double distance;
        public Vertex prev;
        public bool known;
        public bool InShortestPath;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Vertex(string name)
        {
            this.name = name;
            this.adj = new LinkedList<Edge>();
            Reset();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public void Reset()
        {
            distance = Graph.INFINITY;
            prev = null;
            known = false;
        }


        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(name);

            if (distance != Graph.INFINITY)
                stringBuilder.Append($"({distance})");

            if (adj.Count != 0)
            {
                stringBuilder.Append(" [ ");

                foreach (Edge edge in adj)
                    stringBuilder.Append($"{edge.dest.name}({edge.cost}) ");

                stringBuilder.Append("] ");
            }

            return stringBuilder.ToString();
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented during exam
        //----------------------------------------------------------------------

        public int Outgoing()
        {
            return adj.Count;
        }
    }
}
