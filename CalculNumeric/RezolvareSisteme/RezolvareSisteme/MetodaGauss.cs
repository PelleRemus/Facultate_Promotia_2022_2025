using System;

namespace RezolvareSisteme
{
    public static partial class Program
    {
        static void MetodaGauss()
        {
            // I. Date de intrare
            n = 3;
            a = new decimal[,]
            {
                { 10, 2, -1 },
                { -3, 1, -5 },
                { -2, -5, 1 }
            };
            b = new decimal[] { 9, -8, -1 };

            // II. Date de iesire
            x = new decimal[n];

            // III. Pasul 1
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

            // III. Pasul 2
            SistSuperiorTriangular();
        }
    }
}
