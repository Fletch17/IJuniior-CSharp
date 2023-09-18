namespace _10_War
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
        private Country _country1;
        private Country _country2;

        public Battleground()
        {
            _country1 = new Country(5, "Страна 1");
            _country2 = new Country(5, "Страна 2");
        }

        public void Battle()
        {
            bool isFighting = true;

            while (isFighting)
            {
                if (IsArmyDead(_country1, _country2))
                {
                    isFighting = false;
                }
                else
                {
                    Attack(_country1, _country2);
                }

                if (IsArmyDead(_country1, _country2))
                {
                    isFighting = false;
                }
                else
                {
                    Attack(_country2, _country1);
                }
            }
        }

        private void Attack(Country attackerCountry, Country defenderCountry)
        {
            int indexAtacker = UserUtils.GenerateRandomNumber(attackerCountry.SoldiersCount);
            int indexDefender = UserUtils.GenerateRandomNumber(defenderCountry.SoldiersCount);
            Soldier attackerSoldier = attackerCountry.GetSoldier(indexAtacker);
            Soldier defenderSoldier = defenderCountry.GetSoldier(indexDefender);

            Console.WriteLine($"Солдат {attackerSoldier.Name} '{attackerCountry.Name}' атакует");
            attackerSoldier.Shoot(defenderSoldier);
            defenderCountry.RemoveDeadSoldiers();
        }

        private bool IsArmyDead(Country firstCountry, Country secondCountry)
        {
            if (firstCountry.SoldiersCount == 0)
            {
                Console.WriteLine($"Победила '{secondCountry.Name}'");
                return true;
            }
            else if (secondCountry.SoldiersCount == 0)
            {
                Console.WriteLine($"Победила '{firstCountry.Name}'");
                return true;
            }

            return false;
        }

        public class Country
        {
            private List<Soldier> _army;

            public Country(int soliersCount, string name)
            {
                _army = new List<Soldier>();
                FillArmy(soliersCount);
                Name = name;
            }

            public string Name { get; private set; }
            public int SoldiersCount => _army.Count;

            public Soldier GetSoldier(int index) => _army[index];

            public void RemoveDeadSoldiers()
            {
                foreach (var soldier in _army)
                {
                    if (soldier.IsDead)
                    {
                        _army.Remove(soldier);
                        Console.WriteLine($"Солдат '{Name}' погиб");
                        break;
                    }
                }
            }

            private void FillArmy(int soliersCount)
            {
                int damage;
                int health;
                double dodgeChance;
                double criticalAtackChance;
                int[] healthArray = { 100, 125, 150, 300 };
                int[] damageArray = { 30, 35, 40, 70 };
                double[] chancesArray = { 0.05, 0.1, 0.12, 0.15, 0.3, 0.5 };

                for (int i = 0; i < soliersCount; i++)
                {
                    damage = damageArray[UserUtils.GenerateRandomNumber(damageArray.Length)];
                    health = healthArray[UserUtils.GenerateRandomNumber(healthArray.Length)];
                    dodgeChance = chancesArray[UserUtils.GenerateRandomNumber(chancesArray.Length)];
                    criticalAtackChance = chancesArray[UserUtils.GenerateRandomNumber(chancesArray.Length)];

                    _army.Add(new Soldier(health, damage, dodgeChance, criticalAtackChance, i.ToString()));
                }
            }
        }

        public class Soldier
        {
            public Soldier(int health, int damage, double dodgeChance, double critChance, string name)
            {
                Health = health;
                Damage = damage;
                DodgeChance = dodgeChance;
                CritChance = critChance;
                Name = name;
            }

            public string Name { get; private set; }
            public int Health { get; private set; }
            public int Damage { get; private set; }
            public double DodgeChance { get; private set; }
            public double CritChance { get; private set; }
            public bool IsDead => Health <= 0;

            public void Shoot(Soldier soldier)
            {
                if (UserUtils.GenerateRandomDouble() <= soldier.DodgeChance)
                {
                    Console.WriteLine("Промах.");
                    return;
                }

                soldier.TakeDamage(GetDamage());
            }

            private void TakeDamage(int damage)
            {
                if (Health < damage)
                {
                    Health = 0;
                }
                else
                {
                    Health -= damage;
                }

                Console.WriteLine($"Нанесено {damage} урона");
            }

            private int GetDamage()
            {
                double chance = UserUtils.GenerateRandomDouble();
                int damageMultiple = 2;

                return CritChance <= chance ? Damage : Damage * damageMultiple;
            }
        }

        public class UserUtils
        {
            public static int GenerateRandomNumber(int maxValue)
            {
                return new Random().Next(maxValue);
            }

            public static double GenerateRandomDouble()
            {
                return new Random().NextDouble();
            }
        }
    }
}
