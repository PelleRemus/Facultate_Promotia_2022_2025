using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shooter
{
    // abstractizare: clasa Enemy este abstracta prin cuvantul cheie 'abstract'
    // nu mai avem voie sa scriem: new Enemy(...) -> eroare de compilare
    public abstract class Enemy
    {
        public int health, speed, spawnTime;
        // avem nevoie de aceste valori pentru a nu creste inamicul prea repede cand se apropie de ecran
        public double sizeX, sizeY;

        public PictureBox pictureBox;

        public Enemy(int health, int speed, int sizeX, int sizeY, Color color, int spawnTime)
        {
            this.health = health;
            this.speed = speed;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.spawnTime = spawnTime;

            pictureBox = new PictureBox();
            pictureBox.Size = new Size(sizeX, sizeY);
            pictureBox.Location = Engine.GetRandomPoint(sizeX, sizeY);

            pictureBox.BackColor = color;
            pictureBox.Click += PictureBox_Click;
        }

        // cand dam click pe un inamic, tragem in el, deci viata sa scade. daca viata ajunge la 0, acesta dispare de pe ecran
        private void PictureBox_Click(object sender, EventArgs e)
        {
            health = health - 20;
            if (health <= 0)
            {
                Engine.enemies.Remove(this);
                pictureBox.Parent = null;
            }
        }

        // inamicii se misca simplu, pozitia lor pe axa Oy creste cu viteza lor
        // in schimb, pe cum se apropie de ecran, acesta trebuie sa creasca. Pentru a nu creste prea repede,
        // vom creste valorile lui sizeX si sizeY doar cu un numar mai mic decat 1 de fiecare data
        public virtual void Move()
        {
            int x = pictureBox.Location.X;
            int y = pictureBox.Location.Y + speed;
            pictureBox.Location = new Point(x, y);

            sizeX = sizeX + (double)speed / 16;
            sizeY = sizeY + (double)speed / 16;
            pictureBox.Size = new Size((int)sizeX, (int)sizeY);
        }
    }
}
