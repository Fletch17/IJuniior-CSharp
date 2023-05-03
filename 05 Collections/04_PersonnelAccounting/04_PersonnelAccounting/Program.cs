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

            Dictionary<string, string> dossiers = new Dictionary<string, string>();
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

        static void AddDossier(Dictionary<string, string> dossiers)
        {
            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите профессию: ");
            string profession = Console.ReadLine();
            dossiers.Add(fullName, profession);
        }

        static void DeleteDossier(Dictionary<string, string> dossiers)
        {
            Console.Write("Введите номер работника: ");
            string userInput = Console.ReadLine();
            bool isInt = int.TryParse(userInput, out int number);

            if (isInt)
            {
                if (number < dossiers.Count && number >= 0)
                {
                    dossiers.Remove(dossiers.Keys.ElementAt(number));
                }
            }
        }

        static void ShowAllDossiers(Dictionary<string, string> dossiers)
        {
            for (int i = 0; i < dossiers.Count; i++)
            {
                Console.WriteLine(i + ". " + dossiers.ElementAt(i).Key + " - " + dossiers.ElementAt(i).Value);
            }
        }
    }
}