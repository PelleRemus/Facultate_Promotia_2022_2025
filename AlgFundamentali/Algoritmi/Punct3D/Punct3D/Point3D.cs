using System.Drawing;

namespace Punct3D
{
    public class Point3D
    {
        // x si y reprezinta coordonatele punctului in 2D pe ecran
        // z reprezinta "distanta" punctului fata de noi
        // (in aplicatia curenta, are un minim de -100 si un maxim de 100.
        // valoarea 0 inseamna ca punctul este la nivelul nostru, si x si y nu sunt modificate)
        public float x, y, z;

        public Point3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Point3D() : this(0, 0, 0) { }

        public void Draw(Form1 form)
        {
            // coordonatele punctului din centrul ecranului
            int centerX = form.Width / 2;
            int centerY = form.Height / 2;
            // formula urmatoare proiecteaza punctul din 3D in functie de x si y, tinand cont si de distanta (z)
            // cand z este 0, x si y raman neschimbate (punctul este in 2D)
            // cand z este 100, x si y vor fi egale cu centrul ecranului (cel mai indepartat punct)
            // pentru ca z/100 devine 1, si ramanem cu x + centerX - x
            // pentru valorile intermediare, z reprezinta un procent, cat la suta ar trebui sa ne apropiem de centrul ecranului
            // deci inmultim procentul lui z cu distanta ramasa de la punctul curent pana la centru, adica centerX - x
            float projectionX = x + z / 100 * (centerX - x);
            float projectionY = y + z / 100 * (centerY - y);

            // dimensiunea este si ea in functie de distanta. cu cat z este mai mare, dimensiunea va fi mai mica
            // deci vom avea scadere (100 - z). Dar dimensiunea trebuie sa fie in pixeli, deci valoarea respectiva
            // trebuie impartita la o valoare arbitrara (puteti sa schimbati 25 sa vedeti ce efect are)
            // pentru a nu a avea punctele din centru cu dimensiunea 0, am adaugat un pixel obligatoriu la inceput.
            float size = 1 + (100 - z) / 25;
            // "desenam" un cerc in functie de coordonate si dimensiune folosind functia FillEllipse
            form.graphics.FillEllipse(new SolidBrush(Color.White),
                projectionX - size / 2, projectionY - size / 2, size, size);
        }
    }
}
