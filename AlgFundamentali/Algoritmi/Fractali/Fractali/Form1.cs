using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractali
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Pen pen = new Pen(Color.White);
        int offset = 20;
        int steps = 7;

        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            steps = 7;
            graphics.Clear(Color.Black);

            PointF[] triangle = new PointF[3];
            triangle[0] = new PointF(offset, pictureBox1.Height - offset);
            triangle[1] = new PointF(pictureBox1.Width - offset, pictureBox1.Height - offset);
            triangle[2] = new PointF(pictureBox1.Width / 2, offset);
            graphics.DrawPolygon(pen, triangle);

            TriunghiSierpinski(triangle, 0);
        }

        private void TriunghiSierpinski(PointF[] triangle, int i)
        {
            if (i > steps)
                return;

            PointF[] midTriangle = new PointF[3];
            midTriangle[0] = MiddleSegment(triangle[0], triangle[1]);
            midTriangle[1] = MiddleSegment(triangle[1], triangle[2]);
            midTriangle[2] = MiddleSegment(triangle[2], triangle[0]);
            graphics.DrawPolygon(pen, midTriangle);

            TriunghiSierpinski(new PointF[] { triangle[0], midTriangle[0], midTriangle[2] }, i + 1);
            TriunghiSierpinski(new PointF[] { triangle[1], midTriangle[0], midTriangle[1] }, i + 1);
            TriunghiSierpinski(new PointF[] { triangle[2], midTriangle[1], midTriangle[2] }, i + 1);
        }

        private PointF MiddleSegment(PointF point1, PointF point2)
        {
            float x = Math.Min(point1.X, point2.X) + Math.Abs(point1.X - point2.X) / 2;
            float y = Math.Min(point1.Y, point2.Y) + Math.Abs(point1.Y - point2.Y) / 2;
            return new PointF(x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            steps = 5;
            graphics.Clear(Color.Black);

            PointF[] square = new PointF[4];
            square[0] = new PointF(offset, offset);
            square[1] = new PointF(offset, pictureBox1.Height - offset);
            square[2] = new PointF(pictureBox1.Width - offset, pictureBox1.Height - offset);
            square[3] = new PointF(pictureBox1.Width - offset, offset);
            graphics.DrawPolygon(pen, square);

            PatratSierpinski(square, 0);
        }

        private void PatratSierpinski(PointF[] square, int i)
        {
            if (i > steps)
                return;

            int n = 4;
            PointF[] thirds = new PointF[n];
            // for (int i = 0; i < n - 1; i++)
            //    thirds[i] = ThirdOfSegment(square[i], square[i + 1]);
            thirds[0] = ThirdOfSegment(square[0], square[1]);
            thirds[1] = ThirdOfSegment(square[1], square[2]);
            thirds[2] = ThirdOfSegment(square[2], square[3]);
            thirds[3] = ThirdOfSegment(square[3], square[0]);

            PointF[] twoThirds = new PointF[4];
            twoThirds[0] = TwoThirdsOfSegment(square[0], square[1]);
            twoThirds[1] = TwoThirdsOfSegment(square[1], square[2]);
            twoThirds[2] = TwoThirdsOfSegment(square[2], square[3]);
            twoThirds[3] = TwoThirdsOfSegment(square[3], square[0]);

            graphics.DrawLine(pen, thirds[0], thirds[2]);
            graphics.DrawLine(pen, thirds[1], thirds[3]);
            graphics.DrawLine(pen, twoThirds[0], twoThirds[2]);
            graphics.DrawLine(pen, twoThirds[1], twoThirds[3]);

            PatratSierpinski(new PointF[] { square[0], thirds[0], new PointF(thirds[3].X, thirds[0].Y), thirds[3] }, i + 1);
            PatratSierpinski(new PointF[] { twoThirds[0], square[1], thirds[1], new PointF(thirds[1].X, twoThirds[0].Y) }, i + 1);
            PatratSierpinski(new PointF[] { new PointF(twoThirds[1].X, twoThirds[2].Y), twoThirds[1], square[2], twoThirds[2] }, i + 1);
            PatratSierpinski(new PointF[] { thirds[3], new PointF(thirds[3].X, twoThirds[2].Y), twoThirds[2], square[3] }, i + 1);
        }

        private PointF ThirdOfSegment(PointF point1, PointF point2)
        {
            float x = Math.Min(point1.X, point2.X) + Math.Abs(point1.X - point2.X) / 3;
            float y = Math.Min(point1.Y, point2.Y) + Math.Abs(point1.Y - point2.Y) / 3;
            return new PointF(x, y);
        }

        private PointF TwoThirdsOfSegment(PointF point1, PointF point2)
        {
            float x = Math.Min(point1.X, point2.X) + Math.Abs(point1.X - point2.X) * 2 / 3;
            float y = Math.Min(point1.Y, point2.Y) + Math.Abs(point1.Y - point2.Y) * 2 / 3;
            return new PointF(x, y);
        }
    }
}
