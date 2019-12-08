using Lesson02_Basic_Data_Structures.Ex3Stack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson02_Basic_Data_Structures.Ex4BracketChecker
{
    public static class BracketChecker
    {
        public static bool CheckBrackets(string s)
        {
            Dictionary<char, char> oppositesDictionary = new Dictionary<char, char>
            {
                {'(', ')'}
            };
            return CheckBrackets(s, oppositesDictionary);
        }

        public static bool CheckBrackets2(string s)
        {
            Dictionary<char, char> oppositesDictionary = new Dictionary<char, char>
            {
                {'(', ')'},
                {'[', ']'},
                {'{', '}'},
            };

            return CheckBrackets(s, oppositesDictionary);
        }

        // Check the brackets with a stack implementation.
        private static bool CheckBrackets(string s, IReadOnlyDictionary<char, char> oppositesDictionary)
        {
            char[] chars = s.ToCharArray();

            IMyStack<char> charStack = new MyStack<char>();

            foreach (char c in chars)
            {
                if (oppositesDictionary.ContainsKey(c))
                    charStack.Push(c);
                else if (charStack.IsEmpty())
                    return false;
                else if (oppositesDictionary[charStack.Top()] == c)
                    charStack.Pop();
            }

            return charStack.IsEmpty();
        }
    }
}
