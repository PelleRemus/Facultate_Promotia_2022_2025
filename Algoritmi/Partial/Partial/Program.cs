using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Partial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ex1();
            // Ex2();
            //Ex3R1();
            Console.WriteLine(Ex3R2(
                new int[] { 1, 2, 3, 4, 5, 6, 6 },
                new int[] { 2, 3, 3, 4, 4, 4, 3 }));
            Console.ReadKey();
        }

        static void Ex1()
        {
            string[] numbers = ReadFromFile("../../data01.in");
            int n = numbers.Length;
            float[] v = new float[n];

            for(int i=0; i < n; i++)
                v[i] = float.Parse(numbers[i]);

            // insertion sort
            for (int j = 1; j < n; j++)
                for (int i = j; i > 0; i--)
                    if (v[i] < v[i - 1])
                    {
                        float aux = v[i];
                        v[i] = v[i - 1];
                        v[i - 1] = aux;
                    }

            // Randul 1
            // Console.WriteLine(v[(n + 1) / 2 - 1]);

            // Randul 2
            float max = 0;
            for (int i = 1; i < n; i++)
                if (v[i] - v[i - 1] > max)
                    max = v[i] - v[i - 1];
            Console.WriteLine(max);
        }

        static void Ex2()
        {
            string[] numbers = ReadFromFile("../../data02.in");
            int n = numbers.Length;
            byte[] v = new byte[n];

            for (int i = 0; i < n; i++)
                v[i] = byte.Parse(numbers[i]);

            // varianta mai simpla, dar nu acceptata
            //for(int i=0; i<n; i++)
            //{
            //    string binary = Convert.ToString(v[i], 2);
            //    binary = binary.Replace('1', 'X');
            //    Console.WriteLine(binary);
            //}

            int m = 8;
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = m - 1; j >= 0; j--)
                {
                    matrix[i, j] = v[i] % 2;
                    v[i] = (byte)(v[i] / 2);
                }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                        Console.Write(matrix[i, j]);
                    else
                        Console.Write("X");
                }
                Console.WriteLine();
            }
        }

        static void Ex3R1()
        {
            TextReader reader = new StreamReader("../../data03.in");
            string allText = reader.ReadToEnd();
            allText = allText.Replace("\r\n", ",");
            allText = allText.Replace(", ", ",");

            string[] inputs = allText.Split(',');
            List<Data> agentsData = new List<Data>();

            for (int i = 0; i < inputs.Length; i++)
            {
                string[] idValue = inputs[i].Split(' ');
                int id = int.Parse(idValue[0]);
                double value = double.Parse(idValue[1]);

                Data currentData = null; // agentsData.FirstOrDefault(x => x.dataID == id);
                for (int j = 0; j < agentsData.Count; j++)
                {
                    if (id == agentsData[j].dataID)
                        currentData = agentsData[j];
                }

                if (currentData == null)
                {
                    currentData = new Data(id, value);
                    agentsData.Add(currentData);
                }
                else
                    currentData.AddData(id, value);

            }

            TextWriter writer = new StreamWriter("../../data03.out");
            for (int i = 0; i < agentsData.Count; i++)
                writer.WriteLine(agentsData[i]);
            writer.Close();
        }

        static int Ex3R2(int[] v, int[] u)
        {
            int[] putereV = Putere(v);
            int[] putereU = Putere(u);

            int min = Math.Min(putereV.Length, putereU.Length);
            for (int i = 0; i < min; i++)
            {
                if (putereU[i] < putereV[i])
                    return -1;
                if (putereU[i] > putereV[i])
                    return 1;
            }

            return 0;
        }

        static int[] Putere(int[] v)
        {
            int max = 0;
            for (int i = 0; i < v.Length; i++)
                if (max < v[i])
                    max = v[i];

            int[] frecventa = new int[max + 1];
            for (int i = 0; i < v.Length; i++)
            {
                frecventa[v[i]]++;
            }

            for (int j = 1; j <= max; j++)
                for (int i = j; i > 0; i--)
                {
                    if (frecventa[i] > frecventa[i-1])
                    {
                        // (frecventa[i], frecventa[i - 1]) = (frecventa[i - 1], frecventa[i]);
                        int aux = frecventa[i];
                        frecventa[i] = frecventa[i - 1];
                        frecventa[i-1] = aux;
                    }
                }
            return frecventa;
        }

        static string[] ReadFromFile(string filename)
        {
            TextReader reader = new StreamReader(filename);
            string allText = reader.ReadToEnd();
            allText = allText.Replace('\n', ' ');

            string[] numbers = allText.Split(' ');
            return numbers;
        }
    }
}
