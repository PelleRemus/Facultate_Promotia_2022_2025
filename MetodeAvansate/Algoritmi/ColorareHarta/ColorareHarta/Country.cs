using System.Collections.Generic;
using System.Drawing;

namespace ColorareHarta
{
    public class Country
    {
        public int id;
        public string countryName;
        public Color color;
        public List<Point> borders;

        public Country(string input)
        {
            string[] inputs = input.Split(',');
            id = int.Parse(inputs[0]);
            countryName = inputs[1];
            color = Color.White;

            borders = new List<Point>();
            for (int i = 2; i < inputs.Length; i++)
            {
                string[] coordinates = inputs[i].Split(' ');
                int x = int.Parse(coordinates[0]);
                int y = int.Parse(coordinates[1]);
                borders.Add(new Point(x, y));
            }
        }
    }
}
