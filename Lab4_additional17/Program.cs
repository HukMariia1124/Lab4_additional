using System;
using System.Linq;

namespace Lab4_additional17
{
    internal class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int M = int.Parse(Console.ReadLine());
            int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(array1);

            foreach (int num in array2)
            {
                Console.Write(Array.BinarySearch(array1, num) + 1 + " ");
            }
        }
    }
}
