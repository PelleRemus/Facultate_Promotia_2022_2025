using System.Collections.Generic;
using System.Drawing;

namespace CleanCode
{
    // O muchie e formata din 2 verteces, begin si end, adica A --> B (--> e muchia)
    public class Edge
    {
        public Vertex begin;
        public Vertex end;

        public Edge(string data, List<Vertex> vertices)
        {
            string firstVertex = data.Split(' ')[0];
            string secondVertex = data.Split(' ')[1];

            begin = FindVertexByName(firstVertex, vertices);
            end = FindVertexByName(secondVertex, vertices);
        }

        public Vertex FindVertexByName(string name, List<Vertex> vertices)
        {
            foreach (Vertex vertex in vertices)
            {
                if (name == vertex.Name)
                {
                    return vertex;
                }
            }

            return default;
        }

        public void Draw(Graphics handler)
        {
            Pen pen = new Pen(new SolidBrush(Color.Gold), 5);
            handler.DrawLine(pen, begin.Position, end.Position);
        }
    }
}