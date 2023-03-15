using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public class Tile
    {
        public Button button;
        public int line, column;
        public int value;

        // aceasta metoda este speciala, numita constructor. O puteti identifica prin faptul ca
        // nu are tip de return, nici macar void, si are acelasi nume ca si clasa
        // aceasta metoda are rolul de a initializa field-urile clasei, si este apelata automat
        // in momentul in care scriem "new Tile(i, j)": observati ca avem paranteze si parametrii necesari, deci apelam metoda
        public Tile(int i, int j) 
        {
            line = i; column = j;
            value = 0;

            button = new Button();
            button.Parent = Engine.form.pictureBox1;
            button.Size = new Size(Engine.size, Engine.size);

            button.Location = new Point(column * Engine.size, line * Engine.size);
            button.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
