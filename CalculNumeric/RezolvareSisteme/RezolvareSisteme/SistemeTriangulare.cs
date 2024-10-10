namespace RezolvareSisteme
{
    public static partial class Program
    {
        static void InitSistSuperiorTriangular()
        {
            // I. Date de intrare
            n = 3;
            a = new decimal[,]
            {
                { 1, 2, 3 },
                { 0, -2, 4 },
                { 0, 0, 6 }
            };
            b = new decimal[] { 5, 2, 3 };

            // II. Date de iesire
            x = new decimal[n];
        }

        static void SistSuperiorTriangular()
        {
            // III. Pasul 1
            // in pseudocod, := este =, si = este ==
            x[n - 1] = b[n - 1] / a[n - 1, n - 1];

            // III. Pasul 2
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
            // I. Date de intrare
            n = 3;
            a = new decimal[,]
            {
                { 1, 0, 0 },
                { 2, 3, 0 },
                { 4, -1, 6 }
            };
            b = new decimal[] { 2, 4, 1 };

            // II. Date de iesire
            x = new decimal[n];

            // III. Pasul 1
            x[0] = b[0] / a[0, 0];

            // III. Pasul 2
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
    }
}
