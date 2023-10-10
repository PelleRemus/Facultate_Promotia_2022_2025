using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    public class Tile
    {
        public Button button;
        public int line, column;
        public int value;
        public bool isVisited;
        public bool isFlagged;

        // aceasta metoda este speciala, numita constructor. O puteti identifica prin faptul ca
        // nu are tip de return, nici macar void, si are acelasi nume ca si clasa
        // aceasta metoda are rolul de a initializa field-urile clasei, si este apelata automat
        // in momentul in care scriem "new Tile(i, j)": observati ca avem paranteze si parametrii necesari, deci apelam metoda
        public Tile(int i, int j) 
        {
            line = i; column = j;
            value = 0;
            isVisited = false;
            isFlagged = false;

            button = new Button();
            button.Parent = Engine.form.pictureBox1;
            button.Size = new Size(Engine.size, Engine.size);

            button.Location = new Point(column * Engine.size, line * Engine.size);
            button.BackgroundImageLayout = ImageLayout.Stretch;

            button.MouseDown += Button_MouseDown;
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            // daca apasam click stanga pe un buton flagged, nu se intampla nimic
            if(e.Button == MouseButtons.Left && !isFlagged)
            {
                // traversam in matrice incepand cu butonul curent
                Engine.TraverseMatrix(line, column);

                // daca am dat click pe o mina, am pierdut
                if (Engine.buttons[line, column].value == 9)
                    Engine.GameLost();
            }
            // daca incercam sa punem stegulet pe un buton deja vizitat, nu se intampla nimic
            if(e.Button == MouseButtons.Right && !isVisited)
            {
                // punem imaginea cu steguletul, sau stergem imaginea cu steag afisata
                if (!isFlagged)
                    button.BackgroundImage = Engine.form.images.First();
                else
                    button.BackgroundImage = null;

                // facem toggle la proprietatea isFlagged
                isFlagged = !isFlagged;
            }

            // la fiecare apasare de buton, verificam daca jucatorul a castigat, caz in care afisam un mesaj corespunzator
            if (Engine.CheckIfYouWin())
            {
                MessageBox.Show("Ai castigat :D", "Game Won!");
                Engine.SetEnabledToAllButtons(false);
            }
        }
    }
}
