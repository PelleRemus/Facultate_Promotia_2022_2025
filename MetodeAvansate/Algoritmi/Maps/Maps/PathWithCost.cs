using System.Collections.Generic;

namespace Maps
{
    public class PathWithCost
    {
        public List<Vertice> Path;
        public double cost;

        public PathWithCost()
        {
            Path = new List<Vertice>();
            cost = 0;
        }
    }
}
