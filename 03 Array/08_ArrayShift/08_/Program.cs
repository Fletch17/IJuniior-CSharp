namespace _08_ArrayShift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string userInput;
            int tempNumber;

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.Write("\nСколько раз сдвинуть массив влево? ");
            userInput= Console.ReadLine();

            for (int i = 0; i < Convert.ToInt32(userInput); i++)
            {
                tempNumber = numbers[0];

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (j < numbers.Length - 1)
                    {
                        numbers[j] = numbers[j + 1];
                    }
                    else
                    {
                        numbers[j] = tempNumber;
                    }
                }
            }

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}