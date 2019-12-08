using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson06_Graphs.Ex1Graph
{
    public interface IVertex
    {
        void Reset();  // Resets prev, dist and scratch for a vertex
    }
}
