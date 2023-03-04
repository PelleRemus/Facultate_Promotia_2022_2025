using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public partial class Form1 : Form
    {
        Image[] cardsImages = new Image[]
        {
            Image.FromFile("../../Images/AceOfClubs card.png"),
            Image.FromFile("../../Images/2OfClubs card.png"),
            Image.FromFile("../../Images/3OfClubs card.png"),
            Image.FromFile("../../Images/4OfClubs card.png"),
            Image.FromFile("../../Images/5OfClubs card.png"),
            Image.FromFile("../../Images/6OfClubs card.png"),
            Image.FromFile("../../Images/7OfClubs card.png"),
            Image.FromFile("../../Images/8OfClubs card.png"),
            Image.FromFile("../../Images/9OfClubs card.png"),
            Image.FromFile("../../Images/10OfClubs card.png"),
            Image.FromFile("../../Images/JackOfClubs card.png"),
            Image.FromFile("../../Images/KingOfClubs card.png"),
            Image.FromFile("../../Images/QueenOfClubs card.png"),

            Image.FromFile("../../Images/AceOfSpades card.png"),
            Image.FromFile("../../Images/2OfSpades card.png"),
            Image.FromFile("../../Images/3OfSpades card.png"),
            Image.FromFile("../../Images/4OfSpades card.png"),
            Image.FromFile("../../Images/5OfSpades card.png"),
            Image.FromFile("../../Images/6OfSpades card.png"),
            Image.FromFile("../../Images/7OfSpades card.png"),
            Image.FromFile("../../Images/8OfSpades card.png"),
            Image.FromFile("../../Images/9OfSpades card.png"),
            Image.FromFile("../../Images/10OfSpades card.png"),
            Image.FromFile("../../Images/JackOfSpades card.png"),
            Image.FromFile("../../Images/KingOfSpades card.png"),
            Image.FromFile("../../Images/QueenOfSpades card.png"),

            Image.FromFile("../../Images/AceOfHearts card.png"),
            Image.FromFile("../../Images/2OfHearts card.png"),
            Image.FromFile("../../Images/3OfHearts card.png"),
            Image.FromFile("../../Images/4OfHearts card.png"),
            Image.FromFile("../../Images/5OfHearts card.png"),
            Image.FromFile("../../Images/6OfHearts card.png"),
            Image.FromFile("../../Images/7OfHearts card.png"),
            Image.FromFile("../../Images/8OfHearts card.png"),
            Image.FromFile("../../Images/9OfHearts card.png"),
            Image.FromFile("../../Images/10OfHearts card.png"),
            Image.FromFile("../../Images/JackOfHearts card.png"),
            Image.FromFile("../../Images/KingOfHearts card.png"),
            Image.FromFile("../../Images/QueenOfHearts card.png"),

            Image.FromFile("../../Images/AceOfDiamonds card.png"),
            Image.FromFile("../../Images/2OfDiamonds card.png"),
            Image.FromFile("../../Images/3OfDiamonds card.png"),
            Image.FromFile("../../Images/4OfDiamonds card.png"),
            Image.FromFile("../../Images/5OfDiamonds card.png"),
            Image.FromFile("../../Images/6OfDiamonds card.png"),
            Image.FromFile("../../Images/7OfDiamonds card.png"),
            Image.FromFile("../../Images/8OfDiamonds card.png"),
            Image.FromFile("../../Images/9OfDiamonds card.png"),
            Image.FromFile("../../Images/10OfDiamonds card.png"),
            Image.FromFile("../../Images/JackOfDiamonds card.png"),
            Image.FromFile("../../Images/KingOfDiamonds card.png"),
            Image.FromFile("../../Images/QueenOfDiamonds card.png"),
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
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
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
            CardDealingAnimation(p2_5, cardsImages[cardsOrder[9]]); await Task.Delay(200);

            button1.Enabled = true;
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
            float percent = 100F / Distance(card.Location, destination.Location);

            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(i);
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
    }
}
