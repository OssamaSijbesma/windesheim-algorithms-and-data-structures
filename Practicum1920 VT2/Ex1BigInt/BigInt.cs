using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Practicum1920_VT2
{
    public class BigInt
    {
        public BigIntNode first;

        static int CharToInt(char c)
        {
            return c - '0';
        }

        public BigInt(string number)
        {
            if (number == null || number.Length == 0)
            {
                first = new BigIntNode(0);
                return;
            }

            //
            // A number is either 0 or a series of digits, not starting with 0
            // The following regular expression is used to define a number:
            //    0|[1-9][0-9]*
            //
            Regex number_regex = new Regex(@"^(0|([1-9][0-9]*))$", 0);
            Match match = number_regex.Match(number);

            if (!match.Success)
            {
                throw new BigIntWrongInputException();
            }

            string str = match.Value;

            char[] numbers = str.ToCharArray();

            //
            // From here to below you can start to build your list
            // of BigIntNode's, based on string "str".
            //
            // To convert from character representation to int you can
            // use CharToInt()
            //

            first = new BigIntNode(CharToInt(numbers[0]));

            for (int i = 1; i < numbers.Length; i++)
            {
                first = new BigIntNode(CharToInt(numbers[i]), first);
            }
        }

        public override string ToString() => ToString(first);

        private string ToString(BigIntNode node)
        {
            if (node == null)
                return "";

            return $"{ToString(node.next)}{node.digit}";
        }

        public int Sum() => Sum(first);

        public int Sum(BigIntNode node)
        {
            if (node == null)
                return 0;

            return node.digit + Sum(node.next);
        }

        public void Increment()
        {
            BigIntNode curNode = first;

            while (curNode.digit + 1 > 9)
            {
                curNode.digit = 0;

                if (curNode.next != null)
                    curNode = curNode.next;
                else
                {
                    curNode.next = new BigIntNode(0);
                    curNode = curNode.next;
                }
            }

            curNode.digit++;
        }
    }
    public class BigIntWrongInputException : System.Exception
    {

    }
}
