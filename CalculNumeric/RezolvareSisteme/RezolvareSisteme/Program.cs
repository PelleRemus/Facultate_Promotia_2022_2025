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
            SistSuperiorTriangular();
            AfisareSolutie();
            Console.ReadKey();
        }

        static void SistSuperiorTriangular()
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

        static void AfisareSolutie()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(x[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
