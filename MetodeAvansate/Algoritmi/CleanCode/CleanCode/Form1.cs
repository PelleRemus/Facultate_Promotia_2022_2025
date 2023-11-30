using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CleanCode
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        Graph graph;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
            graph = new Graph();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graph.Load(@"..\..\CoordonateGraf.txt");
            graph.GreedyColoring();
            graph.Draw(graphics);
            pictureBox.Image = bitmap;

            DisplayHamiltonianPaths();
        }

        public void DisplayHamiltonianPaths()
        {
            List<string> hamiltonianPath = graph.DetermineHamiltonianPaths();
            DisplayLines(hamiltonianPath);
        }

        private void DisplayGraph()
        {
            List<string> graphAsString = graph.ConvertToString();
            DisplayLines(graphAsString);
        }

        private void DisplayLines(List<string> lines)
        {
            foreach (string line in lines)
            {
                listBox.Items.Add(line);
            }
        }
    }
}
