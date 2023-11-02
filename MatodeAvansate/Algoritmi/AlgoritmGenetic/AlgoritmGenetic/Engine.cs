using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AlgoritmGenetic
{
    public static class Engine
    {
        public static Form1 form;
        public static List<Solution> generation;
        public static Random random = new Random();
        public static Bitmap bitmap;
        public static Graphics graphics;

        public static int vertices;
        public static int[,] mAdiacenta;

        public static int n = 100, survivors = 10;
        public static float mutationRate = 0.07F;

        public static void Init(Form1 f)
        {
            form = f;
            form.listBox1.Items.Add("Hello World!");
            bitmap = new Bitmap(form.pictureBox1.Width, form.pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            TextReader reader = new StreamReader("../../TextFile1.txt");
            string buffer = reader.ReadLine();
            vertices = int.Parse(buffer);
            mAdiacenta = new int[vertices, vertices];

            while ((buffer = reader.ReadLine()) != null)
            {
                string[] split = buffer.Split(' ');
                int i = int.Parse(split[0]);
                int j = int.Parse(split[1]);
                mAdiacenta[i, j] = int.Parse(split[2]);
                mAdiacenta[j, i] = int.Parse(split[2]);
            }
        }

        public static void NextGeneration()
        {
            form.listBox1.Items.Clear();
            bitmap = new Bitmap(form.pictureBox1.Width, form.pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            if (generation == null)
            {
                generation = new List<Solution>();
                for (int i = 0; i < n; i++)
                    generation.Add(new Solution());
            }
            else
            {
                SelectSurvivors();
                CrossoverSurvivors();
                MutateSolutions();
            }

            form.listBox1.Items.Add(generation[0].Fitness());
            for (int i = 0; i < vertices; i++)
                form.listBox1.Items.Add(generation[0].points[i].ToString());

            Color c = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
            for (int i = 0; i < vertices; i++)
            {
                PointF point = generation[0].points[i];
                graphics.FillEllipse(new SolidBrush(c), point.X - 5, point.Y - 5, 11, 11);

                for (int j = 0; j < vertices; j++)
                    if (mAdiacenta[i, j] != 0)
                    {
                        graphics.DrawLine(new Pen(c, 3), point, generation[0].points[j]);
                    }
            }
            form.pictureBox1.Image = bitmap;
        }

        public static void SelectSurvivors()
        {
            generation.Sort((Solution a, Solution b) => a.Fitness().CompareTo(b.Fitness()));
            generation.RemoveRange(survivors, n - survivors);
        }

        public static void CrossoverSurvivors()
        {
            int i = random.Next(survivors);
            int j = random.Next(survivors);

            for (int k = survivors; k < n; k++)
                generation.Add(new Solution(generation[i], generation[j]));
        }

        public static void MutateSolutions()
        {
            for (int i = 0; i < n; i++)
                if (random.NextDouble() < mutationRate)
                {
                    int index = random.Next(vertices);
                    float errorX = (float)random.NextDouble() * 30 - 15;
                    float errorY = (float)random.NextDouble() * 30 - 15;

                    PointF prev = generation[i].points[index];
                    generation[i].points[index] = new PointF(prev.X + errorX, prev.Y + errorY);
                }
        }

        public static float Distance(PointF A, PointF B)
        {
            return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }
    }
}
