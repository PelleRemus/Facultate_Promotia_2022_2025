using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgLuiLee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public PictureBox[,] display;
        public int[,] matrix;
        public int n = 15, m = 20;

        private void Form1_Load(object sender, EventArgs e)
        {
            matrix = new int[n, m];
            display = new PictureBox[n, m];
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
                    pictureBox.Click += PictureBox_Click;

                    display[i,j] = pictureBox;
                }

            Player.Init(this);
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            if(Player.destination != null)
                Player.destination.BackColor = Color.ForestGreen;
            pictureBox.BackColor = Color.Gold;
            Player.destination = pictureBox;

            Player.FindPathLee();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Player.GoToDestination();
        }
    }
}
