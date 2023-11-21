using System;
using System.Collections.Generic;

namespace AlgoritmiElementari
{
    internal class Program
    {
        static int n;
        static int[,] matrix;
        static bool[] visited;

        static void Main(string[] args)
        {
            n = 7;
            matrix = new int[,]
            {
                { 0, 1, 0, 0, 1, 0, 0 },
                { 1, 0, 1, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 0, 1, 0 },
            };
            visited = new bool[n];

            Console.WriteLine(IsHamiltonian());
            Console.ReadKey();
        }

        static bool IsHamiltonian()
        {
            for (int i = 0; i < n; i++)
            {
                visited = new bool[n];
                List<int> noduri = new List<int>();
                noduri.Add(i);
                if (GasireDrum(noduri))
                    return true;
            }
            return false;
        }

        static bool GasireDrum(List<int> noduri)
        {
            int nod = noduri[noduri.Count - 1];
            visited[nod] = true;

            for (int j = 0; j < n; j++)
                if (matrix[nod, j] == 1 && !visited[j])
                {
                    noduri.Add(j);

                    if (noduri.Count == n)
                        return true;

                    if (GasireDrum(noduri))
                        return true;

                    visited[j] = false;
                    noduri.Remove(j);
                }

            return false;
        }
    }
}
