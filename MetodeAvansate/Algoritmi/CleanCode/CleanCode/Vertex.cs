using System.Drawing;
using System.Windows.Markup;

namespace CleanCode
{
    // Vertex = noduri, fiecare nod are un nume si pozitiile x, y
    public class Vertex
    {
        public string Name { get; }
        public Point Position { get; }
        public Color FillColor { private get; set; }

        // Marimea cercului in pixeli
        private static int size = 20;

        public Vertex(string data)
        {
            string[] splittedData = data.Split(' ');

            // splittedData[0] reprezinta numele
            Name = splittedData[0];
            Position = GetPosition(splittedData);
            FillColor = GetColor(splittedData);
        }

        private Point GetPosition(string[] splittedData)
        {
            Point result = new Point();

            // splittedData are pe pozitiile 1 si 2 valorile lui X si Y
            result.X = int.Parse(splittedData[1]);
            result.Y = int.Parse(splittedData[2]);
            return result;
        }

        private Color GetColor(string[] splittedData)
        {
            // splittedData are pe pozitiile 3, 4 si 5 codurile unei culori
            int red = int.Parse(splittedData[3]);
            int green = int.Parse(splittedData[4]);
            int blue = int.Parse(splittedData[5]);

            return Color.FromArgb(red, green, blue);
        }

        public void Draw(Graphics handler)
        {
            // Umplem cercul cu culoara nodului
            handler.FillEllipse(
                new SolidBrush(FillColor),
                Position.X - size, Position.Y - size,
                2 * size + 1, 2 * size + 1
            );

            // Desenam conturul cercului (trebuie sa fie dupa umplere pentru a fi vizibil)
            handler.DrawEllipse(
                Pens.Black,
                Position.X - size, Position.Y - size,
                2 * size + 1, 2 * size + 1
            );

            // Scriem numele nodului in mijloc
            handler.DrawString(
                Name,
                new Font("Arial", 15, FontStyle.Bold),
                new SolidBrush(Color.White),
                new Point(Position.X - size / 2, Position.Y - size / 2)
            );
        }
    }
}