namespace _01_WorkWithRows
{
    internal class Program
    {
        static Random random;

        static void Main(string[] args)
        {
            random = new Random();
            int[,] array = new int[5, 5];
            int summ = 0;
            int productOfNumbers = 1;
            int row = 1;
            int column = 0;            

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(0, 30);
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == 1)
                    {
                        summ += array[i, j];
                    }

                    if (j == 0)
                    {
                        productOfNumbers *= array[i, j];
                    }
                }
            }

            Console.WriteLine("Сумма строки #{0} - {1}", row, summ);
            Console.WriteLine("Произведение столбца #{0} - {1}", column, productOfNumbers);
        }
    }
}