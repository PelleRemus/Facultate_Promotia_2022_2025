using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Shooter
{
    public static class Engine
    {
        public static Form1 form;
        public static Random random = new Random();
        public static List<Enemy> enemies = new List<Enemy>();

        public static int fortResistance = 100;

        public static void Initialize(Form1 f)
        {
            form = f;
            // adaugam 5 inamici, care deocamdata sunt de test
            enemies.Add(new Enemy(100, 5, 50, 50));
            enemies.Add(new Enemy(100, 5, 50, 50));
            enemies.Add(new Enemy(100, 5, 50, 50));
            enemies.Add(new Enemy(100, 5, 50, 50));
            enemies.Add(new Enemy(100, 5, 50, 50));
        }

        public static void MoveEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                // parcurgem toti inamicii pentru a-i misca pe toti
                enemies[i].Move();
                // iar daca acestia ies cu totul din ecran, inamicul dispare si primim damage
                if (enemies[i].pictureBox.Location.Y > form.Height)
                {
                    enemies[i].pictureBox.Parent = null;
                    enemies.Remove(enemies[i]);
                    i--;

                    fortResistance = fortResistance - 20;
                    CheckIfYouLost();
                }
            }
        }

        public static void CheckIfYouLost()
        {
            if (fortResistance <= 0)
            {
                MessageBox.Show("The zombies ate your brain", "Game Over");
                form.Close();
            }
        }

        // aceasta metoda ne va da un punct la intamplare de pe axa Ox, dar acelasi punct pe axa Oy
        // tinem cont de dimensiunile inamicului: nu vrem ca acesta sa iasa din ecran pe axa Ox,
        // si vrem ca punctul unde apar inamicii cu picioarele sa fie acelasi
        public static Point GetRandomPoint(int sizeX, int sizeY)
        {
            return new Point(random.Next(form.Width - sizeX), 200 - sizeY);
        }
    }
}
