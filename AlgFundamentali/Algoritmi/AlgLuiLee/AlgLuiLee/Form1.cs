using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgLuiLee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public MapTile[,] display;
        public int[,] matrix;
        public int n = 15, m = 20;

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeMatrixWithWalls();

            display = new MapTile[n, m];
            // cele doua dimensiuni ale fiecarui picturebox
            int sizeHeight = (Height - 30) / n;
            int sizeWidth = Width / m;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    // initializarea clasica a unui picturebox, pe care am mai facut-o inainte
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Parent = this;
                    pictureBox.Size = new Size(sizeWidth, sizeHeight);
                    pictureBox.Location = new Point(j * sizeWidth, i * sizeHeight);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (matrix[i, j] == 0)
                        pictureBox.BackColor = Color.ForestGreen;
                    else
                        pictureBox.BackColor = Color.Black;

                    // apelam constructorul care creeaza si un picturebox
                    display[i, j] = new MapTile(i, j, pictureBox);
                }

            Player.Init(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Player.GoToDestination();
        }

        public void InitializeMatrixWithWalls()
        {
            matrix = new int[n, m];

            for (int i = 1; i < n; i++)
                for (int j = 0; j < m / 2; j += 2)
                {
                    if ((j / 2) % 2 == 0)
                        matrix[i, j] = -1;
                    else
                        matrix[n - i - 1, j] = -1;
                }

            for (int i = 1; i < n; i += 2)
                for (int j = 0; j < m / 2 - 1; j++)
                {
                    if ((i / 2) % 2 == 0)
                        matrix[i, j + m / 2 - 1] = -1;
                    else
                        matrix[i, m - j - 1] = -1;
                }

            matrix[n / 2, m / 2 - 2] = 0;
        }
    }
}
