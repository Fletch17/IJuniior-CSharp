using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_SortingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Size = 10;

            Random random = new Random();
            int[] numbers = new int[Size];
            int minimumValueInNumbersArray = 0;
            int maximumValueInNumbersArray = 10;
            int currentValue;
            int previousValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minimumValueInNumbersArray, maximumValueInNumbersArray);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[j - 1])
                    {
                        currentValue = numbers[j];
                        previousValue = numbers[j - 1];
                        numbers[j] = previousValue;
                        numbers[j - 1] = currentValue;
                    }
                }
            }

            Console.WriteLine();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
