using System.Drawing;
using System.Windows.Forms;

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
    }
}
