using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Xml.Serialization;

namespace Lab4_additional17
{
    internal class Program
    {
        static int BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (right + left) / 2;

                if (array[mid] == target)
                {
                    return mid;
                }
                if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
        static int[] QuickSort(int[] array)
        {
            if (array.Length <= 1) return array;

            int pivot = array[array.Length / 2];
            int leftCount = 0, rightCount = 0;

            foreach (int x in array)
            {
                if (x < pivot) leftCount++;
                else if (x > pivot) rightCount++;
            }

            int[] left = new int[leftCount];
            int[] right = new int[rightCount];

            int leftIndex = 0, rightIndex = 0;

            foreach (int x in array)
            {
                if (x < pivot) left[leftIndex++] = x;
                else if (x > pivot) right[rightIndex++] = x;
            }

            QuickSort(left);
            QuickSort(right);

            int index = 0;

            foreach (int num in left)
            {
                array[index++] = num;
            }
            array[index++] = pivot;
            foreach (int num in right)
            {
                array[index++] = num;
            }

            return array;
        }
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int[] array1 = new int[N];
            string[] array = Console.ReadLine().Split();
            for (int i = 0; i < N; i++)
                array1[i] = int.Parse(array[i]);

            int M = int.Parse(Console.ReadLine());
            int[] array2 = new int[M];
            array = Console.ReadLine().Split();
            for (int i = 0; i < M; i++)
                array2[i] = int.Parse(array[i]);

            array1 = QuickSort(array1);

            foreach (int num in array2)
            {
                Console.Write(BinarySearch(array1, num) + 1 + " ");
            }
        }
    }
}