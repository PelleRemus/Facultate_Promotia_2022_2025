namespace RezolvareSisteme
{
    public static partial class Program
    {
        static decimal[,] A;
        static decimal[] c, d;

        static void SistTridiagonal()
        {
            // I. Date de intrare
            n = 5; // Defapt, avem 6 ecuatii cu 6 necunoscute, dar vectorii sunt initializati cu n + 1
            A = new decimal[,]
            {
                { 1, -1M/4, 0, 0, 0, 0 },
                { -1M/8, 1, -1M/8, 0, 0, 0 },
                { 0, -1M/8, 1, -1M/8, 0, 0 },
                { 0, 0, -1M/8, 1, -1M/8, 0 },
                { 0, 0, 0, -1M/8, 1, -1M/8 },
                { 0, 0, 0, 0, -1M/4, 1 },
            };
            decimal[] a = new decimal[] { 1, 1, 1, 1, 1, 1 };
            b = new decimal[] { 0, -1M / 8, -1M / 8, -1M / 8, -1M / 8, -1M / 4 };
            c = new decimal[] { -1M / 4, -1M / 8, -1M / 8, -1M / 8, -1M / 8, 0 };
            d = new decimal[] { -21M / 2, 29M / 4, 139M / 16, -51M / 4, 157M / 16, -13M / 2 };

            // II. Date de iesire
            x = new decimal[n + 1];

            // III. Pasul 1
            decimal[] u = new decimal[n + 1];
            u[0] = c[0] / a[0];

            // III. Pasul 2
            decimal[] w = new decimal[n + 1];
            for (int i = 1; i < n; i++)
            {
                w[i] = a[i] - u[i - 1] * b[i];
                u[i] = c[i] / w[i];
            }

            // III. Pasul 3
            w[n] = a[n] - u[n - 1] * b[n];

            // III. Pasul 4
            decimal[] z = new decimal[n + 1];
            z[0] = d[0] / a[0];
            for (int i = 1; i <= n; i++)
            {
                z[i] = (d[i] - b[i] * z[i - 1]) / w[i];
            }

            // III. Pasul 5
            x[n] = z[n];
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = z[i] - u[i] * x[i + 1];
            }
        }
    }
}
