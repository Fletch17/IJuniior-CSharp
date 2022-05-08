using System;

namespace _03_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = 5;
            int step = 7;
            int stopNumber = 96;
            int number = startNumber;

            while (number <= stopNumber)
            {
                Console.WriteLine(number);
                number += step;
            }
        }
    }
}
