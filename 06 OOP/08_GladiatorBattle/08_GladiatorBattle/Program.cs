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
        private Character _firstGladiator;
        private Character _secondGladiator;

        public Battleground()
        {
             _firstGladiator = ChoiseClass();
             _secondGladiator = ChoiseClass();

            if(_firstGladiator.GetType()==_secondGladiator.GetType())
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
            if (!_firstGladiator.IsDead && !_secondGladiator.IsDead)
            {
                return true;
            }
            else
            {
                if (_firstGladiator.IsDead)
                {
                    Console.WriteLine("Второй гладиатор победил.");
                }
                else if (_secondGladiator.IsDead)
                {
                    Console.WriteLine("Первый гладиатор победил.");
                }
                else
                {
                    Console.WriteLine("Ничья.");
                }
            }

            return false;
        }

        private Character ChoiseClass()
        {
            const string CommandWarrior = "1";
            const string CommandMage = "2";
            const string CommandPaladin = "3";
            const string CommandPriest = "4";
            const string CommandRogue = "5";

            string userInput;

            Console.WriteLine($"{CommandWarrior}. Воин");
            Console.WriteLine($"{CommandMage}. Маг");
            Console.WriteLine($"{CommandPaladin}. Паладин");
            Console.WriteLine($"{CommandPriest}. Жрец");
            Console.WriteLine($"{CommandRogue}. Разбойник");
            Console.Write("Выбирите класс: ");           

            while (true)
            {
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandWarrior:
                        return new Warrior();
                    case CommandMage:
                        return new Mage();
                    case CommandPaladin:
                        return new Paladin();
                    case CommandPriest:
                        return new Priest();
                    case CommandRogue:
                        return new Rogue();
                    default:
                        Console.WriteLine("Неправильный индекс.");
                        break;
                }
            }
        }
    }

    public class Rogue :Character
    {
        public Rogue() 
        {
            Name = "Разбойник";
            HealthCurrent = 200;
            HealthMax = HealthCurrent;
            DamageCurrent = 70;
            DamageDefault = DamageCurrent;
            DefenceCurrent = 10;
            DefenceDefault = DefenceCurrent;
            SkillName = "Кара света";
            Color = ConsoleColor.Green;
            DodgeChance = 0.35;
        }

        protected override void UseSkill()
        {
            int damage = 50;

            base.UseSkill();

            if (TurnCount <= 0)
            {
                DamageCurrent += damage;
            }

            TurnCount = 2;            
        }
    }

    public class Priest:Character
    {
        public Priest() 
        {
            Name = "Жрец";
            HealthCurrent = 150;
            HealthMax = HealthCurrent;
            DamageCurrent = 60;
            DamageDefault = DamageCurrent;
            DefenceCurrent = 5;
            DefenceDefault = DefenceCurrent;
            SkillName = "Кара света";
            Color = ConsoleColor.Yellow;
            DodgeChance = 0.1;
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
        public Paladin() 
        {
            Name = "Паладин";
            HealthCurrent = 220;
            HealthMax = HealthCurrent;
            DamageCurrent = 40;
            DamageDefault = DamageCurrent;
            DefenceCurrent = 20;
            DefenceDefault = DefenceCurrent;
            SkillName = "Благословение";
            Color = ConsoleColor.Cyan;
            DodgeChance= 0.15;
        }

        protected override void UseSkill()
        {
            int health = 20;
            int defence = 15;

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

            TurnCount = 2;
        }
    }

    public class Mage : Character
    {
        public Mage() 
        {
            Name = "Маг";
            HealthCurrent = 170;
            HealthMax = HealthCurrent;
            DamageCurrent = 90;
            DamageDefault = DamageCurrent;
            DefenceCurrent = 0;
            DefenceDefault = DefenceCurrent;
            DodgeChance = 0.05;
            SkillName = "Огненное клеймо";
            Color = ConsoleColor.Blue;
        }

        protected override void UseSkill()
        {
            int damageMultiple = 2;

            base.UseSkill();

            DamageCurrent = DamageDefault * damageMultiple;
            TurnCount = 1;
        }
    }

    public class Warrior : Character
    {
        public Warrior()
        {
            Name = "Воин";
            HealthCurrent = 300;
            HealthMax = HealthCurrent;
            DamageCurrent = 50;
            DamageDefault = DamageCurrent;
            DefenceCurrent = 10;
            DefenceDefault = DefenceCurrent;
            SkillName = "Ярость";
            DodgeChance = 0.2;
            Color = ConsoleColor.Red;
        }

        protected override void UseSkill()
        {
            base.UseSkill();

            HealthCurrent -= 20;
            DamageCurrent = DamageDefault + 30;
            TurnCount = 1;
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
        protected string Name;
        protected double DodgeChance;        
        protected string SkillName;
        protected int TurnCount;
        protected ConsoleColor Color;

        private static Random _random;

        private double SkillChance;

        public Character()
        {
            _random = new Random();
            SkillChance = 0.15;
        }

        public bool IsDead => HealthCurrent <= 0;
               
        public void AttackEnemy(Character enemy)
        {
            Console.Write($"{Name} Атакует.   ");    

            if (_random.NextDouble() <= enemy.SkillChance)
            {
                UseSkill();
            }

            int damage = DamageCurrent - enemy.DefenceCurrent;

            if (damage < 0)
            {
                damage = 0;
            }

            if (_random.NextDouble() <= enemy.DodgeChance)
            {
                Console.WriteLine("Промах!");
                return;
            }

            enemy.TakeDamage(damage);
        }

        public void RefreshParameters()
        {
            TurnCount--;

            if (TurnCount == 0)
            {
                DamageCurrent = DamageDefault;
                DefenceCurrent = DefenceDefault;
            }
            else if (TurnCount < 0)
            {
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
}