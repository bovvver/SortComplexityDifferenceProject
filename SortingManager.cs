using System.Drawing;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SortComplexityDifferenceProject
{
    internal static class SortingManager
    {
        public static int BubbleSort(int[] originalArray) {
            int[] array = (int[]) originalArray.Clone();

            int counter = 0;
            int arrayLength = array.Length - 1;
            bool swapped;

            for(int i = 0; i < arrayLength; i++)
            {
                swapped = false;
                for(int j = 0; j < arrayLength - i; j++)
                {
                    counter++;
                    if (array[j] > array[j + 1])
                    {
                        counter++;
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = true;
                    }
                }
                if (swapped == false) break;
            }

            return counter;
        }

        public static int QuickSort(int[] originalArray, int leftIndex, int rightIndex, ref int counter)
        {
            int[] array = (int[])originalArray.Clone();

            if (leftIndex < rightIndex)
            {
                int pivot = QuickSortPartition(array, leftIndex, rightIndex, ref counter);
                QuickSort(array, leftIndex, pivot, ref counter);
                QuickSort(array, pivot + 1, rightIndex, ref counter);
            }

            return counter;
        }

        private static int QuickSortPartition(int[] array, int leftIndex, int rightIndex, ref int counter)
        {
            int pivot = array[leftIndex];
            int leftBorder = leftIndex;

            for (int i = leftIndex + 1; i <= rightIndex; i++)
            {
                counter++;
                if (array[i] < pivot)
                {
                    counter++;
                    (array[i], array[leftBorder]) = (array[leftBorder], array[i]);
                    leftBorder++;
                }
            }

            counter++;
            (pivot, array[leftBorder]) = (array[leftBorder], pivot);

            return leftBorder;
        }

        public static int SelectionSort(int[] originalArray)
        {
            int[] array = (int[])originalArray.Clone();
            int arrayLength = array.Length;
            int counter = 0;

            for(int i = 0; i < arrayLength - 1; i++)
            {
                int minimumIndex = i;
                for(int j = i + 1; j < arrayLength; j++)
                {
                    if (array[j] < array[minimumIndex])
                        minimumIndex = j;
                    counter++;
                }
                (array[minimumIndex], array[i]) = (array[i], array[minimumIndex]);
                counter++;
            }

            return counter;
        }

        public static int ShellSort(int[] originalArray)
        {
            int[] array = (int[])originalArray.Clone();
            int arrayLength = array.Length, counter = 0;

            for (int gap = arrayLength / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < arrayLength; i++)
                {
                    int currentKey = array[i];
                    int index = i;

                    while (index >= gap && array[index - gap] > currentKey)
                    {
                        array[index] = array[index - gap];
                        index -= gap;
                        counter++;
                    }
                    array[index] = currentKey;
                    counter++;
                }
            }
            return counter;
        }

        public static int BogoSort(int[] originalArray)
        {
            int[] array = (int[])originalArray.Clone();
            int counter = 0;

            while(!IsSorted(ref array, ref counter))
            {
                Shuffle(ref array, ref counter);
            }

            return counter;
        }

        private static bool IsSorted(ref int[] array, ref int counter)
        {
            int arrayLength = array.Length;

            while (--arrayLength >= 1)
            {
                counter++;
                if (array[arrayLength] < array[arrayLength - 1]) return false;
            }

            return true;
        }

        private static void Shuffle(ref int[] array, ref int counter)
        {
            var random = new Random();
            int arrayLength = array.Length, randomIndex;

            for (int i = 0; i < arrayLength; i++)
            {
                randomIndex = random.Next(arrayLength);
                (array[i], array[randomIndex]) = (array[randomIndex], array[i]);
                counter++;
            }
        }
    }
}
