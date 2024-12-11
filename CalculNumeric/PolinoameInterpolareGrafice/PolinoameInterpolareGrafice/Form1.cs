using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PolinoameInterpolareGrafice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics graphics;
        Bitmap bitmap;
        decimal x0, xn, y0, yn;

        int m, n;
        decimal[] x, y, f, u;
        decimal[,] Nf, T;

        private void button1_Click(object sender, EventArgs e)
        {
            m = 5;
            x = new decimal[] { 1, 1.1m, 1.3m, 1.5m, 1.6m };
            y = new decimal[] { 1, 1.032m, 1.091m, 1.145m, 1.17m };
            x0 = x[0];
            xn = x[m - 1];
            y0 = y[0];
            yn = y[m - 1];

            // Pasul 1, calculam diferentele divizate
            decimal[,] d = new decimal[m, m];
            for (int i = 0; i < m; i++)
                d[0, i] = y[i];

            for (int j = 1; j < m; j++)
                for (int i = 0; i < m - j; i++)
                    d[j, i] = (d[j - 1, i + 1] - d[j - 1, i]) / (x[i + 1] - x[i]);

            // Pasul 2, calculam Nf
            decimal h = (xn - x0) / 1000;
            u = new decimal[1000];
            Nf = new decimal[m, 1000];
            for (int j = 0; j < 1000; j++)
            {
                u[j] = x[0] + j * h;
                Nf[0, j] = y[0];
                decimal[] p = new decimal[m];
                p[0] = 1;
                for (int i = 1; i < m; i++)
                {
                    p[i] = p[i - 1] * (u[j] - x[i - 1]);
                    Nf[i, j] = Nf[i - 1, j] + p[i] * d[i, 0];
                }
            }

            decimal[] f = new decimal[1000];
            for (int i = 0; i < 1000; i++)
                f[i] = Nf[m - 1, i];

            // Pasul 3, desenare grafic
            DrawGraph(u, f);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            n = 7;
            x = new decimal[] { 7.5M, 10.5M, 13, 15.5M, 18, 21, 24, 27 };
            y = new decimal[] { 130M, 121, 128, 96, 122, 138, 114, 90 };
            x0 = x[0];
            xn = x[n];
            y0 = y.Min();
            yn = y.Max();

            decimal q = (xn - x0) / 1000;
            decimal[] h = new decimal[n + 1];
            for (int i = 1; i <= n; i++)
            {
                h[i] = x[i] - x[i - 1];
            }

            decimal[] a = new decimal[n + 1];
            decimal[] b = new decimal[n + 1];
            decimal[] c = new decimal[n + 1];
            decimal[] d = new decimal[n + 1];
            for (int i = 1; i <= n - 1; i++)
            {
                a[i] = 2;
                d[i] = 6M / (h[i] + h[i + 1]) *
                    ((y[i + 1] - y[i]) / h[i + 1] - (y[i] - y[i - 1]) / h[i]);
            }
            for (int i = 2; i <= n - 2; i++)
            {
                b[i] = h[i] / (h[i] + h[i + 1]);
                c[i] = 1 - b[i];
            }
            b[n - 1] = h[n - 1] / (h[n - 1] + h[n]);
            c[1] = h[2] / (h[1] + h[2]);
        }

        public void DrawGraph(decimal[] x, decimal[] y)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            for (int i = 0; i < x.Length; i++)
            {
                PointF location = MapValuesToPointF(x[i], y[i]);
                graphics.DrawEllipse(new Pen(Color.Red, 9),
                    location.X - 5, location.Y - 5, 11, 11);
            }

            pictureBox1.Image = bitmap;
        }

        public PointF MapValuesToPointF(decimal x, decimal y)
        {
            decimal scaleX = xn - x0;
            decimal scaleY = yn - y0;
            float X = (float)((x - x0) * (pictureBox1.Width - 5) / scaleX);
            float Y = pictureBox1.Height - (float)((y - y0) * (pictureBox1.Height - 5) / scaleY);
            return new PointF(X, Y);
        }
    }
}
