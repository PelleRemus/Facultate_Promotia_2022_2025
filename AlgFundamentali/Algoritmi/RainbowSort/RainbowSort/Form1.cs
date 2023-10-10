using System;
using System.Drawing;
using System.Windows.Forms;

namespace RainbowSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Engine.Initialize(pictureBox1, textBox1);
        }

        private void Shuffle_Click(object sender, EventArgs e)
        {
            Engine.RestartStopwatch();
            Engine.Shuffle();
            Engine.StopStopWatch();
        }

        private void BubbleSort_Click(object sender, EventArgs e)
        {
            Engine.RestartStopwatch();
            Engine.Bubble();
            Engine.StopStopWatch();
        }

        private void InsertionSort_Click(object sender, EventArgs e)
        {
            Engine.RestartStopwatch();
            Engine.Insertion();
            Engine.StopStopWatch();
        }

        private void SelectionSort_Click(object sender, EventArgs e)
        {
            Engine.RestartStopwatch();
            Engine.Selection();
            Engine.StopStopWatch();
        }

        private void QuickSort_Click(object sender, EventArgs e)
        {
            Engine.RestartStopwatch();
            Engine.QuickSort(0, Resources.n - 1);
            Engine.StopStopWatch();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.CornflowerBlue;
            button2.BackColor = Color.White;
            Resources.frequency = 5;
            Resources.GenerateRainbow();
            Resources.ShowRainbow();
            Engine.display.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.CornflowerBlue;
            button1.BackColor = Color.White;
            Resources.frequency = 15;
            Resources.GenerateRainbow();
            Resources.ShowRainbow();
            Engine.display.Update();
        }
    }
}
