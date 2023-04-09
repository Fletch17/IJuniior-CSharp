namespace _03_LocalMaximum
{
    //    Дан одномерный массив целых чисел из 30 элементов.
    //Найдите все локальные максимумы и вывести их. (Элемент является локальным максимумом, если он больше своих соседей)
    //Крайний элемент является локальным максимумом, если он больше своего соседа.
    //Программа должна работать с массивом любого размера.
    //Массив всех локальных максимумов не нужен.
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