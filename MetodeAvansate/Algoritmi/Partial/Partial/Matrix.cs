using System;
using System.Linq;

namespace Partial
{
    public class Matrix
    {
        public string[,] matrix;
        public int n, m;

        public Matrix()
        {
            n = 3; m = 4;
            matrix = new string[,]
            {
                { "1", "2", "3", "4" },
                { "5", "a", "-1", "6" },
                { "7", "-1", "2", "9" }
            };
        }

        public Graph ToGraph()
        {
            Graph graph = new Graph();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    graph.Vertices.Add(new Vertice(i * m + j, matrix[i, j]));

            for (int i = 0; i < n * m; i++)
            {
                int row = (i + 1) / m;
                if (row == i / m)
                {
                    graph.Edges.Add(new Edge(graph.Vertices[i], graph.Vertices[i + 1]));
                }

                if (i + m < n * m)
                {
                    graph.Edges.Add(new Edge(graph.Vertices[i], graph.Vertices[i + m]));
                }
            }

            // afisare optionala
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(graph.Vertices[i * m + j].value);
                    Edge right = graph.Edges.FirstOrDefault(e =>
                        e.start.id == i * m + j && e.end.id == i * m + j + 1);

                    if (right != null)
                        Console.Write("---");
                    else
                        Console.Write("   ");
                }
                Console.WriteLine();

                for (int j = 0; j < m; j++)
                {
                    Edge down = graph.Edges.FirstOrDefault(e =>
                        e.start.id == i * m + j && e.end.id == (i + 1) * m + j);

                    if (down != null)
                        Console.Write("|   ");
                    else
                        Console.Write("    ");
                }
                Console.WriteLine();
            }
            // end afisare

            return graph;
        }
    }
}
