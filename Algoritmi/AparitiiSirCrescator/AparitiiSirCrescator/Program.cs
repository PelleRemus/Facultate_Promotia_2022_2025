using System;
using System.IO;

namespace AparitiiSirCrescator
{
    internal class Program
    {
        // vom modifica putin ce spune in enunt. Exercitiile au fost facute pentru cod de C++,
        // unde cititorul de text functioneaza diferit: putem citi urmatoarea valoare din fisier,
        // iar acesta va sti sa se opreasca la urmatorul spatiu. In c# citim direct ca si string sau char valorile,
        // deci am putea citi ori urmatorul caracter, ori o linie intreaga (care reprezinta tot fisierul in cazul nostru).
        // Pentru a putea avea algoritmul eficient din punct de vedere al memoriei,
        // vom pune fiecare numar pe o linie separata in fisier, astfel putand citi cate un numar din fisier.
        static void Main(string[] args)
        {
            // ------------------------------------------ Solutia 1 (mai ineficienta) ------------------------------------------
            // vom folosi un vector de aparitii: de fiecare data cand apare un numar in fisier,
            // pozitia acestuia in vector creste. Incepand de la 0 pe fiecare pozitie, acesta este ca si un fel de
            // vector de contoare: in loc sa avem un singur "count" sau "nr", avem un vector intreg de astfel de valori.
            // Solutia aceasta este ineficienta pentru ca numerele au maxim 9 cifre, deci avem nevoie de foarte mult spatiu in vector
            // si pentru ca la final, trebuie sa parcurgem acest vector

            /* int n = 1_000_000_000;
            int[] aparitii = new int[n];
            TextReader reader = new StreamReader("../../BAC.TXT");
            string buffer;
            // acest while se poate citi asa: cat timp valoarea de pe linia curenta din reader nu este null
            // stocam valoarea acelei linii in buffer pentru a o putea folosi, iar cand aceasta este null, am ajuns la final de fisier
            while((buffer = reader.ReadLine()) != null)
            {
                int number = int.Parse(buffer);
                aparitii[number]++;
            }

            for(int i = 0; i < n; i++)
            {
                if (aparitii[i] != 0)
                    Console.Write($"{i} {aparitii[i]} ");
            }
            Console.ReadKey();
            */

            // ------------------------------------------- Solutia 2 (mai eficienta) -------------------------------------------
            // pentru ca sirul este crescator, toate valorile egale vor fi consecutive. Vom profita de asta.
            // avem nevoie de un contor care ne spune de cate ori a aparut numerul curent, si valoarea numarului curent
            // cand valoarea nou-citita din fisier este diferita de numarul pentru care faceam numaratoarea pana acum,
            // afisam valorile obtinute, valoarea curenta se schimba uc valoarea citita, si contorul este resetat la 1.
            // acest algoritm este mai eficient pentru ca nu ocupam in memorie decat 3 valori intregi in acelasi timp,
            // iar de parcurs, parcurgem doar numarul de numere aflate in fisier. Daca in fisier am avea "1 2 2",
            // am parcurge doar de 3 ori, pe cand in celalalt algoritm, parcurgerea este tot pentru un miliard de numere.

            int currentNumber = -1, count = 0;
            TextReader reader = new StreamReader("../../BAC.TXT");
            string buffer;
            while ((buffer = reader.ReadLine()) != null)
            {
                int number = int.Parse(buffer);
                // aceasta verificare este necesara pentru a determina pasul initial
                if (currentNumber == -1)
                    currentNumber = number;

                if (number != currentNumber)
                {
                    Console.Write($"{currentNumber} {count} ");
                    currentNumber = number;
                    count = 1;
                }
                else
                    count++;
            }
            // pentru ca noi ne folosim de schimbarea numarului curent, ultimul numar + contorul acestuia nu vor fi afisate
            // deci afisam din nou numarul curent si contorul final
            Console.Write($"{currentNumber} {count}");
            Console.ReadKey();
        }
    }
}
