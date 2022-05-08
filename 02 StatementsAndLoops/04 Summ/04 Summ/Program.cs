using System;

namespace _04_Summ
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int number = rand.Next(0, 101);
            var summ = 0;

            for (int i = 0; i <= number; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                {
                    summ += i;
                }
            }

            Console.WriteLine(summ);
        }
    }
}
