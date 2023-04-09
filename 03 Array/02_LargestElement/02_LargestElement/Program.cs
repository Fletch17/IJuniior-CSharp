namespace _02_LargestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[,] array = new int[10, 10];
            int minimumValueInArray = 0;
            int maximumValueInArray = 50;
            int maximumValue = 0;

            Console.WriteLine("Исходная матрица:");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minimumValueInArray, maximumValueInArray);
                    Console.Write(array[i, j] + "\t");

                    if (maximumValue < array[i, j])
                    {
                        maximumValue = array[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Максимальное значение: {maximumValue}");
            Console.WriteLine("Полученная матрица:");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maximumValue)
                    {
                        array[i, j] = 0;
                    }

                    Console.Write(array[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }
    }
}