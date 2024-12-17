using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace Lab4_additional18
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
            string operation = Console.ReadLine();

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

            int[] result = new int[N+M];
            int index = 0;
            if (operation == "UNION")
            {
                if (array1.Length < array2.Length)
                {
                    for (int i = 0; i < array2.Length; i++)
                    {
                        result[index++] = array2[i];
                    }
                    for (int i = 0; i < array1.Length; i++)
                    {
                        if (BinarySearch(array2, array1[i]) == -1)
                        {
                            result[index++] = array1[i];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < array1.Length; i++)
                    {
                        result[index++] = array1[i];
                    }
                    for (int i = 0; i < array2.Length; i++)
                    {
                        if (BinarySearch(array1, array2[i]) == -1)
                        {
                            result[index++] = array2[i];
                        }
                    }
                }
            }
            else if (operation == "INTERSECTION")
            {
                if (array1.Length < array2.Length)
                {
                    for (int i = 0; i < array1.Length; i++)
                    {
                        if (BinarySearch(array2, array1[i]) != -1)
                        {
                            result[index++] = array1[i];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < array2.Length; i++)
                    {
                        if (BinarySearch(array1, array2[i]) != -1)
                        {
                            result[index++] = array2[i];
                        }
                    }
                }
            }
            else if (operation == "DIFFERENCE")
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    if (BinarySearch(array2, array1[i]) == -1)
                    {
                        result[index++] = array1[i];
                    }
                }
            }
            int[] result2 = new int[index];
            for (int i = 0; i < index; i++)
            {
                result2[i] = result[i];
            }
            result2 = QuickSort(result2);
            Console.WriteLine(string.Join(" ", result2));
            Console.WriteLine();
        }
    }
}