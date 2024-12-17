using System;
using System.Linq;
using System.Xml.Linq;

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

            string[] result = new string[N1 + N2];

            for (int i = 0; i < N1; i++)
            {
                result[i] = array1[i] + t1 + " 1 " + (i + 1);
            }

            for (int i = 0; i < N2; i++)
            {
                int arrivalTime = array2[i] + t2;
                result[N1 + i] = arrivalTime + " 2 " + (i + 1);
            }

            //OrderBy (сортування за обраним ключем) https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.orderby?view=net-9.0
            //Інформація про лямбда-вирази https://learn.microsoft.com/uk-ua/dotnet/csharp/language-reference/operators/lambda-operator
            //ToArray (перетворення послідовності в масив) https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.toarray?view=net-6.0
            result = result.OrderBy(element => int.Parse(element.Split()[0])).ToArray();
            //OrderBy(element => key), element — кожен елемент масиву; key — значення, за яким проводиться сортування (тут int.Parse(element.Split()[0]))).
            //В результаті масив сортується за першим елементом кожного підмасиву в масиві result.
            //Приклад: result = [[10, 1, 1], [14, 1, 2], [17, 1, 3], [15, 2, 1], [18, 2, 2]] => result = [[10, 1, 1], [14, 1, 2], [15, 2, 1], [17, 1, 3], [18, 2, 2]]

            foreach (string v in result)
            {
                Console.WriteLine(v);
            }
        }
    }
}