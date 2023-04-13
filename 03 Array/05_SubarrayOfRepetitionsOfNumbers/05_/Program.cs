using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_SubarrayOfRepetitionsOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int size = 30;
            int[] numbers = new int[size];
            int maximumValueInNumbersArray = 10;
            int minimumValueInNumbersArray= 0;
            int currentNumber;
            int numberForMaximum;
            int currentCount=0;
            int maximumCount = currentCount;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minimumValueInNumbersArray, maximumValueInNumbersArray);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]+" ");
            }

            Console.WriteLine();
            currentNumber=numbers[0];
            numberForMaximum = currentNumber;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == currentNumber)
                {
                    currentCount++;

                    if(maximumCount<currentCount)
                    {
                        numberForMaximum= numbers[i];
                        maximumCount = currentCount;
                    }
                }
                else
                {
                    currentCount = 1;
                    currentNumber = numbers[i];
                }
            }

            Console.WriteLine("Число {0} повторяется {1} раз подряд", numberForMaximum, maximumCount);
        }
    }
}
