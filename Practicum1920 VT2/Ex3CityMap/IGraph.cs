using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT2
{
    public interface IGraph
    {
        //----------------------------------------------------------------------
        // Methods that have to be implemented for exam
        //----------------------------------------------------------------------

        // Returns a vertex from the graph by name
        // If there is no such vertex, one is added
        Vertex GetVertex(string name);
        void AddEdge(string source, string dest, double cost);
        void ClearAll();

        //----------------------------------------------------------------------
        // Methods that have to be implemented for homework
        //----------------------------------------------------------------------
        void Unweighted(string name);
        void Dijkstra(string name);
        bool IsConnected();

        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented during exam
        //----------------------------------------------------------------------
        List<string> VerticesNotOnShortestPath(string origin,
                                               string destination);
    }
}
