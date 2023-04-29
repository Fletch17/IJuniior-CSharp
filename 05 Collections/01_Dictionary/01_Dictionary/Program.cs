namespace _01_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("ball", "мяч");
            dictionary.Add("sword", "меч");
            dictionary.Add("red", "красный");
            dictionary.Add("black", "черный");
            dictionary.Add("sun", "солнце");

            userInput = Console.ReadLine();

            if (dictionary.ContainsKey(userInput))
            {
                Console.WriteLine(dictionary[userInput]);
            }
            else
            {
                Console.WriteLine("Такого слова нет.");
            }


        }
    }
}