using OefenTentamen.Ex1Recursion;
using OefenTentamen.Ex2BinarySearchTree;
using OefenTentamen.Ex3MinHeap;
using OefenTentamen.Ex4Graph;
using System;

namespace OefenTentamen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Ex1 Recursion ====");
            Console.WriteLine(Recursion.PrintLetters(3));
            Console.WriteLine(Recursion.PrintLetters(0));
            Console.WriteLine(Recursion.PrintLetters2(3, 5));
            Console.WriteLine(Recursion.PrintLetters2(2, 0));
            Console.WriteLine();

            Console.WriteLine("==== Ex2 Binary Search Tree ====");
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Insert(6);
            binarySearchTree.Insert(2);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(1);
            binarySearchTree.Insert(4);
            binarySearchTree.Insert(3);
            Console.WriteLine(binarySearchTree.SecondSmallestElement().data);

            BinarySearchTree<int> binarySearchTree2 = new BinarySearchTree<int>();
            binarySearchTree2.Insert(6);
            binarySearchTree2.Insert(2);
            binarySearchTree2.Insert(8);
            binarySearchTree2.Insert(4);
            binarySearchTree2.Insert(3);
            Console.WriteLine(binarySearchTree2.SecondSmallestElement().data);
            Console.WriteLine();

            Console.WriteLine("==== Ex3 MinHeap ====");
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            priorityQueue.AddFreely(10);
            priorityQueue.AddFreely(4);
            priorityQueue.AddFreely(7);
            priorityQueue.AddFreely(1);
            priorityQueue.AddFreely(3);
            priorityQueue.AddFreely(12);
            priorityQueue.AddFreely(5);
            priorityQueue.array[6] = default;
            Console.WriteLine(priorityQueue.IsComplete());
            Console.WriteLine(priorityQueue.IsMaxHeap());

            PriorityQueue<int> priorityQueue2 = new PriorityQueue<int>();
            priorityQueue2.AddFreely(15);
            priorityQueue2.AddFreely(5);
            priorityQueue2.AddFreely(11);
            priorityQueue2.AddFreely(3);
            priorityQueue2.AddFreely(4);
            priorityQueue2.AddFreely(10);
            priorityQueue2.AddFreely(7);
            priorityQueue2.AddFreely(1);
            Console.WriteLine(priorityQueue2.IsComplete());
            Console.WriteLine(priorityQueue2.IsMaxHeap());
            Console.WriteLine();

            Console.WriteLine("==== Ex4 Graph ====");
            Graph graph = new Graph();
            graph.AddEdge("A", "B", 1);
            graph.AddEdge("A", "G", 1);
            graph.AddEdge("C", "B", 1);
            graph.AddEdge("D", "F", 1);
            graph.AddEdge("D", "G", 1);
            graph.AddEdge("E", "C", 1);
            graph.AddEdge("F", "F", 1);
            graph.AddEdge("G", "F", 1);
            graph.AddEdge("G", "D", 1);
            graph.AddEdge("G", "H", 1);
            graph.AddEdge("H", "E", 1);
            graph.AddEdge("H", "K", 1);
            graph.AddEdge("K", "G", 1);
            Console.WriteLine(graph.ToString());
            Console.WriteLine();

            graph.FillDistance("G");
            graph.ShowDistance();
            Console.WriteLine();

            Console.WriteLine(graph.HasCycle("A"));
            graph.ShowCyles();

        }
    }
}
