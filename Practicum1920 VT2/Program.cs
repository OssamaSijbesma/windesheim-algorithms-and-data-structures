using System;

namespace Practicum1920_VT2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ex1 BigInt 

            BigInt b1, b2, b3, b4, b5;

            // Constructor
            b1 = new BigInt(null);
            b2 = new BigInt("0");
            b3 = new BigInt("1234");
            b4 = new BigInt("1230");
            try
            {
                b5 = new BigInt("2d13");
                System.Console.WriteLine("*ERROR* : This line should not be reached");
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("Exception thrown as expected");
            }

            // ToString()
            System.Console.WriteLine(b1);
            System.Console.WriteLine(b2);
            System.Console.WriteLine(b3);
            System.Console.WriteLine(b4);

            // Sum()
            System.Console.WriteLine(new BigInt("87").Sum());     // 15
            System.Console.WriteLine(new BigInt(null).Sum());     // 0
            System.Console.WriteLine(new BigInt("1234").Sum());   // 10

            // Increment()
            b1 = new BigInt("0");
            b2 = new BigInt("1234");
            b3 = new BigInt("999");
            b4 = new BigInt("1499");
            b1.Increment();
            b2.Increment();
            b3.Increment();
            b4.Increment();
            System.Console.WriteLine(b1);
            System.Console.WriteLine(b2);
            System.Console.WriteLine(b3);
            System.Console.WriteLine(b4);

            // Ex3 CityMap
            Graph g = Graph.MakeCityMap();
            System.Console.WriteLine(g.GetVertex("Den Bosch").Outgoing());
            System.Console.WriteLine(g.GetVertex("Tilburg").Outgoing());

            foreach (string s in g.VerticesNotOnShortestPath("Tilburg", "Arnhem"))
                System.Console.WriteLine(s);
            foreach (string s in g.VerticesNotOnShortestPath("Utrecht", "Arnhem"))
                System.Console.WriteLine(s);
        }
    }
}
