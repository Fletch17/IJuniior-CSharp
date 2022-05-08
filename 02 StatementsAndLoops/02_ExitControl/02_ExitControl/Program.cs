using System;

namespace _02_ExitControl
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            string userInput;

            while (isWork)
            {
                Console.Write("Введите команду: ");
                userInput = Console.ReadLine();

                if (userInput == "exit")
                {
                    isWork = false;
                }
            }
        }
    }
}
