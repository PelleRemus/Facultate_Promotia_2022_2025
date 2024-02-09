using System;
using System.Windows.Forms;

namespace TurnurileLuiHanoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width;
            Engine.Init(this);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var messageBoxResult = MessageBox.Show("Are you sure you want to Exit the game?",
                    "Exit game?", MessageBoxButtons.OKCancel);
                if (messageBoxResult == DialogResult.OK)
                    this.Close();
            }
        }

        private void NrOfDisks_ValueChanged(object sender, EventArgs e)
        {
            int nrOfDisks = (int)NrOfDisks.Value;
            Engine.InitGame(nrOfDisks);
            MinimumMoves.Text = "Minimum Moves: " + (Math.Pow(2, nrOfDisks) - 1);
        }

        private async void Solve_Click(object sender, EventArgs e)
        {
            await Engine.SolveRecursive((int)NrOfDisks.Value, Engine.A, Engine.B, Engine.C);//, Engine.D, Engine.E);
        }
    }
}
