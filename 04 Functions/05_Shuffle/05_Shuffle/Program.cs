namespace _05_Shuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            ShowArray(numbers);
            Shuffle(numbers);
            Console.WriteLine();
            ShowArray(numbers);
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();
            int randomIndex;
            int tempNumber;

            for (int i = array.Length - 1; i > 0; i--)
            {
                randomIndex = random.Next(i + 1);
                tempNumber = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = tempNumber;
            }
        }

        static void ShowArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
        }
    }
}