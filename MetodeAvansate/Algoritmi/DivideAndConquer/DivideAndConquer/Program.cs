using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer
{
    internal class Program
    {
        static int n;
        static int[] array;

        static void Main(string[] args)
        {
            //Console.WriteLine(Recursiv('d'));
            n = 10;
            array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(BinarySearch(7, 0, n - 1));
            Console.ReadKey();
        }

        // a
        // aba
        // abacaba
        // abacabadabacaba
        static string Recursiv(char c)
        {
            if (c == 'a')
                return "a";
            return Recursiv((char)(c - 1)) + c + Recursiv((char)(c - 1));
        }

        // Binary Search functioneaza doar pentru array-uri deja sortate
        static bool BinarySearch(int toFind, int left, int right)
        {
            if (left >= right)
                return false;
            int middle = (left + right) / 2;

            if (toFind < array[middle])
                return BinarySearch(toFind, left, middle);
            if (toFind == array[middle])
                return true;
            //if (toFind > array[middle])
            return BinarySearch(toFind, middle, right);
        }
    }
}
