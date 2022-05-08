using System;

namespace _04_Summ
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int startNumberForRandom = 0;
            int endNumberForRandom = 100;
            int summ = 0;
            int firstDivider = 3;
            int secondDivider = 5;
            int number = random.Next(startNumberForRandom, endNumberForRandom + 1);

            for (int i = 0; i <= number; i++)
            {
                if ((i % firstDivider == 0) || (i % secondDivider == 0))
                {
                    summ += i;
                }
            }

            Console.WriteLine(summ);
        }
    }
}
