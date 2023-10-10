using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Shooter
{
    public static class Engine
    {
        public static Form1 form;
        public static Random random = new Random();
        public static List<Enemy> enemies = new List<Enemy>();
        // variabila waves va initializa toti inamicii grupati in functie de wave,
        // iar variabila enemies va fi populata cu acestia la momentul potrivit (in functie de spawnTime)
        public static List<List<Enemy>> waves = new List<List<Enemy>>();

        public static int fortResistance = 100;
        public static int ticks = 0, currentWave = 0;

        public static void Initialize(Form1 f)
        {
            form = f;

            // adaugam 2 wave-uri de test
            List<Enemy> wave1 = new List<Enemy>();
            wave1.Add(new NormalEnemy(5));
            wave1.Add(new NormalEnemy(15));
            wave1.Add(new NormalEnemy(20));
            wave1.Add(new NormalEnemy(30));
            wave1.Add(new NormalEnemy(40));
            waves.Add(wave1);

            List<Enemy> wave2 = new List<Enemy>();
            wave2.Add(new NormalEnemy(5));
            wave2.Add(new NormalEnemy(10));
            wave2.Add(new NormalEnemy(15));
            wave2.Add(new NormalEnemy(20));
            wave2.Add(new NormalEnemy(30));
            wave2.Add(new FastEnemy(40));
            wave2.Add(new FastEnemy(45));
            waves.Add(wave2);
        }

        public static void Tick()
        {
            MoveEnemies();
            ticks++;

            CheckIfNextWave();
            CheckIfYouWin();
            // daca am ajuns cu tick-urile din joc la valoarea spawnTime a urmatorului inamic din wave-ul curent,
            // adaugam acel inamic in lista enemies si il afisam pe picturebox, si il scoatem din lista de wave-uri.
            // primele verificari sunt pentru a nu iesi din index-ul listelor
            if (currentWave < waves.Count && waves[currentWave].Any()
                && waves[currentWave].First().spawnTime <= ticks)
            {
                enemies.Add(waves[currentWave].First());
                enemies.Last().pictureBox.Parent = form.pictureBox1;
                waves[currentWave].RemoveAt(0);
            }
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

        public static void CheckIfNextWave()
        {
            // trecem la wave-ul urmator daca nu mai sunt inamici in wave-ul curent
            // si daca nu mai sunt alti inamici afisati pe ecran
            if (!waves[currentWave].Any() && !enemies.Any())
            {
                currentWave++;
                ticks = 0;
            }
        }

        public static void CheckIfYouWin()
        {
            // castigam in momentul in care nu mai sunt alte wave-uri (am supravietuit)
            if (currentWave >= waves.Count)
            {
                form.timer1.Stop();
                MessageBox.Show("You survived the zombies attack", "You Win!");
                form.Close();
            }
        }

        public static void CheckIfYouLost()
        {
            // peirdem cand "viata" ajunge la 0
            if (fortResistance <= 0)
            {
                form.timer1.Stop();
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
