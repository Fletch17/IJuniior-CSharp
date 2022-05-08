using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int rubCount = 1000;
            int usdCount = 300;
            int eurCount = 300;

            float rubToUsd = 60f;
            float usdToRub = 0.16f;
            float rubToEur = 80f;
            float eurToRub = 0.125f;
            float usdToEur = 0.75f;
            float eurToUsd = 1.33f;

            float coefficient;

            bool isWork = true;
            string userInput;

            while (isWork)
            {
                Console.WriteLine("Ваш баланс: rub - " + rubCount + ", usd - " + usdCount + ", eur - " + eurCount + ".");
                Console.WriteLine("1. Rub->Usd.\n2. Usd->Rub.\n3. Rub->Eur.\n4. Eur->Rub.\n5. Usd->Eur.\n6. Eur->Usd.\n7. Выйти.\nВыберите пункт:");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        coefficient = rubToUsd;
                        break;
                    case "2":
                        coefficient = usdToRub;
                        break;
                    case "3":
                        coefficient = rubToEur;
                        break;
                    case "4":
                        coefficient = eurToRub;
                        break;
                    case "5":
                        coefficient = usdToEur;
                        break;
                    case "6":
                        coefficient = eurToUsd;
                        break;
                    case "7":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Веверная команда.");
                        break;  
                }

                Console.WriteLine("Сколько хотите преобрести валюты: ");
                Convert.ToString(coefficient);
                Convert.
            }
        }

        private static void Convert()
        {
            Console.WriteLine("Какую валюту хотите купить?");

            while (true)
            {
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case"1":

                        break;

                }
            }

        }
    }
}
