namespace _03_ReadInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;

            number = ReadInt();
            Console.WriteLine("Ваше число: " + number);
        }

        static int ReadInt()
        {
            string userInput;
            bool isInt = false;
            int number = 0;

            while (!isInt)
            {
                Console.Write("Введите число: ");
                userInput = Console.ReadLine();
                isInt = int.TryParse(userInput, out number);
            }

            return number;
        }
    }
}