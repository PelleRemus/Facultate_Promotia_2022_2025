using System;

namespace Partial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(args.Length);

            Matrix matrix = new Matrix();
            Graph graph = matrix.matrix.ToGraph();
            graph.SaveToFile("Graph.txt");

            Console.ReadKey();
        }
    }
}
