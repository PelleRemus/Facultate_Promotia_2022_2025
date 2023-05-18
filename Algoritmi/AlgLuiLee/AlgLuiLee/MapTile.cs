using System;
using System.Windows.Forms;

namespace AlgLuiLee
{
    public class MapTile
    {
        public int line, column, value;
        public PictureBox pictureBox;

        public MapTile(int line, int column, int value)
        {
            this.line = line;
            this.column = column;
            this.value = value;
        }

        public MapTile(int line, int column, PictureBox pictureBox) : this(line, column, 0)
        {
            this.pictureBox = pictureBox;
            pictureBox.Click += PictureBox_Click;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Player.ChangeDestination(this);
        }
    }
}
