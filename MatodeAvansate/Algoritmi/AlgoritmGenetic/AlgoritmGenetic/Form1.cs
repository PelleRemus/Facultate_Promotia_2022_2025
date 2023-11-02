using System;
using System.Windows.Forms;

namespace AlgoritmGenetic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.NextGeneration();
        }
    }
}
