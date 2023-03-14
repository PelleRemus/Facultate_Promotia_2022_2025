using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public class Tile
    {
        public Button button;
        public int line, column;
        public int value;

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
