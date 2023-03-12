using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public partial class Form1 : Form
    {
        //     Configuratii posibile:
        // one pair - acelasi numar apare de doua ori
        // two pairs - acelasi numar apare de doua ori, doua perechi
        // three of a kind - acelasi numar apare de trei ori
        // straight - in mana, apar cartile in ordine (culoarea nu conteaza)
        // flush - 5 carti de aceeasi culoare
        // full house - one pair + three of a kind
        // four of a kind - acelasi numar apare de 4 ori
        // straight flush - straight + flush

        Image[] cardsImages = new Image[]
        {
            Image.FromFile("../../Images/2OfClubs card.png"),       // 0
            Image.FromFile("../../Images/3OfClubs card.png"),       // 1
            Image.FromFile("../../Images/4OfClubs card.png"),
            Image.FromFile("../../Images/5OfClubs card.png"),
            Image.FromFile("../../Images/6OfClubs card.png"),
            Image.FromFile("../../Images/7OfClubs card.png"),
            Image.FromFile("../../Images/8OfClubs card.png"),
            Image.FromFile("../../Images/9OfClubs card.png"),
            Image.FromFile("../../Images/10OfClubs card.png"),
            Image.FromFile("../../Images/JackOfClubs card.png"),
            Image.FromFile("../../Images/QueenOfClubs card.png"),
            Image.FromFile("../../Images/KingOfClubs card.png"),
            Image.FromFile("../../Images/AceOfClubs card.png"),     // 12

            Image.FromFile("../../Images/2OfSpades card.png"),      // 13
            Image.FromFile("../../Images/3OfSpades card.png"),      // 14
            Image.FromFile("../../Images/4OfSpades card.png"),
            Image.FromFile("../../Images/5OfSpades card.png"),
            Image.FromFile("../../Images/6OfSpades card.png"),
            Image.FromFile("../../Images/7OfSpades card.png"),
            Image.FromFile("../../Images/8OfSpades card.png"),
            Image.FromFile("../../Images/9OfSpades card.png"),
            Image.FromFile("../../Images/10OfSpades card.png"),
            Image.FromFile("../../Images/JackOfSpades card.png"),
            Image.FromFile("../../Images/QueenOfSpades card.png"),
            Image.FromFile("../../Images/KingOfSpades card.png"),
            Image.FromFile("../../Images/AceOfSpades card.png"),    // 25

            Image.FromFile("../../Images/2OfHearts card.png"),      // 26
            Image.FromFile("../../Images/3OfHearts card.png"),      // 27
            Image.FromFile("../../Images/4OfHearts card.png"),
            Image.FromFile("../../Images/5OfHearts card.png"),
            Image.FromFile("../../Images/6OfHearts card.png"),
            Image.FromFile("../../Images/7OfHearts card.png"),
            Image.FromFile("../../Images/8OfHearts card.png"),
            Image.FromFile("../../Images/9OfHearts card.png"),
            Image.FromFile("../../Images/10OfHearts card.png"),
            Image.FromFile("../../Images/JackOfHearts card.png"),
            Image.FromFile("../../Images/QueenOfHearts card.png"),
            Image.FromFile("../../Images/KingOfHearts card.png"),
            Image.FromFile("../../Images/AceOfHearts card.png"),    // 38

            Image.FromFile("../../Images/2OfDiamonds card.png"),    // 39
            Image.FromFile("../../Images/3OfDiamonds card.png"),    // 40
            Image.FromFile("../../Images/4OfDiamonds card.png"),
            Image.FromFile("../../Images/5OfDiamonds card.png"),
            Image.FromFile("../../Images/6OfDiamonds card.png"),
            Image.FromFile("../../Images/7OfDiamonds card.png"),
            Image.FromFile("../../Images/8OfDiamonds card.png"),
            Image.FromFile("../../Images/9OfDiamonds card.png"),
            Image.FromFile("../../Images/10OfDiamonds card.png"),
            Image.FromFile("../../Images/JackOfDiamonds card.png"),
            Image.FromFile("../../Images/QueenOfDiamonds card.png"),
            Image.FromFile("../../Images/KingOfDiamonds card.png"),
            Image.FromFile("../../Images/AceOfDiamonds card.png"),  // 51
        };
        Random random = new Random();
        int n = 52;
        int[] cardsOrder;

        public Form1()
        {
            InitializeComponent();

            cardsOrder = new int[n];
            for (int i = 0; i < n; i++)
                cardsOrder[i] = i;

            Width = 1300;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            Shuffle();

            CardDealingAnimation(p1_1, cardsImages[cardsOrder[0]]); await Task.Delay(200);
            CardDealingAnimation(p1_2, cardsImages[cardsOrder[1]]); await Task.Delay(200);
            CardDealingAnimation(p1_3, cardsImages[cardsOrder[2]]); await Task.Delay(200);
            CardDealingAnimation(p1_4, cardsImages[cardsOrder[3]]); await Task.Delay(200);
            CardDealingAnimation(p1_5, cardsImages[cardsOrder[4]]); await Task.Delay(200);

            CardDealingAnimation(p2_1, cardsImages[cardsOrder[5]]); await Task.Delay(200);
            CardDealingAnimation(p2_2, cardsImages[cardsOrder[6]]); await Task.Delay(200);
            CardDealingAnimation(p2_3, cardsImages[cardsOrder[7]]); await Task.Delay(200);
            CardDealingAnimation(p2_4, cardsImages[cardsOrder[8]]); await Task.Delay(200);
            CardDealingAnimation(p2_5, cardsImages[cardsOrder[9]]); await Task.Delay(2000);

            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // calculam puterea mainilor fiecarui jucator
            int power1 = 0, power2 = 0;

            // luam functiile descrescator, de la cea mai specifica la cea mai simpla combinatie
            // altfel, in loc de full house, am spune ca un player cu o astfel de mana are o pereche
            // dam o "putere" sau scor diferite pentru fiecare combinatie
            if (StraightFlush(true))
                power1 = 800;
            else if (FourOfAKind(true))
                power1 = 700;
            else if (FullHouse(true))
                power1 = 600;
            else if (Flush(true))
                power1 = 500;
            else if (Straight(true))
                power1 = 400;
            else if (ThreeOfAKind(true))
                power1 = 300;
            else if (TwoPairs(true))
                power1 = 200;
            else if (OnePair(true))
                power1 = 100;

            if (StraightFlush(false))
                power2 = 800;
            else if (FourOfAKind(false))
                power2 = 700;
            else if (FullHouse(false))
                power2 = 600;
            else if (Flush(false))
                power2 = 500;
            else if (Straight(false))
                power2 = 400;
            else if (ThreeOfAKind(false))
                power2 = 300;
            else if (TwoPairs(false))
                power2 = 200;
            else if (OnePair(false))
                power2 = 100;
        }

        private void Shuffle()
        {
            for (int i = 1; i < n; i++)
            {
                int index = random.Next(i);
                Swap(i, index);
            }
        }

        private void Swap(int i, int j)
        {
            int aux = cardsOrder[i];
            cardsOrder[i] = cardsOrder[j];
            cardsOrder[j] = aux;
        }

        private async Task CardDealingAnimation(PictureBox destination, Image cardImage)
        {
            PictureBox card = CreatePictureBoxForNewCard();
            float percent = 30F / Distance(card.Location, destination.Location);

            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(i / 5);
                float x = card.Location.X + percent * (destination.Location.X - card.Location.X);
                float y = card.Location.Y + percent * (destination.Location.Y - card.Location.Y);
                card.Location = new Point((int)x, (int)y);
            }

            destination.BackgroundImage = cardImage;
            this.Controls.Remove(card);
            card.Dispose();
        }

        private PictureBox CreatePictureBoxForNewCard()
        {
            PictureBox card = new PictureBox();
            card.Parent = this;
            card.BackgroundImage = pictureBox1.BackgroundImage;
            card.Location = pictureBox1.Location;
            card.Size = pictureBox1.Size;
            card.BackgroundImageLayout = pictureBox1.BackgroundImageLayout;

            card.BringToFront();
            return card;
        }

        private float Distance(Point p1, Point p2)
        {
            return (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private bool OnePair(bool isPlayer1)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0;
            // daca dam parametrii prin referinta, valoarea acestora va fi schimbata si in metoda curenta, care face apelul
            GetFiveNumbers(isPlayer1, ref a, ref b, ref c, ref d, ref e);

            // trebuie sa fim atenti sa luam toate perechile. pentru asta, trebuie sa gandim aproximativ ca la ordinea in combinari
            // adica intai luam toate posibilitatile pentru primul numar, apoi toate restul pentru al doilea etc
            // (lipseste b == a pentru ca aceasta verificare coincide cu a == b)
            if (a == b || a == c || a == d || a == e ||
                b == c || b == d || b == e ||
                c == d || c == e || d == e)
                return true;
            return false;
        }

        private bool TwoPairs(bool isPlayer1)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0;
            GetFiveNumbers(isPlayer1, ref a, ref b, ref c, ref d, ref e);

            // aici combinatiile sunt mult mai multe. intai epuizam variantele pentru a == b, apoi a == c etc
            // cealalta pereche este ca si la one pair, dar daca am avea doar 3 numere (pt primul rand, c, d si e)
            // dupa ce am epuizat combinatiile pentru a, trecem la cele pentru b. pentru a sti daca mai e nevoie sa o scriem,
            // verificam daca mai apare de 3 ori prin restul combinatiilor. Observam ca lipseste o singura combinatie pentru fiecare dintre
            // b == c, b == d si b == e. varianta care lipseste este cea care o exclude pe a (pentru ca am epuizat combinatiile cu a)
            if ((a == b && c == d) || (a == b && c == e) || (a == b && d == e) ||
                (a == c && b == d) || (a == c && b == e) || (a == c && d == e) ||
                (a == d && b == c) || (a == d && b == e) || (a == d && c == e) ||
                (a == e && b == c) || (a == e && b == d) || (a == e && c == d) ||
                (b == c && d == e) || (b == d && c == e) || (b == e && c == d))
                return true;
            return false;
        }

        private bool ThreeOfAKind(bool isPlayer1)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0;
            GetFiveNumbers(isPlayer1, ref a, ref b, ref c, ref d, ref e);

            // aici este ca si la o pereche, dar mai simplu, pentru ca avem mai putine combinatii
            // luam abc, abd, abe, acd, ace si ade, pentru combinatiile cu a
            // apoi restul pentru b, bcd, bce si bde, si apoi ultima pentru c, cde
            if ((a == b && a == c) || (a == b && a == d) || (a == b && a == e) ||
                (a == c && a == d) || (a == c && a == e) || (a == d && a == e) ||
                (b == c && b == d) || (b == c && b == e) || (b == d && b == e) ||
                (c == d && c == e))
                return true;
            return false;
        }

        private bool Straight(bool isPlayer1)
        {
            int index = 0;
            if (!isPlayer1)
            {
                index = 5;
            }

            // de data aceasta, avem nevoie de carti in ordine, pentru a determina daca ordinea este buna sau nu
            // facem orice sortare pentru cartile jucatorului curent, in functie de numar
            // din nou, facem %13 si pentru a determina ordinea cartilor (si daca sunt consecutive sau nu)
            for (int i = index; i < index + 5; i++)
                for (int j = 0; j < index + 5; j++)
                    if (cardsOrder[i] % 13 < cardsOrder[j] % 13)
                        Swap(i, j);

            // verificam daca numerele cartilor sunt consecutive
            if (cardsOrder[index] % 13 == cardsOrder[index + 1] % 13 - 1 &&
                cardsOrder[index + 1] % 13 == cardsOrder[index + 2] % 13 - 1 &&
                cardsOrder[index + 2] % 13 == cardsOrder[index + 3] % 13 - 1 &&
                cardsOrder[index + 3] % 13 == cardsOrder[index + 4] % 13 - 1)
                return true;
            return false;
        }

        private bool Flush(bool isPlayer1)
        {
            int index = 0;
            if (!isPlayer1)
            {
                index = 5;
            }

            // pentru flush, avem nevoie de aceeasi culoarea a cartilor. Uitati-va din nou la vectorul de imagini,
            // cartile sunt grupate in functie de culoare. per culoare, avem 13 carti. daca facem impartire cu 13,
            // obtinem acelasi numar pentru cartile de aceeasi culaore, de ex pentru primele 13, care sunt toate clubs, obtinem 0.
            // verificarea este simpla, avem nevoie ca toate 5 culorile sa fie egale
            if (cardsOrder[index] / 13 == cardsOrder[index + 1] / 13 &&
               cardsOrder[index] / 13 == cardsOrder[index + 2] / 13 &&
               cardsOrder[index] / 13 == cardsOrder[index + 3] / 13 &&
               cardsOrder[index] / 13 == cardsOrder[index + 4] / 13)
                return true;
            return false;
        }

        private bool FullHouse(bool isPlayer1)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0;
            GetFiveNumbers(isPlayer1, ref a, ref b, ref c, ref d, ref e);

            // pentru a obtine toate combinatiile, luam verificarea de la one pair
            // si verificam daca celelalte 3 numere sunt egale intre ele
            if ((a == b && c == d && c == e) || (a == c && b == d && b == e) ||
                (a == d && b == c && b == e) || (a == e && b == c && b == d) ||
                (b == c && a == d && a == e) || (b == d && a == c && a == e) ||
                (b == e && a == c && a == d) || (c == d && a == b && a == e) ||
                (c == e && a == b && a == d) || (d == e && a == b && a == c))
                return true;
            return false;
        }

        private bool FourOfAKind(bool isPlayer1)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0;
            GetFiveNumbers(isPlayer1, ref a, ref b, ref c, ref d, ref e);

            // ca si la three of a kind, ne inspiram de la one pair, adica mergem ca la combinari
            // si obtinem abcd, abce, abde, acde si bcde
            // cel mai simplu, imaginati-va ca la fiecare combinatie excludem un numar. trebuie sa avem o combinatie pt fiecare numar
            // la prima combinatie, excludem e, la a doua d, la a treia c, apoi b si apoi a.
            if ((a == b && a == c && a == d) || (a == b && a == c && a == e) ||
                (a == b && a == d && a == e) || (a == c && a == d && a == e) ||
                (b == c && b == d && b == e))
                return true;
            return false;
        }

        private bool StraightFlush(bool isPlayer1)
        {
            // verificarile de la straight si de la flush functioneaza diferit, adica
            // una depinde de numere si cealalta de culoare. De aceea, aici putem folosi verificarile deja existente
            // la full house nu am putut verifica pair si three of a kind, pentru ca ambele depind de numere
            // si verificarile s-ar suprapune (cand avem 3 la fel, avem automat si doua la fel)
            return Straight(isPlayer1) && Flush(isPlayer1);
        }

        private void GetFiveNumbers(bool isPlayer1, ref int a, ref int b,
                                    ref int c, ref int d, ref int e)
        {
            // primele 5 carti sunt ale primului jucator, deci incepand cu indexul 0 in vector
            int startingIndex = 0;
            if (!isPlayer1)
            {
                // iar urmatoarele 5 sunt ale celui de-al doilea jucator, deci incepand cu indexul 5 in vector
                startingIndex = 5;
            }

            // pt urmatoarea explicatie, uitati-va si la comentariile din vectorul de imagini
            // pe noi ne intereseaza numarul cartilor, si cum sunt 13 carti pentru fiecare culoare,
            // folosind %13 obtinem 0 si pentru 2 of clubs, si pentru 2 of spades etc
            // pentru ca indexul tuturor acestora se imparte exact la 13: indecsii 0, 13, 26 si 39
            // fiecare dintre asi va fi reprezentat de numarul 12
            a = cardsOrder[startingIndex] % 13;
            b = cardsOrder[startingIndex + 1] % 13;
            c = cardsOrder[startingIndex + 2] % 13;
            d = cardsOrder[startingIndex + 3] % 13;
            e = cardsOrder[startingIndex + 4] % 13;
        }
    }
}
