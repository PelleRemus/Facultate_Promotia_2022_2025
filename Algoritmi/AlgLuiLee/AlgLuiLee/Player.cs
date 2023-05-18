using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgLuiLee
{
    public static class Player
    {
        // pozitia curenta a jucatorului si pozitia destinatiei
        public static Point position, destinationPosition;
        public static Image image = Image.FromFile("../../Resources/player.png"); // imaginea jucatorului
        public static Form1 form;
        public static PictureBox destination; // picturebox-ul care reprezinta destinatia jucatorului
        // calea reprezentata prin mai multe puncte, pe care trebuie sa o faca jucatorul pentru a ajunge la destinatie
        public static List<Point> path;

        public static void Init(Form1 f)
        {
            form = f;
            path = new List<Point>();
            // apelam metoda pentru a adauga imaginea pe pozitia curenta a jucatorului (pozitia 0, 0)
            ChangePosition(position);
        }

        public static void ChangePosition(Point newPosition)
        {
            // intai, stergem imaginea de pe pozitia curenta
            form.display[position.Y, position.X].pictureBox.Image = null;
            // apoi o adaugam pe noua pozitie
            form.display[newPosition.Y, newPosition.X].pictureBox.Image = image;
            position = newPosition;
        }
        public static void ChangeDestination(MapTile newDestination)
        {
            // sa nu uitam sa stergem culoarea aurie de fundal a destinatiei curente
            if (destination != null)
                destination.BackColor = Color.ForestGreen;

            // si apoi o adaugam la destinatia noua
            newDestination.pictureBox.BackColor = Color.Gold;
            destinationPosition = new Point(newDestination.column, newDestination.line);
            destination = newDestination.pictureBox;

            // reinitializam matricea pentru a incepe din nou de la 0
            // ca apoi sa putem apela din nou algoritmul lui Lee si acesta sa functioneze
            form.matrix = new int[form.n, form.m];
            FindPathLee();
        }

        public static void GoToDestination()
        {
            // daca nu avem niciun punct la care trebuie sa mergem, inseamna ca am ajuns la destinatie
            if (path.Count == 0)
                return;
            // luam urmatorul punct din lista, il stergem din lista, si schimbam pozitia jucatorului la acel punct
            Point nextPosition = path[0];
            path.RemoveAt(0);
            ChangePosition(nextPosition);
        }

        public static void FindPathLee()
        {
            // trebuie sa incepem cu drumul de la 0
            path = new List<Point>();

            Queue coada = new Queue();
            coada.Add(new MapTile(destinationPosition.Y, destinationPosition.X, 1));
            form.matrix[destinationPosition.Y, destinationPosition.X] = 1;

            // aici cream matricea cu toate drumurile posibile spre destinatie
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

            // iar aici folosim matricea pentru a alege unul dintre aceste drumuri, de cea mai scurta lungime,
            // de la pozitia curenta a jucatorului pana la destinatie
            MapTile current = new MapTile(position.Y, position.X, form.matrix[position.Y, position.X]);
            while (current.value > 1)
            {
                // stanga
                if (current.column > 0 && form.matrix[current.line, current.column - 1] == current.value - 1)
                {
                    path.Add(new Point(current.column - 1, current.line));
                    current = new MapTile(current.line, current.column - 1, current.value - 1);
                }
                // jos
                else if (current.line < form.n - 1 && form.matrix[current.line + 1, current.column] == current.value - 1)
                {
                    path.Add(new Point(current.column, current.line + 1));
                    current = new MapTile(current.line + 1, current.column, current.value - 1);
                }
                // dreapta
                else if (current.column < form.m - 1 && form.matrix[current.line, current.column + 1] == current.value - 1)
                {
                    path.Add(new Point(current.column + 1, current.line));
                    current = new MapTile(current.line, current.column + 1, current.value - 1);
                }
                // sus
                else if (current.line > 0 && form.matrix[current.line - 1, current.column] == current.value - 1)
                {
                    path.Add(new Point(current.column, current.line - 1));
                    current = new MapTile(current.line - 1, current.column, current.value - 1);
                }
            }
        }
    }
}
