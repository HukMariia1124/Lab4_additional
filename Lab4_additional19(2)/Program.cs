using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_additional19
{
    internal class Program
    {
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
            switch (operation)
            {
                case "UNION":
                    Union(ref array1, ref array2, ref result);
                    break;
                case "INTERSECTION":
                    Intersection(ref array1, ref array2, ref result);
                    break;
                case "DIFFERENCE":
                    Difference(ref array1, ref array2, ref result);
                    break;
            }
            foreach (int num in result)
            {
                if (num != 0)
                {
                    Console.Write(num + " ");
                }
            }
            Console.WriteLine();
        }
        static void Union(ref int[] array1, ref int[] array2, ref int[] result)
        {
            int i = 0, j = 0, k = 0;

            while (i < array1.Length && j < array2.Length)
            {
                if (array1[i] < array2[j])
                {
                    result[k++] = array1[i++];
                }
                else if (array1[i] > array2[j])
                {
                    result[k++] = array2[j++];
                }
                else
                {
                    result[k++] = array1[i++];
                    j++;
                }
            }

            while (i < array1.Length)
            {
                result[k++] = array1[i++];
            }

            while (j < array2.Length)
            {
                result[k++] = array2[j++];
            }
        }
        static void Intersection(ref int[] array1, ref int[] array2, ref int[] result)
        {
            int i = 0, j = 0, k = 0;

            while (i < array1.Length && j < array2.Length)
            {
                if (array1[i] < array2[j])
                {
                    i++;
                }
                else if (array1[i] > array2[j])
                {
                    j++;
                }
                else
                {
                    result[k++] = array1[i++];
                    j++;
                }
            }
        }
        static void Difference(ref int[] array1, ref int[] array2, ref int[] result)
        {
            int i = 0, j = 0, k = 0;

            while (i < array1.Length && j < array2.Length)
            {
                if (array1[i] < array2[j])
                {
                    result[k++] = array1[i++];
                }
                else if (array1[i] > array2[j])
                {
                    j++;
                }
                else
                {
                    i++;
                    j++;
                }
            }
            while (i < array1.Length)
            {
                result[k++] = array1[i++];
            }
        }
    }
}