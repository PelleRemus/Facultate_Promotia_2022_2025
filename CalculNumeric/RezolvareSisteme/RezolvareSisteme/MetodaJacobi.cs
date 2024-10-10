using System;
using System.Linq;

namespace RezolvareSisteme
{
    public static partial class Program
    {
        static int k;
        static decimal[] xk_1;
        static decimal epsilon;

        static void Jacobi()
        {
            // Pasul 1
            n = 3;
            epsilon = 1e-3M; // echivalent cu 10 la -3, adica 0.001

            // Pasul 2
            a = new decimal[,]
            {
                { 5, 1, 1 },
                { 1, 6, 4 },
                { 1, 1, 10 }
            };
            b = new decimal[] { 10, 4, -7 };

            // Pasul 3
            decimal[] u = new decimal[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    u[i] = u[i] + Math.Abs(a[i, j]);
                }
                if (u[i] <= Math.Abs(a[i, i]))
                {
                    throw new ArgumentException("Nu se poate aplica metoda lui Jacobi");
                }
            }

            // Pasul 4
            x = new decimal[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = b[i] / a[i, i];
            }

            // Pasul 5
            do
            {
                k++;
                xk_1 = x;
                x = new decimal[n];

                decimal[] s = new decimal[n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j != i)
                        {
                            s[i] = s[i] + a[i, j] * xk_1[j];
                        }
                    }
                    x[i] = (b[i] - s[i]) / a[i, i];
                }
            } while (Math.Abs(x.Max() - xk_1.Max()) >= epsilon);

            Console.WriteLine($"Algoritmul a fost executat de {k} ori");
        }
    }
}
