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
            matrix = new int[n, m];
            display = new MapTile[n, m];
            int sizeHeight = Height / n;
            int sizeWidth = Width / m;

            for(int i = 0; i < n; i++) 
                for (int j = 0; j < m; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Parent = this;
                    pictureBox.Size = new Size(sizeWidth, sizeHeight);
                    pictureBox.BackColor = Color.ForestGreen;
                    pictureBox.Location = new Point(j * sizeWidth, i * sizeHeight);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    display[i, j] = new MapTile(i, j, pictureBox);
                }

            Player.Init(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Player.GoToDestination();
        }
    }
}
