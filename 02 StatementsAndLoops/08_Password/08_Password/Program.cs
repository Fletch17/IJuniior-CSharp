using System;

namespace _08_Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "olo";
            int numberOfAttempts = 3;
            string message = "Gratz!";
            string userInput;

            for (int i = 0; i < numberOfAttempts; i++)
            {
                Console.Write("Введите пароль: ");
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine(message);
                    return;
                }

                Console.WriteLine("Неправильный пароль");
            }
        }
    }
}
