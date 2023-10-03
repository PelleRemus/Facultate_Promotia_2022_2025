using System;
using System.Windows.Forms;

namespace Shooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Initialize(this);
            // pentru ca intram in full screen la executarea programului, asteptam ca formularul sa fie incarcat intai
            // pentru a da valorile potrivite la pictureBox 1 Width si Height
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // am scos chenarul jocului propriu-zis, deci acum nu mai putem sa inchidem aplicatia decat daca apasam Esc
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        // folosind un timer, putem spune aplicatiei ce sa faca la fiecare "secunda" din joc
        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.Tick();
        }
    }
}
