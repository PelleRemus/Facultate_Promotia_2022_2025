namespace AlgLuiLee
{
    public class Queue
    {
        public MapTile[] v;
        public int length;

        // coada are proprietatile ca se adauga la final si se iese de la inceput
        public Queue()
        {
            v = new MapTile[0];
            length = 0;
        }

        public void Add(MapTile tile)
        {
            length++;
            MapTile[] newV = new MapTile[length];
            for (int i = 0; i < length - 1; i++)
            {
                newV[i] = v[i];
            }
            newV[length - 1] = tile;
            v = newV;
        }

        public MapTile Remove()
        {
            length--;
            MapTile[] newV = new MapTile[length];
            for (int i = 0; i < length; i++)
            {
                newV[i] = v[i + 1];
            }
            MapTile toReturn = v[0];
            v = newV;
            return toReturn;
        }
    }
}
