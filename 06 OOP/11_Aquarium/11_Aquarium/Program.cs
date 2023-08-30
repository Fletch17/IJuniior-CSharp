namespace _11_Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Aquarium(5).Run();
        }
    }

    public class Aquarium
    {
        private List<Fish> _fishes;
        private int _capacity;

        public Aquarium(int capacity)
        {
            _fishes = new List<Fish>();
            _capacity = capacity;
        }

        public void Run()
        {
            const string CommandAddFish = "1";
            const string CommandRemoveFish = "2";
            const string CommandNextTurn = "3";
            const string CommandExit = "4";

            bool isProgramWork = true;
            string userInput;

            Console.WriteLine($"{CommandAddFish}. Добавить рыбу.");
            Console.WriteLine($"{CommandRemoveFish}. Убрать рыбу.");
            Console.WriteLine($"{CommandNextTurn}. Пропустить ход.");
            Console.WriteLine($"{CommandExit}. Выйти.");

            while (isProgramWork)
            {
                Console.Write("Выбирите пункт: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddFish:
                        AddFish();
                        break;
                    case CommandRemoveFish:
                        RemoveFish();
                        break;
                    case CommandNextTurn:
                        break;
                    case CommandExit:
                        isProgramWork = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка!");
                        break;
                }

                SkipTurn();
                ShowInfo();
            }
        }

        private void RemoveFish()
        {
            if (_fishes.Count == 0)
            {
                Console.WriteLine("В аквариуме пусто! Убирать некого.");
                return;
            }

            bool isRemoving = true;
            string userInput;

            while (isRemoving)
            {
                Console.Write("Выбирите индекс: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int index))
                {
                    if (index > 0 && index <= _capacity)
                    {
                        _fishes.RemoveAt(index - 1);
                        isRemoving = false;
                    }
                    else
                    {
                        Console.WriteLine("Индекс неверен!");
                    }
                }
                else
                {
                    Console.WriteLine("Введите число!");
                }
            }
        }

        private void ShowInfo()
        {
            if (_fishes.Count == 0)
            {
                Console.WriteLine("В аквариуме пусто!");
                return;
            }

            Console.WriteLine($"В аквариуме {_fishes.Count}/{_capacity} рыб.");

            for (int i = 0; i < _fishes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_fishes[i].GetInfo()}");
            }
        }

        private void AddFish()
        {
            if (_fishes.Count == _capacity)
            {
                Console.WriteLine("Аквариум полный.");
                return;
            }

            bool isAdding = true;
            int age = 0; ;
            string userInput;
            string name;

            Console.Write("Введите имя рыбы: ");
            name = Console.ReadLine();
            Console.Write("Сколько ходов эта рыба будет жить: ");

            while (isAdding)
            {
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int value))
                {
                    age = value;
                    isAdding = false;
                }
                else
                {
                    Console.WriteLine("Введите число!");
                }
            }

            _fishes.Add(new Fish(name, age));
        }

        private void SkipTurn()
        {
            Console.WriteLine("Пропушен ход.");

            foreach (var fish in _fishes)
            {
                fish.DecreaseTurn();
            }

            CheckForDeads();
        }

        private void CheckForDeads()
        {
            for (int i = _fishes.Count - 1; i >= 0; i--)
            {
                if (_fishes[i].TurnCount == 0)
                {
                    _fishes.Remove(_fishes[i]);
                }
            }
        }
    }

    public class Fish
    {
        private string _name;

        public Fish(string name, int age)
        {
            _name = name;
            TurnCount = age;
        }

        public int TurnCount { get; private set; }

        public string GetInfo()
        {
            return $"{_name} - осталось жить {TurnCount} ходов.";
        }

        public void DecreaseTurn()
        {
            TurnCount--;
        }
    }
}