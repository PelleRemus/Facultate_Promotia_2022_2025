using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        // punem imaginile intr-un array. Punem imaginea cu steguletul prima pentru a avea imaginea cu 1
        // pe indexul 1 al array-ului (asa, putem folosi valoarea butonului pentru a accesa imaginea corecta)
        public Image[] images = new Image[]
        {
            Image.FromFile("../../Images/flag.png"),
            Image.FromFile("../../Images/1.png"),
            Image.FromFile("../../Images/2.png"),
            Image.FromFile("../../Images/3.png"),
            Image.FromFile("../../Images/4.png"),
            Image.FromFile("../../Images/5.png"),
            Image.FromFile("../../Images/6.png"),
            Image.FromFile("../../Images/7.png"),
            Image.FromFile("../../Images/8.png"),
            Image.FromFile("../../Images/mine.png"),
        };

        public Form1()
        {
            InitializeComponent();
            // prin cuvantul cheie "this", folosim obiectul creat la rularea aplicatiei (de tipul Form1)
            // pe mine ma ajuta sa ma gandesc ca folosim "this object", obiectul curent deja creat
            Engine.Init(this);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            // reinitializem toate proprietatile importante ale butoanelor
            for (int i = 0; i < Engine.lines; i++)
                for (int j = 0; j < Engine.lines; j++)
                {
                    Engine.buttons[i, j].button.BackgroundImage = null;
                    Engine.buttons[i, j].button.BackColor = Color.LightGray;
                    Engine.buttons[i,j].isVisited = false;
                    Engine.buttons[i,j].isFlagged = false;
                    Engine.buttons[i, j].value = 0;
                }

            // si facem enable la toate butoanele, dupa care generam minele
            Engine.SetEnabledToAllButtons(true);
            Engine.GenerateMines();
        }
    }
}
