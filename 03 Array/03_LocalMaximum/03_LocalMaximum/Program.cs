namespace _03_LocalMaximum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[30];
            int minimumValueInArray = 0;
            int maximumValueInArray = 20;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minimumValueInArray, maximumValueInArray);
                Console.Write(array[i] + " ");
            }

            Console.Write("\nЛокальные максимумы: ");

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    if (array[i] > array[i + 1])
                    {
                        Console.Write(array[i] + " ");
                    }
                }
                else if (i == array.Length - 1)
                {
                    if (array[i] > array[i - 1])
                    {
                        Console.Write(array[i] + " ");
                    }
                }
                else
                {
                    if (array[i] > array[i - 1] && array[i] > array[i + 1])
                    {
                        Console.Write(array[i] + " ");
                    }
                }
            }
        }
    }
}