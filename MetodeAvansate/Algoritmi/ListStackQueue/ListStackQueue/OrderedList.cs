namespace ListStackQueue
{
    public class OrderedList
    {
        public int n;
        public int[] v;

        public OrderedList()
        {
            n = 0;
            v = new int[n];
        }

        public void AddInOrder(int value)
        {
            n++;
            int[] array = new int[n];
            int index = 0;

            while (index < n - 1 && value > v[index])
            {
                array[index] = v[index];
                index++;
            }
            array[index] = value;

            for (int i = index + 1; i < n; i++)
            {
                array[i] = v[i - 1];
            }
            v = array;
        }

        public void RemoveAll(int value)
        {
            int length = 0;
            for (int i = 0; i < n; i++)
                if (!v[i].Equals(value))
                {
                    length++;
                }

            int[] array = new int[length];
            int index = 0;

            for (int i = 0; i < n; i++)
                if (!v[i].Equals(value))
                {
                    array[index] = v[i];
                    index++;
                }

            n = length;
            v = array;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += v[i].ToString() + " ";
            }
            return result;
        }
    }
}
