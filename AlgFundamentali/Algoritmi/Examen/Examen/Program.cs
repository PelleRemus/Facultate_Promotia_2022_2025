using System;
using System.Collections.Generic;
using System.IO;

namespace Examen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ex4();
        }

        static void Ex1R1()
        {
            Queue<int> q = new Queue<int>();
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();

            string allText = File.ReadAllText("../../data1.in");
            string[] commands = allText.Split(',');

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i].Split(' ')[0];
                int value = int.Parse(commands[i].Split(' ')[1]);

                if (command == "Push")
                    q.Enqueue(value);
                else
                {
                    switch (value)
                    {
                        case 1:
                            int x = q.Dequeue();
                            stack1.Push(x);
                            break;
                        case 2:
                            x = q.Dequeue();
                            stack2.Push(x);
                            break;
                        case 3:
                            x = stack1.Pop();
                            q.Enqueue(x);
                            break;
                        case 4:
                            stack2.Pop();
                            break;
                    }
                }
            }

            Console.Write("Queue1: ");
            foreach (int value in q)
                Console.Write(value + " ");

            Console.WriteLine();
            Console.Write("Stack: ");
            foreach (int value in stack1)
                Console.Write(value + " ");

            Console.WriteLine();
            Console.Write("Queue2: ");
            foreach (int value in stack2)
                Console.Write(value + " ");

            Console.ReadKey();
        }

        static void Ex1R2()
        {
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();
            Stack<int> stack = new Stack<int>();

            string allText = File.ReadAllText("../../data1.in");
            string[] commands = allText.Split(',');

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i].Split(' ')[0];
                int value = int.Parse(commands[i].Split(' ')[1]);

                if (command == "Push")
                    q1.Enqueue(value);
                else
                {
                    switch (value)
                    {
                        case 1:
                            int x = q1.Dequeue();
                            stack.Push(x);
                            break;
                        case 2:
                            x = q1.Dequeue();
                            q2.Enqueue(x);
                            break;
                        case 3:
                            x = stack.Pop();
                            q2.Enqueue(x);
                            break;
                        case 4:
                            q2.Dequeue();
                            break;
                    }
                }
            }

            Console.Write("Queue1: ");
            foreach (int value in q1)
                Console.Write(value + " ");

            Console.WriteLine();
            Console.Write("Stack: ");
            foreach (int value in stack)
                Console.Write(value + " ");

            Console.WriteLine();
            Console.Write("Queue2: ");
            foreach (int value in q2)
                Console.Write(value + " ");

            Console.ReadKey();
        }

        static void Ex2()
        {
            string nume = "Priala";
            string prenume1 = "Emil";
            string prenume2 = "Gabriel";
            int x = 8, y = 0;
            string text = "{Acesta este un text pentru codificarea Huffman}";

            string hufffman = nume + " " + prenume1 + " - " + prenume2;
            hufffman += " (" + x + "," + y + ") ";
            int n = 40 - hufffman.Length;

            for(int i=0; i<n; i++)
                hufffman += text[i].ToString();
            Console.WriteLine(hufffman);
            Console.ReadLine();
        }

        static string[] lines;
        static void Ex4()
        {
            string allText = File.ReadAllText("../../data4.in");
            lines = allText.Split('\n');
            int max = 0;

            for(int i=0; i<lines.Length - max; i++)
                for(int j=0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == ' ')
                    {
                        int lungime = CalculeazaRau(i, j);
                        if (lungime > max)
                            max = lungime;
                    }
                }
            Console.WriteLine(max);
            Console.ReadLine();
        }

        static int CalculeazaRau(int i, int j)
        {
            if (lines.Length <= i + 1)
                return 1;
            int m = lines[i].Length;

            if (m > j + 1 && lines[i + 1][j + 1] == ' ')
                return 1 + CalculeazaRau(i + 1, j + 1);
            if (m > j && lines[i + 1][j] == ' ')
                return 1 + CalculeazaRau(i + 1, j);
            if (m > j - 1 && lines[i + 1][j - 1] == ' ')
                return 1 + CalculeazaRau(i + 1, j - 1);

            return 1;
        }
    }
}
