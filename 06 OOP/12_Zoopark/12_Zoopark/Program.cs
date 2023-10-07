﻿namespace _12_Zoopark
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
                new Aviary(5, new Tiger(),"Вольер с тиграми"),
                new Aviary(6, new Cow(),"Вольер с коровами"),
                new Aviary(7, new Dog(),"Вольер с собаками"),
                new Aviary(8, new Snake(),"Вольер со змеями"),
                new Aviary(9, new Horse(),"Вольер с лошадьми")
            };
        }

        public void Run()
        {
            const string CommandGoToAviary = "1";
            const string CommandExit = "2";

            bool isProgrammWork = true;
            string userInput;

            while (isProgrammWork)
            {
                Console.WriteLine($"{CommandGoToAviary}. Подойти к вольеру.");
                Console.WriteLine($"{CommandExit}. Выйти.");
                Console.Write("Ваш выбор: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandGoToAviary:
                        GoToAviary();
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

        private void GoToAviary()
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

        public Aviary(int animalsCount, Animal animal, string name)
        {
            _animals = new List<Animal>();
            Name = name;

            FillAviary(animalsCount, animal);
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

        private void FillAviary(int animalsCount, Animal animal)
        {
            for (int i = 0; i < animalsCount; i++)
            {
                _animals.Add(animal.Clone());
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

        public override Animal Clone() => new Horse();

    }

    public class Dog : Animal
    {
        public Dog() : base()
        {
            Name = "Собака";
            Voice = "Гав-гав";
        }

        public override Animal Clone() => new Dog();

    }

    public class Snake : Animal
    {
        public Snake() : base()
        {
            Name = "Змея";
            Voice = "ШШшшшш..";
        }

        public override Animal Clone() => new Snake();

    }

    public class Cow : Animal
    {
        public Cow() : base()
        {
            Name = "Корова";
            Voice = "Муууу..";
        }

        public override Animal Clone() => new Cow();

    }

    public class Tiger : Animal
    {
        public Tiger() : base()
        {
            Name = "Тигр";
            Voice = "РРРрррр..";
        }

        public override Animal Clone() => new Tiger();
    }

    public abstract class Animal
    {
        private static Random _s_random = new Random();

        protected string[] SexArray;

        public Animal()
        {
            SexArray = new string[] { "М", "Ж" };
            Sex = GetRandomSex();
        }

        public string Name { get; protected set; }
        public string Sex { get; protected set; }
        public string Voice { get; protected set; }

        public abstract Animal Clone();

        private string GetRandomSex()
        {
            int index = _s_random.Next(SexArray.Length);
            return SexArray[index];
        }
    }
}