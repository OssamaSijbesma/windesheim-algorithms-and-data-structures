using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Graph
{
    // Represents a vertex in the graph
    class Vertex
    {
        public string name;             // Vertex name
        public LinkedList<Edge> edges;  // Adjacent vertices
        public double dist;             // Cost
        public Vertex prev;             // Previous vertex on shortest path
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
    }
}
