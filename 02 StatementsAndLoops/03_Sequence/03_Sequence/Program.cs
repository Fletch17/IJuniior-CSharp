using System;

namespace _03_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = 5;
            int stopNumber = 96;

            for (int i = startNumber; i <= stopNumber; i += 7)
            {
                Console.WriteLine(i);
            }
        }
    }
}
