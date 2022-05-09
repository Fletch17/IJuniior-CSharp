using System;

namespace _06_ConsoleMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            bool isWork = true;

            Console.WriteLine("Добро пожаловать в консоль. Для вывода всех команд введите help.");

            while (isWork)
            {
                Console.Write("Введите команду: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "help":
                        Console.WriteLine("help - вывод всех команд\nchangeConsoleColor - изменение цвета текста;\ntime - вывести текущие дату и время;\nclear - очистить консоль;\nexit - выйти из консоли");
                        break;
                    case "changeConsoleColor":
                        var isChoice = true;

                        while (isChoice)
                        {
                            Console.WriteLine("Выберите цвет: красный - red, зеленый - green, желтый - yellow");
                            userInput = Console.ReadLine();

                            switch (userInput)
                            {
                                case "red":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    isChoice = false;
                                    break;
                                case "green":
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    isChoice = false;
                                    break;
                                case "yellow":
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    isChoice = false;
                                    break;
                                default:
                                    Console.WriteLine("Неверная команда.");
                                    break;
                            }
                        }

                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "time":
                        Console.WriteLine(DateTime.Now);
                        break;
                    case "exit":
                        isWork = false;
                        break;
                }
            }
        }
    }
}
