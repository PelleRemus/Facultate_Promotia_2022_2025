using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgLuiLee
{
    public static class Player
    {
        public static Point position, destinationPosition;
        public static Image image = Image.FromFile("../../Resources/player.png");
        public static Form1 form;
        public static PictureBox destination;
        public static List<Point> path;

        public static void Init(Form1 f)
        {
            position = new Point();
            destinationPosition = new Point();
            path = new List<Point>();
            form = f;
            ChangePosition(position);
        }

        public static void ChangePosition(Point newPosition)
        {
            form.display[newPosition.Y, newPosition.X].Image = image;
        }

        public static void GoToDestination()
        {
            if (path.Count == 0)
                return;
            Point nextPosition = path[0];
            path.RemoveAt(0);
            ChangePosition(nextPosition);

        }

        public static void FindPathLee()
        {
            path = new List<Point>();

            Queue coada = new Queue();
            coada.Add(new MapTile(destinationPosition.Y, destinationPosition.X, 1));
            form.matrix[destinationPosition.Y, destinationPosition.X] = 1;

            while(coada.length > 0)
            {
                MapTile crnt = coada.Remove();
                // stanga
                if(crnt.column > 0 && form.matrix[crnt.line, crnt.column - 1] == 0)
                {
                    coada.Add(new MapTile(crnt.line, crnt.column - 1, crnt.value + 1));
                    form.matrix[crnt.line, crnt.column - 1] = crnt.value + 1;
                }
                // jos
                if (crnt.line < form.n - 1 && form.matrix[crnt.line + 1, crnt.column] == 0)
                {
                    coada.Add(new MapTile(crnt.line + 1, crnt.column, crnt.value + 1));
                    form.matrix[crnt.line + 1, crnt.column] = crnt.value + 1;
                }
                // dreapta
                if (crnt.column < form.m - 1 && form.matrix[crnt.line, crnt.column + 1] == 0)
                {
                    coada.Add(new MapTile(crnt.line, crnt.column + 1, crnt.value + 1));
                    form.matrix[crnt.line, crnt.column + 1] = crnt.value + 1;
                }
                // sus
                if (crnt.line > 0 && form.matrix[crnt.line - 1, crnt.column] == 0)
                {
                    coada.Add(new MapTile(crnt.line - 1, crnt.column, crnt.value + 1));
                    form.matrix[crnt.line - 1, crnt.column] = crnt.value + 1;
                }
            }

            MapTile current = new MapTile(position.Y, position.X, form.matrix[position.Y, position.X]);
            while (current.value > 1)
            {
                // stanga
                if (current.column > 0 && form.matrix[current.line, current.column - 1] == current.value - 1)
                {
                    current = new MapTile(current.line, current.column - 1, current.value - 1);
                    path.Add(new Point(current.column - 1, current.line));
                }
                // jos
                else if (current.line < form.n - 1 && form.matrix[current.line + 1, current.column] == current.value - 1)
                {
                    current = new MapTile(current.line + 1, current.column, current.value - 1);
                    path.Add(new Point(current.column, current.line + 1));
                }
                // dreapta
                else if (current.column < form.m - 1 && form.matrix[current.line, current.column + 1] == current.value - 1)
                {
                    current = new MapTile(current.line, current.column + 1, current.value - 1);
                    path.Add(new Point(current.column + 1, current.line));
                }
                // sus
                else if (current.line > 0 && form.matrix[current.line - 1, current.column] == current.value - 1)
                {
                    current = new MapTile(current.line - 1, current.column, current.value - 1);
                    path.Add(new Point(current.column, current.line - 1));
                }
            }
        }
    }
}
