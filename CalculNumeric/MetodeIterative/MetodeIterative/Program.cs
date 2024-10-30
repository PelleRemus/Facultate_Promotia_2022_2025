using System;

namespace MetodeIterative
{
    public class Program
    {
        static int n;
        static decimal a, b, dda, xn, xn_1, epsilon;

        static void Main(string[] args)
        {
        }

        static void MetodaCoardei()
        {
            a = 0; b = 1; dda = 0; epsilon = 0.0001m; // 1e-4m;
            decimal aux;
            n = 0;

            // Valoarea lui x0 este in functie de f(a)*f"(a)
            if (f(a) * dda < 0)
            {
                xn_1 = a;
                aux = b;
            }
            else
            {
                xn_1 = b;
                aux = a;
            }

            // Metoda coardei in sine:

        }

        static void MetodaTangentei()
        {
            a = 1; b = 2; dda = 6; epsilon = 1e-4m; //1e-8m; //1e-12m
            n = 0;

            // Valoarea lui x0 este in functie de f(a)*f"(a)
            if (f(a) * dda > 0)
                xn_1 = a;
            else
                xn_1 = b;

            // Metoda Tangentei in sine
        }

        static decimal f(decimal x)
        {
            return x * x * x - x + 1; // 1.32471795...
        }

        static decimal df(decimal x)
        {
            return 3 * x * x - 1;
        }
    }
}
