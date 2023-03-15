using System;

namespace Minesweeper
{
    // clasele statice se folosesc fara obiecte, si nu au constructor
    // observati ca pentru a folosi fielduri din clasa Engine, vom scrie direct "Engine.fieldName"
    // deci direct cu numele clasei, pe cand pentru clasa Tile, folosim un obiect al acestei clase: "buttons[i, j].fieldName"
    // poate va este mai usor daca va ganditi ca avem clasa in sine ca si singurul obiect al clasei
    public static class Engine
    {
        public static Form1 form;
        public static Random random;
        public static Tile[,] buttons;

        public static int lines;
        public static int size;

        public static void Init(Form1 f)
        {
            form = f;
            lines = 10;
            size = form.pictureBox1.Width / lines;
            random = new Random();

            // intai initializam matricea, apoi apelam constructorul fiecarui element din matrice pentru initializarea acestora
            // de data asta, vom construi butonul in constructor, in clasa Tile
            buttons = new Tile[10, 10];
            for(int i = 0; i < lines; i++) 
                for(int j = 0; j < lines; j++)
                {
                    buttons[i, j] = new Tile(i, j);
                }

            GenerateMines();
        }

        public static void GenerateMines()
        {
            // vom crea cate mine dorim. Parcurgem numarul de mine cu un for
            int numberOfMines = 15;
            for(int mine = 0; mine < numberOfMines; mine++)
            {
                // pentru fiecare mina, alegem la intamplare linia si coloana pe care dorim sa se afle
                // cu toate acestea, dorim sa nu se suprapuna cu o alta mina existenta, deci tot alegem valori la intamplare
                // cat timp valoarea de pe tile este 9
                int i, j;
                do {
                    i = random.Next(lines);
                    j = random.Next(lines);
                } while (buttons[i, j].value == 9);
                // am ales 9 pentru valoarea ce reprezinta minele pentru ca nu putem avea un 9 ca valoare existenta pe teren
                buttons[i, j].value = 9;

                // pentru fiecare mina, parcurgem patratul de 3x3 care inconjoara mina respectiva
                // pentru a incrementa valoarea tuturor tile-urilor acestora care nu sunt mine
                // alegem apoi imaginea de fundal a butonului in functie de valoarea acestuia
                for (int k = i - 1; k <= i + 1; k++)
                    for (int l = j - 1; l <= j + 1; l++)
                    {
                        if (k >= 0 && k < lines && l >= 0 && l < lines)
                        {
                            if (buttons[k, l].value != 9)
                                buttons[k, l].value++;

                            buttons[k, l].button.BackgroundImage = form.images[buttons[k, l].value];
                        }
                    }
            }
        }
    }
}
