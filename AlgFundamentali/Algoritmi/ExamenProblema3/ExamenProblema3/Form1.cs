using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenProblema3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Graphics grp;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.Black);

            int raza = pictureBox1.Height / 4;
            RecursivitateCerc(pictureBox1.Width / 2, pictureBox1.Height / 2, raza);

            pictureBox1.Image = bmp;
        }

        void RecursivitateCerc(int x, int y, int raza)
        {
            if (raza < 5)
                return;

            grp.DrawEllipse(Pens.White, x - raza, y - raza, 2 * raza, 2 * raza);
            RecursivitateDiamant(x, y - raza, raza / 2);
            RecursivitateDiamant(x - raza, y, raza / 2);
            RecursivitateDiamant(x, y+ raza, raza / 2);
            RecursivitateDiamant(x + raza, y, raza / 2);
        }

        void RecursivitateDiamant(int x, int y, int raza)
        {
            if (raza < 5)
                return;

            List<Point> points = new List<Point>();
            points.Add(new Point(x, y - raza));
            points.Add(new Point(x + raza, y));
            points.Add(new Point(x, y + raza));
            points.Add(new Point(x - raza, y));
            grp.DrawPolygon(Pens.White, points.ToArray());

            RecursivitateCerc(points[0].X, points[0].Y, raza / 2);
            RecursivitateCerc(points[1].X, points[1].Y, raza / 3);
            RecursivitateCerc(points[2].X, points[2].Y, raza / 4);
            RecursivitateCerc(points[3].X, points[3].Y, raza / 5);
        }
    }
}
