using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace CleanCode
{
    public partial class Graph
    {
        public List<Vertex> vertices;
        public List<Edge> edges;
        public int count;
        public bool[,] adjacencyMatrix;
        public static Color[] defaultColors = new Color[]
        {
            Color.Violet,
            Color.Orange,
            Color.Red,
            Color.Blue,
            Color.Cyan,
            Color.Tan,
            Color.Pink,
            Color.Black
        };

        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }

        public void Load(string filePath)
        {
            TextReader reader = new StreamReader(filePath);
            string buffer = reader.ReadLine();
            count = int.Parse(buffer);

            ReadVertices(reader);
            ReadEdges(reader);
            ReadAdjacencyMatrix(reader);
        }

        public void GreedyColoring()
        {
            int[] colorIndexes = new int[count];
            InitializeColorIndexes(colorIndexes);

            for (int i = 1; i < count; i++)
            {
                bool[] visitedColors = GetVisitedColors(i, colorIndexes);
                colorIndexes[i] = GetColorIndex(visitedColors);
            }

            for (int i = 0; i < count; i++)
            {
                vertices[i].FillColor = defaultColors[colorIndexes[i]];
            }
        }

        public List<string> DetermineHamiltonianPaths()
        {
            List<string> resultedPaths = new List<string>();

            int[] solution = new int[vertices.Count];
            List<int[]> permutations = new List<int[]>();
            Backtracking(solution, permutations, 0);

            foreach (var permutation in permutations)
            {
                bool isPath = CheckIfTraversablePath(permutation);
                if (isPath)
                {
                    resultedPaths.Add(String.Join(" ", permutation));
                }
            }

            return resultedPaths;
        }

        public void Draw(Graphics handler)
        {
            foreach (Edge edge in edges)
                edge.Draw(handler);
            foreach (Vertex vertex in vertices)
                vertex.Draw(handler);
        }

        public List<string> ConvertToString()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < count; i++)
            {
                string buffer = "";
                for (int j = 0; j < count; j++)
                {
                    buffer += adjacencyMatrix[i, j] + " ";
                }
                result.Add(buffer);
            }
            return result;
        }
    }
}