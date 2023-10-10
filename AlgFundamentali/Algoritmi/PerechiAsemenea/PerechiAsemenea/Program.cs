using System;
using System.IO;
using System.Linq;

namespace PerechiAsemenea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // reader se pregateste sa citeasca din fisier. Il vom folosi in loc de clasa Console, care citeste "de la tastatura"
            TextReader reader = new StreamReader("../../numere.in");
            // citim prima linie si valorile sale separate prin spatiu
            string buffer = reader.ReadLine();
            string[] split = buffer.Split(' ');
            // convertim valorile (care deocamdata sunt string) la valori intregi. Pe prima linie, avem na si nb, in aceasta ordine
            int na = int.Parse(split[0]);
            int nb = int.Parse(split[1]);

            // citim urmatoarea linie si separam valorile prin spatiu
            buffer = reader.ReadLine();
            split = buffer.Split(' ');
            // initializam vectorul A cu valorile de pe aceasta linie
            int[] A = new int[na];
            for (int i = 0; i < na; i++)
                A[i] = int.Parse(split[i]);

            // citim urmatoarea linie si separam valorile prin spatiu
            buffer = reader.ReadLine();
            split = buffer.Split(' ');
            // initializam vectorul B cu valorile de pe aceasta linie
            int[] B = new int[nb];
            for (int i = 0; i < nb; i++)
                B[i] = int.Parse(split[i]);

            // prin count vom numara cate perechi asemenea gasim
            int count = 0;
            // parcurgem primul vector, iar pentru fiecare din valorile acestuia, parcurgem al doilea vector
            for (int i = 0; i < na; i++)
                for (int j = 0; j < nb; j++)
                {
                    // astfel, putem verifica fiecare numar din primul vector cu fiecare numar din cel de-al doilea vector
                    if (SuntPerechiAsemenea(A[i], B[j]))
                        count++;
                }

            Console.WriteLine(count);
            Console.ReadKey();
        }

        static bool SuntPerechiAsemenea(int x, int y)
        {
            // luam ultimele cifre ale lui x si y, apoi penultimele cifre ale lui x si y
            int ucx = x % 10, ucy = y % 10;
            int pcx = (x % 100) / 10;
            int pcy = (y % 100) / 10;

            // singurele 2 configuratii posibile sunt daca ultimele cifre sunt identice, si penultimele cifre sunt identice
            // sau daca ultima cifra a lui x este identica cu penultima cifra a lui y, si invers
            return (ucx == ucy && pcx == pcy) || (ucx == pcy && pcx == ucy);
        }
    }
}
