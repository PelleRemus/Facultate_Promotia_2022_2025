using System;
using System.Collections.Generic;

namespace AlgoritmGenetic
{
    public static class Engine
    {
        public static Form1 form;
        public static List<Solution> current;
        public static Random random = new Random();

        public static int n = 100, survivors = 10;
        public static float mutationRate = 0.03F;

        public static void Init(Form1 f)
        {
            form = f;
            form.listBox1.Items.Add("Hello World!");
        }

        public static void NextGeneration()
        {
            form.listBox1.Items.Clear();

            if (current == null)
            {
                current = new List<Solution>();
                for (int i = 0; i < n; i++)
                    current.Add(new Solution());
            }
            else
            {
                SelectSurvivors();
                CrossoverSurvivors();
                MutateSolutions();
            }

            for (int i = 0; i < current.Count; i++)
            {
                form.listBox1.Items.Add(current[i].value + " " + current[i].Fitness());
            }
        }

        public static void SelectSurvivors()
        {
            current.Sort((Solution a, Solution b) => b.value.CompareTo(a.value));
            current.RemoveRange(survivors, n - survivors);
        }

        public static void CrossoverSurvivors()
        {
            int i = random.Next(survivors);
            int j = random.Next(survivors);

            for (int k = survivors; k < n; k++)
                current.Add(new Solution(current[i], current[j]));
        }

        public static void MutateSolutions()
        {
            for (int i = 0; i < n; i++)
                if (random.NextDouble() < mutationRate)
                {
                    int index = random.Next(Solution.length);
                    string value = current[i].value;

                    current[i].value = "";
                    for (int j = 0; j < index; j++)
                        current[i].value += value[j];

                    current[i].value += random.Next(2).ToString();
                    for (int j = index + 1; j < value.Length; j++)
                        current[i].value += value[j];
                }
        }
    }
}
