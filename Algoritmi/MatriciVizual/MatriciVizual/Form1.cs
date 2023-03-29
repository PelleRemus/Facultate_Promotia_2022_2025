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
            Color.FromArgb(1, 33, 105),
            Color.White,
            Color.FromArgb(200, 16, 46),
            Color.White,
            Color.White,
            Color.White,
            Color.White,
            Color.White
        };
        Point startLocation = new Point(538, 505);
        Button[] colorButtons;

        public Form1()
        {
            InitializeComponent();
            colorButtons = new Button[colors.Length];
            for(int i=0; i<colors.Length; i++)
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

                    int index = int.Parse(matrix[i][j]);
                    displays[i, j].BackColor = colors[index];
                }
        }
    }
}
