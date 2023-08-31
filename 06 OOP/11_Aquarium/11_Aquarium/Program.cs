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

            while (isProgramWork)
            {
                Console.WriteLine($"{CommandAddFish}. Добавить рыбу.");
                Console.WriteLine($"{CommandRemoveFish}. Убрать рыбу.");
                Console.WriteLine($"{CommandNextTurn}. Пропустить ход.");
                Console.WriteLine($"{CommandExit}. Выйти.");
                ShowInfo();
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
                    if (index > 0 && index <= _fishes.Count)
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

            Console.WriteLine($"В аквариуме {_fishes.Count}/{_capacity} рыб:");

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

            bool isCorrectInput = false;
            int health = 0;
            string userInput;

            Console.Write("Введите имя рыбы: ");
            string name = Console.ReadLine();
            Console.Write("Сколько ходов эта рыба будет жить: ");

            while (isCorrectInput == false)
            {
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int value))
                {
                    if (value > 0)
                    {
                        health = value;
                        isCorrectInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Число должно быть больше 0.");
                    }
                }
                else
                {
                    Console.WriteLine("Введите число!");
                }
            }

            _fishes.Add(new Fish(name, health));
        }

        private void SkipTurn()
        {
            Console.WriteLine("Пропушен ход.");

            foreach (var fish in _fishes)
            {
                fish.DecreaseHealth();
            }

            RemoveDeadFishes();
        }

        private void RemoveDeadFishes()
        {
            for (int i = _fishes.Count - 1; i >= 0; i--)
            {
                if (_fishes[i].IsAlive == false)
                {
                    _fishes.Remove(_fishes[i]);
                }
            }
        }
    }

    public class Fish
    {
        private string _name;
        private int _health;

        public Fish(string name, int health)
        {
            _name = name;
            _health = health;
        }
                
        public bool IsAlive => _health > 0;

        public string GetInfo()
        {
            return $"{_name} - осталось {_health} жизней.";
        }

        public void DecreaseHealth()
        {
            _health--;
        }
    }
}