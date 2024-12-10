using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_additional18
{
    internal class Program
    {
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
            Array.Sort(result);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}