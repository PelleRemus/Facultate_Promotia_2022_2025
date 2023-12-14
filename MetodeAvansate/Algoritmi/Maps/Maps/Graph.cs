using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Maps
{
    public static class Graph
    {
        public static int n;
        public static List<Vertice> vertices = new List<Vertice>();
        public static List<Edge> edges = new List<Edge>();

        public static void LoadFromFile(string path)
        {
            TextReader reader = new StreamReader(path);
            string buffer = reader.ReadLine();
            n = int.Parse(buffer);

            for (int i = 0; i < n; i++)
            {
                buffer = reader.ReadLine();
                vertices.Add(new Vertice(buffer));
            }

            while ((buffer = reader.ReadLine()) != null)
            {
                edges.Add(new Edge(buffer));
            }
        }

        public static PathWithCost FindBestRoute(int source, int destination)
        {
            Vertice pathStart = FindVertice(source);
            Vertice pathEnd = FindVertice(destination);

            PathWithCost[] paths = new PathWithCost[n];
            for (int i = 0; i < n; i++)
            {
                paths[i] = new PathWithCost();
                paths[i].cost = int.MaxValue;
                paths[i].Path.Add(pathStart);
            }

            Queue<Vertice> queue = new Queue<Vertice>();

            paths[source - 1].cost = 0; // distanta pana in nodul pathStart e 0, deoarece de acolo pornim
            queue.Enqueue(pathStart);

            while (queue.Any()) // cat timp avem noduri ce trebuiesc testate
            {
                Vertice current = queue.Dequeue(); // extragem nodul curent din coada

                foreach (Edge edge in edges) // cautam conexiuni cu alte noduri
                {
                    if (edge.start == current || edge.end == current) // daca avem o conexiune cu un alt nod
                    {
                        Vertice neighbour = edge.start; // il consideram vecin
                        if (neighbour == current)
                            neighbour = edge.end;

                        // daca prin nodul curent gasim un drum mai scurt spre nodul vecin 
                        if ((paths[current.value - 1].cost + edge.cost) < paths[neighbour.value - 1].cost)
                        {
                            paths[neighbour.value - 1].cost = paths[current.value - 1].cost + edge.cost; // updatam distanta

                            //Vertice lastVertice = paths[neighbour.value - 1].Path.Last();
                            //paths[neighbour.value - 1].Path.Remove(lastVertice);

                            paths[neighbour.value - 1].Path.Add(current);
                            queue.Enqueue(neighbour); // adaugam nodul vecin in coada, pentru a fi vizitat ulterior
                        }
                    }
                }
            }

            return paths[pathEnd.value - 1];
        }

        public static Vertice FindVertice(int value)
        {
            return vertices.FirstOrDefault(v => v.value == value);
        }

        public static double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
}
