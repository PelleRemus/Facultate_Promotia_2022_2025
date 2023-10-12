namespace BazeGrafuri
{
    public class Vertex
    {
        public int value;
        public int X, Y;

        public Vertex(int v)
        {
            value = v;
        }
        public Vertex(int value, int x, int y) : this(value)
        {
            X = x;
            Y = y;
        }
    }
}
