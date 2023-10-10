using System;
using System.Drawing;
using System.Windows.Forms;

namespace X_si_O
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[,] buttons;
        int n = 3;
        int roundNumber = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            int size = pictureBox1.Width / n;
            buttons = new Button[n, n];

            // parcurgem matricea ca si orice alta matrice, pentru a initializa toate butoanele
            for (int i = 0; i < n; i++)
                for(int j = 0; j < n; j++)
                {
                    Button button = new Button();
                    // fara aceasta proprietate, butonul exista dar nu stie unde sa fie afisat
                    button.Parent = pictureBox1;
                    button.Size = new Size(size, size);

                    // pozitia butonului este in funtie de linie, coloana si dimensiune
                    // j reprezinta coloanele, deci ne da pozitia in planul Ox
                    button.Location = new Point(j * size, i * size);
                    button.BackColor = Color.CornflowerBlue;
                    button.Font = new Font("Arial", 30, FontStyle.Bold);

                    // cand se intampla evenimentul Click la orice buton, vrem sa se apeleze metoda Button_Click
                    // nu apelam noi metoda, deci scriem doar numele acesteia fara sa folosim paranteze
                    // la evenimentul Click, se pot intampla mai multe lucruri, deci am putea adauga mai multe metode, si de aceea folosim operatorul +=
                    button.Click += Button_Click;
                    buttons[i,j] = button;
                }
        }

        // cand apasam pe New Game, aducem butoanele si variabilele din joc la starea lor initiala
        private void button1_Click(object sender, EventArgs e)
        {
            SetEnabledToAllButtons(true);
            roundNumber = 1;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    buttons[i, j].Text = "";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // "sender" este chiar butonul pe care am dat click. Nu dorim sa aparam pe acest buton de mai multe ori, deci ii facem disable
            Button button = sender as Button;
            button.Enabled = false;

            // dam valoare butonului in functie de jucator. Acesta este determinat de numarul rundei
            if (roundNumber % 2 != 0)
                button.Text = "X";
            else
                button.Text = "O";

            if(GameIsWon())
            {
                MessageBox.Show("Player " + button.Text + " has won!", "Game Won");
                SetEnabledToAllButtons(false);
            }
            else if(GameIsOver())
            {
                MessageBox.Show("It's a draw!", "Game Over");
            }

            roundNumber++;
        }

        private bool GameIsWon()
        {
            // vom "traduce" matricea de butoane din valorile X, O sau nimic, in 1, 10 respectiv 0
            int[,] matrix = new int[n, n];

            for(int i = 0; i < n; i++)
                for(int j = 0; j < n; j++)
                {
                    if (buttons[i,j].Text == "X")
                        matrix[i,j] = 1;
                    else if(buttons[i, j].Text == "O")
                        matrix[i,j] = 10;
                }

            /*
            // versiunea simpla, fara sa ne gandim prea mult, care merge cu copy paste
            // ne asiguram ca acoperim sumele tuturor liniilor, coloanelor si diagonalelor
            int suma1 = matrix[0, 0] + matrix[0, 1] + matrix[0, 2];
            int suma2 = matrix[1, 0] + matrix[1, 1] + matrix[1, 2];
            int suma3 = matrix[2, 0] + matrix[2, 1] + matrix[2, 2];

            int suma4 = matrix[0, 0] + matrix[1, 0] + matrix[2, 0];
            int suma5 = matrix[0, 1] + matrix[1, 1] + matrix[2, 1];
            int suma6 = matrix[0, 2] + matrix[1, 2] + matrix[2, 2];

            int suma7 = matrix[0, 0] + matrix[1, 1] + matrix[2, 2];
            int suma8 = matrix[0, 2] + matrix[1, 1] + matrix[2, 0];

            // dupa care verificam daca vreunul din jucatori a castigat pe vreuna dintre acestea
            if(suma1 == 3 || suma1 == 30 ||
                suma2 == 3 || suma2 == 30 ||
                suma3 == 3 || suma3 == 30 ||
                suma4 == 3 || suma4 == 30 ||
                suma5 == 3 || suma5 == 30 ||
                suma6 == 3 || suma6 == 30 ||
                suma7 == 3 || suma7 == 30 ||
                suma8 == 3 || suma8 == 30)
            {
                return true;
            }*/

            // versiunea gandita, mai "corecta" si mai extensibila (poate fi aplicata foarte usor si la o matrice mai mare decat 3x3)
            // calculam programatic sumele pe toate liniile, toate coloanele, si pe diagonale, noi avand de scris practic doar verificari pe 4 sume
            int sumaPrincipala = 0, sumaSecundara = 0;
            for (int i = 0; i < n; i++)
            {
                int sumaLinie = 0, sumaColoana = 0;
                for (int j = 0; j < n; j++)
                {
                    sumaLinie += matrix[i, j];
                    sumaColoana += matrix[j, i]; // pentru a calcula suma pe coloana, inversam indicii in matrice
                }

                if(sumaLinie == 3 || sumaLinie == 30 ||
                    sumaColoana == 3 || sumaColoana == 30)
                    return true;

                sumaPrincipala += matrix[i, i];
                sumaSecundara += matrix[i, n - i - 1];
            }

            if (sumaPrincipala == 3 || sumaPrincipala == 30 ||
                sumaSecundara == 3 || sumaSecundara == 30)
                return true;

            return false;
        }

        private bool GameIsOver()
        {
            // jocul este o remiza daca am dat valoare tuturor butoanelor din joc
            if (roundNumber == n * n)
                return true;
            return false;
        }

        private void SetEnabledToAllButtons(bool isEnabled)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    buttons[i, j].Enabled = isEnabled;
        }
    }
}
