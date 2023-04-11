using System;

namespace Cub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,,] cube = new int[3, 3, 3]
            {
                {
                    {0, 1, 1 },
                    {0, 1, 0 },
                    {0, 1, 1 }
                },
                {
                    {0, 1, 1 },
                    {0, 1, 0 },
                    {0, 1, 1 }
                },
                {
                    {0, 1, 0 },
                    {0, 1, 0 },
                    {0, 0, 1 }
                }
            };
            Console.WriteLine(Count(cube, 3));
            Console.ReadKey();
        }

        public static int Count(int[,,] cube, int n)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (cube[0, i, j] == 1) // fata de sus 
                    {
                        count++;
                        cube[0, i, j] = 0;
                    }
                    if (cube[n - 1, i, j] == 1) // fata de jos
                    {
                        count++;
                        cube[n - 1, i, j] = 0;
                    }
                    if (cube[i, j, 0] == 1) // fata din stanga
                    {
                        count++;
                        cube[i, j, 0] = 0;
                    }
                    if (cube[i, j, n - 1] == 1) // fata din dreapta 
                    {
                        count++;
                        cube[i, j, n - 1] = 0;
                    }
                    if (cube[i, 0, j] == 1) // fata din spate 
                    {
                        count++;
                        cube[i, 0, j] = 0;
                    }
                    if (cube[i, n - 1, j] == 1) // fata din fata 
                    {
                        count++;
                        cube[i, n - 1, j] = 0;
                    }
                }
            return count;
        }
    }
}