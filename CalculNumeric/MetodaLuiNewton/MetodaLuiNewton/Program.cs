namespace MetodaLuiNewton
{
    internal class Program
    {
        static int n;
        static decimal xn_1, yn_1, xn, yn, epsilon;
        static void Main(string[] args)
        {
            xn_1 = 1.2m; yn_1 = 1.7m; epsilon = 1e-4m;
        }

        static decimal J(decimal x, decimal y)
        {
            return dfx(x, y) * dgy(x, y) - dfy(x, y) * dgx(x, y);
        }
        static decimal F(decimal x, decimal y)
        {
            return 2 * x * x * x - y * y - 1;
        }
        static decimal G(decimal x, decimal y)
        {
            return x * y * y * y - y - 4;
        }
        static decimal dfx(decimal x, decimal y)
        {
            return 6 * x * x;
        }
        static decimal dfy(decimal x, decimal y)
        {
            return -2 * y;
        }
        static decimal dgx(decimal x, decimal y)
        {
            return y * y * y;
        }
        static decimal dgy(decimal x, decimal y)
        {
            return 3 * x * y * y - 1;
        }
    }
}
