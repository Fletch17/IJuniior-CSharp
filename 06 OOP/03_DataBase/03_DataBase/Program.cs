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
            DataBase dataBase = new DataBase();

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
                        dataBase.ChangePlayerStatus(true);
                        break;

                    case ComandUnbanPlayer:
                        dataBase.ChangePlayerStatus(false);
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

    class DataBase
    {
        private List<Player> _players;

        public DataBase()
        {
            _players = new List<Player>();
        }

        public void ChangePlayerStatus(bool ban)
        {
            bool isPlayerExist = IsPlayerExist(out int index);

            if (isPlayerExist)
            {
                _players[index].ChangeBanStatus(ban);
            }
        }

        public bool IsPlayerExist(out int index)
        {
            string userInput;
            bool isInt = false;
            int id = 0;
            index = 0;

            while (isInt == false)
            {
                Console.Write("Введите Id: ");
                userInput = Console.ReadLine();
                isInt = int.TryParse(userInput, out id);
            }

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Id == id)
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }

        public void DeletePlayer()
        {
            bool isPlayerExist = IsPlayerExist(out int index);

            if (isPlayerExist)
            {
                _players.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Такого Id нет.");
            }
        }

        public void AddPlayer()
        {
            int number = 0;
            bool isInt = false;
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            while (isInt == false)
            {
                Console.Write("Введите уровень: ");
                string level = Console.ReadLine();
                isInt = int.TryParse(level, out number);
            }

            _players.Add(new Player(name, number));
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
    }

    class Player
    {
        static private int _id;

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

        public void ChangeBanStatus(bool isBan)
        {
            IsBan = isBan;
        }
    }
}