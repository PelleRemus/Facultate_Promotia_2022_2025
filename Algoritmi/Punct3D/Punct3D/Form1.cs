using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Punct3D
{
    public partial class Form1 : Form
    {
        public Bitmap bitmap;
        public Graphics graphics;
        public Random random = new Random();
        List<Point3D> points = new List<Point3D>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = Width;
            pictureBox1.Height = Height;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        // acest timer executa metoda aceasta la fiecare milisecunda
        private void timer1_Tick(object sender, EventArgs e)
        {
            // bitmap reprezinta, practic, o imagine. Graphics este un obiect care deseneaza peste o imagine
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            // adaugam cateva puncte la intamplare
            // (daca aveti ecran mic, incercati sa reduceti numarul de puncte adaugate)
            points.Add(GenerateRandomPoint3D());
            points.Add(GenerateRandomPoint3D());
            points.Add(GenerateRandomPoint3D());
            points.Add(GenerateRandomPoint3D());

            // parcurgem intreaga lista de puncte
            for (int i = 0; i < points.Count; i++)
            {
                // desenam fiecare punct si ne apropiem putin de el
                points[i].Draw(this);
                points[i].z--;

                // verificam daca punctul a iesit inafara ecranului, caz in care il scoatem din lista
                if (points[i].z < -100)
                {
                    points.RemoveAt(i);
                    i--;
                }
            }
            // motivul pentru care am creat bitmap: sa fie afisat. punem bitmap ca imaginea picturebox-ului
            pictureBox1.Image = bitmap;
        }

        private Point3D GenerateRandomPoint3D()
        {
            int x = 0, y = 0;
            // punctul poate fi generat in 4 zone ale ecranului
            int zone = random.Next(4);
            switch (zone)
            {
                case 0:                 // zona din stanga (vest)
                    x = random.Next(Width / 4);
                    y = random.Next(Height);
                    break;
                case 1:                 // zona din dreapta (est)
                    x = random.Next(3 * Width / 4, Width);
                    y = random.Next(Height);
                    break;
                case 2:                 // zona de sus (nord)
                    x = random.Next(Width);
                    y = random.Next(Height / 4);
                    break;
                case 3:                 // zona de jos (sud)
                    x = random.Next(Width);
                    y = random.Next(3 * Height / 4, Height);
                    break;
            }
            // initializam fiecare punct ca fiind in cel mai indepartat punct de noi, cu z-ul 100
            return new Point3D(x, y, 100);
        }
    }
}
