using System;

namespace _07_NameInSquare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string symbol;
            int letterCount;

            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.Write("Введите символ: ");
            symbol = Console.ReadLine();

            letterCount = name.Length;

            for (int i = 0; i < letterCount + 2; i++)
            {
                Console.Write(symbol);
            }

            Console.Write("\n" + symbol);
            Console.Write(name);
            Console.Write(symbol + "\n");

            for (int i = 0; i < letterCount + 2; i++)
            {
                Console.Write(symbol);
            }
        }
    }
}
