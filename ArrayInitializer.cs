namespace SortComplexityDifferenceProject
{
    internal class ArrayInitializer
    {
        public static int[] InitializeArray(int length)
        {
            if (length < 3)
            {
                MessageBox.Show("Minimum length of an array is 3.\nPlease try again.");
                return [];
            }

            int[] values = RandomlyFillAnArray(length);
            return values;
        }

        private static int[] RandomlyFillAnArray(int length)
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