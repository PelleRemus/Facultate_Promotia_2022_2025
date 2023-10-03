using System.Drawing;

namespace RainbowSort
{
    public static class Resources
    {
        public static int n, frequency = 15, stroke;
        public static Colour[] rainbow;
        public static Bitmap bmp = new Bitmap(Engine.display.Width, Engine.display.Height);
        public static Graphics grp = Graphics.FromImage(bmp);

        public static void GenerateRainbow()
        {
            int interval = 255 / frequency;
            n = interval * 6;
            rainbow = new Colour[n];
            stroke = 2 * frequency / 5;
            int r = 255, g = 0, b = 0;

            for (int i = 0; i < interval; i++)
                rainbow[i] = new Colour(Color.FromArgb(r, g += frequency, b), i);
            for (int i = interval; i < 2 * interval; i++)
                rainbow[i] = new Colour(Color.FromArgb(r -= frequency, g, b), i);
            for (int i = 2 * interval; i < 3 * interval; i++)
                rainbow[i] = new Colour(Color.FromArgb(r, g, b += frequency), i);
            for (int i = 3 * interval; i < 4 * interval; i++)
                rainbow[i] = new Colour(Color.FromArgb(r, g -= frequency, b), i);
            for (int i = 4 * interval; i < 5 * interval; i++)
                rainbow[i] = new Colour(Color.FromArgb(r += frequency, g, b), i);
            for (int i = 5 * interval; i < n; i++)
                rainbow[i] = new Colour(Color.FromArgb(r, g, b -= frequency), i);
        }

        public static void ShowRainbow()
        {
            for (int i = 0; i < n; i++)
                Draw(i);
        }

        public static void Draw(int i)
        {
            grp.DrawLine(new Pen(rainbow[i].colour, stroke), i * stroke, 0, i * stroke, Engine.display.Height);
            Engine.display.Image = bmp;
        }

        public static void DrawBlack(int i)
        {
            grp.DrawLine(new Pen(Color.Black, stroke), i * stroke, 0, i * stroke, Engine.display.Height);
            Engine.display.Image = bmp;
        }
    }
}
