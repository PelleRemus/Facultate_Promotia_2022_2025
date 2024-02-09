using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurnurileLuiHanoi
{
    public static class Engine
    {
        public static int moves;
        public static Form1 form;
        public static Rod A, B, C, D, E, selectedRod;
        public static Disk selectedDisk;

        public static void Init(Form1 f)
        {
            form = f;
            A = new Rod(100);
            B = new Rod(450);
            C = new Rod(800);
            D = new Rod(1150);
            E = new Rod(1500);

            InitGame(3);
        }

        public static void InitGame(int nrOfDisks)
        {
            moves = 0;
            form.Moves.Text = "Moves: 0";
            A.ClearDisks();
            B.ClearDisks();
            C.ClearDisks();
            D.ClearDisks();
            E.ClearDisks();

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
            D.CheckIfSelectedRod();
            E.CheckIfSelectedRod();
        }

        public static void Deselect()
        {
            if (selectedDisk != null)
            {
                selectedDisk.Display.BorderStyle = BorderStyle.None;
            }
            selectedDisk = null;
            selectedRod = null;
            A.Display.Cursor = B.Display.Cursor = C.Display.Cursor = D.Display.Cursor = E.Display.Cursor = Cursors.Arrow;
        }

        public static async Task Move(Rod from, Rod to)
        {
            if (to.Tower.Count == 0 || from.Tower.Peek().Value < to.Tower.Peek().Value)
            {
                Disk disk = from.RemoveDisk();
                to.AddDisk(disk);
                moves++;
                form.Moves.Text = "Moves: " + moves;

                Deselect();
                CheckIfYouWin();
                await Task.Delay(100);
            }
        }

        public static async Task SolveRecursive(int n, Rod from, Rod middle, Rod to)
        {
            if (n == 1)
            {
                await Move(from, to);
            }
            else
            {
                await SolveRecursive(n - 1, from, to, middle);
                await SolveRecursive(1, from, middle, to);
                await SolveRecursive(n - 1, middle, from, to);
            }
        }

        public static async Task SolveRecursive4(int n, Rod from, Rod middle1, Rod middle2, Rod to)
        {
            if (n == 1)
            {
                await Move(from, to);
            }
            else if (n == 2)
            {
                await Move(from, middle1);
                await Move(from, to);
                await Move(middle1, to);
            }
            else
            {
                await SolveRecursive4(n - 2, from, middle2, to, middle1);
                await SolveRecursive4(2, from, middle2, middle1, to);
                await SolveRecursive4(n - 2, middle1, from, middle2, to);
            }
        }

        public static async Task SolveRecursive5(int n, Rod from, Rod middle1, Rod middle2, Rod middle3, Rod to)
        {
            if (n == 1)
            {
                await Move(from, to);
            }
            else if (n == 2)
            {
                await Move(from, middle1);
                await Move(from, to);
                await Move(middle1, to);
            }
            else if (n == 3)
            {
                await Move(from, middle1);
                await SolveRecursive5(2, from, middle2, middle1, middle3, to);
                await Move(middle1, to);
            }
            else
            {
                await SolveRecursive5(n - 3, from, middle3, middle2, to, middle1);
                await SolveRecursive5(3, from, middle2, middle3, middle1, to);
                await SolveRecursive5(n - 3, middle1, from, middle3, middle2, to);
            }
        }

        public static void CheckIfYouWin()
        {
            if (E.Tower.Count == form.NrOfDisks.Value)
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
