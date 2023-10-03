using System.Drawing;

namespace Shooter
{
    public class FastEnemy : Enemy
    {
        public FastEnemy(int spawnTime) : base(70, 10, 40, 40, Color.RoyalBlue, spawnTime)
        {
        }

        // polimorfism: metodele virtuale din clasa de baza pot fi suprascrise
        // putem pastra implementarea precedenta daca dorim, prin cuvantul cheie base.NumeleMetodei()
        // dupa care putem veni cu implementarea proprie: ne apropiem incet de centrul ecranului
        public override void Move()
        {
            base.Move();

            if (pictureBox.Location.X < Engine.form.Width / 2)
                pictureBox.Location = new Point(pictureBox.Location.X + speed,
                                                pictureBox.Location.Y);
            else
                pictureBox.Location = new Point(pictureBox.Location.X - speed,
                                                pictureBox.Location.Y);
        }
    }
}
