﻿using System.Collections.Generic;

namespace _02_Amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string crime = "Антиправительственное";
            List<Criminal> criminals = new List<Criminal>()
            {new Criminal("Гоша", "Воровство"),
            new Criminal("Тоша", "Антиправительственное"),
            new Criminal("Артем", "Воровство"),
            new Criminal("Андрей", "Антиправительственное"),
            new Criminal("Дмитрий", "Убийство") };

            var filteredCriminals = from Criminal criminal in criminals
                                    where IsCrimeNotTheSame(criminal, crime)
                                    select criminal;

            ShowInfo("До амнистии:", criminals);
            Console.WriteLine();
            ShowInfo("После амнистии:", filteredCriminals);
        }

        static bool IsCrimeNotTheSame(Criminal criminal, string crime)
        {
            return criminal.Crime != crime;
        }

        static void ShowInfo(string message, IEnumerable<Criminal> criminals)
        {
            Console.WriteLine(message);

            foreach (var criminal in criminals)
            {
                Console.WriteLine(criminal.Name);
            }
        }
    }

    public class Criminal
    {
        public string Name { get; private set; }
        public string Crime { get; private set; }

        public Criminal(string name, string crime)
        {
            Name = name;
            Crime = crime;
        }
    }
}