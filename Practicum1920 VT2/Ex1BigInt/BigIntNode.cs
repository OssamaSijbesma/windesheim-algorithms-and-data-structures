using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT2
{
    public class BigIntNode
    {

        public int digit;
        public BigIntNode next;

        public BigIntNode(int digit)
        {
            this.digit = digit;
        }

        public BigIntNode(int digit, BigIntNode next)
        {
            this.digit = digit;
            this.next = next;
        }
    }
}
