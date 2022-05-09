using System;

namespace _09_Multiples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int startNumber = 1;
            int endNumber = 27;
            int number = random.Next(startNumber, endNumber + 1);
            int multilesCount = 0;

            Console.WriteLine($"Ваше число {number}");

            for (int i = number; i < 1000; i += number)
            {
                if (i >= 100)
                {
                    multilesCount++;
                }
            }

            Console.WriteLine($"Кол-во кратных чисел - {multilesCount}.");
        }
    }
}
