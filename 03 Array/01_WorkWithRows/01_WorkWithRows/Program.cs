namespace _01_WorkWithRows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minimumValue = 0;
            int maximumValue = 6;
            int[,] array = new int[5, 5];
            int summ = 0;
            int productOfNumbers = 1;
            int row = 1;
            int column = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minimumValue, maximumValue);
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                summ += array[row, i];
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                productOfNumbers *= array[i, column];
            }

            Console.WriteLine("Сумма строки #{0} - {1}", row, summ);
            Console.WriteLine("Произведение столбца #{0} - {1}", column, productOfNumbers);
        }
    }
}