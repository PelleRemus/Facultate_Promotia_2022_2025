using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Partial
{
    public class Graph
    {
        public List<Vertice> Vertices;
        public List<Edge> Edges;
        public int n;

        public Graph()
        {
            Vertices = new List<Vertice>();
            Edges = new List<Edge>();
        }

        public List<Vertice> BreadthFirstSearch()
        {
            n = Vertices.Count;
            bool[] visited = new bool[n];
            Queue<Vertice> queue = new Queue<Vertice>();

            List<Vertice> solution = new List<Vertice>();
            queue.AddEnd(Vertices.First());
            visited[Vertices.First().id] = true;

            while (queue.n > 0)
            {
                Vertice current = queue.RemoveBeginning();
                solution.Add(current);

                foreach (Edge edge in Edges)
                {
                    if (edge.start == current && !visited[edge.end.id])
                    {
                        queue.AddEnd(edge.end);
                        visited[edge.end.id] = true;
                    }
                    if (edge.end == current && !visited[edge.start.id])
                    {
                        queue.AddEnd(edge.start);
                        visited[edge.start.id] = true;
                    }
                }
            }
            return solution;
        }

        public void SaveToFile(string fileName)
        {
            n = Vertices.Count();
            using (StreamWriter writer = new StreamWriter($"../../{fileName}"))
            {
                writer.WriteLine(n);

                for (int i = 0; i < n; i++)
                    writer.WriteLine(Vertices[i].id + " " + Vertices[i].value);

                for (int i = 0; i < Edges.Count; i++)
                    writer.WriteLine(Edges[i].start.id + " " + Edges[i].end.id);
            }
        }
    }
}
