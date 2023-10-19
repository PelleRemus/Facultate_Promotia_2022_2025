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
            Engine.Coloring();
            Engine.DrawMap();
        }
    }
}
