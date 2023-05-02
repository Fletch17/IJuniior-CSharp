namespace _03_DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            bool isProgramWork = true;
            string commandExit = "exit";
            string commandSum = "sum";
            string userInput;
            int sum;

            while (isProgramWork)
            {
                userInput = Console.ReadLine();
                bool isInt = int.TryParse(userInput, out int index);

                if (isInt)
                {
                    numbers.Add(index);
                }
                else 
                {
                    if (userInput == commandSum)
                    {
                        sum = 0;

                        foreach (int number in numbers)
                        {
                            sum += number;
                        }

                        Console.WriteLine($"Сумма равна: {sum}");
                    }
                    else if (userInput == commandExit)
                    {
                        isProgramWork = false;
                    }
                }
            }
        }
    }
}