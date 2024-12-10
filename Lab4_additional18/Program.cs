using System;
using System.Linq;

namespace Lab4_additional18
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

            foreach (int v in array2)
            {
                int first = BinarySearch(array1, v, true);
                if (first == -1)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    int last = BinarySearch(array1, v, false);
                    Console.WriteLine($"{first + 1} {last + 1}");
                }
            }
        }

        static int BinarySearch(int[] arr, int target, bool searchFirst)
        {
            int left = 0, right = arr.Length - 1, result = -1;

            while (left <= right)
            {
                int mid = (right + left) / 2;

                if (arr[mid] == target)
                {
                    result = mid;
                    if (searchFirst) right = mid - 1;
                    else left = mid + 1;
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}