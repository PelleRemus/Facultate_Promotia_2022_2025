using System;
using System.Windows.Forms;

namespace BazeGrafuri
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
            Engine.ReadFile("../../InputMuchii.txt");
            Engine.CreateMatrix();
            Engine.WriteGraph();
            Engine.DrawGraph();
        }
    }
}
