using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_additional20
{
    internal class Program
    {
        static void Main()
        {
            string[] data = Console.ReadLine().Split();
            int N = int.Parse(data[0]);
            int M = int.Parse(data[1]);

            int[] commonNumbers = new int[0];

            for (int i = 0; i < N; i++)
            {
                string[] row = Console.ReadLine().Split();
                int[] currentRow = new int[row.Length];
                for (int j = 0; j<row.Length; j++)
                    currentRow[j] = int.Parse(row[j]);

                if (i == 0)
                {
                    commonNumbers = currentRow;
                }
                else
                {
                    commonNumbers = Intersection(commonNumbers, currentRow);
                }

                if (commonNumbers.Length == 0)
                {
                    break;
                }
            }

            if (commonNumbers.Length > 0)
            {
                Console.WriteLine(string.Join(" ", commonNumbers));
            }
            else
            {
                Console.WriteLine();
            }
        }
        static int[] Intersection(int[] array1, int[] array2)
        {
            int i = 0, j = 0, k = 0;
            int[] temp = new int[k];

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
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[k++] = array1[i++];
                    j++;
                }
            }
            return temp;
        }
    }
}