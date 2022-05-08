using System;

namespace _01_Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int repeatsCount;
            string phrase;

            Console.Write("Введите фразу: ");
            phrase = Console.ReadLine();
            Console.Write("Сколько раз повторить? ");
            repeatsCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < repeatsCount; i++)
            {
                Console.WriteLine(phrase);
            }
        }
    }
}
