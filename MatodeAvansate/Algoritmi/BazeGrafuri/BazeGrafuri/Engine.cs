using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace BazeGrafuri
{
    public static class Engine
    {
        public static Form1 form;
        public static int n;
        public static List<Vertex> vertices = new List<Vertex>();
        public static List<Edge> edges = new List<Edge>();
        public static int[,] matrix;

        public static Bitmap bitmap;
        public static Graphics graphics;

        public static void Init(Form1 f)
        {
            form = f;
        }

        public static void ReadFile(string path)
        {
            TextReader reader = new StreamReader(path);
            string buffer = reader.ReadLine();
            n = int.Parse(buffer);

            for (int i = 1; i <= n; i++)
            {
                buffer = reader.ReadLine();
                string[] split = buffer.Split(' ');
                vertices.Add(new Vertex(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])));
            }

            while ((buffer = reader.ReadLine()) != null)
            {
                string[] split = buffer.Split(' ');
                Vertex begin = vertices.First(vertex => vertex.value == int.Parse(split[0]));
                Vertex end = vertices.First(vertex => vertex.value == int.Parse(split[1]));
                edges.Add(new Edge(begin, end));
            }
        }

        public static void CreateMatrix()
        {
            matrix = new int[n, n];
            foreach (Edge edge in edges)
            {
                int i = edge.begin.value - 1;
                int j = edge.end.value - 1;

                matrix[i, j] = 1;
                matrix[j, i] = 1;
            }
        }

        public static void WriteGraph()
        {
            form.listBox1.Items.Add(n);
            foreach (Vertex vertex in vertices)
            {
                form.listBox1.Items.Add($"{vertex.value} {vertex.X} {vertex.Y}");
            }
            foreach (Edge edge in edges)
            {
                form.listBox1.Items.Add($"{edge.begin.value} {edge.end.value}");
            }
            for (int i = 0; i < n; i++)
            {
                string line = "";
                for (int j = 0; j < n; j++)
                    line += matrix[i, j] + " ";
                form.listBox1.Items.Add(line);
            }
        }

        public static void DrawGraph()
        {
            bitmap = new Bitmap(form.pictureBox1.Width, form.pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            foreach (Edge edge in edges)
            {
                graphics.DrawLine(new Pen(Color.Brown, 5), edge.begin.X, edge.begin.Y, edge.end.X, edge.end.Y);
            }
            foreach (Vertex vertex in vertices)
            {
                graphics.FillEllipse(new SolidBrush(Color.ForestGreen), vertex.X - 25, vertex.Y - 25, 50, 50);
                graphics.DrawString(vertex.value.ToString(), new Font("Arial", 25, FontStyle.Bold),
                    new SolidBrush(Color.Black), vertex.X - 15, vertex.Y - 15);
            }
            form.pictureBox1.Image = bitmap;
        }
    }
}
