using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MatriciVizual
{
    public partial class Form1 : Form
    {
        PictureBox[,] displays = new PictureBox[0, 0];
        Color[] colors = new Color[]
        {
            Color.DeepPink,
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

        private void picaturi_Click(object sender, EventArgs e)
        {
            int n = 7, m = 10;
            int[] v = new int[7] { 3, 1, 7, 2, 5, 6, 2 };

            // cream "bordurile" (peretii) matricei
            int[,] mat = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (v[j] >= i)
                        mat[i, j] = 1;
                }
            }

            // umplem matricea cu aer (unde ramane 0, avem apa)
            for (int i = 0; i < m; i++)
            {
                int right = n - 1;
                int left = 0;
                while (right > 0)
                {
                    if (mat[i, right] == 1)
                    {
                        break;
                    }
                    else
                    {
                        mat[i, right] = 2;
                    }
                    right--;
                }
                while (left < n)
                {
                    if (mat[i, left] == 1)
                    {
                        break;
                    }
                    else
                    {
                        mat[i, left] = 2;
                    }
                    left++;
                }
            }

            // rotim matricea in jurul "axei Ox" (linia din mijloc), ca sa nu fie cu susul in jos
            for (int i = 0; i < m / 2; i++)
                for (int j = 0; j < n; j++)
                {
                    int aux = mat[i, j];
                    mat[i, j] = mat[m - i - 1, j];
                    mat[m - i - 1, j] = aux;
                }

            // numaram cata apa tine vectorul
            int apa = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (mat[i, j] == 0)
                        apa++;
                }

            AddMatrixToTextBox(mat, m, n);
            MessageBox.Show($"The given array holds {apa} apa.");
        }

        private void romb_Click(object sender, EventArgs e)
        {
            int n = 18;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n / 2; i++)
                for (int j = 0; j < n / 2; j++)
                {
                    if (i + j < n / 2 - 1)
                        matrix[i, j] = 1;
                    else
                        matrix[n / 2 + i, n / 2 + j] = 1;

                    if(i >= j)
                        matrix[n / 2 + i, j] = 1;
                    else
                        matrix[i, n / 2 + j] = 1;
                }

            AddMatrixToTextBox(matrix, n, n);
        }

        private void tricolor_Click(object sender, EventArgs e)
        {
            int n = 9;
            int[,] matrix = new int[n, n];

            for(int i=0; i<n; i++)
                for(int j=0; j<n; j++)
                {
                    if (j < n / 3)
                        matrix[i, j] = 5;
                    else if (j < 2 * n / 3)
                        matrix[i, j] = 3;
                    else
                        matrix[i, j] = 1;
                }

            AddMatrixToTextBox(matrix, n, n);
        }

        private void diagonale_Click(object sender, EventArgs e)
        {

            int n = 19;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = 1;
                matrix[i, n - i - 1] = 1;
                matrix[i, n / 2] = 1;
                matrix[n / 2, i] = 1;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        private void serpuit_Click(object sender, EventArgs e)
        {
            int value = 0;
            int n = 13;
            int[,] matrix = new int[n, n];
            bool upDirection = true;

            for(int diagonalSize = 1; diagonalSize <= n; diagonalSize++)
            {
                if(upDirection)
                    TraverseUpwards(matrix, diagonalSize, value);
                else
                    TraverseDownwards(matrix, diagonalSize, value);

                value++;
                upDirection = !upDirection;
            }

            for (int diagonalSize = n - 1; diagonalSize > 0; diagonalSize--)
            {
                if (upDirection)
                    TraverseUpwards(matrix, diagonalSize, value, true);
                else
                    TraverseDownwards(matrix, diagonalSize, value, true);

                value++;
                upDirection = !upDirection;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        private void TraverseUpwards(int[,] matrix, int diagonalSize, int value, bool isSecondHalf = false)
        {
            int i = diagonalSize - 1;
            int j = 0;
            if (isSecondHalf)
            {
                i = matrix.GetLength(0) - 1;
                j = matrix.GetLength(1) - diagonalSize;
            }

            while (diagonalSize > 0)
            {
                matrix[i, j] = value;
                i--; j++;
                diagonalSize--;
            }
        }

        private void TraverseDownwards(int[,] matrix, int diagonalSize, int value, bool isSecondHalf = false)
        {
            int i = 0;
            int j = diagonalSize - 1;
            if (isSecondHalf)
            {
                i = matrix.GetLength(0) - diagonalSize;
                j = matrix.GetLength(1) - 1;
            }

            while (diagonalSize > 0)
            {
                matrix[i, j] = value;
                i++; j--;
                diagonalSize--;
            }
        }
    }
}
