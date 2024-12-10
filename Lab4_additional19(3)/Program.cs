using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_additional18
{
    internal class Program
    {
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
            string operation = Console.ReadLine();

            int N = int.Parse(Console.ReadLine());
            int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int M = int.Parse(Console.ReadLine());
            int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] result = new int[0];
            if (operation == "UNION")
            {
                result = array1.Union(array2).ToArray();
            }
            else if (operation == "INTERSECTION")
            {
                result = array1.Intersect(array2).ToArray();
            }
            else if (operation == "DIFFERENCE")
            {
                result = array1.Except(array2).ToArray();
            }
            result = QuickSort(result);
            Console.WriteLine(string.Join(" ", QuickSort(result)));
        }
    }
}