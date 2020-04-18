using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT2
{
    public partial interface IVertex
    {

        void Reset();  // Resets prev, distance and known for a vertex


        //----------------------------------------------------------------------
        // Methods that have to be implemented during exam
        //----------------------------------------------------------------------
        int Outgoing();
    }
}
