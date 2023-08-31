namespace _12_Zoopark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Zoopark().Run();
        }
    }

    public class Zoopark
    {
        private List<Aviary> _aviaries;

        public Zoopark()
        {
            _aviaries = new List<Aviary>
            {
                new Aviary(5, AnimalType.Tiger),
                new Aviary(6, AnimalType.Cow),
                new Aviary(7, AnimalType.Dog),
                new Aviary(8, AnimalType.Snake),
                new Aviary(9, AnimalType.Horse)
            };
        }

        public void Run()
        {
            const string CommandGoToVolier = "1";
            const string CommandExit = "2";

            bool isProgrammWork = true;
            string userInput;

            while (isProgrammWork)
            {
                Console.WriteLine($"{CommandGoToVolier}. Подойти к вольеру.");
                Console.WriteLine($"{CommandExit}. Выйти.");
                Console.Write("Ваш выбор: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandGoToVolier:
                        GoToVolier();
                        break;
                    case CommandExit:
                        isProgrammWork = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }

        private void ShowInfo()
        {
            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_aviaries[i].Name}");
            }
        }

        private void GoToVolier()
        {
            bool isCorrectInput = false;
            string userInput;

            while (isCorrectInput == false)
            {
                ShowInfo();
                Console.Write("Введите номер вольера: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int index))
                {
                    if (index > 0 && index <= _aviaries.Count)
                    {
                        _aviaries[index - 1].ShowInfo();
                        isCorrectInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Число должно быть больше 0 и меньше, либо равно {_aviaries.Count}.");
                    }
                }
                else
                {
                    Console.WriteLine("Введите число!");
                }
            }
        }
    }

    public class Aviary
    {
        private List<Animal> _animals;

        public Aviary(int animalsCount, AnimalType animalType)
        {
            _animals = new List<Animal>();

            FillAviary(animalsCount, animalType);

            if (animalsCount > 0)
            {
                Name = _animals[0].Name;
            }
            else
            {
                Name = "Пусто";
            }
        }

        public string Name { get; private set; }

        public void ShowInfo()
        {
            if (_animals.Count == 0)
            {
                Console.WriteLine("Животных тут нет.");
                return;
            }

            int maleCount = 0;
            int femaleCount = 0;
            string maleSymbol = "М";
            string femaleSymbol = "Ж";

            foreach (var animal in _animals)
            {
                if (animal.Sex == maleSymbol)
                {
                    maleCount++;
                }
                else if (animal.Sex == femaleSymbol)
                {
                    femaleCount++;
                }
            }

            Console.WriteLine($"Подходя к вольеру вы слышите '{_animals[0].Voice}'");
            Console.WriteLine($"Вольер с '{Name}' {_animals.Count} ед. из них {maleCount} пола '{maleSymbol}' и {femaleCount} пола '{femaleSymbol}'.");
        }

        private void FillAviary(int animalsCount, AnimalType animalType)
        {
            for (int i = 0; i < animalsCount; i++)
            {
                if (animalType == AnimalType.Tiger)
                {
                    _animals.Add(new Tiger());
                }
                else if (animalType == AnimalType.Cow)
                {
                    _animals.Add(new Cow());
                }
                else if (animalType == AnimalType.Snake)
                {
                    _animals.Add(new Snake());
                }
                else if (animalType == AnimalType.Horse)
                {
                    _animals.Add(new Horse());
                }
                else if (animalType == AnimalType.Dog)
                {
                    _animals.Add(new Dog());
                }
            }
        }
    }

    public class Horse : Animal
    {
        public Horse() : base()
        {
            Name = "Лошадь";
            Voice = "Фр-фр-фр";
        }
    }

    public class Dog : Animal
    {
        public Dog() : base()
        {
            Name = "Собака";
            Voice = "Гав-гав";
        }
    }

    public class Snake : Animal
    {
        public Snake() : base()
        {
            Name = "Змея";
            Voice = "ШШшшшш..";
        }
    }

    public class Cow : Animal
    {
        public Cow() : base()
        {
            Name = "Корова";
            Voice = "Муууу..";
        }
    }

    public class Tiger : Animal
    {
        public Tiger() : base()
        {
            Name = "Тигр";
            Voice = "РРРрррр..";
        }
    }

    public class Animal
    {
        protected static Random s_random;

        protected string[] SexArray;

        public string Name { get; protected set; }
        public string Sex { get; protected set; }
        public string Voice { get; protected set; }

        public Animal()
        {
            s_random = new Random();
            SexArray = new string[] { "М", "Ж" };
            Sex = GetRandomSex();
        }

        private string GetRandomSex()
        {
            int index = s_random.Next(SexArray.Length);
            return SexArray[index];
        }
    }

    public enum AnimalType
    {
        Tiger,
        Cow,
        Snake,
        Dog,
        Horse
    }
}