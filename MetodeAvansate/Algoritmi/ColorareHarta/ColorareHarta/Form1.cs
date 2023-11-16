using System.Windows.Forms;

namespace ColorareHarta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Engine.Init(this);
            Engine.ReadFromFile("../../TextFile1.txt");
            // Engine.Coloring();
            // Engine.DrawMap();

            // Engine.Hamiltonian();
            // label1.Text = Engine.solutions.Count.ToString();
            // Engine.DisplayRoad();

            button1.Enabled = button2.Enabled = textBox1.Enabled = false;
            Engine.DrawMap();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Engine.index++;
            textBox1.Text = Engine.index.ToString();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Engine.index--;
            textBox1.Text = Engine.index.ToString();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out Engine.index))
            {
                if (Engine.index < 0)
                    Engine.index = Engine.solutions.Count - 1;
                Engine.index = Engine.index % Engine.solutions.Count;
                textBox1.Text = Engine.index.ToString();
                Engine.DisplayRoad();
            }
        }

        private void dfsButton_Click(object sender, System.EventArgs e)
        {
            Engine.DepthFirstSearch(Engine.countries[0]);
            Engine.DrawMap();
        }

        private void bfsButton_Click(object sender, System.EventArgs e)
        {
            Engine.BreadthFirstSearch(Engine.countries[0]);
            Engine.DrawMap();
        }
    }
}
