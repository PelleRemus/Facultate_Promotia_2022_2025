using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuadratura
{
    internal class Program
    {
        static decimal a, b;
        static int n;

        static void Main(string[] args)
        {
            a = 0; b = 1;
            n = 100;

            decimal[] x = new decimal[n + 1];
            // ...
        }

        static decimal f(decimal x)
        {
            return 1M / (x + 1);
        }
    }
}
