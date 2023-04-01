using System;
using System.Drawing;
using System.Windows.Forms;

namespace MatriciVizual
{
    public partial class Form1 : Form
    {
        PictureBox[,] displays = new PictureBox[0, 0];
        Color[] colors = new Color[]
        {
            Color.White,
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Blue,
            Color.Indigo,
            Color.BlueViolet
        };
        Point startLocation = new Point(538, 505);
        Button[] colorButtons;

        public Form1()
        {
            InitializeComponent();
            colorButtons = new Button[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                Button button = new Button();
                button.Parent = this;

                button.Size = new Size(40, 40);
                button.Location = new Point(startLocation.X + i * 41, startLocation.Y);
                button.BackColor = colors[i];

                button.Click += ColorButton_Click;
                colorButtons[i] = button;
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                int index = Array.IndexOf(colorButtons, sender as Button);
                colors[index] = colorPicker.Color;
                (sender as Button).BackColor = colorPicker.Color;
            }
        }

        private void display_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < displays.GetLength(0); i++)
                for (int j = 0; j < displays.GetLength(1); j++)
                    displays[i, j].Parent = null;

            string[][] matrix = new string[textBox1.Lines.Length][];
            for (int i = 0; i < textBox1.Lines.Length; i++)
                matrix[i] = textBox1.Lines[i].Split(' ');

            int n = matrix.Length;
            int m = matrix[0].Length;
            displays = new PictureBox[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    displays[i, j] = new PictureBox();
                    displays[i, j].Parent = pictureBox1;

                    int sizeX = pictureBox1.Width / m, sizeY = pictureBox1.Height / n;
                    displays[i, j].Size = new Size(sizeX, sizeY);
                    displays[i, j].Location = new Point(j * sizeX, i * sizeY);

                    int index = int.Parse(matrix[i][j]) % colors.Length;
                    displays[i, j].BackColor = colors[index];
                }
        }

        private void AddMatrixToTextBox(int[,] matrix, int n, int m)
        {
            textBox1.Text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m - 1; j++)
                    textBox1.Text += matrix[i, j] + " ";
                textBox1.Text += matrix[i, m - 1] + "\r\n";
            }
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 2);
        }

        private void diagonalaPrincipala_Click(object sender, EventArgs e)
        {
            int n = 9;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i > j)
                        matrix[i, j] = 1;
                    if (i < j)
                        matrix[i, j] = 2;
                }
            AddMatrixToTextBox(matrix, n, n);
        }

        private void diagonalaSecundara_Click(object sender, EventArgs e)
        {
            int n = 9;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i + j > n - 1)
                        matrix[i, j] = 1;
                    if (i + j < n - 1)
                        matrix[i, j] = 2;
                }
            AddMatrixToTextBox(matrix, n, n);
        }

        private void chenar_Click(object sender, EventArgs e)
        {
            int n = 9;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n - 1; i++)
                matrix[0, i] = 1;
            for (int i = 0; i < n - 1; i++)
                matrix[i, n - 1] = 2;
            for (int i = 0; i < n - 1; i++)
                matrix[n - 1, n - i - 1] = 3;
            for (int i = 0; i < n - 1; i++)
                matrix[n - i - 1, 0] = 4;

            AddMatrixToTextBox(matrix, n, n);
        }

        private void spirala_Click(object sender, EventArgs e)
        {
            int n = 9, step = 0;
            int[,] matrix = new int[n, n];

            for (int k = 0; k < n / 2; k++)
            {
                for (int i = k; i < n - k - 1; i++)
                    matrix[k, i] = step;
                step++;
                for (int i = k; i < n - k - 1; i++)
                    matrix[i, n - k - 1] = step;
                step++;
                for (int i = k; i < n - k - 1; i++)
                    matrix[n - k - 1, n - i - 1] = step;
                step++;
                for (int i = k; i < n - k - 1; i++)
                    matrix[n - i - 1, k] = step;
                step++;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        private void NSEV_Click(object sender, EventArgs e)
        {
            int n = 19;
            int[,] matrix = new int[n, n];

            for (int i = 0; i <= n / 2; i++)
                for (int j = i; j < n - i; j++)
                {
                    matrix[i, j] = 1;
                    matrix[j, n - i - 1] = 2;
                    matrix[n - i - 1, j] = 3;
                    matrix[j, i] = 4;
                }

            AddMatrixToTextBox(matrix, n, n);
        }
    }
}
