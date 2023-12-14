using System;
namespace Maps
{
    public class Edge
    {
        public Vertice start;
        public Vertice end;
        public double cost;

        public Edge(string data)
        {
            string[] split = data.Split(' ');
            start = Graph.FindVertice(int.Parse(split[0]));
            end = Graph.FindVertice(int.Parse(split[1]));
            cost = Graph.GetDistance(start.position, end.position);
        }
    }
}
