using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[0];
            int number;
            int sum;
            bool isProgrammWork = true;
            bool isInt;
            string userInput;
            string exitCommand = "exit";
            string sumCommand = "sum";

            Console.Write("Введите числа: ");

            while (isProgrammWork)
            {
                sum = 0;
                userInput = Console.ReadLine();
                isInt = int.TryParse(userInput, out number);

                if (isInt)
                {
                    int[] tempArray = new int[numbers.Length + 1];

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        tempArray[i] = numbers[i];
                    }

                    tempArray[numbers.Length] = number;
                    numbers = tempArray;
                }
                else
                {
                    if (userInput == sumCommand)
                    {
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            sum += numbers[i];
                        }

                        Console.WriteLine("Сумма: " + sum);
                    }
                    else if (userInput == exitCommand)
                    {
                        isProgrammWork = false;
                    }
                    else
                    {
                        Console.WriteLine("Введите число или команды: {0}, {1}.", sumCommand, exitCommand);
                    }
                }
            }
        }
    }
}
