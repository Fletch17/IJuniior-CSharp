using System.Xml.Linq;
using System;

namespace _01_PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CommandAddDossier = 1;
            const int CommandShowAllDossiers = 2;
            const int CommandDellDossier = 3;
            const int CommandFindDossier = 4;
            const int CommandExit = 5;

            string[] fullNames = new string[0];
            string[] professions = new string[0];
            bool _isProgrammWrok = true;
            string userInput;
            int index;

            Console.WriteLine(CommandAddDossier + ". Добавить досье.");
            Console.WriteLine(CommandShowAllDossiers + ". Вывести все досье.");
            Console.WriteLine(CommandDellDossier + ". Удалить досье.");
            Console.WriteLine(CommandFindDossier + ". Поиск по фамилии.");
            Console.WriteLine(CommandExit + ". Выход.");

            while (_isProgrammWrok)
            {
                Console.Write("\nВведите команду: ");
                userInput = Console.ReadLine();
                bool isInt = int.TryParse(userInput, out index);

                if (isInt)
                {
                    switch (index)
                    {
                        case CommandAddDossier:
                            Console.Write("Введите ФИО: ");
                            userInput = Console.ReadLine();
                            fullNames = AddElementToDossier(fullNames, userInput);
                            Console.Write("Введите профессию: ");
                            userInput = Console.ReadLine();
                            professions = AddElementToDossier(professions, userInput);
                            break;

                        case CommandShowAllDossiers:
                            Console.WriteLine("Все досье: ");
                            ShowAllDossiers(fullNames, professions);
                            break;

                        case CommandDellDossier:
                            Console.Write("Введите номер сотрудника: ");
                            userInput = Console.ReadLine();
                            fullNames = DellDossier(Convert.ToInt32(userInput) - 1, fullNames);
                            professions = DellDossier(Convert.ToInt32(userInput) - 1, professions);
                            break;

                        case CommandFindDossier:
                            Console.Write("Введите фамилию: ");
                            userInput = Console.ReadLine();
                            FindDossierBySurname(fullNames, professions, userInput);
                            break;

                        case CommandExit:
                            _isProgrammWrok = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введите номер пункта");
                }
            }
        }

        static string[] AddElementToDossier(string[] array, string element)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[array.Length] = element;
            return tempArray;
        }

        static void ShowAllDossiers(string[] namesArray, string[] professionsArray)
        {
            for (int i = 0; i < namesArray.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + namesArray[i] + " - " + professionsArray[i]);
            }
        }

        static string[] DellDossier(int index, string[] array)
        {
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = index + 1; i < array.Length; i++)
            {
                tempArray[i - 1] = array[i];
            }

            return tempArray;
        }

        static void FindDossierBySurname(string[] fullNameArray, string[] professionsArray, string surname)
        {
            for (int i = 0; i < fullNameArray.Length; i++)
            {
                if (fullNameArray[i].Contains(surname))
                {
                    Console.WriteLine(i + 1 + ". " + fullNameArray[i] + " - " + professionsArray[i]);
                }
            }
        }
    }
}