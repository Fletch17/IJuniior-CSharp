namespace _02_LargestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int RowCount = 10;
            const int ColumnCount = 10;

            Random random = new Random();
            int[,] numbers = new int[RowCount, ColumnCount];
            int minimumValueInNumbersArray = 0;
            int maximumValueInNumbersArray = 50;
            int maximumValue;
            int setValue = 0;

            Console.WriteLine("Исходная матрица:");

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = random.Next(minimumValueInNumbersArray, maximumValueInNumbersArray);
                }
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write(numbers[i, j] + "\t");
                }

                Console.WriteLine();
            }

            maximumValue = numbers[0, 0];

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (maximumValue < numbers[i, j])
                    {
                        maximumValue = numbers[i, j];
                    }
                }
            }

            Console.WriteLine($"Максимальное значение: {maximumValue}");
            Console.WriteLine("Полученная матрица:");

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (numbers[i, j] == maximumValue)
                    {
                        numbers[i, j] = setValue;
                    }
                }
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write(numbers[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }
    }
}