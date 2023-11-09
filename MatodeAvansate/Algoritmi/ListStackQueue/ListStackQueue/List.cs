using System;

namespace ListStackQueue
{
    public class List<T> where T : IEquatable<T>
    {
        public int n;
        public T[] v;

        public List()
        {
            n = 0;
            v = new T[n];
        }

        public void AddBeginning(T value)
        {
            n++;
            T[] array = new T[n];
            array[0] = value;

            for (int i = 1; i < n; i++)
            {
                array[i] = v[i - 1];
            }
            v = array;
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

        public void RemoveAll(T value)
        {
            int length = 0;
            for (int i = 0; i < n; i++)
                if (!v[i].Equals(value))
                {
                    length++;
                }

            T[] array = new T[length];
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
