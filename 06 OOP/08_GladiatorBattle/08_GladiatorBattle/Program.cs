using System;
using System.Runtime.CompilerServices;

namespace _08_GladiatorBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Battleground().Battle();
        }
    }

    public class Battleground
    {
        private List<Character> _characterList;
        private Character _firstGladiator;
        private Character _secondGladiator;

        public Battleground()
        {
            _characterList = new List<Character>()
            {
            new Warrior(),
            new Mage(),
            new Rogue(),
            new Paladin(),
            new Priest()
            };

            _firstGladiator = GetClass(СhooseClass());
            _secondGladiator = GetClass(СhooseClass());

            if (_firstGladiator.GetType() == _secondGladiator.GetType())
            {
                _secondGladiator.SetWhiteColor();
            }
        }

        public void Battle()
        {
            while (IsAllAlive())
            {
                _firstGladiator.AttackEnemy(_secondGladiator);
                _secondGladiator.AttackEnemy(_firstGladiator);
                _firstGladiator.ShowInfo();
                _secondGladiator.ShowInfo();
                _firstGladiator.RefreshParameters();
                _secondGladiator.RefreshParameters();
            }
        }

        private bool IsAllAlive()
        {
            if (_firstGladiator.IsDead == false && _secondGladiator.IsDead == false)
            {
                return true;
            }
            else
            {
                if (_firstGladiator.IsDead && _secondGladiator.IsDead)
                {
                    Console.WriteLine("Ничья.");
                }
                if (_firstGladiator.IsDead)
                {
                    Console.WriteLine("Второй гладиатор победил.");
                }
                else if (_secondGladiator.IsDead)
                {
                    Console.WriteLine("Первый гладиатор победил.");
                }
            }

            return false;
        }

        private int СhooseClass()
        {
            bool isChoosing = true;
            string userInput;
            int index = 0;

            for (int i = 0; i < _characterList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_characterList[i].Name}");
            }

            Console.Write("Выбирите класс: ");

            while (isChoosing)
            {
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out index))
                {
                    if (index > 0 && index <= _characterList.Count)
                    {
                        index = index - 1;
                        isChoosing = false;
                    }
                    else
                    {
                        Console.WriteLine("Неправильный индекс.");
                    }
                }
                else
                {
                    Console.WriteLine("Введите номер класса гладитора.");
                }
            }

            return index;
        }

        private Character GetClass(int index)
        {
            Type characterType = _characterList[index].GetType();
            return (Character)Activator.CreateInstance(characterType);
        }
    }

    public class Rogue : Character
    {
        public Rogue() : base("Разбойник", 200, 70, 10, 0.35, "Отравленное лезвие", ConsoleColor.Green)
        {
        }

        protected override void UseSkill()
        {
            int damage = 50;
            int turnCount = 2;

            base.UseSkill();

            if (TurnCount <= 0)
            {
                DamageCurrent += damage;
            }

            TurnCount = turnCount;
        }
    }

    public class Priest : Character
    {
        public Priest() : base("Жрец", 150, 60, 5, 0.1, "Кара света", ConsoleColor.Yellow)
        {
        }

        protected override void UseSkill()
        {
            int health = 20;
            int damage = 15;

            base.UseSkill();

            if (HealthCurrent + health > HealthMax)
            {
                HealthCurrent = HealthMax;
            }
            else
            {
                HealthCurrent += health;
            }

            DamageCurrent += damage;
        }
    }

    public class Paladin : Character
    {
        public Paladin() : base("Паладин", 220, 40, 20, 0.15, "Благословение", ConsoleColor.Cyan)
        {
        }

        protected override void UseSkill()
        {
            int health = 20;
            int defence = 15;
            int turnCount = 2;

            base.UseSkill();

            if (HealthCurrent + health > HealthMax)
            {
                HealthCurrent = HealthMax;
            }
            else
            {
                HealthCurrent += health;
            }

            if (TurnCount <= 0)
            {
                DefenceCurrent += defence;
            }

            TurnCount = turnCount;
        }
    }

    public class Mage : Character
    {
        public Mage() : base("Маг", 170, 90, 0, 0.05, "Огненное клеймо", ConsoleColor.Blue)
        {
        }

        protected override void UseSkill()
        {
            int damageMultiple = 2;
            int turnCount = 1;

            base.UseSkill();

            DamageCurrent = DamageDefault * damageMultiple;
            TurnCount = turnCount;
        }
    }

    public class Warrior : Character
    {
        public Warrior() : base("Воин", 300, 50, 10, 0.2, "Ярость", ConsoleColor.Red)
        {
        }

        protected override void UseSkill()
        {
            int deltaHealth = -20;
            int deltaDamage = 30;
            int turnCount = 1;

            base.UseSkill();

            HealthCurrent += deltaHealth;
            DamageCurrent = DamageDefault + deltaDamage;
            TurnCount = turnCount;
        }
    }

    public class Character
    {
        protected int HealthMax;
        protected int HealthCurrent;
        protected int DamageCurrent;
        protected int DamageDefault;
        protected int DefenceCurrent;
        protected int DefenceDefault;
        protected double DodgeChance;
        protected string SkillName;
        protected int TurnCount;
        protected ConsoleColor Color;

        private double _skillChance;

        public Character(string name, int health, int damage, int defence, double dodgeChance, string skillName, ConsoleColor color)
        {
            Name = name;
            HealthCurrent = health;
            HealthMax = health;
            DamageCurrent = damage;
            DamageDefault = damage;
            DefenceCurrent = defence;
            DefenceDefault = defence;
            SkillName = skillName;
            DodgeChance = dodgeChance;
            Color = color;
            _skillChance = 0.15;
        }

        public string Name { get; protected set; }
        public bool IsDead => HealthCurrent <= 0;

        public void AttackEnemy(Character enemy)
        {
            Console.Write($"{Name} Атакует.   ");

            if (UserUtils.GenerateRandomDouble() <= enemy._skillChance)
            {
                UseSkill();
            }

            int damage = DamageCurrent - enemy.DefenceCurrent;

            if (damage < 0)
            {
                damage = 0;
            }

            if (UserUtils.GenerateRandomDouble() <= enemy.DodgeChance)
            {
                Console.WriteLine("Промах!");
                return;
            }

            enemy.TakeDamage(damage);
        }

        public void RefreshParameters()
        {
            TurnCount--;

            if (TurnCount <= 0)
            {
                DamageCurrent = DamageDefault;
                DefenceCurrent = DefenceDefault;
                TurnCount = 0;
            }
        }

        public void ShowInfo()
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine($"{Name} - {HealthCurrent}/{HealthMax} хп, защита {DefenceCurrent}, {DamageCurrent} урона");
            Console.ForegroundColor = defaultColor;
        }

        public void SetWhiteColor()
        {
            Color = ConsoleColor.White;
        }

        protected virtual void UseSkill()
        {
            Console.Write($"{Name} использует {SkillName}.   ");
        }

        private void TakeDamage(int damage)
        {
            if (HealthCurrent - damage < 0)
            {
                HealthCurrent = 0;
            }
            else
            {
                HealthCurrent -= damage;
            }

            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine($"{Name} - получает {damage} урона");
            Console.ForegroundColor = defaultColor;
        }
    }

    public class UserUtils
    {
        public static double GenerateRandomDouble()
        {
            return new Random().NextDouble();
        }
    }
}