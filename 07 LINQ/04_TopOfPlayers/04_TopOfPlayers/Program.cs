namespace _04_TopOfPlayers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player> {
            new Player ("Tom", 15, 24),
            new Player ("Jack", 17, 20),
            new Player ("Noob", 50, 101),
            new Player ("Nagib", 34, 48),
            new Player ("1337Pacan", 101, 200),
            new Player ("Alukard", 72, 183),
            new Player ("Clyde", 3, 2),
            new Player ("Noname", 45, 110),
            new Player ("Death", 26, 34),
            new Player ("nnm3241231", 13, 22)
            };
            List<Player> topLevelPlayers = new List<Player>();
            List<Player> topPowerPlayers = new List<Player>();

            topLevelPlayers = players.OrderBy(player => player.Level).ToList();
            topPowerPlayers = players.OrderBy(player => player.Power).ToList();

            ShowList("Список игроков:", players);
            ShowList("Топ по уровню:", topLevelPlayers);
            ShowList("Топ по силе:", topPowerPlayers);
        }

        static void ShowList(string message, List<Player> players)
        {
            Console.WriteLine(message);

            foreach (var player in players)
            {
                Console.WriteLine($"Name: {player.Name}, level: {player.Level}, power: {player.Power}");
            }

            Console.WriteLine();
        }
    }

    public class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }
    }
}