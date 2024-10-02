using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezolvareSisteme
{
    internal class Program
    {
        static int n;
        static decimal[,] a;
        static decimal[] b, x;

        static void Main(string[] args)
        {
            //InitSistSuperiorTriangular();
            //SistSuperiorTriangular();
            //SistInferiorTriangular();
            MetodaGauss();
            SistSuperiorTriangular();

            Afisare();
            Console.ReadKey();
        }

        static void SistSuperiorTriangular()
        {
            // in pseudocod, := este =, si = este ==
            x[n - 1] = b[n - 1] / a[n - 1, n - 1];

            for (int k = n - 2; k >= 0; k--)
            {
                decimal s = 0;
                for (int i = k + 1; i < n; i++)
                {
                    s += a[k, i] * x[i];
                }
                x[k] = (b[k] - s) / a[k, k];
            }
        }

        static void SistInferiorTriangular()
        {
            n = 3;
            a = new decimal[,]
            {
                { 1, 0, 0 },
                { 2, 3, 0 },
                { 4, -1, 6 }
            };
            b = new decimal[] { 2, 4, 1 };
            x = new decimal[n];

            x[0] = b[0] / a[0, 0];

            for (int k = 1; k < n; k++)
            {
                decimal s = 0;
                for (int i = 0; i < k; i++)
                {
                    s += a[k, i] * x[i];
                }
                x[k] = (b[k] - s) / a[k, k];
            }
        }

        static void MetodaGauss()
        {
            n = 3;
            a = new decimal[,]
            {
                { 10, 2, -1 },
                { -3, 1, -5 },
                { -2, -5, 1 }
            };
            b = new decimal[] { 9, -8, -1 };
            x = new decimal[n];

            for (int k = 0; k < n - 1; k++)
            {
                if (a[k, k] == 0)
                {
                    throw new ArgumentException("Pentru metoda Gauss, nu putem avea 0 pe diagonala principala!");
                }
                decimal p = a[k, k];

                for (int j = k; j < n; j++)
                {
                    a[k, j] = a[k, j] / p;
                }
                b[k] = b[k] / p;

                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k + 1; j < n; j++)
                    {
                        a[i, j] = a[i, j] - a[k, j] * a[i, k];
                    }
                    b[i] = b[i] - b[k] * a[i, k];
                }
            }
        }

        static void InitSistSuperiorTriangular()
        {
            n = 3;
            a = new decimal[,]
            {
                { 1, 2, 3 },
                { 0, -2, 4 },
                { 0, 0, 6 }
            };
            b = new decimal[] { 5, 2, 3 };
            x = new decimal[n];
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
