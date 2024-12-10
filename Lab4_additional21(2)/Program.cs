using System;
using System.Linq;

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

            for (int i = 0; i < N1; i++)
            {
                Times[i] = array1[i] + t1;
                Skyscrapers[i] = 1;
            }
            for (int i = N1; i < N1+N2; i++)
            {
                Times[i] = array2[i-N1] + t2;
                Skyscrapers[i] = 2;
            }

            //Інформація https://stackoverflow.com/questions/59907372/how-to-use-this-combined-data-type-int-int
            //У кожному кортежі перший елемент відповідає часу з масиву Times, а другий елемент – відповідному числу з масиву Skyscrapers
            (int, int)[] pairs = new (int, int)[N1 + N2];
            for (int i = 0; i < N1 + N2; i++)
            {
                pairs[i] = (Times[i], Skyscrapers[i]);
            }
            //Тобто, для прикладу з умови:
            //Для i = 0: pairs[0] = (10, 1)
            //Для i = 1: pairs[1] = (14, 1)
            //Для i = 2: pairs[2] = (17, 1)...
            //pairs = [(10, 1), (14, 1), (17, 1), (15, 2), (18, 2)]

            //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
            //Cортує масив pairs за першим елементом кожного кортежу (Item1) – тобто за значеннями з масиву Times.
            Array.Sort(pairs, (pair1, pair2) => pair1.Item1.CompareTo(pair2.Item1));
            //pairs = [(10, 1), (14, 1), (15, 2), (17, 1), (18, 2)]

            int Order1 = 0;
            int Order2 = 0;

            for (int q = 0; q < Times.Length; q++)
            {
                if (pairs[q].Item2 == 1) Console.WriteLine($"{pairs[q].Item1} {pairs[q].Item2} {++Order1}");
                else Console.WriteLine($"{pairs[q].Item1} {pairs[q].Item2} {++Order2}");
            }
        }
    }
}