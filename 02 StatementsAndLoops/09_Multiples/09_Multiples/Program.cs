using System;

namespace _09_Multiples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int startNumberForRandom = 1;
            int endNumberForRandom = 27;
            int number = random.Next(startNumberForRandom, endNumberForRandom + 1);
            int multilesCount = 0;
            int firstThreeDigitNumber = 100;
            int maxNumber = 1000;

            Console.WriteLine($"Ваше число {number}");

            for (int i = number; i < maxNumber; i += number)
            {
                if (i >= firstThreeDigitNumber)
                {
                    multilesCount++;
                }
            }

            Console.WriteLine($"Кол-во кратных чисел - {multilesCount}.");
        }
    }
}
