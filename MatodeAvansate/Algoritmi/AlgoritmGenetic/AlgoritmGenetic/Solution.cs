namespace AlgoritmGenetic
{
    public class Solution
    {
        public string value;
        public static int length = 20;

        public Solution()
        {
            value = "";
            for (int i = 0; i < length; i++)
                value += Engine.random.Next(2).ToString();
        }

        public Solution(Solution a, Solution b)
        {
            value = "";
            int middle = Engine.random.Next(1, length - 1);

            for (int i = 0; i < middle; i++)
                value += a.value[i];
            for (int i = middle; i < length; i++)
                value += b.value[i];
        }

        public float Fitness()
        {
            float count = 0;
            for (int i = 0; i < length; i++)
            {
                if (value[i] == '1')
                    count++;
            }
            return count / length;
        }
    }
}
