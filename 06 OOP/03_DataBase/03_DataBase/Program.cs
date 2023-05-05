namespace _03_DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ComandAddPlayer = "1";
            const string ComandBanPlayer = "2";
            const string ComandUnbanPlayer = "3";
            const string ComandDeletePlayer = "4";
            const string ComandShowInfo = "5";
            const string ComandExit = "6";

            bool isProgrammWork = true;
            string userInput;
            Database dataBase = new Database();

            while (isProgrammWork)
            {
                Console.WriteLine($"{ComandAddPlayer}. Добавить игрока.");
                Console.WriteLine($"{ComandBanPlayer}. Забанить игрока.");
                Console.WriteLine($"{ComandUnbanPlayer}. Разбанить игрока.");
                Console.WriteLine($"{ComandDeletePlayer}. Удалить игрока.");
                Console.WriteLine($"{ComandShowInfo}. Вывести всю информацию.");
                Console.WriteLine($"{ComandExit}. Выход.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ComandAddPlayer:
                        dataBase.AddPlayer();
                        break;

                    case ComandBanPlayer:
                        dataBase.BanPlayer();
                        break;

                    case ComandUnbanPlayer:
                        dataBase.UnbanPlayer();
                        break;

                    case ComandDeletePlayer:
                        dataBase.DeletePlayer();
                        break;

                    case ComandShowInfo:
                        dataBase.ShowInfo();
                        break;

                    case ComandExit:
                        isProgrammWork = false;
                        break;
                }
            }
        }
    }

    class Database
    {
        private List<Player> _players;

        public Database()
        {
            _players = new List<Player>();
        }

        public void UnbanPlayer()
        {
            bool isPlayerExist = TryGetPlayer(out Player player);

            if (isPlayerExist)
            {
                player.SetPlayerUnban();
            }
        }

        public void BanPlayer()
        {
            bool isPlayerExist = TryGetPlayer(out Player player);

            if (isPlayerExist)
            {
                player.SetPlayerBan();
            }
        }

        public void DeletePlayer()
        {
            bool isPlayerExist = TryGetPlayer(out Player player);

            if (isPlayerExist)
            {
                _players.Remove(player);
            }
            else
            {
                Console.WriteLine("Такого Id нет.");
            }
        }

        public void ShowInfo()
        {
            string banInfo;

            foreach (Player player in _players)
            {
                banInfo = player.IsBan ? "Забанен" : "Не забанен";
                Console.WriteLine($"{player.Id}. {player.Name} - {player.Level} лвл. {banInfo}");
            }
        }

        public void AddPlayer()
        {
            bool isInt = false;
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            int number = TryGetInteger("Введите уровень: ");
            _players.Add(new Player(name, number));
        }

        private int TryGetInteger(string message)
        {
            int number = 0;
            bool isInt = false;

            while (isInt == false)
            {
                Console.Write(message);
                string userInput = Console.ReadLine();
                isInt = int.TryParse(userInput, out number);
            }

            return number;
        }

        private bool TryGetPlayer(out Player player)
        {
            string userInput;
            bool isInt = false;
            player = new Player();
            int id = TryGetInteger("Введите Id: ");

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Id == id)
                {
                    player = _players[i];
                    return true;
                }
            }

            return false;
        }
    }

    class Player
    {
        private static int _id;

        public Player()
        {
        }

        public Player(string name, int level)
        {
            Id = ++_id;
            Name = name;
            Level = level;
            IsBan = false;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBan { get; private set; }

        public void SetPlayerBan()
        {
            IsBan = true;
        }

        public void SetPlayerUnban()
        {
            IsBan = false;
        }
    }
}