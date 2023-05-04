namespace _01_WorkingWithClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Alex", 100, 23);

            player.ShowInformation();
        }
    }

    class Player
    {
        private string _name;
        private int _health;
        private int _gold;

        public Player(string name, int healt, int gold)
        {
            _name = name;
            _health = healt;
            _gold = gold;
        }

        public void ShowInformation()
        {
            Console.WriteLine($"{_name}. Здоровье - {_health}, золото - {_gold}");
        }
    }
}