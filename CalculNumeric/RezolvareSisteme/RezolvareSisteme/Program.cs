using System;
using System.Linq;

namespace RezolvareSisteme
{
    public static partial class Program
    {
        static int n;
        static decimal[,] a;
        static decimal[] b, x;

        static void Main(string[] args)
        {
            // InitSistSuperiorTriangular();

            // SistSuperiorTriangular();

            // SistInferiorTriangular();

            // MetodaGauss();

            // SistTridiagonal();

            Jacobi();

            Afisare();
            Console.ReadKey();
        }

        static void Afisare()
        {
            Console.WriteLine("Sistemul de n ecuatii cu n necunoscute dat are urmatoarea solutie:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"x{i}: {x[i]}    ");
            }
            Console.WriteLine();
        }
    }
}
