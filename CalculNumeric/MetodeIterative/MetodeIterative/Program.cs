using System;

namespace MetodeIterative
{
    public class Program
    {
        static int n;
        static decimal a, b, dda, xn, xn_1, yn, yn_1, epsilon;

        static void Main(string[] args)
        {
            MetodaAproximatiilorSuccesivePentruSisteme();
            Console.ReadLine();
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

        static void MetodaAproximatiilorSuccesive()
        {
            a = 1; b = 2; epsilon = 1e-4m;
            xn_1 = a;

            // Algoritmul in sine
            xn = fi(xn_1);

            do
            {
                n++;
                xn_1 = xn;
                xn = fi(xn_1);

            } while (Math.Abs(xn - xn_1) >= epsilon);

            Console.WriteLine($"x are valoarea {xn}, si a fost gasita dupa {n} iteratii");
        }

        static void MetodaAproximatiilorSuccesivePentruSisteme()
        {
            epsilon = 1e-4m;
            xn_1 = 3.5m;
            yn_1 = 2.2m;

            // Algoritmul in sine
            yn = G(xn_1, yn_1);
            xn = F(xn_1, yn_1);

            do
            {
                n++;
                yn_1 = yn;
                xn_1 = xn;
                yn = G(xn_1, yn_1);
                xn = F(xn_1, yn_1);

            } while (Math.Abs(xn - xn_1) >= epsilon || Math.Abs(yn - yn_1) >= epsilon);

            Console.WriteLine($"x are valoarea {xn} si y are valoarea {yn}, si au fost gasite dupa {n} iteratii");
        }

        static decimal F(decimal x, decimal y)
        {
            return (decimal)Math.Sqrt((double)(x * (y + 5) - 1) / 2);
        }

        static decimal G(decimal x, decimal y)
        {
            return (decimal)Math.Sqrt((double)x + 3 * Math.Log10((double)x));
        }

        static decimal fi(decimal x)
        {
            return (decimal)Math.Pow((double)x + 1, 0.25);
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
