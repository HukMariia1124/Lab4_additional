using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_additional20
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
        static void Main()
        {
            string[] data = Console.ReadLine().Split();
            int N = int.Parse(data[0]);
            int M = int.Parse(data[1]);

            int[] commonNumbers = new int[0];
            int[] temp = new int[0];

            for (int i = 0; i < N; i++)
            {
                string[] row = Console.ReadLine().Split();
                int[] currentRow = new int[row.Length];
                for (int j = 0; j < row.Length; j++)
                    currentRow[j] = int.Parse(row[j]);

                if (i == 0)
                {
                    commonNumbers = currentRow;
                }
                for (int j = 0; j<M;j++)
                {
                    if (BinarySearch(commonNumbers, currentRow[j]) != -1)
                    {
                        Array.Resize(ref temp, temp.Length + 1);
                        temp[temp.Length-1] = currentRow[j];
                    }
                }
                commonNumbers = temp;
                temp = new int[0];

                if (commonNumbers.Length == 0)
                {
                    break;
                }
            }

            if (commonNumbers.Length > 0)
            {
                Array.Sort(commonNumbers);
                Console.WriteLine(string.Join(" ", commonNumbers));
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}