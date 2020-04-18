using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT2
{
    public class BSTNode
    {
        public const int UNDEFINED = -1;

        public int data = UNDEFINED;
        public int left = UNDEFINED;
        public int right = UNDEFINED;

        public BSTNode()
        {
        }
        public BSTNode(int data)
        {
            this.data = data;
        }
    }
}
