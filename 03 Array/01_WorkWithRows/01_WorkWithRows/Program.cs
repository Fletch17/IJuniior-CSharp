namespace _01_WorkWithRows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minimumValue = 0;
            int maximumValue = 6;
            int[,] numbers = new int[5, 5];
            int summ = 0;
            int productOfNumbers = 1;
            int row = 1;
            int column = 0;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = random.Next(minimumValue, maximumValue);
                    Console.Write(numbers[i, j] + "\t");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                summ += numbers[row, i];
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                productOfNumbers *= numbers[i, column];
            }

            Console.WriteLine("Сумма строки #{0} - {1}", row, summ);
            Console.WriteLine("Произведение столбца #{0} - {1}", column, productOfNumbers);
        }
    }
}