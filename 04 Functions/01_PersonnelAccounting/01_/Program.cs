using System.Xml.Linq;
using System;
using System.Reflection;

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

            Console.WriteLine(CommandAddDossier + ". Добавить досье.");
            Console.WriteLine(CommandShowAllDossiers + ". Вывести все досье.");
            Console.WriteLine(CommandDellDossier + ". Удалить досье.");
            Console.WriteLine(CommandFindDossier + ". Поиск по фамилии.");
            Console.WriteLine(CommandExit + ". Выход.");

            while (_isProgrammWrok)
            {
                Console.Write("\nВведите команду: ");
                userInput = Console.ReadLine();
                bool isInt = int.TryParse(userInput, out int index);

                if (isInt)
                {
                    switch (index)
                    {
                        case CommandAddDossier:
                            AddElementToDossier(ref fullNames, ref professions);
                            break;

                        case CommandShowAllDossiers:
                            ShowAllDossiers(fullNames, professions);
                            break;

                        case CommandDellDossier:
                            DellDossier(ref fullNames, ref professions);
                            break;

                        case CommandFindDossier:
                            FindDossierBySurname(fullNames, professions);
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

        static void AddElementToDossier(ref string[] fullNames, ref string[] professions)
        {
            Console.Write("Введите ФИО: ");
            AddElementToArray(ref fullNames);
            Console.Write("Введите профессию: ");
            AddElementToArray(ref professions);
        }

        static void AddElementToArray(ref string[] array)
        {
            string userInput = Console.ReadLine();
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[array.Length] = userInput;
            array = tempArray;
        }

        static void ShowAllDossiers(string[] namesArray, string[] professionsArray)
        {
            Console.WriteLine("Все досье: ");

            for (int i = 0; i < namesArray.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + namesArray[i] + " - " + professionsArray[i]);
            }
        }

        static void DellElementInArray(ref string[] array, int index)
        {
            string[] tempArray = new string[array.Length - 1];
            index--;

            for (int i = 0; i < index; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = index + 1; i < array.Length; i++)
            {
                tempArray[i - 1] = array[i];
            }

            array = tempArray;
        }

        static void DellDossier(ref string[] fullNames, ref string[] professions)
        {
            Console.Write("Введите номер сотрудника: ");
            string userInput = Console.ReadLine();
            bool isInt = int.TryParse(userInput, out int index);

            if (isInt && index > 0 && index <= fullNames.Length)
            {
                DellElementInArray(ref fullNames, index);
                DellElementInArray(ref professions, index);
            }
            else
            {
                Console.WriteLine("Неверный ввод.");
            }
        }

        static void FindDossierBySurname(string[] fullNameArray, string[] professionsArray)
        {
            Console.Write("Введите фамилию: ");
            string userInput = Console.ReadLine();
            string[] tempArray;

            for (int i = 0; i < fullNameArray.Length; i++)
            {
                tempArray = fullNameArray[i].Split(' ');

                if (tempArray[0] == userInput)
                {
                    Console.WriteLine(i + 1 + ". " + fullNameArray[i] + " - " + professionsArray[i]);
                }
            }
        }
    }
}