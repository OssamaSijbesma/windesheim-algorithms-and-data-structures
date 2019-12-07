using Lesson05_Binary_Trees.Ex1BinarySearchTree;
using Lesson05_Binary_Trees.Ex2PriorityQueue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson05_Binary_Trees
{
    public class DSBuilder
    {
        public static IBinarySearchTree<int> CreateBinarySearchTreeIntEmpty()
        {
            BinarySearchTree<int> t = new BinarySearchTree<int>();
            return t;
        }

        public static IBinarySearchTree<int> CreateBinarySearchTreeInt1Element()
        {
            BinaryNode<int> t4 = new BinaryNode<int>(4, null, null);

            BinarySearchTree<int> t = new BinarySearchTree<int>();
            t.root = t4;
            return t;
        }

        //
        //         6
        //       /   \
        //     4       7
        //    / \
        //   2   5
        //
        public static IBinarySearchTree<int> CreateBinarySearchTreeIntSmall()
        {
            BinaryNode<int> t2 = new BinaryNode<int>(2, null, null);
            BinaryNode<int> t5 = new BinaryNode<int>(5, null, null);
            BinaryNode<int> t7 = new BinaryNode<int>(7, null, null);
            BinaryNode<int> t4 = new BinaryNode<int>(4, t2, t5);
            BinaryNode<int> t6 = new BinaryNode<int>(6, t4, t7);

            BinarySearchTree<int> t = new BinarySearchTree<int>();
            t.root = t6;
            return t;
        }
        public static IBinarySearchTree<int> CreateBinarySearchTreeIntModerate()
        {
            BinaryNode<int> t7 = new BinaryNode<int>(7, null, null);
            BinaryNode<int> t12 = new BinaryNode<int>(12, null, null);
            BinaryNode<int> t24 = new BinaryNode<int>(24, null, null);
            BinaryNode<int> t37 = new BinaryNode<int>(37, null, null);
            BinaryNode<int> t50 = new BinaryNode<int>(50, null, null);
            BinaryNode<int> t8 = new BinaryNode<int>(8, t7, t12);
            BinaryNode<int> t3 = new BinaryNode<int>(3, null, t8);
            BinaryNode<int> t42 = new BinaryNode<int>(42, t37, null);
            BinaryNode<int> t34 = new BinaryNode<int>(34, null, t42);
            BinaryNode<int> t45 = new BinaryNode<int>(45, t34, t50);
            BinaryNode<int> t32 = new BinaryNode<int>(32, null, t45);
            BinaryNode<int> t26 = new BinaryNode<int>(26, t24, t32);
            BinaryNode<int> t17 = new BinaryNode<int>(17, t3, t26);

            BinarySearchTree<int> t = new BinarySearchTree<int>();
            t.root = t17;
            return t;
        }

        public static IPriorityQueue<int> CreatePriorityQueueEmpty()
        {
            PriorityQueue<int> q = new PriorityQueue<int>();
            return q;
        }

        //
        //          1
        //        /   \
        //      3       5
        //     /
        //    4
        //
        public static IPriorityQueue<int> CreatePriorityQueueSmall()
        {
            PriorityQueue<int> q = new PriorityQueue<int>();

            q.array = new int[] { 0, 1, 3, 5, 4 };
            q.size = 4;

            return q;
        }

        //
        //          2
        //        /   \
        //      4       2
        //     / \     / \
        //    7   5   5   6
        //   / \
        //  8   9
        //
        public static IPriorityQueue<int> CreatePriorityQueueModerate()
        {
            PriorityQueue<int> q = new PriorityQueue<int>();

            q.array = new int[] { 0, 2, 4, 2, 7, 5, 5, 6, 8, 9 };
            q.size = 9;

            return q;
        }

        public static IPriorityQueue<int> CreatePriorityQueueFull()
        {
            PriorityQueue<int> q = new PriorityQueue<int>();
            System.Random r = new System.Random();

            for (int i = 0; i < PriorityQueue<int>.DEFAULT_CAPACITY; i++)
                q.Add(r.Next(PriorityQueue<int>.DEFAULT_CAPACITY * 3));
            q.size = PriorityQueue<int>.DEFAULT_CAPACITY;

            return q;
        }
    }
}
