using System;

namespace _05_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            float rubCount = 10000f;
            float usdCount = 100f;
            float eurCount = 50f;
            float rubToUsd = 65f;
            float usdToRub = 0.016f;
            float eurToUsd = 0.95f;
            float usdToEur = 1.05f;
            float rubToEur = 75f;
            float eurToRub = 0.014f;
            string userChoiceSell;
            string userChoiceBuy;
            float userInput;
            string continueOrExit;
            bool isWork = true;

            Console.Write("Добро пожаловать в банк! Здесь вы можете обеменивать рубли, доллары и евро между собой.\n");
            Console.Write("Ваш баланс: " + rubCount + " рублей, " + usdCount + " долларов, " + eurCount + " евро.\n");

            while (isWork)
            {
                Console.Write("1.Рубли - rub\n2.Доллары - usd\n3.Евро - eur\nВведите наименование валюты, которую хотите приобрести: ");
                userChoiceBuy = Console.ReadLine();
                Console.Write("Введите наименование валюты, которую хотите потратить: ");
                userChoiceSell = Console.ReadLine();
                Console.Write("Сколько вы хотите обменять? ");
                userInput = Convert.ToSingle(Console.ReadLine());

                switch (userChoiceSell)
                {
                    case "rub":
                        if (rubCount < userInput)
                        {
                            Console.WriteLine("Недостаточно средств");
                            break;
                        }
                        else
                        {
                            switch (userChoiceBuy)
                            {
                                case "usd":
                                    rubCount -= userInput;
                                    usdCount += (userInput / rubToUsd);
                                    break;
                                case "eur":
                                    rubCount -= userInput;
                                    eurCount += (userInput / rubToEur);
                                    break;
                                default:
                                    Console.Write("Ошибка ввода валюты");
                                    break;
                            }
                            break;
                        }
                    case "usd":
                        if (usdCount < userInput)
                        {
                            Console.WriteLine("Недостаточно средств");
                            break;
                        }
                        else
                        {
                            switch (userChoiceBuy)
                            {
                                case "rub":
                                    usdCount -= userInput;
                                    rubCount += (userInput / usdToRub);
                                    break;
                                case "eur":
                                    usdCount -= userInput;
                                    eurCount += (userInput / usdToEur);
                                    break;
                                default:
                                    Console.Write("Ошибка ввода валюты");
                                    break;
                            }
                            break;
                        }
                    case "eur":
                        if (eurCount < userInput)
                        {
                            Console.WriteLine("Недостаточно средств");
                            break;
                        }
                        else
                        {
                            switch (userChoiceBuy)
                            {
                                case "usd":
                                    eurCount -= userInput;
                                    usdCount += (userInput / eurToUsd);
                                    break;
                                case "rub":
                                    eurCount -= userInput;
                                    rubCount += (userInput / eurToRub);
                                    break;
                                default:
                                    Console.Write("Ошибка ввода валюты");
                                    break;
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("Ошибка ввода валюты");
                        break;
                }

                Console.WriteLine("Ваш баланс: " + rubCount + " рублей, " + usdCount + " долларов, " + eurCount + " евро.");
                Console.Write("Хотите продолжить? y/n  ");
                continueOrExit = Console.ReadLine();

                switch (continueOrExit)
                {
                    case "y":
                        break;
                    case "n":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода");
                        break;
                }
            }
        }
    }
}


