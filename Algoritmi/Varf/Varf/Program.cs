using System;
using System.Collections.Generic;
using System.IO;

namespace Varf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = Int32.MaxValue; // valoarea maxima pe care o poate lua un numar intreg in C#: 2_147_483_647
            int varf = -1;
            TextReader reader = new StreamReader("../../bac.in");
            string buffer;

            // ------------------------------------------ Solutia 1 (mai ineficienta) ------------------------------------------
            // citim tot fisierul intr-o lista. Este ineficienta mai ales din cauza memoriei
            /* List<int> numbers = new List<int>();
            while ((buffer = reader.ReadLine()) != null)
                numbers.Add(int.Parse(buffer));

            for (int i = 1; i < numbers.Count - 1; i++)
                Parte_Comuna(numbers[i - 1], numbers[i], numbers[i + 1], ref min, ref varf);
            */

            // ------------------------------------------- Solutia 2 (mai eficienta) -------------------------------------------
            // luam primele 3 valori din fisier in doua variabile a si b, iar apoi pana la final de fisier, citim c
            // pentru a pastra ultimele 3 valori stocate in a, b si c, la fiecare pas dupa executarea algoritmului,
            // valoarea celui de-al doilea numar se pune in prima variabila, iar cel de-al 3-lea se pune in a doua variabila
            // aceasta solutie este eficienta d.p.d.v. al memoriei pentru ca stocam doar cate 3 variabile deodata
            // si d.p.d.v. al timpului pentru ca parcurgem o singura data lista de numere
            // (cum citim un numar, cum executam algoritmul pentru ultimele 3 valori numerice)
            int a = int.Parse(reader.ReadLine());
            int b = int.Parse(reader.ReadLine());
            while ((buffer = reader.ReadLine()) != null)
            {
                int c = int.Parse(buffer);
                Parte_Comuna(a, b, c, ref min, ref varf);
                a = b;
                b = c;
            }

            // (partea de afisare este comuna ambelor solutii)
            // am initializat varful cu -1 pentru a determina cazul in care nu s-a gasit niciun varf (numerele sunt naturale, nu putem avea -1 ca si varf)
            if (varf == -1)
                Console.WriteLine("nu exista");
            else
                Console.WriteLine(varf);
            Console.ReadKey();
        }

        private static void Parte_Comuna(int a, int b, int c, ref int min, ref int varf)
        {
            if (b > a && b > c)
            {
                // calculam diferenta ca valoarea absoluta (modulul) valorilor din stanga si din dreapta valorii curente
                int difference = Math.Abs(a - c);
                // aceasta diferenta trebuie sa fie minima, deci folosim calculul minimului pe aceasta
                if (min > difference)
                {
                    min = difference;
                    varf = b; // iar daca gasim un nou minim, de asemenea, spunem ca am gasit un nou varf
                }
                // cand gasim o diferenta cu aceeasi valoare ca si minimul curent, valoarea varfului va fi valoarea maxima dintre acestea
                else if (min == difference && varf < b)
                    varf = b;
            }
        }
    }
}
