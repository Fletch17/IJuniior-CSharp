namespace _02_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int money = 0;
            int numberCount = 10;

            for (int i = 0; i < numberCount; i++)
            {
                queue.Enqueue(i);
            }

            while (queue.Count != 0)
            {
                money += queue.Dequeue();
                Console.WriteLine($"Ваш баланс {money}");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}