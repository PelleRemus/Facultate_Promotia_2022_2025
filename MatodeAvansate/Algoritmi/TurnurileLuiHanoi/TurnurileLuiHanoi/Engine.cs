using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurnurileLuiHanoi
{
    public static class Engine
    {
        public static int moves;
        public static Form1 form;
        public static Rod A, B, C, selectedRod;
        public static Disk selectedDisk;

        public static void Init(Form1 f)
        {
            form = f;
            A = new Rod(100);
            B = new Rod(550);
            C = new Rod(1000);

            InitGame(3);
        }

        public static void InitGame(int nrOfDisks)
        {
            moves = 0;
            form.Moves.Text = "Moves: 0";
            A.ClearDisks();
            B.ClearDisks();
            C.ClearDisks();

            for (int i = nrOfDisks; i > 0; i--)
            {
                A.AddDisk(new Disk(i));
            }
        }

        public static void FindSelectedRod()
        {
            A.CheckIfSelectedRod();
            B.CheckIfSelectedRod();
            C.CheckIfSelectedRod();
        }

        public static void Deselect()
        {
            if (selectedDisk != null)
            {
                selectedDisk.Display.BorderStyle = BorderStyle.None;
            }
            selectedDisk = null;
            selectedRod = null;
            A.Display.Cursor = B.Display.Cursor = C.Display.Cursor = Cursors.Arrow;
        }

        public static void Move(Rod from, Rod to)
        {
            if (to.Tower.Count == 0 || from.Tower.Peek().Value < to.Tower.Peek().Value)
            {
                Disk disk = from.RemoveDisk();
                to.AddDisk(disk);
                moves++;
                form.Moves.Text = "Moves: " + moves;

                Deselect();
                CheckIfYouWin();
            }
        }

        public static async Task SolveRecursive(int n, Rod from, Rod middle, Rod to)
        {
            if (n == 1)
            {
                Move(from, to);
                await Task.Delay(300);
            }
            else
            {
                await SolveRecursive(n - 1, from, to, middle);
                await SolveRecursive(1, from, middle, to);
                await SolveRecursive(n - 1, middle, from, to);
            }
        }

        public static void CheckIfYouWin()
        {
            if (C.Tower.Count == form.NrOfDisks.Value)
            {
                string message = "But you did not solve this in the minimum number of moves!";
                if (moves == Math.Pow(2, (int)form.NrOfDisks.Value) - 1)
                {
                    message = "Congratulations! Your solve was with the minimum number of moves!";
                }
                MessageBox.Show(message, "You Win!");
            }
        }
    }
}
