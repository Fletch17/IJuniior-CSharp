using System;

namespace _04_Summ
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int startNumber = 0;
            int endNumber = 101;
            int summ = 0;
            int firstDivider = 3;
            int secondDivider = 5;
            int number = random.Next(startNumber, endNumber);

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
