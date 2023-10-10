using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RainbowSort
{
    public static class Engine
    {
        public static PictureBox display;
        public static TextBox textBox;
        public static Stopwatch stopWatch;

        public static void Initialize(PictureBox pb, TextBox tb)
        {
            display = pb;
            textBox = tb;
            Resources.GenerateRainbow();
            Resources.ShowRainbow();
        }

        public static void Swap(int i, int j)
        {
            Colour c = Resources.rainbow[i];
            Resources.rainbow[i] = Resources.rainbow[j];
            Resources.rainbow[j] = c;
            UpdatePositionsVisually(i, j);
        }

        public static void UpdatePositionsVisually(int i, int j)
        {
            Resources.ShowRainbow();
            Resources.DrawBlack(i);
            Resources.DrawBlack(j);
            display.Update();
            UpdateStopWatch();
        }

        public static void Shuffle()
        {
            Random r = new Random();
            for (int i = 1; i < Resources.n; i++)
            {
                int index = r.Next(i);
                Swap(i, index);
            }
        }

        public static void Bubble()
        {
            int k = 0;
            bool ok;
            do
            {
                ok = true;
                for (int i = 0; i < Resources.n - k - 1; i++)
                    if (Resources.rainbow[i].value > Resources.rainbow[i + 1].value)
                    {
                        Swap(i, i + 1);
                        ok = false;
                    }
                k++;
            } while (!ok);
        }

        public static void Insertion()
        {
            for (int i = 1; i < Resources.n; i++)
                for (int j = i; j > 0; j--)
                    if (Resources.rainbow[j].value < Resources.rainbow[j - 1].value)
                        Swap(j, j - 1);
        }

        public static void Selection()
        {
            for (int i = 0; i < Resources.n; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < Resources.n; j++)
                {
                    UpdatePositionsVisually(i, j);
                    if (Resources.rainbow[minIndex].value > Resources.rainbow[j].value)
                        minIndex = j;
                }
                Swap(i, minIndex);
            }
        }

        public static void QuickSort(int left, int right)
        {
        }

        public static void RestartStopwatch()
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public static void UpdateStopWatch()
        {
            float timeInSeconds = (float)stopWatch.ElapsedMilliseconds / 1000;
            textBox.Text = $"{timeInSeconds.ToString("0.000")} s";
            textBox.Update();
        }

        public static void StopStopWatch()
        {
            stopWatch.Stop();
        }
    }
}
