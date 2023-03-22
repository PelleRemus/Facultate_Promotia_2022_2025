using System;

namespace AparitiiCifre
{
    internal class Program
    {
        static int nrCifre = 10;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] frequencies = new int[nrCifre]; // vector de frecventa a cifrelor

            // cum metoda cif ne da nr de aparitii, trecand prin toate cifrele si apeland metoda, obtinem vectorul de frecventa
            for (int i = 0; i < nrCifre; i++)
                frequencies[i] = cif(n, i);

            Console.WriteLine(GeneratePalindromFrom(frequencies));
            Console.ReadKey();
        }

        static int cif(int a, int b)
        {
            int count = 0;
            // parcurgerea cifrelor unui numar: cat timp acesta mai are cifre, luam ultima cifra si o stergem de la final
            while (a > 0)
            {
                int cifra = a % 10;
                a = a / 10;
                if (cifra == b)
                    count++;
            }
            return count;
        }

        static int GeneratePalindromFrom(int[] frequencies)
        {
            int palindrom = 0;
            // dorim cel mai mare palindrom, deci intai parcurgem descrescator pentru a adauga cele mai mari cifre la inceput
            // pentru exemplul 11222233, la finalul for-ului, vom avea palindrom = 3221
            for (int i = nrCifre - 1; i >= 0; i--)
            {
                // pentru a fi palindrom (cu numar par de cifre), nr de aparitii al fiecarei cifre trebuie sa fie par
                // (pentru a aparea si in partea din stanga, si in cea din dreapta a numarului)
                if (frequencies[i] % 2 != 0)
                    return 0;
                palindrom = AddDigitsFromFrequency(palindrom, i, frequencies[i]);
            }
            // parcurgem din nou cifrele in ordine crescatoare pentru a forma simetria numarului
            // pentru exemplul dat, la finalul for-ului, palindrom = 32211223
            for (int i = 0; i < nrCifre; i++)
                palindrom = AddDigitsFromFrequency(palindrom, i, frequencies[i]);
            return palindrom;
        }

        static int AddDigitsFromFrequency(int number, int digit, int frequency)
        {
            // adaugam doar jumatate din cifre, cealalta jumatate va fi afisata in al doilea for
            frequency = frequency / 2;
            // frequency ne spune cate cifre trebuie sa adaugam la finalul numarului
            while (frequency != 0)
            {
                number = number * 10 + digit;
                frequency--;
            }
            return number;
        }
    }
}
