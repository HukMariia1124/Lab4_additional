using System;

namespace Lab4_additional21
{
    internal class Program
    {
        static void Main()
        {
            int t1 = int.Parse(Console.ReadLine());
            int N1 = int.Parse(Console.ReadLine());
            int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int t2 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] Times = new int[N1 + N2];
            int[] Skyscrapers = new int[N1 + N2];
            int[] Order = new int[N1 + N2];

            int i = 0, j = 0, k = 0;

            while (i < N1 && j < N2)
            {
                int time1 = array1[i] + t1;
                int time2 = array2[j] + t2;

                if (time1 <= time2)
                {
                    Times[k] = time1;
                    Skyscrapers[k] = 1;
                    Order[k++] = i++ + 1;
                }
                else
                {
                    Times[k] = time2;
                    Skyscrapers[k] = 2;
                    Order[k++] = j++ + 1;
                }
            }

            while (i < N1)
            {
                Times[k] = array1[i] + t1;
                Skyscrapers[k] = 1;
                Order[k++] = i++ + 1;
            }

            while (j < N2)
            {
                Times[k] = array2[j] + t2;
                Skyscrapers[k] = 2;
                Order[k++] = j++ + 1;
            }

            for (int q = 0; q < Times.Length; q++)
            {
                Console.WriteLine($"{Times[q]} {Skyscrapers[q]} {Order[q]}");
            }
        }
    }
}