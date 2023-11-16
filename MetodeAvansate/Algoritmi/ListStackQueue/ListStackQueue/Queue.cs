namespace ListStackQueue
{
    public class Queue<T>
    {
        public int n;
        public T[] v;

        public Queue()
        {
            n = 0;
            v = new T[n];
        }

        public void AddEnd(T value)
        {
            n++;
            T[] array = new T[n];

            for (int i = 0; i < n - 1; i++)
            {
                array[i] = v[i];
            }
            array[n - 1] = value;
            v = array;
        }

        public T RemoveBeginning()
        {
            n--;
            T[] array = new T[n];
            T value = v[0];

            for (int i = 1; i <= n; i++)
            {
                array[i - 1] = v[i];
            }
            v = array;
            return value;
        }
    }
}
