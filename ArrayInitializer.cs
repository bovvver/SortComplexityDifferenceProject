namespace SortComplexityDifferenceProject
{
    internal class ArrayInitializer
    {
        public static int[] InitializeArray(int length)
        {
            var random = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(1, 1001);
            }

            return array;
        }
    }
}