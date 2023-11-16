using System.Drawing;
using System.Windows.Forms;

namespace TurnurileLuiHanoi
{
    public class Disk
    {
        public int Value { get; set; }
        public PictureBox Display { get; set; }

        public Disk(int value)
        {
            Value = value;
            int width = 80 + value * 40;

            Display = new PictureBox();
            Display.Parent = Engine.form;
            Display.Size = new Size(width, 50);
            Display.BringToFront();
            Display.Click += Display_Click;

            switch (value)
            {
                case 1: Display.BackColor = Color.Red; break;
                case 2: Display.BackColor = Color.Orange; break;
                case 3: Display.BackColor = Color.Yellow; break;
                case 4: Display.BackColor = Color.YellowGreen; break;
                case 5: Display.BackColor = Color.Green; break;
                case 6: Display.BackColor = Color.Blue; break;
                case 7: Display.BackColor = Color.Indigo; break;
                case 8: Display.BackColor = Color.Violet; break;
            }
        }

        private void Display_Click(object sender, System.EventArgs e)
        {
            if (Display.Cursor == Cursors.Hand)
            {
                if (Engine.selectedDisk != null)
                {
                    Engine.selectedDisk.Display.BorderStyle = BorderStyle.None;
                }
                Engine.selectedDisk = this;
                Display.BorderStyle = BorderStyle.Fixed3D;
                Engine.FindSelectedRod();
            }
        }
    }
}
