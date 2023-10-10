using System;

namespace Partial
{
    public class Data
    {
        public int dataID;
        public double med;
        public int pondere;
        public double min;
        public double max;

        public Data(int id, double value)
        {
            AddData(id, value);
            min = med;
            max = med;
        }

        public void AddData(int id, double value)
        {
            dataID = id;
            med = (med * pondere + value) / (pondere + 1);
            pondere++;
            min = Math.Min(min, value);
            max = Math.Max(max, value);
        }

        public override string ToString()
        {
            return $"dataID: {dataID}, med: {med}, min: {min}, max: {max}";
        }
    }
}
