using System;

namespace Lab4_additional16
{
    internal class Program
    {
        static void Main()
        {
            string[] nums = Console.ReadLine().Split();
            long min = long.Parse(nums[0]);
            long max = long.Parse(nums[1]);
            string result = "";
            long temp = 0;
            while (result != "=")
            {
                temp = (min + max) / 2;
                Console.WriteLine("try " + temp);
                result = Console.ReadLine();
                if (result == "+")
                {
                    min = temp+1;
                }
                else if (result == "-")
                {
                    max = temp-1;
                }
            }
            Console.WriteLine("answer " + temp);
        }
    }
}
