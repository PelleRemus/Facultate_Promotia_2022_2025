namespace ListStackQueue
{
    public class Stack<T>
    {
        public int n;
        public T[] v;

        public Stack()
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

        public T RemoveEnd()
        {
            n--;
            T[] array = new T[n];
            T value = v[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = v[i];
            }
            v = array;
            return value;
        }
    }
}
