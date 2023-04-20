namespace _07_Split
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "Сегодня хороший день";
            string[] arrayWords;
            char symbol = ' ';
            arrayWords= message.Split(symbol);

            foreach(string word in arrayWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}