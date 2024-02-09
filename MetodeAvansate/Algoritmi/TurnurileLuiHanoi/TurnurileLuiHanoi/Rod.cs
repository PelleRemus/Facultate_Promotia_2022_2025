using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TurnurileLuiHanoi
{
    public class Rod
    {
        public const int Y = 250;
        public const int Width = 300;
        public const int Height = 500;

        public int X { get; set; }
        public PictureBox Display { get; set; }
        public Stack<Disk> Tower { get; set; }

        public Rod(int x)
        {
            X = x;
            Tower = new Stack<Disk>();

            Display = new PictureBox();
            Display.Parent = Engine.form;
            Display.Size = new Size(20, Height);
            Display.Location = new Point(x + (Width - Display.Width) / 2, Y);
            Display.BackColor = Color.Black;
            Display.Click += Display_Click;
        }

        private async void Display_Click(object sender, System.EventArgs e)
        {
            if (Display.Cursor == Cursors.Hand)
            {
                await Engine.Move(Engine.selectedRod, this);
            }
        }

        public void CheckIfSelectedRod()
        {
            if (Tower.Count > 0 && Tower.Peek() == Engine.selectedDisk)
            {
                Engine.selectedRod = this;
                Display.Cursor = Cursors.Arrow;
            }
            else
            {
                Display.Cursor = Cursors.Hand;
            }
        }

        public void AddDisk(Disk disk)
        {
            if (Tower.Count > 0)
            {
                Tower.Peek().Display.Cursor = Cursors.Arrow;
            }
            Tower.Push(disk);

            disk.Display.Cursor = Cursors.Hand;
            disk.Display.Left = X + (Width - disk.Display.Width) / 2;
            disk.Display.Top = Display.Bottom - Tower.Count * 60;
        }

        public Disk RemoveDisk()
        {
            Disk disk = Tower.Pop();
            if (Tower.Count > 0)
            {
                Tower.Peek().Display.Cursor = Cursors.Hand;
            }
            return disk;
        }

        public void ClearDisks()
        {
            foreach (Disk disk in Tower)
            {
                disk.Display.Parent = null;
            }
            Tower.Clear();
        }
    }
}
