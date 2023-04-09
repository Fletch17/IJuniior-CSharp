namespace _03_LocalMaximum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int Size = 30;

            Random random = new Random();
            int[] numbers = new int[Size];
            int minimumValueInNumbers = 0;
            int maximumValueInNumbers = 20;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minimumValueInNumbers, maximumValueInNumbers);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.Write("\nЛокальные максимумы: ");


            if (numbers[0] > numbers[1])
            {
                Console.Write(numbers[0] + " ");
            }

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                {
                    Console.Write(numbers[i] + " ");
                }
            }

            if (numbers[numbers.Length - 1] > numbers[numbers.Length - 2])
            {
                Console.Write(numbers[numbers.Length - 1] + " ");
            }
        }
    }
}