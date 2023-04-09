namespace _01_WorkWithRows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int RowCount = 5;
            const int ColumnCount = 5;

            Random random = new Random();
            int minimumValueInNumbersArray = 0;
            int maximumValueInNumbersArray = 6;
            int[,] numbers = new int[RowCount, ColumnCount];
            int summ = 0;
            int productOfNumbers = 1;
            int roworSearch = 1;
            int columnForSearch = 0;

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

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                summ += numbers[roworSearch, i];
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                productOfNumbers *= numbers[i, columnForSearch];
            }

            Console.WriteLine("Сумма строки #{0} - {1}", roworSearch, summ);
            Console.WriteLine("Произведение столбца #{0} - {1}", columnForSearch, productOfNumbers);
        }
    }
}