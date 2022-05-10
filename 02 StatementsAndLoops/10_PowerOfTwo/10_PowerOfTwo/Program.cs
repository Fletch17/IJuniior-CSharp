using System;

namespace _10_PowerOfTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int startNumberForRandom = 10;
            int endNumberForRandom = 200;
            double number = random.Next(startNumberForRandom, endNumberForRandom);
            double desiredNumber = 0;
            double power = 2;

            Console.WriteLine($"Ваше число: {number}");

            for (int i = 0; i < int.MaxValue; i++)
            {
                desiredNumber = Math.Pow(power, i);

                if (desiredNumber > number)
                {
                    Console.WriteLine($"Искомая степень: {i}, число: {desiredNumber}");
                    break;
                }
            }
        }
    }
}
