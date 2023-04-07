namespace _12_BattleVSBoss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int fireBall = 1;
            const int fireFenix = 2;
            const int fireWall = 3;
            const int fireRain = 4;
            Random random = new Random();
            string userInput;
            int userHealth = 500;
            int bossHealth = 1000;
            int bossDamage;
            int bossDamageMin = 40;
            int bossDamageMax = 85;
            bool isBattle = true;
            int userDamage = 0;
            bool isChoiseCorrect;

            string fireFenixName = "Огненный феникс";
            int fireFenixDamage = 125;

            string fireWallName = "Огенная стена";
            int fireWallDamage = 50;

            string fireRainName = "Огненный ливень";
            int fireRainDamage = 100;
            bool isFireRainCombo = false;
            int fireRainMultiplier = 3;
            int fireRainMultiplierChance = 50;

            string fireBallName = "Шар огня";
            int fireBallDamage = 75;
            bool isFireBallCombo = false;
            int fireBallMultiplier = 2;

            Console.WriteLine("Вы маг огня и перед Вами босс. Ваши действия?");

            while (isBattle)
            {
                Console.WriteLine("Ваше здоровье: {0}\nЗдоровье босса: {1}\n", userHealth, bossHealth);
                Console.WriteLine("{0}. {1} (серия наносит урон x{2}, при использовании другого навыка серия прерывается) - {3} урона.", fireBall, fireBallName, fireBallMultiplier, fireBallDamage);
                Console.WriteLine("{0}. {1} - {2} урона.", fireFenix, fireFenixName, fireFenixDamage);
                Console.WriteLine("{0}. {1} (дает {2}% шанс нанести урон x{3} навыком Огненный ливень) - {4} урона.", fireWall, fireWallName, fireRainMultiplierChance, fireRainMultiplier, fireWallDamage);
                Console.WriteLine("{0}. {1} - {2} урона.", fireRain, fireRainName, fireRainDamage);
                isChoiseCorrect = true;

                while (isChoiseCorrect)
                {
                    Console.Write("Выберите умение: ");
                    userInput = Console.ReadLine();
                    isChoiseCorrect = false;

                    switch (userInput)
                    {
                        case "1":
                            if (isFireBallCombo)
                            {
                                userDamage = fireBallDamage * fireBallMultiplier;
                            }
                            else
                            {
                                userDamage = fireBallDamage;
                            }

                            isFireBallCombo = true;
                            isFireRainCombo = false;
                            break;

                        case "2":
                            isFireBallCombo = false;
                            userDamage = fireFenixDamage;
                            break;

                        case "3":
                            isFireBallCombo = false;
                            isFireRainCombo = true;
                            userDamage = fireWallDamage;
                            break;

                        case "4":
                            isFireBallCombo = false;

                            if (isFireRainCombo && random.Next(100) > fireRainMultiplierChance)
                            {
                                userDamage = fireRainDamage * fireRainMultiplier;
                            }
                            else
                            {
                                userDamage = fireRainDamage;
                            }

                            isFireRainCombo = false;
                            break;

                        default:
                            Console.WriteLine("Введите номер пункта из предложенных.");
                            isChoiseCorrect = true;
                            break;
                    }
                }

                Console.Clear();
                bossHealth -= userDamage;
                bossDamage = random.Next(bossDamageMin, bossDamageMax);
                userHealth -= bossDamage;
                Console.WriteLine("Вы используете: {0} и наносите {1} урона", fireBallName, userDamage);
                Console.WriteLine("Босс наносит вам: {0} урона\n", bossDamage);

                if (userHealth <= 0 || bossHealth <= 0)
                {
                    isBattle = false;
                }
            }

            if (userHealth <= 0 && bossHealth > 0)
            {
                Console.WriteLine("Вы проиграли.");
            }
            else if (userHealth > 0 && bossHealth <= 0)
            {
                Console.WriteLine("Вы победили.");
            }
            else if (userHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("Вы оба погибли.");
            }

            Console.WriteLine("Ваше здоровье: {0}\nЗдоровье босса: {1}\n", userHealth, bossHealth);
        }
    }
}