using System.Drawing;

namespace Shooter
{
    // mostenire: clasa NormalEnemy mosteneste clasa Enemy
    // ca sa nu avem eroare de compilare, trebuie sa satisfacem constructorul clasei de baza
    // acesta este apelat prin cuvantul cheie base(...) -> putem folosi aceleasi argumente
    // pentru proprietatile care dorim sa aiba mereu aceeasi valoare pentru obiectele de tipul NormalEnemy
    public class NormalEnemy : Enemy
    {
        public NormalEnemy(int spawnTime) : base(100, 5, 50, 50, Color.Crimson, spawnTime)
        {
        }
    }
}
