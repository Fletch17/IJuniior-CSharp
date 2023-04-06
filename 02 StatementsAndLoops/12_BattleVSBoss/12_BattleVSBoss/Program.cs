namespace _12_BattleVSBoss
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            string fireBallName = "Шар огня";
            int fireBallDamage = 75;
            bool isFireBallCombo = false;

            Console.WriteLine("Вы маг огня и перед Вами босс. Ваши действия?");

            while (isBattle)
            {
                Console.WriteLine("Ваше здоровье: {0}\nЗдоровье босса: {1}\n", userHealth, bossHealth);
                Console.WriteLine("1. {0} (серия наносит двойной урон, при использовании другого навыка серия прерывается) - {1} урона.", fireBallName, fireBallDamage);
                Console.WriteLine("2. {0} - {1} урона.", fireFenixName, fireFenixDamage);
                Console.WriteLine("3. {0} (дает 50% шанс нанести тройной урон навыком Огненный ливень) - {1} урона.", fireWallName, fireWallDamage);
                Console.WriteLine("4. {0} - {1} урона.", fireRainName, fireRainDamage);
                isChoiseCorrect = false;

                while (!isChoiseCorrect)
                {
                    Console.Write("Выберите умение: ");
                    userInput = Console.ReadLine();
                    isChoiseCorrect = true;

                    switch (userInput)
                    {
                        case "1":
                            if (!isFireBallCombo)
                            {
                                userDamage = fireBallDamage;
                            }
                            else
                            {
                                userDamage = fireBallDamage * 2;
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

                            if (isFireRainCombo && random.Next(100) > 50)
                            {
                                userDamage = fireRainDamage * 3;
                            }
                            else
                            {
                                userDamage = fireRainDamage;
                            }

                            isFireRainCombo = false;
                            break;
                        default:
                            Console.WriteLine("Введите номер пункта из предложенных.");
                            isChoiseCorrect = false;
                            break;
                    }
                }

                Console.Clear();
                bossHealth -= userDamage;
                bossDamage = random.Next(bossDamageMin, bossDamageMax);
                userHealth -= bossDamage;
                Console.WriteLine("Вы используете: {0} и наносите {1} урона", fireBallName, userDamage);
                Console.WriteLine("Босс наносит вам: {0} урона\n", bossDamage);

                if (userHealth <= 0 && bossHealth > 0)
                {
                    Console.WriteLine("Вы проиграли.");
                    isBattle = false;
                }
                else if (userHealth > 0 && bossHealth <= 0)
                {
                    Console.WriteLine("Вы победили.");
                    isBattle = false;
                }
                else if (userHealth <= 0 && bossHealth <= 0)
                {
                    Console.WriteLine("Вы оба погибли.");
                    isBattle = false;
                }
            }

            Console.WriteLine("Ваше здоровье: {0}\nЗдоровье босса: {1}\n", userHealth, bossHealth);
        }
    }    
}