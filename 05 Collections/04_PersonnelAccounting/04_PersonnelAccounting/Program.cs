namespace _04_PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandShowAllDossiers = "2";
            const string CommandDeleteDossier = "3";
            const string CommandExit = "4";

            List<string> names = new List<string>();
            Dictionary<string, List<string>> dossiers = new Dictionary<string, List<string>>();
            bool isProgramWork = true;
            string userInput;

            while (isProgramWork)
            {
                Console.WriteLine(CommandAddDossier + ". Добавить досье.");
                Console.WriteLine(CommandShowAllDossiers + ". Показать все досье.");
                Console.WriteLine(CommandDeleteDossier + ". Удалить досье.");
                Console.WriteLine(CommandExit + ". Выход.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddDossier:
                        AddDossier(dossiers);
                        break;

                    case CommandShowAllDossiers:
                        ShowAllDossiers(dossiers);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(dossiers);
                        break;

                    case CommandExit:
                        isProgramWork = false;
                        break;
                }
            }
        }

        static void AddDossier(Dictionary<string, List<string>> dossiers)
        {
            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите профессию: ");
            string profession = Console.ReadLine();

            if (dossiers.ContainsKey(profession))
            {
                dossiers[profession].Add(fullName);
            }
            else
            {
                dossiers.Add(profession, new List<string>() { fullName });
            }
        }

        static void DeleteDossier(Dictionary<string, List<string>> dossiers)
        {
            Console.Write("Введите ФИО работника: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите профессию работника: ");
            string profession = Console.ReadLine();

            if(dossiers.ContainsKey(profession))
            {
                if (dossiers[profession].Contains(fullName))
                {
                    if(dossiers[profession].Count>1)
                    {
                        dossiers[profession].Remove(fullName);
                    }
                    else
                    {
                        dossiers.Remove(profession);
                    }
                }
                else
                {
                    Console.WriteLine("Такого работника нет.");
                }
            }
            else
            {
                Console.WriteLine("Работников с такой профессией нет.");
            }
        }

        static void ShowAllDossiers(Dictionary<string, List<string>> dossiers)
        {
            int number = 1;

            foreach (var dossier in dossiers)
            {
                for (int i = 0; i < dossier.Value.Count; i++)
                {
                    Console.WriteLine(number + ". " + dossier.Value[i] + " - " + dossier.Key);
                    number++;
                }
            }

            Console.WriteLine();
        }
    }
}