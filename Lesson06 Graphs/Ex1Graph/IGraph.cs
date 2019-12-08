using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson06_Graphs.Ex1Graph
{
    public interface IGraph
    {
        //----------------------------------------------------------------------
        // Methods that have to be implemented for exam
        //----------------------------------------------------------------------
        Vertex GetVertex(string name);
        void AddEdge(string source, string dest, double cost);
        void ClearAll();

        //----------------------------------------------------------------------
        // Methods that have to be implemented for homework
        //----------------------------------------------------------------------
        void Unweighted(string name);
        void Dijkstra(string name);
        bool IsConnected();
    }
}
