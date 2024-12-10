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
                    commonNumbers = commonNumbers.Intersect(currentRow).ToArray();
                }

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