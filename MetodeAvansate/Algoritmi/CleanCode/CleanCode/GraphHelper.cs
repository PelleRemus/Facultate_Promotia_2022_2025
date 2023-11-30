using System.Collections.Generic;
using System.IO;

namespace CleanCode
{
    public partial class Graph
    {
        private void ReadVertices(TextReader reader)
        {
            for (int i = 0; i < count; i++)
            {
                string buffer = reader.ReadLine();
                vertices.Add(new Vertex(buffer));
            }
        }
        private void ReadEdges(TextReader reader)
        {
            string buffer;
            while ((buffer = reader.ReadLine()) != null)
            {
                edges.Add(new Edge(buffer, vertices));
            }
        }
        private void ReadAdjacencyMatrix(TextReader reader)
        {
            adjacencyMatrix = new bool[count, count];
            for (int i = 0; i < edges.Count; i++)
            {
                int beginIndex = vertices.IndexOf(edges[i].begin);
                int endIndex = vertices.IndexOf(edges[i].end);

                adjacencyMatrix[beginIndex, endIndex] = true;
                adjacencyMatrix[endIndex, beginIndex] = true;
            }
        }

        private void InitializeColorIndexes(int[] colorIndexes)
        {
            colorIndexes[0] = 0;
            for (int i = 1; i < count; i++)
            {
                colorIndexes[i] = -1;
            }
        }
        private bool[] GetVisitedColors(int vertexIndex, int[] colorIndexes)
        {
            bool[] visitedColors = new bool[count];
            for (int j = 0; j < count; j++)
            {
                if (adjacencyMatrix[vertexIndex, j] && colorIndexes[j] != -1)
                {
                    visitedColors[colorIndexes[j]] = true;
                }
            }

            return visitedColors;
        }
        private int GetColorIndex(bool[] visitedColors)
        {
            int colorIndex = 0;
            while (visitedColors[colorIndex])
            {
                colorIndex++;
            }

            return colorIndex;
        }

        private void Backtracking(int[] solution, List<int[]> permutations, int index)
        {
            if (!IsValid(solution, index))
            {
                return;
            }

            for (int i = 0; i < solution.Length; i++)
            {
                solution[index] = i;

                if (index == solution.Length - 1)
                {
                    List<int> permutation = new List<int>(solution);
                    permutations.Add(permutation.ToArray());
                }
                else
                {
                    Backtracking(solution, permutations, index + 1);
                }
            }
        }
        private bool IsValid(int[] solution, int index)
        {
            for (int i = 0; i < index; i++)
                if (solution[i] == solution[index])
                {
                    return false;
                }

            return true;
        }

        private bool CheckIfTraversablePath(int[] permutation)
        {
            bool isPath = true;
            for (int i = 0; i < permutation.Length - 1; i++)
            {
                if (adjacencyMatrix[permutation[i], permutation[i + 1]] == false)
                {
                    isPath = false;
                    break;
                }
            }

            return isPath;
        }
    }
}
